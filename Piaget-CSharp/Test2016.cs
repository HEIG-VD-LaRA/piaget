using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;

//using Galil;
using System.Text.RegularExpressions;

using System.Speech;//**for speak Code 016.02.29
using System.Speech.Synthesis;//**for speak Code 016.02.29


using BC9020;
using System.Threading;

namespace Piaget_CSharp
{
    public partial class Test2016 : Form
    {
        public Test2016()
        {
            InitializeComponent();
        }
        public static class MyGlobals
        {
            public static int check = 0;
            public static string str1 = "";
            public static string str2 = "";
        }


        private void bst_Click(object sender, EventArgs e)
        {
            int a;
            a = int.Parse(tC.Text);


            if (uPanel.Choix[uPanel.NCCalibration].Etat)
                uMouv.P0RobotFutur.ds = uPanel.CalibrationDs; //(*DistancePourCalibration*)
            else uMouv.P0RobotFutur.ds = a;
            uMouv.LancerMouvement(uPanel.tModeDeMouvement.MDMds, uMouv.P0RobotFutur);
            // (*  t *)
        }

        private void bsv_Click(object sender, EventArgs e)
        {
            int a;
            a = int.Parse(tC.Text);

            if (uPanel.Choix[uPanel.NCCalibration].Etat)
                uMouv.P0RobotFutur.ds = -uPanel.CalibrationDs;
            else uMouv.P0RobotFutur.ds = -a;
            uMouv.LancerMouvement(uPanel.tModeDeMouvement.MDMds, uMouv.P0RobotFutur);
            //   (* V *)
        }

        private void bEnterPosition_Click(object sender, EventArgs e)
        {
            int x,y,d;
            x = int.Parse(tX.Text);
            y = int.Parse(tY.Text);
            d = int.Parse(tD.Text);


           uPiaget.SetPositionRobot(x, y, d);
        }

        private void bsg_Click(object sender, EventArgs e)
        {

            float a;
            a = float.Parse(tMAngle.Text);
            if (uPanel.Choix[uPanel.NCCalibration].Etat)
                uMouv.P0RobotFutur.ThetaRobotDegres = uMouv.P0Robot.ThetaRobotDegres + uPanel.CalibrationAngle; //(* 45 div 2 *)
            else
                uMouv.P0RobotFutur.ThetaRobotDegres = (float)(uMouv.P0Robot.ThetaRobotDegres + a); // (* 45 div 2 *)
            uMouv.LancerMouvement(uPanel.tModeDeMouvement.Rot, uMouv.P0RobotFutur);
            //   (* g *)
        }

        private void bsf_Click(object sender, EventArgs e)
        {
            float a;
            a = float.Parse(tMAngle.Text);
            if (uPanel.Choix[uPanel.NCCalibration].Etat)
                uMouv.P0RobotFutur.ThetaRobotDegres = uMouv.P0Robot.ThetaRobotDegres - uPanel.CalibrationAngle;
            else
                uMouv.P0RobotFutur.ThetaRobotDegres = Convert.ToInt32(uMouv.P0Robot.ThetaRobotDegres - a);   //  (* 45 div 2 *)
            uMouv.LancerMouvement(uPanel.tModeDeMouvement.Rot, uMouv.P0RobotFutur);
            //   (* f *)
        }

        private void bExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bClear_Click(object sender, EventArgs e)
        {
            tC.Text = "0";
            tX.Text = "0";
            tY.Text = "0";
            tD.Text = "0";
            tMAngle.Text = "0";
            TSound.Text = "";

        }

        private void bT_Click(object sender, EventArgs e)
        {
            uMouv.P0RobotFutur.RayonTrajectoire = 15; //(* cm; <> DemiEcartRouesExt*);
            if (uPanel.Choix[uPanel.NCCalibration].Etat)
                uMouv.P0RobotFutur.AngleTrajectoire = -uPanel.CalibrationAngle;
            else
                uMouv.P0RobotFutur.AngleTrajectoire = -23;    // (* 45 div 2 *)
            uMouv.LancerMouvement(uPanel.tModeDeMouvement.RotExc, uMouv.P0RobotFutur);
        }

        private void bG_Click(object sender, EventArgs e)
        {
            uMouv.P0RobotFutur.RayonTrajectoire = -15; //(* cm; <> DemiEcartRouesExt*);
            if (uPanel.Choix[uPanel.NCCalibration].Etat)
                uMouv.P0RobotFutur.AngleTrajectoire = +uPanel.CalibrationAngle;
            else
                uMouv.P0RobotFutur.AngleTrajectoire = +23;  //(* 45 div 2 *)
            uMouv.LancerMouvement(uPanel.tModeDeMouvement.RotExc, uMouv.P0RobotFutur);
            //   (* G *)
        }

        private void bV_Click(object sender, EventArgs e)
        {
            uMouv.P0RobotFutur.RayonTrajectoire = -15; //(* cm; <> DemiEcartRouesExt*);
            if (uPanel.Choix[uPanel.NCCalibration].Etat)
                uMouv.P0RobotFutur.AngleTrajectoire = -uPanel.CalibrationAngle;
            else
                uMouv.P0RobotFutur.AngleTrajectoire = -23;   //  (* 45 div 2 *)
            uMouv.LancerMouvement(uPanel.tModeDeMouvement.RotExc, uMouv.P0RobotFutur);
            //   (* V *)
        }

        private void bF_Click(object sender, EventArgs e)
        {
            uMouv.P0RobotFutur.RayonTrajectoire = 15; // (* cm; <> DemiEcartRouesExt*);
            if (uPanel.Choix[uPanel.NCCalibration].Etat)
                uMouv.P0RobotFutur.AngleTrajectoire = uPanel.CalibrationAngle;
            else
                uMouv.P0RobotFutur.AngleTrajectoire = 23; // (* 45 div 2 *)
            uMouv.LancerMouvement(uPanel.tModeDeMouvement.RotExc, uMouv.P0RobotFutur);
            //  (* F *)
        }





        private void bMLeft_Click(object sender, EventArgs e)
        {
            FPiaget t2 = new FPiaget();
            t2.Owner = this;


            int a;
            a = int.Parse(tC.Text);
            if (uPanel.Choix[uPanel.NCCalibration].Etat)
                uMouv.P0RobotFutur.ds = -uPanel.CalibrationDs; //(*DistancePourCalibration*)
            else uMouv.P0RobotFutur.ds = -a;
            uMouv.LancerMouvement(uPanel.tModeDeMouvement.Lat, uMouv.P0RobotFutur);
        }

        private void bMRight_Click(object sender, EventArgs e)
        {
            int a;
            a = int.Parse(tC.Text);
            if (uPanel.Choix[uPanel.NCCalibration].Etat)
                uMouv.P0RobotFutur.ds = uPanel.CalibrationDs; //(*DistancePourCalibration*)
            else uMouv.P0RobotFutur.ds = a;
            uMouv.LancerMouvement(uPanel.tModeDeMouvement.Lat, uMouv.P0RobotFutur);
        }
        SpeechSynthesizer reader = new SpeechSynthesizer();






        private void EnterSound_Click(object sender, EventArgs e)
        {
            if (TSound.Text != "")
            {
                reader.Dispose();
                reader = new SpeechSynthesizer();


                reader.SpeakAsync("I heard " + TSound.Text);

                label4.Text="I heard "+TSound.Text;






            }
            else
            {
                MessageBox.Show("Please enter some text first !!");


            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            MessageBox.Show(label4.Text);
        }

        private void Test2016_Load(object sender, EventArgs e)
        {
            
        }



        
    }
}
