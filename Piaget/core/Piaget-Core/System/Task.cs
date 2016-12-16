using System;
using System.Threading;
using Piaget_Core.Lib;

using Piaget_Core.System;

namespace Piaget_Core {

    interface ITask {
        string Name { get; }
        double Period { get; }
        void SetState(Action next_state_procedure);
        void SetSleep(long extra_time);
        void AddParallelTask(string name, WithTask task, long period);
        void AddSerialTask(string name, WithTask task, long period);
        void SetHibernated();
        void SetRecovered();
        void SetTerminated();
    }

    class Task : DoubleLinkedNode<Task>, ITask {
        private string name;
        protected Clock clock;
        private TaskManager task_manager;
        private Action current_procedure;
        private long wakeup_sw_time;

        public long sw_period;
        public double Period {
            get {
                return (double)this.sw_period / (double)Clock.sec;
            }
        }

        public long WakeupSWTime {
            get { return this.wakeup_sw_time; }
        }

        public void Init(string name, double sw_period, TaskManager task_manager, Clock clock) {
            this.name = name;
            this.sw_period = (long)sw_period;
            this.clock = clock;
            this.task_manager = task_manager;
            ResetWakeupTime();
        }
        
        public void ResetWakeupTime() {
            this.wakeup_sw_time = clock.ElapsedSWTime;
        }

        public string Name {
            get {
                return this.name;
            }
        }

        public void SetState(Action next_state_procedure) {
            this.current_procedure = next_state_procedure;
        }

        public void Exec() {
            this.current_procedure();
            this.wakeup_sw_time += sw_period;
        }

        public void SetSleep(long time) {
            this.wakeup_sw_time += time - sw_period;
        }

        public void Sleep() {
            long time_to_sleep = (long)(this.wakeup_sw_time - clock.ElapsedSWTime);
            if (time_to_sleep > Config.SleepTimeIncrement) {
                Thread.Sleep(Clock.ToSleepTime(time_to_sleep));
            }
        }

        public void AddParallelTask (string name, WithTask task, long period) {
            this.task_manager.AddParallelTask(name, task, period);
        }

        public void AddSerialTask(string name, WithTask task, long period) {
            this.task_manager.AddSerialTask(name, task, period, this);
        }

        public void SetHibernated() {
            task_manager.Hibernate(this);
        }

        public void SetRecovered() {
            this.wakeup_sw_time = this.clock.ElapsedSWTime;
            task_manager.Recover(this);
        }

        public void SetTerminated() {
            task_manager.RemoveFromPool(this);
        }
    }
}
