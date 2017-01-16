using System.Diagnostics;

namespace Piaget_Core {
    public class Clock {
        
        static public readonly double sec = Stopwatch.Frequency;
        static public readonly double ms = sec / 1000.0;
        static public readonly double us = ms / 1000.0;
        
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
                return ToRealTime(this.ElapsedSWTime);
            }
        }

        public long ElapsedSWTime {
            get {
                return stopwatch.ElapsedTicks;
            }
        }
    }
}
