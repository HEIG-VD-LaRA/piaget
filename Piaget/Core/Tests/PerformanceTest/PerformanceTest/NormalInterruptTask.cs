using System;
using Piaget_Core;

namespace PerformanceTest {
    class NormalInterruptTask : WithTasking {
        private readonly uint N_Cycles;
        private readonly Action done_callback;
        private uint cycles;

        public NormalInterruptTask(uint max_cycles, Action done_callback) {
            this.N_Cycles = max_cycles;
            this.done_callback = done_callback;
        }

        protected override void Reset() {
            this.cycles = 0;
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
