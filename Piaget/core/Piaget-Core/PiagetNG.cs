using Piaget_Core.System;

namespace Piaget_Core {
    class PiagetNG {
        private TaskManager task_manager;
        private Clock clock = new Clock();
        public Clock TheClock {
            get { return this.clock; }
        }

        public PiagetNG () {
            task_manager = new TaskManager(clock);
        }

        public void AddParallelTask(string name, WithTask task, double sw_period) {
            task_manager.AddParallelTask(name, task, sw_period);
        }

        public void Start() {
            task_manager.Start();
        }

        public TaskPoolNode TerminateAll() {
            return task_manager.TerminateAll();
        }

    }
}
