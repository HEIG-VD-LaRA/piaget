using System;

namespace Piaget_Core.Lib {
    public class DoubleLinkedList<T_Node> where T_Node : DoubleLinkedNode<T_Node> {
        private T_Node first = null;

        protected T_Node First {
            get { return this.first; }
            set { this.first = value; }
        }

        public void Add(T_Node node) {
            if (this.first == null) {
                this.first = node;
            } else {
                node.InsertBefore(this.first);
            }
        }

        public void Remove(T_Node node) {
            Remove<T_Node>(node, delegate (T_Node current) { return current != node; });
        }

        public void Remove<T_Obj>(T_Obj obj, Func<T_Node, bool> false_condition) {
            T_Node current = this.first;
            while (false_condition(current)) {
                current = current.next;
            }
            if (current == first) { // Is it the first element to be removed ?
                if (first == first.next) { // Is there only 1 element in the list ?
                    first = null;
                    return;
                }
                first = first.next;
            }
            current.previous.next = current.next;
        }

        public T_Node Find<T_Obj>(T_Obj obj, Func<T_Node, bool> true_condition) {
            T_Node current = this.first;
            while (true) {
                if (true_condition(current)) {
                    return current;
                }
                current = current.next;
            }
        }
    }

}
