using System;
using System.Windows.Forms;
using Piaget_Core;
using System.Threading;
using Lib4Testing;

namespace TestOneApp {
    public partial class frmTestOneTask : Form {
        private Thread piaget_thread, update_thread;
        private PiagetNG piaget;
        private double elapsed_time_ref;
        private double absolute_error, absolute_delta_error;
        private double relative_error, relative_delta_error;

        public frmTestOneTask() {
            InitializeComponent();
            // Easy but unsafe solution for allowing cross-thread operations on the controls of the form
            // This is needed as the callback functions that modify controls of the form are called with a
            // different thread as the thread that created the form. If a safe solution is required, use
            // BackgroundWorker
            Form.CheckForIllegalCrossThreadCalls = false;
            //
        }

        private void btnGo_Click(object sender, EventArgs e) {
            this.piaget = new PiagetNG();
            this.piaget.AddParallelTask("The task !", new TestOneTask(UpdateMeasure), 50.0 * Clock.us);

            this.piaget_thread = new Thread(this.piaget.Start);
            this.piaget_thread.Start();

            this.update_thread = new Thread(UpdateForm);
            this.update_thread.Start();
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
                lblElapsedTimeRef.Text = this.elapsed_time_ref.ToString();
                lblElapsedTime.Text = this.piaget.TheClock.ElapsedTime.ToString();
                lblAbsoluteError.Text = (1000.0 * this.absolute_error).ToString();
                lblRelativeError.Text = (100 * this.relative_error).ToString();
                lblAbsoluteDeltaError.Text = (1000.0 * this.absolute_delta_error).ToString();
                lblRelativeDeltaError.Text = (100 * this.relative_delta_error).ToString();
                Thread.Sleep(100);
            }
        }



    }
}
