using Piaget_Core;
using System;
using System.Diagnostics;

namespace Lib4Testing {

    class ErrorValue {
        public double ElapsedTime { get; private set; }
        public double Absolute { get; private set; }
        public double Relative { get; private set; }
        public double AbsoluteOnDelta { get; private set; }
        public double RelativeOnDelta { get; private set; }
        private uint N_running_mean;
        private double[] measured_deltas, reference_deltas;
        private uint means_index;
        private double deltas_measured_mean;
        private double deltas_reference_mean;

        public ErrorValue(uint N_running_mean = 16) {
            this.N_running_mean = N_running_mean;
            this.measured_deltas = new double[N_running_mean];
            this.reference_deltas = new double[N_running_mean];
            Array.Clear(measured_deltas, 0, measured_deltas.Length);
            Array.Clear(reference_deltas, 0, reference_deltas.Length);
            this.means_index = 0;
        }

        public void Calculate(double reference_value, double mesured_value) {
            this.ElapsedTime = reference_value;
            this.Absolute = mesured_value - reference_value;
            this.Relative = 1.0 - (double)mesured_value / (double)reference_value;
            RunningMeanCalculation(reference_value, mesured_value);
            this.AbsoluteOnDelta = this.deltas_measured_mean - this.deltas_reference_mean;
            this.RelativeOnDelta = 1.0 - (double)this.deltas_measured_mean / (double)this.deltas_reference_mean;
        }

        private uint Modulo(uint number) {
            return number % this.N_running_mean;
        }

        private void RunningMeanCalculation(double reference_value, double mesured_value) {
            measured_deltas[this.means_index] = mesured_value - measured_deltas[Modulo(this.means_index - 1)];
            reference_deltas[this.means_index] = reference_value - reference_deltas[Modulo(this.means_index - 1)];
            //
            double sum_measured = 0;
            double sum_reference = 0;
            for (int i = 0; i < N_running_mean; i++) {
                sum_measured += measured_deltas[i];
                sum_reference += reference_deltas[i];
            }
            this.deltas_measured_mean = sum_measured / this.N_running_mean;
            this.deltas_reference_mean = sum_reference / this.N_running_mean;
            means_index = Modulo(means_index + 1);
        }
    }

    class TimeMeasurement {
        enum Units { sec, ms, us, ns };
        private ErrorValue time_error;
        private double period;
        private int n_cycles;
        private bool has_started = false;
        private long time_0;

        public TimeMeasurement(double period) {
            time_error = new ErrorValue();
            this.period = period;
        }
        public ErrorValue ErrTimeCheck(int delta_cycles = 1) {
            this.n_cycles += delta_cycles;
            if (!this.has_started) {
                this.has_started = true;
                this.n_cycles = 0;
                time_0 = Stopwatch.GetTimestamp();
            } else {
                time_error.Calculate(reference_value: (double)(Stopwatch.GetTimestamp() - time_0) / (double)Stopwatch.Frequency,
                                     mesured_value: (double)this.n_cycles * period);
            }
            return time_error;
        }

        static public string TimeFormat(long sw_time, uint div_factor = 1) {
            double real_time = (double)sw_time / (double)Clock.sec;
            Units units = Units.sec;
            double dbl_time = (double)real_time/div_factor;
            while (dbl_time < 1.0) {
                dbl_time *= 1000.0;
                units++;
            }
            return (Math.Truncate(dbl_time * 100.0) / 100.0).ToString() + " " + units.ToString();
        }
    }
}
