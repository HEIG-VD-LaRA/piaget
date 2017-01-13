
using System;

namespace Piaget_Core.System {
    class TaskManager  {
        private TaskPool task_pool;
        private HibernatedTaskPool hibernated_task_pool = new HibernatedTaskPool();
        private Clock clock;

        public TaskManager(Clock clock) {
            this.clock = clock;
            this.task_pool = new TaskPool(clock);
        }

        public void AddParallelTask(string name, WithTask with_task, double sw_period) {
            with_task.__NewTask(name, sw_period, this, this.clock);
            this.task_pool.Add((Task)with_task.Task);
        }

        public void AddSerialTask(string name, WithTask with_task, double sw_period, Task parent) {
            with_task.__NewTask(name, sw_period, this, this.clock);
            // If the user use the same task state to add several serial tasks,
            // only the first one added will be the top one
            if (parent == task_pool.Current.task) {
                MoveToChildTask((Task)with_task.Task, parent);
            }
        }

        private void MoveToChildTask(Task new_task, Task parent) {
            new_task.InsertAfter(parent);
            task_pool.Current.task = new_task;
        }

        public void Start() {
            AddSystemTasks();
            // Start multitasking
            // (...)
            this.clock.Start();
            while (true) {
                this.task_pool.Current.task.Sleep();
                this.task_pool.Current.task.Exec();
                this.clock.UpdateElapsedTime();
                this.task_pool.MoveNext();
            }
        }
        private void AddSystemTasks() {
            // TO BE IMPLEMENTED
        }

        public void Terminate(Task task) {
            task.SetTerminated();
            this.RemoveFromPool(task);
        }
        public void RemoveFromPool(Task task) {
            this.task_pool.Remove(task);
        }

        public void Hibernate(Task task) {
            TaskPoolNode task_pool_node = this.task_pool.Find(task);
            this.task_pool.Remove(task_pool_node);
            this.hibernated_task_pool.Add(task_pool_node);
        }

        public void Recover(Task task) {
            TaskPoolNode task_pool_node = this.hibernated_task_pool.Find(task);
            this.hibernated_task_pool.Remove(task_pool_node);
            task.ResetWakeupTime();
            this.task_pool.Add(task_pool_node);
        }

        public void TerminateAll() {
            this.task_pool.Reset();
        }
    }
}
