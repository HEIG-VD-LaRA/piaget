using System;
using System.Windows.Forms;
using Piaget_Core;
using System.Threading;
using Lib4Testing;

namespace TestOneApp {
    public partial class frmTestOneTask : Form {
        private Thread update_thread;
        private Piaget piaget;
        private double elapsed_time_ref;
        private double absolute_error, absolute_delta_error;
        private double relative_error, relative_delta_error;

        public frmTestOneTask() {
            InitializeComponent();
        }

        private void btnGo_Click(object sender, EventArgs e) {
            this.piaget = new Piaget(this);
            this.piaget.AddTask("The task !", new SingleTask(UpdateMeasure), 50.0 * Time.us);
            this.piaget.Start();

            this.update_thread = new Thread(UpdateForm);
            this.update_thread.Start();
        }

        private void frmTestOneTask_FormClosing(object sender, FormClosingEventArgs e) {
            this.piaget.Stop();
            this.update_thread.Abort();
        }

        private void UpdateMeasure(ErrorValue time_error) {
            this.elapsed_time_ref = time_error.ElapsedTime;
            this.absolute_error = time_error.Absolute;
            this.relative_error = time_error.Relative;
            this.absolute_delta_error = time_error.AbsoluteOnDelta;
            this.relative_delta_error = time_error.RelativeOnDelta;
        }

        private void UpdateForm() {
            while (true) {
                this.Invoke(() => {
                    this.lblElapsedTimeRef.Text = Time.Format(this.elapsed_time_ref);
                    this.lblElapsedTime.Text = this.piaget.ApplicationElapsedTimeFormatted;
                    this.lblAbsoluteError.Text = (1000.0 * this.absolute_error).ToString();
                    this.lblRelativeError.Text = (100 * this.relative_error).ToString();
                    this.lblAbsoluteDeltaError.Text = (1000.0 * this.absolute_delta_error).ToString();
                    this.lblRelativeDeltaError.Text = (100 * this.relative_delta_error).ToString();
                } );
                Thread.Sleep(100);
            }
        }
    }
}
