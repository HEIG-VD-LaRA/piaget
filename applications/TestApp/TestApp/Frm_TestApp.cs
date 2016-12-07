using System;
using System.Windows.Forms;
using Piaget_Core;

namespace TestApp {
    public partial class Frm_TestApp : Form {

        public Frm_TestApp() {
            InitializeComponent();
        }

        private void btnGo_Click(object sender, EventArgs e) {

            PiagetNG piaget = new PiagetNG();
            piaget.AddParallelTask("The FSM", new MyAppTask(), 1 * Clock.ms);
            piaget.Start();
        }
    }
}
