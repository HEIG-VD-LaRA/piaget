using System.Windows.Forms;
using System;

using Piaget_Core;
using Lib4Testing;

namespace PerformanceTest {
    public partial class frmPerformanceTest : Form {
        private const uint N_Cycles = 10000;
        private const long T_Task_Resolution = 1;
        private readonly string NewLine = Environment.NewLine;
        private uint n_tasks;
        private uint n_done_tasks;
        private PiagetJB piaget;

        public frmPerformanceTest() {
            InitializeComponent();
            // Easy but unsafe solution for allowing cross-thread operations on the controls of the form
            // This is needed as the callback functions that modify controls of the form are called with a
            // different thread as the thread that created the form. If a safe solution is required, use
            // BackgroundWorker
            Form.CheckForIllegalCrossThreadCalls = false;
            //
        }

        private void btnGo_Click(object sender, EventArgs e) {
            if (btnGo.Text == "Go") {
                this.n_tasks = 1;
                this.btnGo.Text = "Stop";
                this.tbMeasures.Clear();
                this.rbNormal.Enabled = false;
                this.rbWithYields.Enabled = false;
                Restart();
            } else {
                this.piaget.TerminateAll();
                btnGo.Text = "Go";
                this.rbNormal.Enabled = true;
                this.rbWithYields.Enabled = true;
            }
        }

        private void Restart() {
            this.n_done_tasks = 0;
            this.piaget = new PiagetJB();
            for (int i = 1; i <= n_tasks; i++ ) {
                // We want to make sure that no (or as less as possible) sleep occur as it is a performance test. 
                // Therefore the task cycle is set to 1.0 which corresponds to the resolution of the clock (stopwatch)
                if (this.rbNormal.Checked) {
                    this.piaget.AddParallelTask("Task " + i.ToString(), new NormalInterruptTask(N_Cycles, Done_Callback), 1.0);
                } else {
                    this.piaget.AddParallelTask("Task " + i.ToString(), new YieldInterruptTask(N_Cycles, Done_Callback), 1.0);
                }
            }
            this.piaget.Start();
        }

        private void PrepareForOneMoreTask(long elapsed_sw_time) {
            double T_tasks = (double)elapsed_sw_time / (double)N_Cycles;
            tbMeasures.AppendText("n = " + this.n_tasks.ToString() + " : " + TimeMeasurement.TimeFormat(T_tasks) +
                                  " (" + TimeMeasurement.TimeFormat(T_tasks / this.n_tasks) + " per task execution)" + 
                                  NewLine);
            this.n_tasks++;
        }

        private void Done_Callback() {
            long elapsed_sw_time = this.piaget.Clock.ElapsedSWTime;
            this.n_done_tasks++;
            if (this.n_done_tasks == this.n_tasks) {
                this.piaget.TerminateAll();
                
                PrepareForOneMoreTask(elapsed_sw_time);

                Restart();
            }
        }
    }
}
