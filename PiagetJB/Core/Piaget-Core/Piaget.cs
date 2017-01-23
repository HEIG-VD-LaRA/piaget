using Piaget_Core.Base;

using System.Threading;
using System;
using System.Windows.Forms;

namespace Piaget_Core {
    public class Piaget {
        private Thread task_manager_thread;
        private ITasksLauncher task_manager;
        private Form frm;
        private SyncUIWithTasks sync_task;
        private bool is_started;

        public double ApplicationElapsedTime {
            get { return this.task_manager.Clock.ElapsedTime; }
        }

        public string ApplicationElapsedTimeFormatted {
            get { return Time.Format(this.task_manager.Clock.ElapsedTime); }
        }

        public Piaget(Form frm) {
            this.frm = frm;
            this.sync_task = new SyncUIWithTasks();
            this.task_manager = (ITasksLauncher)new TaskManager(this.sync_task);
            this.is_started = false;
            if (System.Windows.Application.Current == null) {
                new System.Windows.Application();
            }
        }

        public void AddTask(string name, WithTasking task, double period) {
            // Avoid concurrency issues when the UI thread add a task while the task manager is running (in a different thread),
            // which could result of both of them reading and/or modifying the task pool at the same time, which could corrupt
            // the task list of the task pool.
            if (UIThread() && this.is_started) {
                Invoke(() => this.task_manager.AddParallelTask(name, task, period));
            } else {
                this.task_manager.AddParallelTask(name, task, period);
            }
        }

        public void Start() {
            this.task_manager_thread = new Thread(this.task_manager.Start);
            this.task_manager_thread.Start();
            this.is_started = true;
        }

        public void Stop() {
            if (! UIThread()) {
                throw new Exception("Must be called by the UI thread because the task manager thread will be aborted !");
            }
            this.task_manager_thread.Abort();
            this.task_manager.TerminateAll();
            this.is_started = false;
        }

        // Use this method to avoid concurrency issues when changing internal variables
        // of a task with the UI thread.
        //
        // Usage :
        // Invoke(() => {
        //    <line(s) of code ended by semi-colons>
        // }
        // Or : Invoke(() => <single line of code>)
        public void Invoke(Action action) {
            this.sync_task.Invoke(action);
        }


        // PRIVATE METHODS ------------------------------------------------

        private bool UIThread() {
            return (System.Windows.Application.Current.Dispatcher.CheckAccess());
        }

    }
}
