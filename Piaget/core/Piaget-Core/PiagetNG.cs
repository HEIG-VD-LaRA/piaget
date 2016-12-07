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
            clock = new Clock();
        }
        public void AddParallelTask(string name, WithRegularTask task, ulong period) {
            task_manager.AddParallelTask(name, task, period);
        }

        public void Start() {
            task_manager.Start();
        }

        public TaskPoolNode TerminateAll() {
            return task_manager.TerminateAll();
        }

    }
}
