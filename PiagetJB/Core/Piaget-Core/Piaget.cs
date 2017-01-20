using Piaget_Core.System;

using System.Threading;
using System;
using System.Windows.Forms;

namespace Piaget_Core {
    public class Piaget {
        private Thread task_manager_thread;
        private ITasksLauncher task_manager;
        private Form frm;
        private SyncUIWithTasks sync_task;
        private bool is_stopped;

        public double ApplicationElapsedTime {
            get { return this.task_manager.Clock.ElapsedTime; }
        }

        public string ApplicationElapsedTimeFormatted {
            get { return Time.Format(this.task_manager.Clock.ElapsedTime); }
        }

        public Piaget(Form frm) {
            this.frm = frm;
            this.task_manager = (ITasksLauncher)new TaskManager();
            AddSystemTasks();
            this.is_stopped = true;
        }

        public void AddParallelTask(string name, WithTasking task, double sw_period) {
            if (this.is_stopped) {
                this.task_manager.AddParallelTask(name, task, sw_period);
            } else {
                this.sync_task.Invoke(() => this.task_manager.AddParallelTask(name, task, sw_period));
            }
        }

        public void Start() {
            this.task_manager_thread = new Thread(this.task_manager.Start);
            this.task_manager_thread.Start();
            this.is_stopped = false;
        }

        // Must be called with TaskInvoke if it result from a user interface action !
        // Otherwise it may create some concurrency issue !
        public void Stop() {
            this.task_manager.TerminateAll();
        }

        public void TaskInvoke(Action action) {
            this.sync_task.Invoke(action);
        }


        // PRIVATE METHODS ------------------------------------------------

        private void AddSystemTasks() {
            this.sync_task = new SyncUIWithTasks(this.frm);
            this.task_manager.AddParallelTask("Sync UI with tasks", sync_task, Config.SyncUISleep);
        }
    }
}
