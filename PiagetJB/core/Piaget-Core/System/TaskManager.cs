
namespace Piaget_Core.Base {

    // Interface for PiagetJB
    public interface ITasksLauncher {
        void AddParallelTask(string name, WithTasking with_task, double period);
        void Start();
        void TerminateAll();
        Clock Clock { get; }
    }
    // Interface for tasks
    public interface ITaskPoolManager {
        void AddParallelTask(string name, WithTasking with_task, double period);
        void AddChildTask(string name, WithTasking with_task, double period, PiagetTask parent);
        void Terminate(PiagetTask task);
        void RemoveFromPool(PiagetTask task);
    }

    public class TaskManager : ITasksLauncher, ITaskPoolManager {
        private SyncUIWithTasks sync_task;
        private TaskPool task_pool;
        private Clock clock;

        // METHODS FOR ITaskManager_Launcher, ITaskManager_Tasking ------------------------------------------------
        public void AddParallelTask(string name, WithTasking with_task, double period) {
            ((ITaskingManagement)with_task).NewTask(name, period, this.clock,
                                                    (ITaskPoolManager)this);
            this.task_pool.Add(((ITaskingManagement)with_task).Task);
        }

        // METHODS FOR ITaskManager_Launcher ------------------------------------------------

        public TaskManager(SyncUIWithTasks sync_task) {
            this.clock = new Clock();
            ((ITaskingManagement)sync_task).NewTask("Sync UI with tasks", Config.SyncUISleep, this.clock,
                                                    (ITaskPoolManager)this);
            this.sync_task = sync_task;
            this.task_pool = new TaskPool(((ITaskingManagement)sync_task).Task);
        }

        public void Start() {
            this.clock.Start();
            while (true) {
                this.task_pool.Current.task.Sleep();
                this.task_pool.Current.task.Exec();
                this.task_pool.MoveNext();
            }
        }
        
        public Clock Clock {
            get { return this.clock; }
        }
        
        public void TerminateAll() {
            this.task_pool.Reset();
            this.Clock.Stop();
        }


        // METHODS FOR ITaskManager_Tasking ------------------------------------------------

        public void AddChildTask(string name, WithTasking with_task, double period, PiagetTask parent) {
            ((ITaskingManagement)with_task).NewTask(name, period, this.clock,
                                                    (ITaskPoolManager)this);
            // If the user use the same task state to add several child tasks,
            // only the first one added will be the top one
            if (parent == task_pool.Current.task) {
                MoveToChildTask(((ITaskingManagement)with_task).Task, parent);
            }
        }

        public void Terminate(PiagetTask task) {
            task.SetTerminated();
        }

        public void RemoveFromPool(PiagetTask task) {
            this.task_pool.Remove(task);
        }


        // PRIVATE METHODS ------------------------------------------------

        private void MoveToChildTask(PiagetTask new_task, PiagetTask parent) {
            new_task.InsertAfter(parent);
            task_pool.Current.task = new_task;
        }

    }
}
