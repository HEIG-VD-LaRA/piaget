using Piaget_Core.Lib;

namespace Piaget_Core.System {
    class HibernatedTaskPool : DoubleLinkedList<TaskPoolNode> {

        public TaskPoolNode Find(Task task) {
            return Find<Task>(task, (current) => (current.task == task));
        }

    }
}
