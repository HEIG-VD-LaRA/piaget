using System;
using Piaget_Core;
using System.Threading;

namespace TestClock {
    class TestClock {
        private const long TaskPeriod = 100 * Clock.ms;
        private Clock clock;
        private Thread thread_task_manager; //, thread_time_check;
        private Action<int> update_callback;

        public TestClock(Action<int> update_callback) {
            this.update_callback = update_callback;
            Start();
        }

        public void Start() {
            this.clock = new Clock();

            this.thread_task_manager = new Thread(SimulateTaskManager);
            this.thread_task_manager.Start();
            //this.thread_time_check = new Thread(ElapsedTimeCheck);
            //this.thread_time_check.Start();
        }

        internal void Stop() {
            this.thread_task_manager.Abort();
            //this.thread_time_check.Abort();
            this.clock = null;
        }

        public void SimulateTaskManager() {
            int sleep_time = Clock.ToSoftwareTime(TaskPeriod);
            this.clock.Start();
            while (true) {
                this.clock.IncElapsedTime();
                Thread.Sleep(sleep_time);
                this.update_callback(Clock.ToSoftwareTime(this.clock.ElapsedTime));
            }
        }

        //public void T_Tic_UpdateCallBack() {
        //    this.update_callback(Clock.ToSoftwareTime(this.clock.ElapsedTime));
        //}
    }
}
