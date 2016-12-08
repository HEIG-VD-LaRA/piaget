using System;
using System.Diagnostics;
using System.Threading;
using Piaget_Core.System;

namespace Piaget_Core {
    class Clock {
        
        // With ps as base unit, the system can run during 100 days before overflow on elapsed_time
        public const long ps = 1;
        public const long us = 1000 * ps;
        public const long ms = 1000 * us;
        public const long sec = 1000 * ms;

        private long T_tick;
        // Should only be modified by the task handler thread in order to avoid multithreading issues
        private long elapsed_time = 0;
        private long ticks = 0;
        //
        private Thread thread;

        public Clock() { }

        static public int ToSoftwareTime(long piaget_time) {
            return (int)(piaget_time / SystemConfig.SoftwareTimeIncrement);
        }

        public void Start() {
            this.thread = new Thread(TticCalculation);
            this.thread.Start();
        }

        public long ElapsedTime {
            get {
                return this.elapsed_time;
            }
        }

        public void IncElapsedTime() {
            this.elapsed_time += T_tick;
            this.ticks++;
        }

        public void AddSleepToElapsedTime(long sleep_time) {
            this.elapsed_time += sleep_time;
        }

        private void TticCalculation() {
            long t0, tf; // Unit : us
            long systick0, systickf;
            long tick0, tickf;
            long delta_realtime;

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            while (true) {
                if (this.T_tick == 0) this.T_tick = 1;
                t0 = this.elapsed_time;
                tick0 = this.ticks;
                systick0 = stopwatch.ElapsedTicks;
                do {
                    Thread.Sleep(Config.Clock_SleepInMilliseconds);
                    tf = this.elapsed_time;
                    tickf = this.ticks;
                    systickf = stopwatch.ElapsedTicks;
                } while (tickf - tick0 < Config.Clock_DeltaTicksToResume);
                delta_realtime = ((systickf - systick0) * sec) / Stopwatch.Frequency;
                this.T_tick = (this.T_tick * delta_realtime) / (tf - t0);
            }
        }
    }
}
