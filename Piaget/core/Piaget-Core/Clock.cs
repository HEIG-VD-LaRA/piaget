using System.Diagnostics;

namespace Piaget_Core {
    class Clock {
        
        static public readonly double sec = Stopwatch.Frequency;
        static public readonly double ms = sec / 1000.0;
        static public readonly double us = ms / 1000.0;

        private long elapsed_sw_time = 0;
        private Stopwatch stopwatch = new Stopwatch();

        public void Start() {
            this.stopwatch.Start();
        }

        static public int ToSleepTime(long piaget_time) {
            return (int)(piaget_time / SystemConfig.SleepTimeIncrement);
        }

        static public double ToRealTime(long piaget_time) {
            return (double)piaget_time / (double)Stopwatch.Frequency;
        }

        public double ElapsedTime {
            get {
                return ToRealTime(this.elapsed_sw_time);
            }
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
