using System;
using System.Diagnostics;
using System.Threading;
using Piaget_Core.System;

namespace Piaget_Core {
    class Clock {
        
        public const long base_unit_100_ns = 1;
        public const long us = 10 * base_unit_100_ns;
        public const long ms = 1000 * us;
        public const long sec = 1000 * ms;

        private long elapsed_time = 0;
        private long T_tic_minimal;
        private long T_tic;
        private int time_to_sleep;

        private Thread thread;

        static public int ToSoftwareTime(long piaget_time) {
            return (int)(piaget_time / SystemConfig.SoftwareTimeIncrement);
        }

        public Clock() {
            this.thread = new Thread(TticCalculation);
            this.thread.Start();
        }

        public long ElapsedTime {
            get {
                return this.elapsed_time;
            }
        }

        public void IncElapsedTime() {
            this.elapsed_time += T_tic;
        }

        public void SetMinimalTaskPeriod(long minimal_task_period) {
            this.T_tic_minimal = minimal_task_period;
            this.T_tic = minimal_task_period;
            this.time_to_sleep = ToSoftwareTime(Math.Max(UserConfig.Clock_MinSleep, this.T_tic * Config.Clock_Factor));
        }

        private void TticCalculation() {
            long t0, tf; // Unit : us
            long tsys0, tsysf; // Unit : 100 ns

            while (true) {
                t0 = this.elapsed_time;
                tsys0 = DateTime.Now.Ticks;
                Thread.Sleep(this.time_to_sleep);
                tf = this.elapsed_time;
                tsysf = DateTime.Now.Ticks;
                
                T_tic = (this.T_tic * (tsysf - tsys0)) / (tf - t0);
                if (this.T_tic == 0) { // Should happen only when ...
                    this.T_tic = this.T_tic_minimal;
                }
            }
        }
    }
}
