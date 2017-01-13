using System;
using Piaget_Core;

namespace PerformanceTest {
    class NormalInterruptTask : WithTasking {
        private readonly uint N_Cycles;
        private readonly Action done_callback;
        private uint cycles;

        public NormalInterruptTask(uint N_Cycles, Action done_callback) {
            this.N_Cycles = N_Cycles;
            this.done_callback = done_callback;
        }

        protected override void Reset() {
            this.cycles = 1;
            this.Task.SetState(A);
        }
        private void A() {
            this.cycles++;
            if (this.cycles == this.N_Cycles) {
                this.done_callback();
            }
        }
    }
}
