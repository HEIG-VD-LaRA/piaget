using System;
using System.Windows.Forms;
using Piaget_Core;

using static System.Environment; // for NewLine
using System.Diagnostics;

namespace DemoApplication {
    public partial class frmDemoApplication : Form {
        private PiagetJB piaget;
        private long timestamp_0;

        public frmDemoApplication() {
            InitializeComponent();
        }
        private void btnGo_Click(object sender, EventArgs e) {
            this.btnGo.Enabled = false;
            this.btnStop.Enabled = true;
            this.tbMessages.Clear();
            timestamp_0 = Stopwatch.GetTimestamp();
            this.piaget = new PiagetJB();
            this.piaget.AddParallelTask("Main task", new MainTask(this.AppendMessage_Callback), 1.0 * Clock.sec);
            this.piaget.Start();
        }
        public void AppendMessage_Callback(string message) {
            
            this.Invoke(() => {
                this.tbMessages.AppendText(Clock.TimeFormat(GetSWTime()) + " : " + message + NewLine);
            });
        }
        private void btnStop_Click(object sender, EventArgs e) {
            this.btnGo.Enabled = true;
            this.btnStop.Enabled = false;
            this.piaget.Stop();
        }
        private long GetSWTime() {
            return Stopwatch.GetTimestamp() - timestamp_0;
        }
    }
}
