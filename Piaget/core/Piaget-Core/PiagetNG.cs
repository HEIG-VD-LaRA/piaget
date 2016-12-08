using Piaget_Core.System;

namespace Piaget_Core {
    class PiagetNG {
        private TaskManager task_manager;
        private Clock clock;
        public Clock TheClock {
            get { return this.clock; }
        }

        public PiagetNG () {
            task_manager = new TaskManager(clock);
        }

        public void AddParallelTask(string name, WithRegularTask task, long period) {
            task_manager.AddParallelTask(name, task, period);
        }

        public void Start() {
            this.clock = new Clock();
            task_manager.Start();
        }

        public TaskPoolNode TerminateAll() {
            return task_manager.TerminateAll();
        }

    }
}
