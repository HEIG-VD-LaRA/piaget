using Piaget_Core;
using System;
using Yieldable = System.Collections.IEnumerator;

namespace DemoApplication {

    class ParallelTask : WithTasking {
        Action<string> append_message_callback;
        private readonly int n_loops;

        public ParallelTask(int n_loops, Action<string> append_message_callback) {
            this.n_loops = n_loops;
            this.append_message_callback = append_message_callback;
        }

        protected override void Reset() {
            this.append_message_callback(this.Task.Name + " : ! RESET !");
            this.Task.SetState(State_1);
        }

        private Yieldable State_1() {
            this.append_message_callback(this.Task.Name + " : State_1 - A");
            yield return null;
            this.append_message_callback(this.Task.Name + " : State_1 - B");
            for (int i = 0; i < 4; i++) {
                yield return null;
                this.append_message_callback(this.Task.Name + " : State_1 - C" + i);
            }
            this.Task.SetState(LastState);
        }

        private void LastState() {
            this.append_message_callback(this.Task.Name + " : LastState");
            this.Task.SetTerminated();
        }
    }
}
