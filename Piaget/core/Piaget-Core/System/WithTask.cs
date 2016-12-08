
namespace Piaget_Core.System {
    abstract class WithTask {
        private ITask i_task;
        public ITask Task {
            get { return this.i_task; }
        }

        abstract protected void Reset();

        public void __ResetForTaskManager() {
            Task task = (Task)this.i_task;
            task.ResetWakeupTime();
            Reset();
        }
    }
}
