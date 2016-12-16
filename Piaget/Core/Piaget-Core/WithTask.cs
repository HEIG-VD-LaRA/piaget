using Piaget_Core.System;

namespace Piaget_Core {
    abstract class WithTask {
        private ITask i_task = new Task();
        public ITask Task {
            get { return this.i_task; }
        }

        abstract protected void Reset();

        public void __NewTask(string name, double period, TaskManager task_manager, Clock clock) {
            Task task = new Task();
            task.Init(name, period, task_manager, clock);
            task.SetState(Reset);
            this.i_task = (Task)task;
        }
    }
}
