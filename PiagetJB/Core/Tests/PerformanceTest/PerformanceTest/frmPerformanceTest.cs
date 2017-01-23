using System.Windows.Forms;
using System;
using static System.Environment; // for NewLine

using Piaget_Core;

namespace PerformanceTest {
    public partial class frmPerformanceTest : Form {
        // Strangely the lower is n_tasks, the higher must be N_cycles, otherwise there is a big error on task time calculation
        private const uint N_Cycles_0 = 500000;
        private uint N_cycles;
        private uint n_tasks;
        private uint n_done_tasks;
        private Piaget piaget;

        public frmPerformanceTest() {
            InitializeComponent();
            this.piaget = new Piaget(this);
        }

        private void btnGo_Click(object sender, EventArgs e) {
            if (btnGo.Text == "Go") {
                this.n_tasks = 1;
                this.N_cycles = N_Cycles_0;
                this.btnGo.Text = "Stop";
                this.tbMeasures.Clear();
                this.rbNormal.Enabled = false;
                this.rbWithYields.Enabled = false;
                Restart();
            } else {
                this.piaget.Stop();
                btnGo.Text = "Go";
                this.rbNormal.Enabled = true;
                this.rbWithYields.Enabled = true;
            }
        }

        private void Restart() {
            this.n_done_tasks = 0;
            for (int i = 1; i <= n_tasks; i++ ) {
                // We want to make sure that no (or as less as possible) sleep occur as it is a performance test. 
                // Therefore the task cycle is set to 1.0 which corresponds to the resolution of the clock (stopwatch)
                if (this.rbNormal.Checked) {
                    this.piaget.AddTask("Task " + i.ToString(), new NormalInterruptTask(this.N_cycles, Done_Callback), 1.0);
                } else {
                    this.piaget.AddTask("Task " + i.ToString(), new YieldInterruptTask(this.N_cycles, Done_Callback), 1.0);
                }
            }
            this.piaget.Start();
        }

        private void PrepareForOneMoreTask(double elapsed_time) {
            double T_tasks = elapsed_time / (double)this.N_cycles;
            this.Invoke(() => {
                tbMeasures.AppendText("n = " + this.n_tasks.ToString() + " : " + Time.Format(T_tasks) +
                                      " (" + Time.Format(T_tasks / this.n_tasks) + " per task execution)" +
                                      NewLine);
            } );
            this.n_tasks++;
            this.N_cycles = N_Cycles_0 / n_tasks;
        }

        private void Done_Callback() {
            double elapsed_time = this.piaget.ApplicationElapsedTime;
            this.n_done_tasks++;
            if (this.n_done_tasks == this.n_tasks) {
                this.Invoke( () => {
                    this.piaget.Stop();
                    PrepareForOneMoreTask(elapsed_time);
                    Restart();
                });
            }
        }
    }
}
