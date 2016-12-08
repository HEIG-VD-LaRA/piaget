
using Piaget_Core.System;

namespace Piaget_Core {
    abstract class WithLoopTask : WithTask {
        protected override void Reset() {
            this.Task.SetState(Main_Loop);
        }
        abstract protected void Main_Loop();
    }
}
