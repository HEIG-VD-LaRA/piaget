using Piaget_Core.Lib;

namespace Piaget_Core.System {
    public class HibernatedTaskPool : DoubleLinkedList<TaskPoolNode> {

        public TaskPoolNode Find(Task task) {
            return Find<Task>(task, delegate (TaskPoolNode current) { return current.task == task; });
        }

    }
}
