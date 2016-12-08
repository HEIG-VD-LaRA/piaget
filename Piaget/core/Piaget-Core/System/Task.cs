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
        void SetSleep(ulong extra_time);
        void AddParallelTask(string name, WithRegularTask task, ulong period);
        void AddSerialTask(string name, WithRegularTask task, ulong period);
        void AddLoopTask(string name, WithLoopTask task, ulong period);
        void SetHibernated();
        void SetRecovered();
        void SetTerminated();
    }

    class Task : DoubleLinkedNode<Task>, ITask {
        private string name;
        private ulong period;
        private Clock clock;
        private TaskManager task_manager;
        protected Action current_procedure;
        private ulong wakeup_time;

        public ulong WakeupTime {
            get { return this.wakeup_time; }
        }

        public void Init(string name, ulong period, Clock clock, TaskManager task_manager) {
            this.name = name;
            this.period = period;
            this.clock = clock;
            this.task_manager = task_manager;
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

        public void SetSleep(ulong time) {
            this.wakeup_time += time - period;
        }

        public void Sleep() {
            long delta_t = (long)(this.wakeup_time - clock.ElapsedTime);
            if (delta_t > SystemConfig.SoftwareTimeIncrement) {
                Thread.Sleep(Clock.ToSoftwareTime(delta_t));
            }
        }

        public void AddParallelTask (string name, WithRegularTask task, ulong period) {
            this.task_manager.AddParallelTask(name, task, period);
        }

        public void AddSerialTask(string name, WithRegularTask task, ulong period) {
            this.task_manager.AddSerialTask(name, task, period, this);
        }

        public void AddLoopTask(string name, WithLoopTask task, ulong period) {
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
