using System;
using System.Threading;
using Piaget_Core.Lib;

using Piaget_Core.System;

namespace Piaget_Core {

    //class TaskBaseNode : DoubleLinkedNode<TaskBaseNode> {
    //    public TaskBase task;
    //}

    interface ITask {
        string Name { get; }
        void SetState(Action next_state_procedure);
        void SetSleep(long extra_time);
        void AddParallelTask(string name, WithRegularTask task, long period);
        void AddSerialTask(string name, WithRegularTask task, long period);
        void AddLoopTask(string name, WithLoopTask task, long period);
        void SetHibernated();
        void SetRecovered();
        void SetTerminated();
    }

    class Task : DoubleLinkedNode<Task>, ITask {
        private string name;
        private long period;
        private Clock clock;
        private TaskManager task_manager;
        protected Action current_procedure;
        private long wakeup_time;

        public long Period {
            get { return this.period; }
        }
        public long WakeupTime {
            get { return this.wakeup_time; }
        }

        public void Init(string name, long period, TaskManager task_manager, Clock clock) {
            this.name = name;
            this.period = period;
            this.clock = clock;
            this.task_manager = task_manager;
            ResetWakeupTime();
        }
        
        public void ResetWakeupTime() {
            this.wakeup_time = clock.ElapsedTime;
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
            this.wakeup_time += period;
        }

        public void SetSleep(long time) {
            this.wakeup_time += time - period;
        }

        public void Sleep() {
            long time_to_sleep = (long)(this.wakeup_time - clock.ElapsedTime);
            if (time_to_sleep > SystemConfig.SoftwareTimeIncrement) {
                Thread.Sleep(Clock.ToSoftwareTime(time_to_sleep));
            }
        }

        public void AddParallelTask (string name, WithRegularTask task, long period) {
            this.task_manager.AddParallelTask(name, task, period);
        }

        public void AddSerialTask(string name, WithRegularTask task, long period) {
            this.task_manager.AddSerialTask(name, task, period, this);
        }

        public void AddLoopTask(string name, WithLoopTask task, long period) {
            this.task_manager.AddSerialTask(name, task, period, this);
        }

        public void SetHibernated() {
            task_manager.Hibernate(this);
        }

        public void SetRecovered() {
            this.wakeup_time = this.clock.ElapsedTime;
            task_manager.Recover(this);
        }

        public void SetTerminated() {
            task_manager.RemoveFromPool(this);
        }
    }
}
