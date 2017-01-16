using System;
using Piaget_Core.Lib;

namespace Piaget_Core.System {

    public class TaskPoolNode : DoubleLinkedNode<TaskPoolNode> {
        public Task task;
        public TaskPoolNode(Task task) {
            this.task = task;
        }
    }

    public class TaskPool : DoubleLinkedListSorted<TaskPoolNode> {
        static private Func<TaskPoolNode,long> get_wakeup_time = delegate (TaskPoolNode node) { return node.task.WakeupSWTime; };
        // When running, the task manager needs that there is at least one task in the pool.
        // So when there is no tasks to be executed, null_task will appear in the pool.
        private readonly Task null_task = new Task();
        private readonly long null_task_period = (long)(100.0 * Clock.ms);

        public TaskPoolNode Current {
            get { return this.First; }
            set { this.First = value; }
        }

        public TaskPool(Clock clock) : base(get_wakeup_time) {
            this.null_task.Init("Null task", null_task_period, null, clock);
            this.null_task.SetState(() => { }); // void procedure to be executed
            Add(new TaskPoolNode(this.null_task));
        }

        public void Reset() {
            Current.next = Current;
            Current.previous = Current;
            Current.task = this.null_task;
        }

        public void Add(Task task) {
            if (Current.task == this.null_task) { // First task to be added ?
                Current.task = task;
            } else {
                TaskPoolNode task_pool_node = new TaskPoolNode(task);
                Add(task_pool_node);
            }
        }

        public new void Remove(TaskPoolNode task_pool_node) {
            if (task_pool_node == task_pool_node.next) { // Removing the last task in the pool ?
                task_pool_node.task = null_task;
            } else {
                base.Remove(task_pool_node);
            }
        }

        public void Remove(Task task) {
            TaskPoolNode executing_task_pool_node = Find(task);
            if (task == task.next) { // No other tasks in the same task pool node ?
                Remove(executing_task_pool_node);
            } else { // Remove the task from the current task pool node
                Task old_executing_task = executing_task_pool_node.task;
                Task new_executing_task = task.previous;
                Task bottom_task = old_executing_task.next;

                new_executing_task.next = bottom_task;
                bottom_task.previous = new_executing_task;
                executing_task_pool_node.task = new_executing_task;
            }
        }

        public TaskPoolNode Find(Task node) {
            while (true) { // Loop thru all the serial task list in which node belongs
                TaskPoolNode current = this.First;
                while (true) { // Loop thru all the pool
                    if (current.task == node) {
                        return current;
                    }
                    current = current.next;
                    if (current == this.First) { // Did we loop thru all the pool without finding the current node ?
                        // Then we will try with the next node on the serial task list
                        break;
                    }
                }
                node = node.next;
            }
        }

        public void Hibernate(Task node) {
            Hibernate(Find(node));
        }

        public void Hibernate(TaskPoolNode serial_task_list) {
            this.Remove(serial_task_list);
        }

        public void MoveNext() {
            // At this point, the Current task is the task that was lastly executed and the tasks list
            // need to be wandered so that the Current task can be moved in the right place in the list,
            // as the list is sorted by scheduling order
            TaskPoolNode next_task_pool_node = Current.next;

            while (true) {
                // If the next execution of the current task is scheduled later as the current element of the list,
                // Then we know that the current task will be moved after the current element (but not necessarly
                // right after), so we move to the next element of the list and do this check again
                if (get_wakeup_time(Current) > get_wakeup_time(next_task_pool_node)) {
                    next_task_pool_node = next_task_pool_node.next;
                // Otherwise we have found where the current task has to be in the list
                } else {
                    // Check if moving to the next task is actually needed, because it isn't the case when the current 
                    // task is to be scheduled to be executed again before all the tasks.
                    if (next_task_pool_node != Current.next) {
                        Current = Current.next;
                        // Check if the last executed task has to be moved in the list, because if it has to be executed  
                        // after the last task in list, it is already at the right position, as the list is circular.
                        if (next_task_pool_node != Current.previous) {
                            Current.previous.MoveBefore(next_task_pool_node);
                        }
                    }
                    return;
                }
            }
        }
    }
}
