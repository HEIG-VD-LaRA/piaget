using System;
using System.Windows.Forms;
using Piaget_Core;

namespace TestOneApp {
    public partial class frmTestOneTask : Form {

        public frmTestOneTask() {
            InitializeComponent();
        }

        private void btnGo_Click(object sender, EventArgs e) {

            PiagetNG piaget = new PiagetNG();
            piaget.AddParallelTask("The FSM", new TestOneTask(), 1 * Clock.ms);
            piaget.Start();
        }
    }
}
