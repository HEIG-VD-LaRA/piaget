using System;
using Piaget_Core.Lib;

namespace Piaget_Core.System {

    class TaskPoolNode : DoubleLinkedNode<TaskPoolNode> {
        public Task task;
        public TaskPoolNode(Task task) {
            this.task = task;
        }
    }

    class TaskPool : DoubleLinkedListSorted<TaskPoolNode> {
        static private Func<TaskPoolNode,long> get_wakeup_time = delegate (TaskPoolNode node) { return node.task.WakeupSWTime; };
        private Clock clock;
        private readonly Task null_task = new Task();
        private readonly long null_task_period = (long)(100.0 * Clock.ms);

        public TaskPool(Clock clock) : base(get_wakeup_time) {
            this.clock = clock;
            this.null_task.Init("Null task", null_task_period, null, clock);
            this.null_task.SetState(() => { }); // void procedure to be executed
            Add(new TaskPoolNode(this.null_task));
        }

        public TaskPoolNode Current {
            get { return this.First; }
            set { this.First = value; }
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
            TaskPoolNode next_task_pool_node = Current.next;
            while (true) {
                if (get_wakeup_time(next_task_pool_node) >= get_wakeup_time(Current)) {
                    if (next_task_pool_node == Current.next) { // == Il faut encore exécuter la tâche courante avant la suivante ?
                        return;
                    }
                    if (next_task_pool_node == Current) { // On a fait le tour et on est arrivé de nouveau sur current ?
                        Current = Current.next; // ça veut dire que 
                        return;
                    }
                    Current.MoveBefore(next_task_pool_node);
                    return;
                }
                next_task_pool_node = next_task_pool_node.next;
            }
        }

    }
        //public new void Add(Task task) {
        //    base.Add(task);
        //}
}

    //class TaskCircularList {
    //    private class TaskNode {
    //        public Task obj;
    //        public TaskNode next;
    //    }
    //    private TaskNode Current = null;

    //    public void Add(Task task) {
    //        TaskNode new_task_node = new TaskNode();
    //        new_task_node.obj = task;

    //        if (Current == null) {
    //            Current = new_task_node;
    //            Current.next = Current;
    //        } else {
    //            new_task_node.next = Current.next;
    //            Current.next = new_task_node;
    //        }
    //    }
    //    public Task CurrentTask {
    //        get {
    //            return Current.obj;
    //        }
    //    }
    //    public void MoveNext() {
    //        Current = Current.next;
    //    }
    //}
