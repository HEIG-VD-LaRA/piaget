using System.Diagnostics;

namespace Piaget_Core.System {
    public class Clock {

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
            return (double)piaget_time / (double)Time.sec;
        }

    }
}
