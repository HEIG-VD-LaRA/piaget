using System;
using System.Diagnostics;
using System.Threading;
using Piaget_Core.System;

namespace Piaget_Core {
    class Clock {

        // With ps as base unit, the system can run during 100 days before overflow on elapsed_time
        public const long ps = 1;
        public const long ns = 1000 * ps;
        public const long us = 1000 * ns;
        public const long ms = 1000 * us;
        public const long sec = 1000 * ms;

        static public readonly long Stopwatch_Period = sec / Stopwatch.Frequency;

        private long elapsed_sw_time = 0;
        private Stopwatch stopwatch = new Stopwatch();

        static public int ToSleepTime(long piaget_time) {
            return (int)(piaget_time / SystemConfig.SleepTimeIncrement);
        }

        static public long ToPiagetTime(long real_time) {
            return (real_time * Stopwatch.Frequency) / sec;
        }

        static public long ToRealTime(long piaget_time) {
            return piaget_time * Stopwatch_Period;
        }

        public long ElapsedTime {
            get {
                return ToRealTime(this.elapsed_sw_time);
            }
        }

        public void Start() {
            this.stopwatch.Start();
        }

        public long ElapsedSWTime {
            get {
                return this.elapsed_sw_time;
            }
        }

        public void UpdateElapsedTime() {
            this.elapsed_sw_time = stopwatch.ElapsedTicks;
        }
    }
}
