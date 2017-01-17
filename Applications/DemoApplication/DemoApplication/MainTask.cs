using Piaget_Core;
using System;

namespace DemoApplication {
    class MainTask : WithTasking {
        Action<string> append_message_callback;
        private int n_loops = 1;
        private string task_id;

        public MainTask(Action<string> append_message_callback) {
            this.append_message_callback = append_message_callback;
        }

        protected override void Reset() {
            this.append_message_callback("1." + this.Task.Name + " : ! RESET !");
            this.Task.SetState(State_1);
        }

        private void State_1() {
            this.task_id = this.n_loops + "." + this.Task.Name;
            this.append_message_callback(this.task_id + " : State_1");
            this.Task.SetState(State_2);
        }

        private void State_2() {
            this.append_message_callback(this.task_id + " : State_2");
            this.Task.AddChildTask(this.n_loops + ".Child task", 
                                   new ChildTask(this.n_loops, this.append_message_callback), 
                                   1.0 * Clock.sec);
            this.Task.SetState(LastState);
        }

        private void LastState() {
            this.append_message_callback(this.task_id + " : LastState");
            this.n_loops++;
            this.Task.SetState(State_1);
        }
    }
}
