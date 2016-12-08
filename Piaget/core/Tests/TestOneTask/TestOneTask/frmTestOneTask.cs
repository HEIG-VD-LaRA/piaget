using System;
using System.Windows.Forms;
using Piaget_Core;
using System.Threading;

namespace TestOneApp {
    public partial class frmTestOneTask : Form {
        private Thread piaget_thread, update_thread;
        private PiagetNG piaget;

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
            this.piaget.AddParallelTask("The task !", new TestOneTask(), 50 * Clock.ms);

            this.piaget_thread = new Thread(this.piaget.Start);
            this.piaget_thread.Start();

            this.update_thread = new Thread(UpdateForm);
            this.update_thread.Start();
        }

        private void UpdateForm() {
            while (true) {
                lblElapsedTime.Text = this.piaget.TheClock.ElapsedTime.ToString();
                Thread.Sleep(400);
            }
        }



    }
}
