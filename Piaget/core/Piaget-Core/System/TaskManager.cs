
namespace Piaget_Core.System {
    class TaskManager  {
        private TaskPool task_pool = new TaskPool();
        private HibernatedTaskPool hibernated_task_pool = new HibernatedTaskPool();
        private Clock clock;

        public TaskManager(Clock clock) {
            this.clock = clock;
        }

        public void AddParallelTask(string name, WithRegularTask with_regular_task, ulong period) {
            InitTask(name, with_regular_task, period);
            this.task_pool.Add((Task)with_regular_task.Task);
        }

        public void AddSerialTask(string name, WithTask with_task, ulong period, Task parent) {
            InitTask(name, with_task, period);
            // If the user use the same task state to add several serial tasks,
            // only the first one added will be the top one
            if (parent == task_pool.Current.task) {
                MoveToChildTask((Task)with_task.Task, parent);
            }
        }

        private void InitTask(string name, WithTask with_task, ulong period) {
            Task task = (Task)with_task.Task;
            task.Init(name, period, this.clock, this);
            with_task.__ResetForTaskManager();
        }

        private void MoveToChildTask(Task new_task, Task parent) {
            new_task.InsertAfter(parent);
            task_pool.Current.task = new_task;
        }

        public void Start() {
            AddSystemTasks();
            // Start multitasking
            // (...)
            while (true) {
                this.task_pool.Current.task.Sleep();
                this.task_pool.Current.task.Exec();
                this.clock.IncElapsedTime();
                this.task_pool.MoveNext();
            }
        }
        private void AddSystemTasks() {
            // TO BE IMPLEMENTED
        }

        public void Terminate(Task task) {
            task.SetTerminated();
            RemoveFromPool(task);
        }

        public void RemoveFromPool(Task task) {
            this.task_pool.SerialRemove(task);
        }

        public void Hibernate(Task task) {
            TaskPoolNode task_pool_node = this.task_pool.Find(task);
            this.task_pool.Remove(task_pool_node);
            this.hibernated_task_pool.Add(task_pool_node);
        }

        public void Recover(Task task) {
            TaskPoolNode task_pool_node = this.hibernated_task_pool.Find(task);
            this.hibernated_task_pool.Remove(task_pool_node);
            this.task_pool.Add(task_pool_node);
        }

        public TaskPoolNode TerminateAll() {
            TaskPoolNode first = this.task_pool.Current;
            TaskPoolNode current = first;
            do {
                current.task.SetTerminated();
                current = current.next;
            } while (current != first);
            return first;
        }
    }
}
