using Piaget_Core;
using System;

namespace DemoApplication {
    class ChildTask : WithTasking {
        Action<string> append_message_callback;
        private readonly int n_loops;

        public ChildTask(int n_loops, Action<string> append_message_callback) {
            this.n_loops = n_loops;
            this.append_message_callback = append_message_callback;
        }

        protected override void Reset() {
            this.append_message_callback(this.Task.Name + " : ! RESET !");
            this.Task.SetState(State_1);
        }

        private void State_1() {
            this.append_message_callback(this.Task.Name + " : State_1");
            this.Task.SetState(State_2);
        }

        private void State_2() {
            this.append_message_callback(this.Task.Name + " : State_2");
            this.Task.AddParallelTask(this.n_loops + ".Parallel task", 
                                      new ParallelTask(this.n_loops, this.append_message_callback), 
                                      1.0 * Clock.sec);
            this.Task.SetState(LastState);
        }

        private void LastState() {
            this.append_message_callback(this.Task.Name + " : LastState");
            this.Task.SetTerminated();
        }
    }
}
