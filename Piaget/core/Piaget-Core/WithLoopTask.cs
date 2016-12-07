
using Piaget_Core.System;

namespace Piaget_Core {
    abstract class WithLoopTask : WithTask {
        public override void Reset() {
            this.Task.SetNextState(Main_Loop);
        }
        abstract protected void Main_Loop();
    }
}
