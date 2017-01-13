using System;
using Piaget_Core;
using Yieldable = System.Collections.IEnumerator;

namespace PerformanceTest {
    class YieldInterruptTask : WithTasking {
        private readonly uint N_Cycles;
        private readonly Action done_callback;
        private uint cycles;

        public YieldInterruptTask(uint max_cycles, Action done_callback) { // max_cycles must be k * 2 !
            this.N_Cycles = max_cycles;
            this.done_callback = done_callback;
        }

        protected override void Reset() {
            this.cycles = 0;
            this.Task.SetState(A);
        }
        private Yieldable A() {
            // The division by 2 is just there to test if A() will be called again after it completed
            // the first half of the cycles and therefore returned without a yield return null statement.
            for (int i = 0; i < this.N_Cycles / 2; i++) {
                this.cycles++;
                yield return null;
            }
            if (this.cycles == this.N_Cycles) {
                this.done_callback();
            }
        }
    }
}
