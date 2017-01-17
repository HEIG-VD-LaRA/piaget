using System;
using Piaget_Core;
using Yieldable = System.Collections.IEnumerator;

namespace PerformanceTest {
    class YieldInterruptTask : WithTasking {
        private readonly uint N_Cycles;
        private readonly Action done_callback;
        private uint cycles;

        public YieldInterruptTask(uint N_Cycles, Action done_callback) {
            this.N_Cycles = N_Cycles;
            this.done_callback = done_callback;
        }

        protected override void Reset() {
            this.cycles = 1;
            this.Task.SetState(A);
        }
        // This routine is executed in 2 main parts :
        // - 1st: It enters the for loop and is interrupted at every iteration
        // - 2nd: Once the loop is done, execution is resumed right after the loop.
        //        At which point, the current state is set to B.
        private Yieldable A() {
            for (uint i = this.cycles; i < this.N_Cycles - 10; i++) {
                this.cycles++;
                yield return null;
            }
            this.cycles++;
            this.Task.SetState(B);
        }

        // This routine is executed in 2 main parts :
        // - 1st: It is interrupted 3 times with the yield keyword and 1 time by exiting the routine
        // - 2nd: Idem, but at the end, the condition cycles == N_Cycles - 1 becomes true,
        //        then the current state is set to C.
        private Yieldable B() {
            this.cycles++;
            yield return null;
            this.cycles++;
            yield return null;
            this.cycles++;
            yield return null;

            this.cycles++;
            if (this.cycles == this.N_Cycles - 1) {
                this.Task.SetState(C);
            }
        }

        // A last state to show that it is possible to mix Yieldable and regular (void) state routines.
        private void C() {
            this.cycles++;
            this.done_callback();
        }
    }
}
