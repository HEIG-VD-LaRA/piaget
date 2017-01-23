using System;
using System.Threading;
using Yieldable = System.Collections.IEnumerator;

using Piaget_Core.Lib;

namespace Piaget_Core.Base {

    public interface IPiagetTask {
        string Name { get; }
        double SWPeriod { get; }
        //
        void SetState(Action state_action_proc);
        void SetState(Func<Yieldable> state_yieldable_proc, int dummy = 0); // See comment below for the dummy parameter
        void SetSleep(double time);
        void AddParallelTask(string name, WithTasking task, double period);
        void AddChildTask(string name, WithTasking task, double sw_period);
        void SetTerminated();
    }

    public class PiagetTask : DoubleLinkedNode<PiagetTask>, IPiagetTask {
        
        protected Clock clock;
        private ITaskPoolManager task_manager;

        private Action state_action_proc;
        private Func<Yieldable> state_yieldable_proc;
        private Yieldable state_current_exec;

        private string name;
        public string Name {
            get { return this.name; }
        }

        public long sw_period;
        public double SWPeriod {
            get { return (double)this.sw_period; }
        }

        private long wakeup_sw_time;
        public long WakeupSWTime {
            get { return this.wakeup_sw_time; }
        }
        // (name, period, clock, Reset, task_manager, sync_task)
        public void Init(string name, double period, Clock clock, Action user_reset,
                         ITaskPoolManager task_manager) {
            this.name = name;
            this.sw_period = (long)period;
            this.clock = clock;
            this.task_manager = task_manager;
            ResetWakeupTime();
            user_reset();
        }

        public void ResetWakeupTime() {
            this.wakeup_sw_time = clock.ElapsedSWTime + this.sw_period;
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

        public void SetSleep(double time) {
            this.wakeup_sw_time += (long)time - sw_period; // "- sw_period" to cancel the += sw_period at the end of Exec()
        }

        public void Sleep() {
            long time_to_sleep = (long)(this.wakeup_sw_time - clock.ElapsedSWTime);
            if (time_to_sleep > SystemConfig.SleepTimeIncrement) {
                Thread.Sleep(Clock.ToSleepTime(time_to_sleep));
            }
        }

        public void AddParallelTask (string name, WithTasking task, double period) {
            this.task_manager.AddParallelTask(name, task, period);
        }

        public void AddChildTask(string name, WithTasking task, double period) {
            this.task_manager.AddChildTask(name, task, period, this);
        }

        public void SetTerminated() {
            this.task_manager.RemoveFromPool(this);
        }
    }
}
