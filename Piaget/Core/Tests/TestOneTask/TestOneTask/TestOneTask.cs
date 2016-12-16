using System.Diagnostics;

using Piaget_Core;

namespace TestOneApp {

    class TestOneTask : WithRegularTask {

        protected override void Reset() {
            this.Task.SetState(Init);
        }

        private void Init() {
            this.Task.SetState(Start);
        }

        private void Start() {
            this.Task.SetState(Stop);
        }

        private void Stop() {
            this.Task.SetState(Init);
        }
    }
}
