using System;
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

        static public int ToSleepTime(long piaget_time) {
            return (int)(piaget_time / SystemConfig.SleepTimeIncrement);
        }

        static public double ToRealTime(long piaget_time) {
            return (double)piaget_time / (double)Stopwatch.Frequency;
        }

        enum Units { sec, ms, us, ns };
        static public string TimeFormat(double sw_time) {
            double real_time = sw_time / (double)Clock.sec;
            Units units = Units.sec;
            while (real_time < 1.0) {
                real_time *= 1000.0;
                units++;
            }
            return (Math.Truncate(real_time * 100.0) / 100.0).ToString() + " " + units.ToString();
        }
    }
}
