using System.Diagnostics;

namespace Piaget_Core.Base {
    public class Clock {

        private Stopwatch stopwatch = new Stopwatch();

        public void Start() {
            this.stopwatch.Restart();
        }
        public void Stop() {
            this.stopwatch.Stop();
            this.stopwatch = new Stopwatch(); // This avoids a performance issue when restarting
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
