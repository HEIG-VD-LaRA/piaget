using Piaget_Core;

using System;
using System.Windows.Forms;
using static System.Environment; // for NewLine

namespace TestChildTask {
    public partial class frmTestChildTask : Form {
        private PiagetJB piaget;

        public frmTestChildTask() {
            InitializeComponent();
            // Easy but unsafe solution for allowing cross-thread operations on the controls of the form
            // This is needed as the callback functions that modify controls of the form are called with a
            // different thread as the thread that created the form. If a safe solution is required, use
            // BackgroundWorker
            Form.CheckForIllegalCrossThreadCalls = false;
            //
        }

        private void FormUpdate_Callback(string message) {
            this.tbMessages.AppendText(message + NewLine);
        }

        private void Done_Callback() {
            this.btnGo.Text = "Go";
            this.piaget.Stop();
        }

        private void btnGo_Click(object sender, EventArgs e) {
            if (this.btnGo.Text == "Go") {
                this.tbMessages.Clear();
                this.btnGo.Text = "Stop";
                this.piaget = new PiagetJB();
                this.piaget.AddParallelTask("Task 1",
                                            new SerialTask(1, (int)nbMaxLevel.Value, 
                                                           FormUpdate_Callback, Done_Callback), 
                                            0.1 * Clock.sec);
                this.piaget.Start();
            } else {
                this.btnGo.Text = "Go";
                this.piaget.Stop();
            }
        }
    }
}
