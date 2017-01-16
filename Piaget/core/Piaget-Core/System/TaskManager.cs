namespace Piaget_Core.System {

    // Interface for PiagetJB
    public interface ITasksLauncher {
        void AddParallelTask(string name, WithTasking with_task, double sw_period);
        void Start();
        Clock Clock { get; }
        void TerminateAll();
    }
    // Interface for tasks
    public interface ITaskPoolManager {
        void AddParallelTask(string name, WithTasking with_task, double sw_period);
        void AddSerialTask(string name, WithTasking with_task, double sw_period, Task parent);
        void Terminate(Task task);
        void RemoveFromPool(Task task);
    }

    public class TaskManager : ITasksLauncher, ITaskPoolManager {
        private TaskPool task_pool;
        private Clock clock;


        // METHODS FOR ITaskManager_Launcher, ITaskManager_Tasking ------------------------------------------------
        public void AddParallelTask(string name, WithTasking with_task, double sw_period) {
            ((ITaskingManagement)with_task).NewTask(name, sw_period, (ITaskPoolManager)this, this.clock);
            this.task_pool.Add(((ITaskingManagement)with_task).Task);
        }


        // METHODS FOR ITaskManager_Launcher ------------------------------------------------

        public TaskManager() {
            this.clock = new Clock();
            this.task_pool = new TaskPool(this.clock);
        }

        public void Start() {
            AddSystemTasks();
            // Start multitasking
            this.clock.Start();
            while (true) {
                this.task_pool.Current.task.Exec();
                this.task_pool.Current.task.Sleep();
                this.task_pool.MoveNext();
            }
        }

        public Clock Clock {
            get { return this.clock; }
        }

        public void TerminateAll() {
            this.task_pool.Reset();
        }


        // METHODS FOR ITaskManager_Tasking ------------------------------------------------

        public void AddSerialTask(string name, WithTasking with_task, double sw_period, Task parent) {
            ((ITaskingManagement)with_task).NewTask(name, sw_period, this, this.clock);
            // If the user use the same task state to add several serial tasks,
            // only the first one added will be the top one
            if (parent == task_pool.Current.task) {
                MoveToChildTask(((ITaskingManagement)with_task).Task, parent);
            }
        }

        public void Terminate(Task task) {
            task.SetTerminated();
        }

        public void RemoveFromPool(Task task) {
            this.task_pool.Remove(task);
        }


        // PRIVATE METHODS ------------------------------------------------

        // Tasks that exist in every Piaget applications
        private void AddSystemTasks() {
            // TO BE IMPLEMENTED
        }

        private void MoveToChildTask(Task new_task, Task parent) {
            new_task.InsertAfter(parent);
            task_pool.Current.task = new_task;
        }
    }
}
