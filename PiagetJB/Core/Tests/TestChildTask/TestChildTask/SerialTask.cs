using System;

using Piaget_Core;

namespace TestChildTask {
    class SerialTask : WithTasking {
        private readonly int level, max_level;
        private Action<string> update_form_callback;
        private Action done_callback;

        public SerialTask(int level, int max_level, Action<string> update_form_callback, Action done_callback = null) {
            this.level = level;
            this.max_level = max_level;
            this.update_form_callback = update_form_callback;
            this.done_callback = done_callback;
        }

        protected override void Reset() {
            this.update_form_callback(this.Task.Name + " : ! RESET !");
            this.Task.SetState(FirstState);
        }

        private void FirstState() {
            this.update_form_callback(this.Task.Name + " : First state");
            this.Task.SetState(SecondState);
        }

        private void SecondState() {
            this.update_form_callback(this.Task.Name + " : Second state");
            if (this.level < this.max_level - 1) {
                this.Task.AddChildTask("Task level " + (level + 1), 
                                       new SerialTask(this.level + 1, max_level, 
                                                      this.update_form_callback),
                                       this.Task.SWPeriod);
            }
            this.Task.SetState(LastState);
        }

        private void LastState() {
            this.update_form_callback(this.Task.Name + " : Last state");
            if (level == 0) {
                this.done_callback();
            }
            this.Task.SetTerminated();
        }
    }
}
