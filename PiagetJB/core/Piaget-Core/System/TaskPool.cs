﻿using System;
using Piaget_Core.Lib;

namespace Piaget_Core.Base {

    public class TaskPoolNode : DoubleLinkedNode<TaskPoolNode> {
        public PiagetTask task;
        public TaskPoolNode(PiagetTask task) {
            this.task = task;
        }
    }

    public class TaskPool : DoubleLinkedListSorted<TaskPoolNode> {
        //
        // When running, the task manager needs that there is at least one task in the pool.
        // So when there is no tasks to be executed, null_task will appear in the pool.
        private PiagetTask persistant_task;

        public TaskPoolNode Current {
            get { return this.First; }
            set { this.First = value; }
        }

        static private Func<TaskPoolNode, long> get_wakeup_time = delegate (TaskPoolNode node) { return node.task.WakeupSWTime; };
        public TaskPool(PiagetTask persistant_task) : base(get_wakeup_time) {
            this.persistant_task = persistant_task;
            Add(new TaskPoolNode(persistant_task));
        }

        public void Reset() {
            Current.next = Current;
            Current.previous = Current;
            Current.task = this.persistant_task;
        }

        public void Add(PiagetTask task) {
            TaskPoolNode task_pool_node = new TaskPoolNode(task);
            Add(task_pool_node);
        }

        public new void Remove(TaskPoolNode task_pool_node) {
            base.Remove(task_pool_node);
        }

        public void Remove(PiagetTask task) {
            TaskPoolNode executing_task_pool_node = Find(task);
            if (task == task.next) { // No other tasks in the same task pool node ? (which means that the task isn't the child of another task)
                Remove(executing_task_pool_node);
            } else { // Remove the task from the current task pool node, so that the task manager can switch to its parent task
                PiagetTask child_task = executing_task_pool_node.task;
                PiagetTask parent_task = task.previous;
                PiagetTask bottom_task = child_task.next;
                parent_task.next = bottom_task;
                bottom_task.previous = parent_task;
                executing_task_pool_node.task = parent_task;
                // As the parent task is now activated, its wake-up time needs to be updated with regards to the current time
                parent_task.ResetWakeupTime();
            }
        }

        public TaskPoolNode Find(PiagetTask node) {
            TaskPoolNode current = this.First;
            while (current.task != node) { // Loop thru all the pool
                current = current.next;
            }
            return current;
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
                if (Current.task.WakeupSWTime > next_task_pool_node.task.WakeupSWTime) {
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
