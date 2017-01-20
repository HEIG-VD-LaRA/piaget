using Piaget_Core.System;

namespace Piaget_Core {

    public interface ITaskingManagement {
        PiagetTask Task { get; }
        void NewTask(string name, double period, Clock clock,
                     ITaskPoolManager task_manager);
    }

    public abstract class WithTasking : ITaskingManagement {
        private PiagetTask task;
        private Clock clock;

        protected IPiagetTask Task {
            get { return (IPiagetTask)this.task; }
        }
        abstract protected void Reset();

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
