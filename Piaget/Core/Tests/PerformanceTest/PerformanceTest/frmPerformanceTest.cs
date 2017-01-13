﻿using System.Windows.Forms;
using System;
using static System.Environment; // for NewLine

using Piaget_Core;
using Lib4Testing;

namespace PerformanceTest {
    public partial class frmPerformanceTest : Form {
        // Strangely the lower is n_tasks, the higher must be N_cycles, otherwise there is a big error on task time calculation
        private const uint N_Cycles_0 = 500000;
        private uint N_cycles;
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
            this.piaget = new PiagetJB();
            for (int i = 1; i <= n_tasks; i++ ) {
                // We want to make sure that no (or as less as possible) sleep occur as it is a performance test. 
                // Therefore the task cycle is set to 1.0 which corresponds to the resolution of the clock (stopwatch)
                if (this.rbNormal.Checked) {
                    this.piaget.AddParallelTask("Task " + i.ToString(), new NormalInterruptTask(this.N_cycles, Done_Callback), 1.0);
                } else {
                    this.piaget.AddParallelTask("Task " + i.ToString(), new YieldInterruptTask(this.N_cycles, Done_Callback), 1.0);
                }
            }
            this.piaget.Start();
        }

        private void PrepareForOneMoreTask(long elapsed_sw_time) {
            double T_tasks = (double)elapsed_sw_time / (double)this.N_cycles;
            tbMeasures.AppendText("n = " + this.n_tasks.ToString() + " : " + TimeMeasurement.TimeFormat(T_tasks) +
                                  " (" + TimeMeasurement.TimeFormat(T_tasks / this.n_tasks) + " per task execution)" + 
                                  NewLine);
            this.n_tasks++;
            this.N_cycles = N_Cycles_0 / n_tasks;
        }

        private void Done_Callback() {
            long elapsed_sw_time = this.piaget.ElapsedSWTime;
            this.n_done_tasks++;
            if (this.n_done_tasks == this.n_tasks) {
                this.piaget.Stop();
                PrepareForOneMoreTask(elapsed_sw_time);
                Restart();
            }
        }
    }
}
