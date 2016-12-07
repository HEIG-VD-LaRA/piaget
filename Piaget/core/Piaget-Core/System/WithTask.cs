
namespace Piaget_Core.System {
    abstract class WithTask {
        private ITask task;
        public ITask Task {
            get { return this.task; }
        }

        abstract public void Reset();
    }
}
