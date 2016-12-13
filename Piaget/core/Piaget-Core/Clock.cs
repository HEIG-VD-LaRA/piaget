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

        private long elapsed_sw_ticks = 0;
        private Stopwatch stopwatch = new Stopwatch();

        static public int ToSleepTime(long piaget_time) {
            return (int)(piaget_time / SystemConfig.SleepTimeIncrement);
        }

        static public long ToPiagetTime(long real_time) {
            return (real_time * Stopwatch.Frequency) / sec;
        }

        static public long ToRealTime(long piaget_time) {
            return (piaget_time * sec) / Stopwatch.Frequency;
        }

        public long ElapsedTime {
            get {
                return ToRealTime(this.elapsed_sw_ticks);
            }
        }

        public void Start() {
            this.stopwatch.Start();
        }

        public long ElapsedSWTime {
            get {
                return this.elapsed_sw_ticks;
            }
        }

        public void UpdateElapsedSWTicks() {
            this.elapsed_sw_ticks = stopwatch.ElapsedTicks;
        }
    }
}
