
using System;

namespace Piaget_Core.Lib {
    class DoubleLinkedNode<T_Node> where T_Node : DoubleLinkedNode<T_Node> {
        public T_Node previous;
        public T_Node next;

        public DoubleLinkedNode() {
            this.previous = (T_Node)this;
            this.next = (T_Node)this;
        }
        public void MoveBefore(T_Node before_that) {
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

        public void Remove() {
            if (this == this.next) {
                // ! Must destroy this if it is the only element !
                throw new NotImplementedException();
                //return;
            }
            this.previous.next = this.next;
            this.next.previous = this.previous;
        }
    }
}
