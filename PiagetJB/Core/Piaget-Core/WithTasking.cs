using Piaget_Core.Base;
using System;
using Yieldable = System.Collections.IEnumerator;

namespace Piaget_Core {
    
    // Interface for the user
    public interface IPiagetTask {
        string Name { get; }
        double Period { get; }
        //
        void SetState(Action state_action_proc);
        void SetState(Func<Yieldable> state_yieldable_proc, int dummy = 0); // See comment below for the dummy parameter
        void SetSleep(double time);
        void AddParallelTask(string name, WithTasking task, double period);
        void AddChildTask(string name, WithTasking task, double sw_period);
        void SetTerminated();
    }

    // Interface for the task manager
    public interface ITaskingManagement {
        PiagetTask Task { get; }
        void NewTask(string name, double period, Clock clock,
                     ITaskPoolManager task_manager);
    }

    public abstract class WithTasking : ITaskingManagement {
        private PiagetTask task;
        private Clock clock;

        // VISIBLE FOR THE USER
        protected IPiagetTask Task {
            get { return (IPiagetTask)this.task; }
        }
        abstract protected void Reset();
        //

        public double ApplicationElapsedTime {
            get { return this.clock.ElapsedTime; }
        }

        // METHODS CALLED BY THE TASK MANAGER :

        PiagetTask ITaskingManagement.Task {
            get { return this.task; }
        }

        void ITaskingManagement.NewTask(string name, double period, Clock clock,
                                        ITaskPoolManager task_manager) {
            this.task = new PiagetTask();
            this.task.Init(name, period, clock, Reset, task_manager);
            this.clock = clock;
        }

    }
}
