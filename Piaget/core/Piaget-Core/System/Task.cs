using System;
using System.Threading;
using Yieldable = System.Collections.IEnumerator;

using Piaget_Core.Lib;
using Piaget_Core.System;

namespace Piaget_Core {

    interface ITask {
        string Name { get; }
        double Period { get; }
        //
        void SetState(Action state_action_proc);
        void SetState(Func<Yieldable> state_yieldable_proc, int dummy = 0); // See comment below for the dummy parameter
        void SetSleep(long time);
        void AddParallelTask(string name, WithTasking task, long period);
        void AddChildTask(string name, WithTasking task, long period);
        void SetHibernated();
        void SetRecovered();
        void SetTerminated();
    }

    class Task : DoubleLinkedNode<Task>, ITask {
        private string name;
        protected Clock clock;
        private ITaskPoolManager task_manager;
        private long wakeup_sw_time;
        private bool is_hibernated;

        private Action state_action_proc;
        private Func<Yieldable> state_yieldable_proc;
        private Yieldable state_current_exec;

        public long sw_period;
        public double Period {
            get {
                return (double)this.sw_period / (double)Clock.sec;
            }
        }

        public long WakeupSWTime {
            get { return this.wakeup_sw_time; }
        }

        public void Init(string name, double sw_period, ITaskPoolManager task_manager, Clock clock) {
            this.name = name;
            this.sw_period = (long)sw_period;
            this.clock = clock;
            this.task_manager = task_manager;
            this.is_hibernated = false;
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

        public void SetState(Action state_action_proc) {
            this.state_action_proc = state_action_proc;
        }

        // The dummy parameter avoid a strange compiler error. It can be ignored when using this overloading of SetState.
        // More details here : http://stackoverflow.com/questions/4573011/why-is-funct-ambiguous-with-funcienumerablet
        public void SetState(Func<Yieldable> state_yieldable_proc, int dummy = 0) {
            this.state_action_proc = null;
            this.state_yieldable_proc = state_yieldable_proc;
            this.state_current_exec = state_yieldable_proc();
        }

        public void Exec() {
            if (this.state_action_proc != null) {
                this.state_action_proc();
            } else {
                // Did we reach the end of the yieldable procedure ?
                if (! this.state_current_exec.MoveNext()) {
                    // Then we reset the enumerator so that the procedure will start from the beginning at the next execution
                    this.state_current_exec = this.state_yieldable_proc();
                }
            }
            this.wakeup_sw_time += sw_period;
        }

        public void SetSleep(long time) {
            this.wakeup_sw_time += time - sw_period; // "- sw_period" to cancel the += sw_period at the end of Exec()
        }

        public void Sleep() {
            long time_to_sleep = (long)(this.wakeup_sw_time - clock.ElapsedSWTime);
            if (time_to_sleep > Config.SleepTimeIncrement) {
                Thread.Sleep(Clock.ToSleepTime(time_to_sleep));
            }
        }

        public void AddParallelTask (string name, WithTasking task, long period) {
            this.task_manager.AddParallelTask(name, task, period);
        }

        public void AddChildTask(string name, WithTasking task, long period) {
            this.task_manager.AddSerialTask(name, task, period, this);
        }

        public void SetHibernated() {
            this.is_hibernated = true;
            task_manager.Hibernate(this);
        }

        public void SetRecovered() {
            this.is_hibernated = false;
            this.wakeup_sw_time = this.clock.ElapsedSWTime;
            task_manager.Recover(this);
        }

        public void SetTerminated() {
            this.task_manager.RemoveFromPool(this, this.is_hibernated);
        }
    }
}
