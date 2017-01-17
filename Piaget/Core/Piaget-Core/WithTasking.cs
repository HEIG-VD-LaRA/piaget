using Piaget_Core.System;
using System;

namespace Piaget_Core {

    public interface ITaskingManagement {
        PiagetTask Task { get; }
        void NewTask(string name, double period, ITaskPoolManager task_manager, Clock clock);
    }

    public abstract class WithTasking : ITaskingManagement {
        private PiagetTask task;

        protected IPiagetTask Task {
            get { return (IPiagetTask)this.task; }
        }
        abstract protected void Reset();


        // METHODS CALLED BY THE TASK MANAGER :

        PiagetTask ITaskingManagement.Task {
            get { return this.task; }
        }

        void ITaskingManagement.NewTask(string name, double period, ITaskPoolManager task_manager, Clock clock) {
            this.task = new PiagetTask();
            this.task.Init(name, period, task_manager, clock, Reset);
        }

    }
}
