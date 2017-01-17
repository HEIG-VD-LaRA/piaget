using Lib4Testing;
using Piaget_Core;
using System;

namespace TestOneApp {

    class SingleTask : WithTasking {

        private TimeMeasurement time_measurement;
        private Action<ErrorValue> update_measure_callback;
        private int n_cycle;

        public SingleTask(Action<ErrorValue> update_measure_callback) {
            this.update_measure_callback = update_measure_callback;
        }

        protected override void Reset() {
            n_cycle = 0;
            time_measurement = new TimeMeasurement(this.Task.SWPeriod / Clock.sec);
            this.Task.SetState(A);
        }

        private void A() {
            update_measure_callback(time_measurement.ErrTimeCheck(10));
            this.Task.SetState(B);
        }

        private void B() {
            this.Task.SetState(C);
        }

        private void C() {
            this.Task.SetState(D);
        }

        private void D() {
            this.Task.SetState(E);
        }

        private void E() {
            this.Task.SetState(F);
        }

        private void F() {
            this.Task.SetState(G);
        }

        private void G() {
            this.Task.SetState(H);
        }

        private void H() {
            this.Task.SetState(I);
        }

        private void I() {
            this.Task.SetState(J);
        }

        private void J() {
            n_cycle++;
            this.Task.SetState(A);
        }
    }
}
