
using System;

namespace Piaget_Core.Lib {
    class DoubleLinkedNode<T_Node> where T_Node : DoubleLinkedNode<T_Node> {
        public T_Node previous;
        public T_Node next;

        public DoubleLinkedNode() {
            this.previous = (T_Node)this;
            this.next = (T_Node)this;
        }
        public bool IsAlone() {
            if (this.next == this) {
                return true;
            }
            return false;
        }

        public void MoveBefore(T_Node before_that) {
            if (this.IsAlone()) {
                return;
            }
            this.Remove();
            this.InsertBefore(before_that);
        }

        public void InsertBefore(T_Node before_that) {
            this.previous = before_that.previous;
            this.next = before_that;
            before_that.previous.next = (T_Node)this;
            before_that.previous = (T_Node)this;
        }
        public void InsertAfter(T_Node after_that) {
            this.InsertBefore(after_that.next);
        }
        private void Remove() {
            this.previous.next = this.next;
            this.next.previous = this.previous;
        }

        static public void Remove(ref T_Node to_be_removed) {
            if (to_be_removed.IsAlone()) { // Is it the only element from the list ?
                to_be_removed = null;
                return;
            }
            to_be_removed.Remove();
        }
    }
}
