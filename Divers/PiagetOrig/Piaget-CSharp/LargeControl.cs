using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Piaget_CSharp
{
    public partial class LargeControl : Form
    {
        public LargeControl()
        {
            InitializeComponent();
        }

       

        private void bRUp_LC_Click(object sender, EventArgs e)
        {

            uPanel.CarLu = 't';
        }

        private void LargeControl_Load(object sender, EventArgs e)
        {

        }

        private void bRFR_LC_Click(object sender, EventArgs e)
        {
            uPanel.CarLu = 'G';
            uPanel.OPDeplacementCrabeX += 10;     // cm
            uPanel.OPDeplacementCrabeY += 10;     // cm
        }

        private void bRFL_LC_Click(object sender, EventArgs e)
        {
            uPanel.CarLu = 'T';
            uPanel.OPDeplacementCrabeX -= 10;     // cm
            uPanel.OPDeplacementCrabeY += 10;     // cm
        }

        private void bRTL_LC_Click(object sender, EventArgs e)
        {
            uPanel.CarLu = 'f';
        }

        private void bRTR_LC_Click(object sender, EventArgs e)
        {
            uPanel.CarLu = 'g';
        }

        private void bRBL_LC_Click(object sender, EventArgs e)
        {
            uPanel.CarLu = 'F';
        }

        private void bRDown_LC_Click(object sender, EventArgs e)
        {
            uPanel.CarLu = 'v';
        }

        private void bRBR_LC_Click(object sender, EventArgs e)
        {
            uPanel.CarLu = 'V';
        }
    }
}
