using Piaget_Core;

using System;
using System.Windows.Forms;
using static System.Environment; // for NewLine

namespace TestChildTask {
    public partial class frmTestChildTask : Form {
        private PiagetJB piaget;

        public frmTestChildTask() {
            InitializeComponent();
        }

        private void FormUpdate_Callback(string message) {
            this.Invoke(() => this.tbMessages.AppendText(message + NewLine));
        }

        private void Done_Callback() {
            this.Invoke(() => {
                this.tbMessages.AppendText("---- DONE ----" + NewLine);
                this.btnGo.Text = "Go";
            });
            this.piaget.Stop();
        }

        private void btnGo_Click(object sender, EventArgs e) {
            if (this.btnGo.Text == "Go") {
                this.tbMessages.Clear();
                this.btnGo.Text = "Stop";
                this.piaget = new PiagetJB();
                this.piaget.AddParallelTask("Task level 0",
                                            new SerialTask(0, (int)nbMaxLevel.Value, 
                                                           FormUpdate_Callback, Done_Callback), 
                                            0.5 * Clock.sec);
                this.piaget.Start();
            } else {
                this.btnGo.Text = "Go";
                this.piaget.Stop();
            }
        }
    }
}
