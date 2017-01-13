using System.Threading;

using Piaget_Core.System;

namespace Piaget_Core {
    class PiagetJB {
        private Thread task_manager_thread;
        private TaskManager task_manager;
        private Clock clock = new Clock();
        public Clock Clock {
            get { return this.clock; }
        }

        public PiagetJB () {
            task_manager = new TaskManager(clock);
        }

        public void AddParallelTask(string name, WithTask task, double sw_period) {
            task_manager.AddParallelTask(name, task, sw_period);
        }

        public void Start() {
            this.task_manager_thread = new Thread(this.task_manager.Start);
            this.task_manager_thread.Start();
        }

        public void TerminateAll() {
            task_manager.TerminateAll();
        }

    }
}
