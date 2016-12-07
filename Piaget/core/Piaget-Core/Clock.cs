using System.Diagnostics;
using System.Threading;
using Piaget_Core.System;

namespace Piaget_Core {
    class Clock {

        public const ulong ps = 1;
        public const ulong ns = 1000 * ps;
        public const ulong us = 1000 * ns;
        public const ulong ms = 1000 * us;
        public const ulong sec = 1000 * ms;

        private ulong elapsed_time = 0;
        private ulong T_tic;
        private int time_to_sleep;

        private PeriodList period_list = new PeriodList();

        private Thread thread;
        private Stopwatch stopWatch = new Stopwatch();

        static public int ToSoftwareTime(long piaget_time) {
            return (int)(piaget_time / SystemConfig.SoftwareTimeIncrement);
        }

        public Clock() {
            this.thread = new Thread(TticCalculation);
            this.thread.Start();
        }

        public ulong ElapsedTime {
            get {
                return this.elapsed_time;
            }
        }

        public void IncElapsedTime() {
            this.elapsed_time += T_tic;
        }

        public void AddPeriodToList(ulong period) {
            period_list.Add(period);
            Reset();
        }

        public void RemovePeriodFromList(ulong period) {
            period_list.Remove(period);
            Reset();
        }

        private void Reset() {
            this.T_tic = period_list.Min();
            this.time_to_sleep = (int)this.T_tic * Config.Clock_Factor;
        }

        private void TticCalculation() {
            ulong t0, tf; // Unit : ps
            
            while (true) {
                t0 = this.elapsed_time;
                stopWatch.Restart();
                Thread.Sleep(this.time_to_sleep);
                tf = this.elapsed_time;
                stopWatch.Stop();
                this.T_tic = (ulong)((double)this.T_tic * stopWatch.Elapsed.TotalMilliseconds * (double)ms / (double)(tf - t0));
                if (this.T_tic == 0) { // Should only happen when or when incorrect parameter
                    Reset();
                }
            }
        }
    }
}
