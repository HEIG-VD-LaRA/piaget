using Piaget_Core.System;
using System.Windows.Forms;
using System.Threading;

namespace Piaget_Core {
    public class Piaget {
        private Thread task_manager_thread;
        private ITasksLauncher task_manager;

        public double ApplicationElapsedTime {
            get { return this.task_manager.Clock.ElapsedTime; }
        }

        public string ApplicationElapsedTimeFormatted {
            get { return Time.Format(this.task_manager.Clock.ElapsedTime); }
        }

        public Piaget() {
            task_manager = (ITasksLauncher)new TaskManager();
        }

        public void AddParallelTask(string name, WithTasking task, double sw_period) {
            task_manager.AddParallelTask(name, task, sw_period);
        }

        public void Start() {
            this.task_manager_thread = new Thread(this.task_manager.Start);
            this.task_manager_thread.Start();
        }

        public void Stop() {
            task_manager.TerminateAll();
        }
    }
}
