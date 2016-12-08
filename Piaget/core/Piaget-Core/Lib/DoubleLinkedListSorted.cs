
using System;

namespace Piaget_Core.Lib {

    class DoubleLinkedListSorted<T_Node> where T_Node : DoubleLinkedNode<T_Node> {
        private Func<T_Node,long> get_val;
        private T_Node first = null;

        protected T_Node First {
            get { return this.first; }
            set { this.first = value; }
        }

        public DoubleLinkedListSorted(Func<T_Node,long> get_val) {
            this.get_val = get_val;
        }

        public long Min() {
            return get_val(this.first);
        }

        public void Add(T_Node node) {
            if (this.first == null) {
                this.first = node;
            } else {
                T_Node current = this.first;
                do {
                    if (get_val(current) >= get_val(node)) {
                        node.InsertBefore(current);
                        if (current == this.first) {
                            this.first = node; // == this.first.previous
                        }
                        break;
                    }
                    if (current == this.first) { // If it did a complete loop, it means that the value to be inserted is the highest of the list
                        node.InsertBefore(current);
                        break;
                    }
                    current = current.next;
                } while (true);
            }
        }

        public void Remove(T_Node node) {
            Remove<T_Node>(node, delegate (T_Node current) { return current != node; });
        }

        public void Remove(long val) {
            Remove<long>(val, delegate (T_Node current) { return get_val(current) != val; });
        }

        public void Remove<T_Obj>(T_Obj obj, Func<T_Node,bool> false_condition) {
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



        ////public void Add(Node start_node, ObjType obj) {
        ////    Node current = start_node;
        ////    do {
        ////        if (current.obj.val >= obj.val) {
        ////            InsertNew(obj, current);
        ////            if (current == start_node) {
        ////                start_node = start_node.previous;
        ////            }
        ////            break;
        ////        }
        ////        if (current == start_node) {
        ////            InsertNew(obj, current);
        ////            break;
        ////        }
        ////        current = current.next;
        ////    } while (true);
        ////}

        //public void MoveFirstBefore(Node before_this_node) {
        //    Node new_first = this.first.next;
        //    this.first.next = before_this_node;
        //    this.first.previous = before_this_node.previous;
        //    before_this_node.previous.next = this.first;
        //    before_this_node.previous = this.first;
        //    this.first = new_first;
        //}

        //public void Remove(ObjType obj) {
        //    Node current = this.first;
        //    while (current.obj != obj) {
        //        current = current.next;
        //    }
        //    if (current == first) {
        //        if (first == first.next) {
        //            first = null;
        //            return;
        //        }
        //        first = first.next;
        //    }
        //    current.previous.next = current.next;
        //}

        //public void Remove(long val) {
        //    Node current = this.first;
        //    while (current.obj.val != val) {
        //        current = current.next;
        //    }
        //    if (current == first) {
        //        if (first == first.next) {
        //            first = null;
        //            return;
        //        }
        //        first = first.next;
        //    }
        //    current.previous.next = current.next;
        //}

    }
    }
