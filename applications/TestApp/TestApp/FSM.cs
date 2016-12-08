using Piaget_Core;
using Piaget_Core.System;

namespace TestApp {

    class MyLoopTask : WithLoopTask {
        public int i, j;
        public int a, b, ret;

        /* for (i = 0; i < 2; i++) {
         *    z += a * b;
         *    for (j = 1; j < 3; j++) {
         *      a += j;
         *    }
         *    z -= a + b;
         * } */

        protected override void Main_Loop() {
            if (i == 2) {
                this.Task.SetTerminated();
                return;
            }
            ret += a * b;
            this.Task.SetState(Second_Loop);
        }

        private void Second_Loop() {
            if (j == 3) {
                j = 0;
                this.Task.SetState(End_Main_Loop);
                return;
            }
            a += j;
            j++;
        }

        private void End_Main_Loop() {
            ret -= a * b;
            i++;
            this.Task.SetState(Main_Loop);
        }
    }

    class MyAppTask : WithRegularTask {

        private MyLoopTask my_loop_task;

        public override void Reset() {
            this.Task.SetState(Init);
        }

        private void Init() {
            this.Task.SetState(Start);
        }

        private void Start() {
            my_loop_task = new MyLoopTask {
                i = 0,
                j = 1,
                a = 5,
                b = 7
            };
            this.Task.AddLoopTask("For loops", my_loop_task, 10 * Clock.us);
            this.Task.SetState(Stop);
        }

        private void Stop() {
            this.Task.SetState(Init);
        }
    }
}
