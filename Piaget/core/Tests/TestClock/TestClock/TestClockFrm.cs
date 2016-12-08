using System;
using System.Diagnostics;
using System.Windows.Forms;



namespace TestClock {
    public partial class TestClockFrm : Form {
        private TestClock test_clock;
        private const long Unitialized = -1000000000000;
        private long real_time_offset = Unitialized;

        public TestClockFrm() {
            InitializeComponent();
            // Easy but unsafe solution for allowing cross-thread operations on the controls of the form
            // This is needed as the callback functions that modify controls of the form are called with a
            // different thread as the thread that created the form. If a safe solution is required, use
            // BackgroundWorker
            Form.CheckForIllegalCrossThreadCalls = false;
            //
        }

        private void btnGo_Click(object sender, EventArgs e) {
            if (btnGo.Text == "Pause") {
                test_clock.Stop();
                this.real_time_offset = Unitialized;
                btnGo.Text = "Go";
            } else {
                lblMesuredTime.Text = "";
                lblRealTime.Text = "";
                this.lblAbsError.Text = "";
                test_clock = new TestClock(FormUpdate_CallBack);
                btnGo.Text = "Pause";
            }
        }

        private void FormUpdate_CallBack(int mesured_time) {
            if (this.real_time_offset == Unitialized) {
                this.real_time_offset = DateTime.Now.Ticks / 10000 - mesured_time;
            }
            int real_time = (int)(DateTime.Now.Ticks / 10000 - this.real_time_offset);
            int abs_error = real_time - mesured_time;
            double rel_error = (double)abs_error / (double)real_time;
            lblMesuredTime.Text = mesured_time.ToString();
            lblRealTime.Text = real_time.ToString();
            this.lblAbsError.Text = abs_error.ToString();
            this.lblRelError.Text = rel_error.ToString();


        }
    }
}
