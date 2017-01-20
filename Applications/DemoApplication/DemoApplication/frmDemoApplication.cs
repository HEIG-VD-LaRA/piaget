using System;
using System.Windows.Forms;
using Piaget_Core;

using static System.Environment; // for NewLine

namespace DemoApplication {
    public partial class frmDemoApplication : Form {
        private Piaget piaget;

        public frmDemoApplication() {
            InitializeComponent();
        }
        private void btnGo_Click(object sender, EventArgs e) {
            this.btnGo.Enabled = false;
            this.btnStop.Enabled = true;
            this.tbMessages.Clear();
            this.piaget = new Piaget(this);
            this.piaget.AddParallelTask("Main task", new MainTask(AppendMessage_Callback), 1.0 * Time.sec);
            this.piaget.Start();
        }
        public void AppendMessage_Callback(string message) {
            this.Invoke(() => {
                this.tbMessages.AppendText(this.piaget.ApplicationElapsedTimeFormatted + " : " + message + NewLine);
            });
        }
        private void btnStop_Click(object sender, EventArgs e) {
            this.btnGo.Enabled = true;
            this.btnStop.Enabled = false;
            this.piaget.Stop();
        }
    }
}
