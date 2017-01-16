using Piaget_Core.System;
using System;

namespace Piaget_Core {

    public interface ITaskingManagement {
        Task Task { get; }
        void NewTask(string name, double period, ITaskPoolManager task_manager, Clock clock);
    }

    public abstract class WithTasking : ITaskingManagement {
        private Task task;

        protected ITask Task {
            get { return (ITask)this.task; }
        }
        abstract protected void Reset();


        // METHODS CALLED BY THE TASK MANAGER :

        Task ITaskingManagement.Task {
            get { return this.task; }
        }

        void ITaskingManagement.NewTask(string name, double period, ITaskPoolManager task_manager, Clock clock) {
            this.task = new Task();
            this.task.Init(name, period, task_manager, clock);
            this.task.SetState(Reset);
        }

    }
}
