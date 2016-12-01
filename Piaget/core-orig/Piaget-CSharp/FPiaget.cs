//#define SimulationOnly
#undef SimulationOnly

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;
//using Galil;
using System.Text.RegularExpressions;

using BC9020;
using LaRA_manip27;
using System.Threading;


using System.Speech;            //for speak Code 016.02.29
using System.Speech.Synthesis;  //for speak Code 016.02.29


namespace Piaget_CSharp 

    //Copyright HESSO.HEIG-VD.iAi.LaRA 1998, 2009-, JD Dessimoz 14.7.2009, Yverdon-les-Bains
    // Western Switzerland University of Applied Sciences
{  
 
     public enum mmlogic { mtrue, mfalse }

     public partial class FPiaget : Form
 {
     public MJPEGStream videoSourceTr, videoSourceClr;
     Bitmap img;
     public static int GalilCode; 
         public static DialogResult result;
        uPiaget uPiaget1 = new uPiaget();

        System.Windows.Forms.Timer MyTimer = new System.Windows.Forms.Timer();
//         Timer MyTimer = new Timer();
        DateTime now = DateTime.Now;

        ConfigReadWrite ConfigReadWrite1 = new ConfigReadWrite();
   //     FPiaget FPiaget1 = new FPiaget(); // temp

        Task01 Task01i = new Task01();
        Task02 Task02i = new Task02();
        Task03 Task03i = new Task03();
        Task04 Task04i = new Task04();
     //   Task05 Task05i = new Task05(); //***
        Task06 Task06i = new Task06();
    //   Task07 Task07i = new Task07(); //***
        Task08 Task08i = new Task08();
        Task12 Task12i = new Task12();

        Task21 Task21i = new Task21();


        //=====GLOBAL VARIABLE==============================================================
        public static class MyGlobals
        {
            public static int check = 0;
            public static string str1 = "";
            public static string str2 = ""; 
        }
 
      public  FPiaget()
        {
            InitializeComponent();
         
        }





        void Routine( int a) {
            a += 1;
        
        }
        void Routinev(ref int a)
        {
            a += 1;

        }
        public void Tests()
        {
            long TicksTemp;
// lecture des paramètres
            TicksTemp = Properties.Settings.Default.sTicksPerSecond;        
// écriture des paramètres (dans l'application)
             Properties.Settings.Default.sTicksPerSecond = TicksTemp+1;
// sauvetage du fichier
             Properties.Settings.Default.Save();


          int b = 0;

            Routine(b);  //should return 0
            //       Routine(ref b);  //should return 0
            Routinev(ref b); //should return 1
            //      Routinev( b); //should return 1

            pTable.Visible = true;
            pTable.Tag = "Table";
        //    pTable.BeginInvoke();
            pTable.BackColor=System.Drawing.Color.Blue;
            pTable.Update();

//OK       pRobot.Visible = true;
            //OK        pRobot.Tag = "Robot";
            //OK           pRobot.BackColor = System.Drawing.Color.Lime;
            //OK          System.Drawing.Point loc = new System.Drawing.Point(12, 20);
            //OK         System.Drawing.Size siz = new System.Drawing.Size(30, 30);
            //           pRobot.Size.Width = 30;
            //OK       pRobot.Size = siz;
            //       pRobot.Location.X = 30;
            //        pRobot.Location = System.Drawing.Point(12, 20);
            //OK       pRobot.Location = loc;
            //OK       pRobot.Update();

     // OK       bSimulation.BackColor = System.Drawing.Color.Lime;

            int[] intArray;
            intArray = new int[100];








    // OK         tBMemo1.Text = uPanel.Message;
#if SimulationOnly
    //        if (FPiaget.ActiveForm != null)
     //           FPiaget.ActiveForm.Controls["tBMouvement"].Text = "configuration de compilation \"SimulationOnly\"";// dans project build configuration
     //   tBMouvement.Text = "configuration de compilation \"SimulationOnly\"";// dans project build configuration
            tBUser.Text = "configuration de compilation \"SimulationOnly\"";// dans project build configuration

#elif DEBUG
            FPiaget.ActiveForm.Controls["tBMouvement"].Text = "configuration decompilation \"Debug\"";
#else
        FPiaget.ActiveForm.Controls["tBMouvement"].Text = "configuration decompilation \"Release\"";
#endif

        }  // end void Tests
        void BouclePrincipale(bool Done)
        {
          //  Tests();// temporary

            if (!uPanel.Initialise)
            {
                uPiaget1.Initialiser();
                uPanel.Initialise = true;
            }

            while(!uPanel.InteractionSouhaitee)
           {
               uMTasks.SysTicksOld = uMTasks.SysTicks;
               uMTasks.SysTicks = System.DateTime.Now.Ticks;
               uPanel.Ticks += 1;
               
               Task01i.Task01c();
               Task02i.Task02c(); // Faire un pas  move a little bit
               Task03i.Task03c(); // Lire clavier  read keyboard
               Task04i.Task04c(); // Mouvements PTP move point to point
               //Task05i.Task05c(); // Stratégie
               uPiaget1.Task05c(); // Stratégie  //***
               Task06i.Task06c(); // Entrées / Sortie  IO
               Task07c(); // Affichage         Display  //***
               Task08i.Task08c();// Mouvements spatiaux  special movement for computing position of the robot
               
               Task12i.Task12c();
               
                Task21i.Task21c(); // Map Manager ... encore vide


            if ((uPanel.Ticks % 1000000) == 0)uPanel.InteractionSouhaitee = true;
                            
  

            }//end while
        
        Done=false;
        uPanel.InteractionSouhaitee = false;
    }// end of void BouclePrincipale
//------------------

/*
void __fastcall TForm1::BouclePrincipale(TObject *Sender, bool &Done)
{



  //ChatForm->RemoteOn=false;



  //Open ExSapi
 // ofstream ExSapi;
//  ExSapi.open("\\Sound\\ExSapi.exe");


  //ifstream is;
  //is.open ("D:\\Etudiant\\KaiChen\\voicein.txt", ifstream::binary);

 }



  //clean up the file
  ofstream outfile;
  outfile.open (fileVoiceIn, ofstream::binary);
  outfile.close ();

  is.open (fileVoiceIn, ifstream::in);

  InitHelloString() ;

  FrmT2S->String2File("Hello") ;
  btLoadMapClick(Form1);
}
*/
    
       
     
        private void FPiaget_Idle(object sender, System.EventArgs e)
        {
            bool Done = true;
            //tBMemo1.Text = "Hello";
            BouclePrincipale(Done);
        }
       
        private void BQuit_Click(object sender, EventArgs e)
        {  // //exit(0);
            // CarLu='q';
            uPanel.InteractionSouhaitee = false;
            #if (!SimulationOnly)
            if (uPanel.Choix[uPanel.NCSimulation].Etat == false) uGalil.CouperPuissanceGalil();
            #endif
            Close();
        }

        private void FPiaget_Activated(object sender, EventArgs e)
        {
            BouclePrincipale(true);   // Done = true or false
        }

        private void FPiaget_Shown(object sender, EventArgs e)
        {
            BouclePrincipale(true);
            
        }

        private void FPiaget_Load(object sender, EventArgs e)
        {
            Application.Idle += new EventHandler(FPiaget_Idle);
            ConfigReadWrite1.WriteToCfg();
            ConfigReadWrite1.ReadFromCfg();
            TrialBox1.Text = ConfigReadWrite1.line;

            
            MyTimer.Interval = 30;//100 ms par defaut 
            MyTimer.Tick += new EventHandler(MyTimer_Tick);
            MyTimer.Start();

           // testlabel.Visible = false;


            SpeechSynthesizer reader = new SpeechSynthesizer();//**for speak Code 016.02.29
            reader.Dispose();
            reader = new SpeechSynthesizer();
            reader.SpeakAsync("Hello,I am ready !");
            //testlabel.Text = "Hello,I am ready !";
            
        }

        private void bReset_Click(object sender, EventArgs e)
        {


            SpeechSynthesizer reader = new SpeechSynthesizer();//**for speak Code 016.05.30
            reader.Dispose();
            reader = new SpeechSynthesizer();
            reader.SpeakAsync("Reset!");
            
            
            uPiaget1.Initialiser();
          //  if (FPiaget.ActiveForm != null)
               FPiaget.ActiveForm.Activate();

            /*-*
            CarLu = 'r';
            UpdateColorButtonsModeTestRAH();
            SayString("Reset");
             *-*/
        }

        private void bUp_Click(object sender, EventArgs e)
        {
            uPanel.OffsetLignesTaches--;
            if (uPanel.OffsetLignesTaches < 0) uPanel.OffsetLignesTaches = 0;
            
        }

        private void bDown_Click(object sender, EventArgs e)
        {
            uPanel.OffsetLignesTaches++;
            if (uPanel.OffsetLignesTaches > (uMTasks.NTasks - uPanel.NLignesVisibles))
                uPanel.OffsetLignesTaches = uMTasks.NTasks - uPanel.NLignesVisibles;
        }
        //---------------------------------------------------------------------------
        // vérifie l'état Choix[NCSimulation] afin de fixer l'etat de SupportPhysiqueES
        // et dans ce cas, modifier Choix[NCSimulation].etat .
        public static void CheckSupportPhysiqueES()
        {       //DialogResult result;
            
        uPiaget.WriteOnCheckBoard("FPiaget.CheckSupportPhysiqueES");

        if (!uPanel.Choix[uPanel.NCSimulation].Etat)
        {// if_01
            //  tBUser.Text="Connections Ethernet (E/S) + Alim Branchées !? ?";
            //    if (MessageDlg("Connections Ethernet (E/S) + Alim Branchées !? ?", mtWarning, TMsgDlgButtons() << mbNo << mbYes, 0) == mrNo)
            //
            //pop up msg box and return value

            /*
             * Problème avec le MessageBox. Il nous renvoie toujours au début de la méthode
             */
            result = MessageBox.Show("Connections Ethernet (E/S) + Alim Branchées !? ? ", "Are you sure?", MessageBoxButtons.YesNo);

            if (result != DialogResult.Yes)
            {
                //  http://blogs.techrepublic.com.com/howdoi/?p=161
                uPanel.SupportPhysiqueES = false;
                uPanel.Choix[uPanel.NCSimulation].Etat = true;

            }
            else
            {
                uPanel.SupportPhysiqueES = true;
                uPanel.Choix[uPanel.NCSimulation].Etat = false;
#if (!SimulationOnly)
                    if (uPanel.Choix[uPanel.NCGalil].Etat) uGalil.InitialiserGalil();// InitialiserGalil();

                    if (uPanel.ChoixGalilFront)            uGalil.InitialiserGalilFront();// InitialiserGalilFront();

                    if (uPanel.ChoixGalilBack)             uGalil.InitialiserGalilBack();// InitialiserGalilBack();
                    
#endif

            }
        }
        else
        {
            uPanel.SupportPhysiqueES = false;
        }
            /// end_if_01
               
            FPiaget.ToggleSupportPhysique();
        } /// end of CheckSupportPhysique QM
   
         
        //---------------------------------------------------------------------------
        // initialise ou coupe la communication avec les E/S en fct de SupportPhysiqueES
        public static void ToggleSupportPhysique()
        {
            if (uPanel.SupportPhysiqueES)
            {
                if (uPanel.Choix[uPanel.NCBeckhoff].Etat)
                    uPanel.BeckhoffEnLigne = true;
                else
                    uPanel.BeckhoffEnLigne = false;
            }
            else
                uPanel.BeckhoffEnLigne = false;
        }  // end of ToggleSupportPhysique

        private void bSimulation_Click(object sender, EventArgs e)
        {   
#if (!SimulationOnly)
            if (uPanel.Choix[uPanel.NCSimulation].Etat == false && uPanel.Choix[uPanel.NCGalil].Etat) uGalil.CouperPuissanceGalil();
           
#endif
            uPanel.Choix[uPanel.NCSimulation].Etat = !uPanel.Choix[uPanel.NCSimulation].Etat;
            CheckSupportPhysiqueES();
#if (!SimulationOnly)
            if (uPanel.Choix[uPanel.NCSimulation].Etat == false && uPanel.Choix[uPanel.NCGalil].Etat)
            {
               uGalil.CheckConnectionGalil();   
                
            }
#endif
            /*
            if (bGalilM27.BackColor == System.Drawing.Color.Lime)
                bGalilM27.BackColor = System.Drawing.Color.Fuchsia;
            else if (bGalilM27.BackColor == System.Drawing.Color.Fuchsia)
                bGalilM27.BackColor = System.Drawing.Color.Lime;
            */

        }

        private void button2_Click(object sender, EventArgs e)
        {
            uPiaget.ToggleEtatSI(4);

        }

        private void bSI1_Click(object sender, EventArgs e)
        {
            uPiaget.ToggleEtatSI(1);
        }

        private void bSI2_Click(object sender, EventArgs e)
        {
            uPiaget.ToggleEtatSI(2);

        }

        private void bSI3_Click(object sender, EventArgs e)
        {
            uPiaget.ToggleEtatSI(3);
        }
        //---------------------------------------------------------------------------
        void ToggleEtatSAIn(int NS)
        {
            int NS2;
            float incr, min, max;
            min = 0;
            incr = 15;
            max = 300;
            NS2 = uPanel.NSignauxBoolIn + NS;
            if (NS == 5)  // batterie?
            {
                incr = 1;
                min = 22;
                max = 27;
             //   NS2 = uPanel.CaptUSBD;
            }

            if (!uPanel.SignauxIn[NS].actif) uPanel.SignauxIn[NS].actif = true;  //EHe 015.04.13
            else uPanel.SignauxIn[NS].actif = false;

            if (!uPanel.SignauxIn[NS2].actif)
            {
                uPanel.SignauxIn[NS2].actif = true;
                uPanel.SignauxIn[NS2].valeur = min;
            }
            else
                uPanel.SignauxIn[NS2].valeur = uPanel.SignauxIn[NS2].valeur + incr;
            if (uPanel.SignauxIn[NS2].valeur > max)
            {
                uPanel.SignauxIn[NS2].actif = false;
                uPanel.SignauxIn[NS2].valeur = min;
            }
        }
        //---------------------------------------------------------------------------
        private void bAIn4_Click(object sender, EventArgs e)
        {
            ToggleEtatSAIn(11);
        }  
        
         private void bAIn1_Click(object sender, EventArgs e)
         {
             ToggleEtatSAIn(6);  // --> bSI6
         }

         private void bAIn2_Click(object sender, EventArgs e)
         {
             ToggleEtatSAIn(7);
         }

         private void bAIn3_Click(object sender, EventArgs e)
         {
             ToggleEtatSAIn(8);
         }

         private void bAIn5_Click(object sender, EventArgs e)
         {
             ToggleEtatSAIn(12);

         }
         //---------------------------------------------------------------------------
         void ComplementerSO(int NS)
         {
         // ***    DemandeRefreshSortie = true;
             uPanel.SignauxOut[NS].EtatVF = !uPanel.SignauxOut[NS].EtatVF;

/*
             if (uPanel.SignauxOut[4].EtatVF)
             { uPanel.SignauxOut[4].EtatVF = false; }
             else
             { uPanel.SignauxOut[4].EtatVF = true; }

             uPanel.SignauxOut[16].EtatVF = uPanel.SignauxOut[2].EtatVF;

             uPanel.DemandeRefreshSortie = true;
*/

         }

         private void bSO1_Click(object sender, EventArgs e)
         {
             ComplementerSO(1);
             uPanel.SignauxOut[15].EtatVF = uPanel.SignauxOut[1].EtatVF;
             /* extrait version c++
              * ComplementerSO(1);
              * SignauxOut[15].EtatVF=SignauxOut[1].EtatVF;
              */
         }

         private void bSO2_Click(object sender, EventArgs e)
         {
             //ComplementerSO(2);
             if (uPanel.SignauxOut[2].EtatVF)          //traiter la 2 et copier pour 16
              uPanel.SignauxOut[2].EtatVF = false; 
             else
              uPanel.SignauxOut[2].EtatVF = true; 

             uPanel.SignauxOut[16].EtatVF = uPanel.SignauxOut[2].EtatVF;
             
             uPanel.DemandeRefreshSortie = true;

             /* extrait c++
              if (SignauxOut[2].EtatVF)          //traiter la 2 et copier pour 16
   { SignauxOut[2].EtatVF=false;}
   else
   { SignauxOut[2].EtatVF=true;}

   SignauxOut[16].EtatVF=SignauxOut[2].EtatVF;


  DemandeRefreshSortie = true ;
              */
         }

         private void bSO3_Click(object sender, EventArgs e)
         {
             //ComplementerSO(3);
             if (uPanel.SignauxOut[3].EtatVF)
             { uPanel.SignauxOut[3].EtatVF = false; }
             else
             { uPanel.SignauxOut[3].EtatVF = true; }

             uPanel.SignauxOut[16].EtatVF = uPanel.SignauxOut[2].EtatVF;

             uPanel.DemandeRefreshSortie = true;

             /*
              if (SignauxOut[3].EtatVF)
   { SignauxOut[3].EtatVF=false;}
   else
   { SignauxOut[3].EtatVF=true;}

   SignauxOut[16].EtatVF=SignauxOut[2].EtatVF;

  DemandeRefreshSortie = true ;
              */
         }

         private void bSO4_Click(object sender, EventArgs e)
         {
             //ComplementerSO(4);
             if (uPanel.SignauxOut[4].EtatVF)
             { uPanel.SignauxOut[4].EtatVF = false; }
             else
             { uPanel.SignauxOut[4].EtatVF = true; }

             uPanel.SignauxOut[16].EtatVF = uPanel.SignauxOut[2].EtatVF;

             uPanel.DemandeRefreshSortie = true;
         }

         private void bAOut1_Click(object sender, EventArgs e)
         {
             // ComplementerSO(5);   // Moteur Milieu Ciel
             if (uPanel.SignauxOut[5].EtatVF)
                { uPanel.SignauxOut[5].EtatVF = false; }
             else
                { uPanel.SignauxOut[5].EtatVF = true; }

             uPanel.DemandeRefreshSortie = true;
             
             /*
              // ComplementerSO(5);   // Moteur Milieu Ciel
  if (SignauxOut[5].EtatVF)
   { SignauxOut[5].EtatVF=false;}
   else
   { SignauxOut[5].EtatVF=true;}

  DemandeRefreshSortie = true ;
              */
         }

         private void bSI5_Click(object sender, EventArgs e)
         {
             uPiaget.ToggleEtatSI(5);
         }

         private void bSI9_Click(object sender, EventArgs e)
         {
             uPiaget.ToggleEtatSI(9);
         }

         private void bSI10_Click(object sender, EventArgs e)
         {
             uPiaget.ToggleEtatSI(10);
         }

         private void bSI13_Click(object sender, EventArgs e)
         {
             uPiaget.ToggleEtatSI(13);
         }

         private void bSI14_Click(object sender, EventArgs e)
         {
             uPiaget.ToggleEtatSI(14);
         }

         private void bSI15_Click(object sender, EventArgs e)
         {
             uPiaget.ToggleEtatSI(15);
         }

         private void bVisionContinue_Click(object sender, EventArgs e)
         {
             uPanel.Choix[uPanel.NCVisionContinue].Etat = !uPanel.Choix[uPanel.NCVisionContinue].Etat;

         }

         private void bModeTest_Click(object sender, EventArgs e)
         {
             uPanel.ModeTest = !uPanel.ModeTest;
             if (!uPanel.ModeTest)
                 uMTasks.Work[5].StateNo = 1;
             else
             {
                 uMTasks.Work[5].StateNo = 900;
             }

         }

         private void bCalibration_Click(object sender, EventArgs e)
         {
             uPanel.Choix[uPanel.NCCalibration].Etat = !uPanel.Choix[uPanel.NCCalibration].Etat;

             if (!uPanel.Choix[uPanel.NCCalibration].Etat)
             { bCalibration.BackColor = System.Drawing.Color.Red; }
             else
             { bCalibration.BackColor = System.Drawing.Color.Lime; }

             bFine.BackColor = System.Drawing.Color.Red;
             uPanel.CalibrationAngle = 90;
             uPanel.CalibrationDs = 150;

         }

         private void bFine_Click(object sender, EventArgs e)
         {
             if (bFine.BackColor == System.Drawing.Color.Lime)
             {
                 bFine.BackColor = System.Drawing.Color.Red;
                 uPanel.CalibrationAngle = 90;
                 uPanel.CalibrationDs = 150;
                 uPanel.Choix[uPanel.NCCalibration].Etat = false;
                 bCalibration.BackColor = System.Drawing.Color.Red;
             }
             else
             {
                 bFine.BackColor = System.Drawing.Color.Lime;
                 uPanel.CalibrationAngle = 2;
                 uPanel.CalibrationDs = 1;
                 uPanel.Choix[uPanel.NCCalibration].Etat = true;
                 bCalibration.BackColor = System.Drawing.Color.Lime;
             }

         }

         private void bBeckhoff_Click(object sender, EventArgs e)
         {
             uPanel.Choix[uPanel.NCBeckhoff].Etat = !uPanel.Choix[uPanel.NCBeckhoff].Etat;
             ToggleSupportPhysique();
         }

         private void bCamera_Click(object sender, EventArgs e)
         {
             uPanel.Choix[uPanel.NCCamera].Etat = !uPanel.Choix[uPanel.NCCamera].Etat;
         }

         private void bModeNewLaser_Click(object sender, EventArgs e)
         {
             uPanel.ModeNewLaser = !uPanel.ModeNewLaser;
             //  if(PModeNewLaser->Color != clLime)
             if (uPanel.ModeNewLaser)
                 bModeNewLaser.BackColor = System.Drawing.Color.Lime;
             else
                 bModeNewLaser.BackColor = System.Drawing.Color.Red;
         }

         private void bLaserA_Click(object sender, EventArgs e)
         {
             uPanel.ChoixLaserA = !uPanel.ChoixLaserA;
             if (uPanel.ChoixLaserA)
             {
                 if (uPanel.Choix[uPanel.NCSimulation].Etat)
                     bLaserA.BackColor = System.Drawing.Color.Fuchsia;
                 else
                     bLaserA.BackColor = System.Drawing.Color.Lime;
             }
             else
                 bLaserA.BackColor = System.Drawing.Color.Red;
         }

         private void bLaserB_Click(object sender, EventArgs e)
         {
             uPanel.ChoixLaserB = !uPanel.ChoixLaserB;
             if (uPanel.ChoixLaserB)
             {
                 if (uPanel.Choix[uPanel.NCSimulation].Etat)
                     bLaserB.BackColor = System.Drawing.Color.Fuchsia;
                 else
                     bLaserB.BackColor = System.Drawing.Color.Lime;
             }
             else
                 bLaserB.BackColor = System.Drawing.Color.Red;
         }

         private void bLaserC_Click(object sender, EventArgs e)
         {
             uPanel.ChoixLaserC = !uPanel.ChoixLaserC;
             if (uPanel.ChoixLaserC)
             {
                 if (uPanel.Choix[uPanel.NCSimulation].Etat)
                     bLaserC.BackColor = System.Drawing.Color.Fuchsia;
                 else
                     bLaserC.BackColor = System.Drawing.Color.Lime;
             }
             else
                 bLaserC.BackColor = System.Drawing.Color.Red;
         }

         private void bShoulder_Click(object sender, EventArgs e)
         {
             uPanel.Choix[uPanel.NCShoulder].Etat = !uPanel.Choix[uPanel.NCShoulder].Etat;
         }

         private void bHand_Click(object sender, EventArgs e)
         {
             uPanel.Choix[uPanel.NCHand].Etat = !uPanel.Choix[uPanel.NCHand].Etat;
         }

         private void bGalil_Click(object sender, EventArgs e)
         {

             bGalilM27.BackColor = System.Drawing.Color.Red;
          //   bGalil.BackColor = System.Drawing.Color.Red;
             bGalilFront.BackColor = System.Drawing.Color.Red;  
             bGalilBack.BackColor = System.Drawing.Color.Red;


             uPanel.Choix[uPanel.NCGalil].Etat = !uPanel.Choix[uPanel.NCGalil].Etat;
             uPanel.Choix[uPanel.NCGalilM27].Etat = false; // Code 016
             uPanel.ChoixGalilFront = false;
             uPanel.ChoixGalilBack = false;
             label8.Text = "Galil 2W";

             if (bGalil.BackColor == System.Drawing.Color.Lime)
             {
                 /*bFine.BackColor = System.Drawing.Color.Red;
                 uPanel.CalibrationAngle = 90;
                 uPanel.CalibrationDs = 150;
                 uPanel.Choix[uPanel.NCCalibration].Etat = false;
                 bCalibration.BackColor = System.Drawing.Color.Red;*/


                 label8.Text = "";

                 // Properties.Settings.Default["sGalil_W2"] = 0;


             }
             else if (bGalil.BackColor == System.Drawing.Color.Red)
             {
                 label8.Text = "Galil 2W";
                 //label8.Text = "";

                 //   Properties.Settings.Default["sGalil_W2"] = 1;

             }

             else
             {
                 //label8.Text = "Galil 2W";
                 label8.Text = "";

                 /* bFine.BackColor = System.Drawing.Color.Lime;
                  uPanel.CalibrationAngle = 2;
                  uPanel.CalibrationDs = 1;
                  uPanel.Choix[uPanel.NCCalibration].Etat = true;
                  bCalibration.BackColor = System.Drawing.Color.Lime;*/

                 //  Properties.Settings.Default["sGalil_W2"] = 2;


             }

         }

         private void bGalilFront_Click(object sender, EventArgs e)
         {
           //  uPanel.Choix[uPanel.NCGalilFront].Etat = !uPanel.Choix[uPanel.NCGalilFront].Etat; // Code & JD 016.05.11 



             uPanel.ChoixGalilFront = !uPanel.ChoixGalilFront;

             uPanel.Choix[uPanel.NCGalil].Etat = false;     // Code 016
             uPanel.Choix[uPanel.NCGalilM27].Etat = false;
             uPanel.ChoixGalilBack = false;


             if (uPanel.ChoixGalilFront)
             {
                 if (uPanel.Choix[uPanel.NCSimulation].Etat)
                     bGalilFront.BackColor = System.Drawing.Color.Fuchsia;
                 else
                     bGalilFront.BackColor = System.Drawing.Color.Lime;
             }
             else
             {
                 bGalilFront.BackColor = System.Drawing.Color.Red;
             }
             label8.Text = "Galil Front";

             if (bGalilFront.BackColor == System.Drawing.Color.Red)
                 label8.Text = "";


        }

         private void bGalilBack_Click(object sender, EventArgs e)
         {


             
             uPanel.ChoixGalilBack = !uPanel.ChoixGalilBack;
             uPanel.Choix[uPanel.NCGalil].Etat = false;             // Code 016
             uPanel.Choix[uPanel.NCGalilM27].Etat = false;
             uPanel.ChoixGalilFront = false;


             if (uPanel.ChoixGalilBack)
             {
                 if (uPanel.Choix[uPanel.NCSimulation].Etat)
                     bGalilBack.BackColor = System.Drawing.Color.Fuchsia;
                 else
                     bGalilBack.BackColor = System.Drawing.Color.Lime;
             }
             else
             {
                 bGalilBack.BackColor = System.Drawing.Color.Red;

             }
             label8.Text = "Galil Back";
             if (bGalilBack.BackColor == System.Drawing.Color.Red)
             {
                 label8.Text = "";

             }
         }

         private void bImage1_Click(object sender, EventArgs e)
         {
             uPanel.SimulationImageNumber = 1;
         }

         private void button1_Click(object sender, EventArgs e)
         {
             uPanel.SimulationImageNumber = 2;
         }

         private void bImage3_Click(object sender, EventArgs e)
         {
             uPanel.SimulationImageNumber = 3;
         }

         private void bImage4_Click(object sender, EventArgs e)
         {
             uPanel.SimulationImageNumber = 4;
         }

         private void bImage5_Click(object sender, EventArgs e)
         {
             uPanel.SimulationImageNumber = 5;
         }

         private void bRHYControllerNumber_Click(object sender, EventArgs e)
         {
             int n = Convert.ToInt16(bRHYControllerNumber.Text) ;//bRHYControllerNumber
             n++;
             if (n > 3) n = 1;
             uGalil.GalilRHYControllerNumber = n;
             bRHYControllerNumber.Text = n.ToString();
         }

        private void bOPYControllerFront_Click(object sender, EventArgs e)
         {
             int n = Convert.ToInt16(bOPYControllerFront.Text);
            n++;
             if (n > 3) n = 1;
             uGalil.GalilOPYControllerFrontNumber = n;
             bOPYControllerFront.Text = n.ToString();
         }

        private void bOPYControllerBack_Click(object sender, EventArgs e)
        {
            int n = Convert.ToInt16(bOPYControllerBack.Text);
            n++;
            if (n > 3) n = 1;
            uGalil.GalilOPYControllerBackNumber = n;
            bOPYControllerBack.Text = n.ToString();
        }

        void ToggleModeRHYorOPYlow()
{     uPanel.ModeRHYorOPYlow=!uPanel.ModeRHYorOPYlow;

    if (uPanel.ModeRHYorOPYlow)
    {
        /*      // already done in Task07, StateNo 169! EHe 015.05.04
         * 
                bRHY.BackColor = System.Drawing.Color.Lime;
              bRHYControllerNumber.BackColor = System.Drawing.Color.Lime;
               uGalil.GalilRHYControllerNumber=Convert.ToInt16(bRHYControllerNumber.Text);

               bOPY.BackColor = System.Drawing.Color.Red;
               bOPYControllerFront.BackColor = System.Drawing.Color.Red;
               bOPYControllerBack.BackColor = System.Drawing.Color.Red;
               bTrajNormalLeft.Visible = false;
               bTrajNormalRight.Visible = false;
               bRTRt.Visible = false;
               bRTLt.Visible = false;
        */
       uPanel.PasParCmGauche = uPanel.PasParCmGaucheRH;
       uPanel.PasParDegreRobotGauche = uPanel.PasParDegreRobotGaucheRH;
       uPanel.PasParCmDroite = uPanel.PasParCmDroiteRH;
       uPanel.PasParDegreRobotDroite = uPanel.PasParDegreRobotDroiteRH;
       uPanel.DemiEcartRouesExt = uPanel.DemiEcartRouesExtRH;
         
    }
      else
    {
        /*      // already done in Task07 StateNo 169! EHe 015.05.04
         * 
              bRHY.BackColor = System.Drawing.Color.Red;
              bRHYControllerNumber.BackColor = System.Drawing.Color.Red;

              bOPY.BackColor = System.Drawing.Color.Lime;
              uGalil.GalilOPYControllerFrontNumber = Convert.ToInt16(bOPYControllerFront.Text);
              uGalil.GalilOPYControllerBackNumber = Convert.ToInt16(bOPYControllerBack.Text);

               bOPYControllerFront.BackColor = System.Drawing.Color.Lime;
               bOPYControllerBack.BackColor = System.Drawing.Color.Lime;
               bTrajNormalLeft.Visible = true;
               bTrajNormalRight.Visible = true;
               bRTRt.Visible = true;
               bRTLt.Visible = true;
        */
       uPanel.PasParCmGauche = uPanel.PasParCmGaucheOP;
       uPanel.PasParDegreRobotGauche = uPanel.PasParDegreRobotGaucheOP;
       uPanel.PasParCmDroite = uPanel.PasParCmDroiteOP;
       uPanel.PasParDegreRobotDroite = uPanel.PasParDegreRobotDroiteOP;
       uPanel.DemiEcartRouesExt = uPanel.DemiEcartRouesExtOP;
         
    }

    if (uPanel.PasParCmGauche > uPanel.PasParCmDroite)
        uPanel.PasParCmMax = uPanel.PasParCmGauche;
    else uPanel.PasParCmMax = uPanel.PasParCmDroite;

    if (uPanel.PasParDegreRobotGauche > uPanel.PasParDegreRobotDroite)
        uPanel.PasParDegreRobotMax = uPanel.PasParDegreRobotGauche;
    else uPanel.PasParDegreRobotMax = uPanel.PasParDegreRobotDroite;

    if (uPanel.PasParDegreRobotMax == 0) uPanel.PasParDegreRobotMax = 1;
     
}
/// <summary>
/// Sets the pushed button (sender) active
/// Uses the "tag" to store informations   // EHe 015.05.06
/// </summary>
/// <param name="sender"></param>
/// <param name="e"></param>
        private void button_Click_in_Platforms(object sender, EventArgs e)
        {




            Button TB = (Button)sender;

                foreach (Control control in gBPlatform.Controls)
                {
                    Button button = control as Button;

                    if (button.Text == TB.Text)
                    {
                        if (((string)button.Tag) != "Active")
                            button.Tag = "Active";
                        else
                            button.Tag = "";
                    }
                    else 
                    {
                        button.Tag = "";
                    }

                }
                if (((string)TB.Tag) == "")
                {
                    uPanel.Platform = uPanel.tPlatform.NONE;
                }
                else
                {
                    if (TB.Text == "RH-Y")bRHY_Click(sender, e);
                    else if (TB.Text == "OP-Y") bOPY_Click(sender, e);
                    else if (TB.Text == "OP12-Y") bOP12Y_Click(sender, e);
                    else if (TB.Text == "Manip. 25") bplatformManip25_Click(sender, e);
                }
        }

        private void bplatformManip25_Click(object sender, EventArgs e)
        {
            uPanel.Platform = uPanel.tPlatform.MANIP25;
        }


        private void bRHY_Click(object sender, EventArgs e)
        {
           uPanel.PlatformRHY = !uPanel.PlatformRHY;


            uPanel.Platform = uPanel.tPlatform.RHY;

            ToggleModeRHYorOPYlow();
            #if (!SimulationOnly)
            uGalil.SetAddressGalil(uGalil.AddressGalilRHY);
            uGalil.CheckConnectionGalil();
            #endif
        }

        private void bRUp_Click(object sender, EventArgs e)
        {
         
            uPanel.CarLu = 't';
            uPanel.OPDeplacement += 10;

        }

        private void bRDown_Click(object sender, EventArgs e)
        {
            uPanel.CarLu = 'v';
            uPanel.OPDeplacement -= 10;     // cm
        }

        private void bRTL_Click(object sender, EventArgs e)
        {
            uPanel.CarLu = 'f';
            /*
             * P12Y.CDG.Angle -= 10;     // degré
             */
        }

        private void bRTR_Click(object sender, EventArgs e)
        {
            uPanel.CarLu = 'g';
            /*
             * P12Y.CDG.Angle += 10;     // degré
             */
        }

        private void bRFR_Click(object sender, EventArgs e)
        {
            uPanel.CarLu = 'G';
            uPanel.OPDeplacementCrabeX += 10;     // cm
            uPanel.OPDeplacementCrabeY += 10;     // cm
        }

        private void bRFL_Click(object sender, EventArgs e)
        {
            uPanel.CarLu = 'T';
            uPanel.OPDeplacementCrabeX -= 10;     // cm
            uPanel.OPDeplacementCrabeY += 10;     // cm
        }

        private void bRBL_Click(object sender, EventArgs e)
        {
            uPanel.CarLu = 'F';
            uPanel.OPDeplacementCrabeX -= 10;     // cm
            uPanel.OPDeplacementCrabeY -= 10;     // cm

        }

        private void bRBR_Click(object sender, EventArgs e)
        {
            uPanel.CarLu = 'V';
            uPanel.OPDeplacementCrabeX += 10;     // cm
            uPanel.OPDeplacementCrabeY -= 10;     // cm

        }
         /*
          * bouton '<' press
          */
/*
        private void bTrajNormalLeft_Click(object sender, EventArgs e){
            //  <  avance latéralement 10 cm à gauche de la trajectoire; SEULEMENT Omnidrive
            if (uPanel.Choix[uPanel.NCCalibration].Etat)
                uMouv.P0RobotFutur.ds = uPanel.CalibrationDs; //(*DistancePourCalibration*)
            else uMouv.P0RobotFutur.ds = 10;
            uMouv.LancerMouvement(uPanel.tModeDeMouvement.Lat, uMouv.P0RobotFutur);
        }
         */
        private void bTrajNormalLeft_Click(object sender, EventArgs e)
        {
            //  <  avance latéralement 10 cm à droite de la trajectoire; SEULEMENT Omnidrive
            if (uPanel.Choix[uPanel.NCCalibration].Etat)
                uMouv.P0RobotFutur.ds = -uPanel.CalibrationDs; //(*DistancePourCalibration*)
            else uMouv.P0RobotFutur.ds = -10;
            uMouv.LancerMouvement(uPanel.tModeDeMouvement.Lat, uMouv.P0RobotFutur);

        }
         //Code 016.02.25
         /*
        private void bTrajNormalRight_Click(object sender, EventArgs e)
        {
            //  <  avance latéralement 10 cm à droite de la trajectoire; SEULEMENT Omnidrive
            if (uPanel.Choix[uPanel.NCCalibration].Etat)
                uMouv.P0RobotFutur.ds = -uPanel.CalibrationDs; //(*DistancePourCalibration*)
            else uMouv.P0RobotFutur.ds = -10;
            uMouv.LancerMouvement(uPanel.tModeDeMouvement.Lat, uMouv.P0RobotFutur);

        }
     */
        private void bTrajNormalRight_Click(object sender, EventArgs e)
        {
            //  <  avance latéralement 10 cm à droite de la trajectoire; SEULEMENT Omnidrive
            if (uPanel.Choix[uPanel.NCCalibration].Etat)
                uMouv.P0RobotFutur.ds = uPanel.CalibrationDs; //(*DistancePourCalibration*)
            else uMouv.P0RobotFutur.ds = 10;
            uMouv.LancerMouvement(uPanel.tModeDeMouvement.Lat, uMouv.P0RobotFutur);

        }


        private void button3_Click(object sender, EventArgs e)
        {// bNextstep
            uPanel.V5CarLu = ' ';
        }

        private void bPlus1000BPt_Click(object sender, EventArgs e)
        {
            uPanel.BreakpointNumber += 1000;
            tBBreakpoint.Text = uPanel.BreakpointNumber.ToString();
            uPanel.BreakpointEnabled = true;

        }

        private void bMinus1000BPt_Click(object sender, EventArgs e)
        {
            uPanel.BreakpointNumber -= 1000;
            tBBreakpoint.Text = uPanel.BreakpointNumber.ToString();
            uPanel.BreakpointEnabled = true;
     }

        private void bPlus100BPt_Click(object sender, EventArgs e)
        {
            uPanel.BreakpointNumber += 100;
            tBBreakpoint.Text = uPanel.BreakpointNumber.ToString();
            uPanel.BreakpointEnabled = true;
    }

        private void bPlus10BPt_Click(object sender, EventArgs e)
        {
            uPanel.BreakpointNumber += 10;
            tBBreakpoint.Text = uPanel.BreakpointNumber.ToString();
            uPanel.BreakpointEnabled = true;
        }

        private void bPlus1BPt_Click(object sender, EventArgs e)
        {
            uPanel.BreakpointNumber += 1;
            tBBreakpoint.Text = uPanel.BreakpointNumber.ToString();
            uPanel.BreakpointEnabled = true;
        }

        private void bMinus100BPt_Click(object sender, EventArgs e)
        {
            uPanel.BreakpointNumber -= 100;
            tBBreakpoint.Text = uPanel.BreakpointNumber.ToString();
            uPanel.BreakpointEnabled = true;
        }

        private void bMinus10BPt_Click(object sender, EventArgs e)
        {
            uPanel.BreakpointNumber -= 10;
            tBBreakpoint.Text = uPanel.BreakpointNumber.ToString();
            uPanel.BreakpointEnabled = true;
        }

        private void bMinus1BPt_Click(object sender, EventArgs e)
        {
            uPanel.BreakpointNumber -= 1;
            tBBreakpoint.Text = uPanel.BreakpointNumber.ToString();
            uPanel.BreakpointEnabled = true;
        }

        private void bOPY_Click(object sender, EventArgs e)
        {
            uPanel.Platform = uPanel.tPlatform.OPY;
            ToggleModeRHYorOPYlow();
            #if (!SimulationOnly)
            uGalil.SetAddressGalil(uGalil.AddressGalilOPY);
            uGalil.CheckConnectionGalil();
            #endif
        }

        private void bDebugStepOn_Click(object sender, EventArgs e)
        {
            uPanel.DebugStep = true;
        }

        private void bDebugStepOff_Click(object sender, EventArgs e)
        {
            uPanel.DebugStep = false;
        }

        private void bDebugStep_Click(object sender, EventArgs e)
        {
        uPanel.DebugStep=!uPanel.DebugStep;
      //  if (uPanel.DebugStep) bDebugStepOn.SetFocus();
        if (uPanel.DebugStep) bDebugStepOn.Select();
        }

        private void bSauver_Click(object sender, EventArgs e)
        {
        //   ConfigReadWrite1.WriteToCfg();
        //    ConfigReadWrite1.ReadFromCfg();
        //  TrialBox1.Text = ConfigReadWrite1.line;
            uParam.SauverParametres();
        }

        private void tBTicksPerSecond_TextChanged(object sender, EventArgs e)
        {

        }

        private void BTicksPSMClick(object sender, EventArgs e)
        {
            uPanel.TicksPerSecond =(long)(0.97 * uPanel.TicksPerSecond);
        }

        private void tBTicks_TextChanged(object sender, EventArgs e)
        {

        }

        private void BTicksPSPClick(object sender, EventArgs e)
        {
            uPanel.TicksPerSecond = (long)(1.03 * uPanel.TicksPerSecond);
        }

        private void PSynchro_Click(object sender, EventArgs e)
        {
            uPanel.TicksPerSecond = (long)uPanel.V7TicksParSecondeEstime;
        }

        private void PTrajLeftClick(object sender, EventArgs e)
        {
            /* tourne la TRAJECTOIRE (le sens du mouvement) de 22.5 degrés supplémentaires
             * par rapport au robot  (pas de mouvement; applicable à une plateforme omnidirectionnelle seulement)
             */
            if (uPanel.Choix[uPanel.NCCalibration].Etat)
                uMouv.P0RobotFutur.AngleRobotTraj = +uPanel.CalibrationAngle; //(*DistancePourCalibration*)
            else uMouv.P0RobotFutur.AngleRobotTraj = +22;//normalement 22.5
            uMouv.P0RobotFutur.AngleRobotTraj += uMouv.P0RobotFutur.AngleRobotTraj;
            uMouv.P0Robot.AngleRobotTraj += uMouv.P0RobotFutur.AngleRobotTraj;

            /*Extrait de code en C++ SL 2013
             if (Choix[NCCalibration].Etat)
	     P0RobotFutur.AngleRobotTraj=+CalibrationAngle; //(* 45 div 2 *)
                 else
             P0RobotFutur.AngleRobotTraj=+22.5 ; // (* 45 div 2 *)

   P0Robot.AngleRobotTraj+=P0RobotFutur.AngleRobotTraj ;
             */
        }

        private void PTrajRightClick(object sender, EventArgs e)
        {
            /* tourne la TRAJECTOIRE (le sens du mouvement) de -22.5 degrés supplémentaires
               par rapport au robot  (pas de mouvement; applicable à une plateforme omnidirectionnelle seulement)
             */
            if (uPanel.Choix[uPanel.NCCalibration].Etat)
                uMouv.P0RobotFutur.AngleRobotTraj = -uPanel.CalibrationAngle; //(*DistancePourCalibration*)
            else uMouv.P0RobotFutur.AngleRobotTraj = -22;//normalement 22.5
            uMouv.P0Robot.AngleRobotTraj += uMouv.P0RobotFutur.AngleRobotTraj;
            //uMouv.P0Robot.AngleRobotTraj
            /*
             if (Choix[NCCalibration].Etat) P0RobotFutur.AngleRobotTraj=-CalibrationAngle; //(* 45 div 2 *)
             else
             P0RobotFutur.AngleRobotTraj=-22.5 ; // (* 45 div 2 *)
             P0Robot.AngleRobotTraj+=P0RobotFutur.AngleRobotTraj ;
             */
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void BSetP_Click(object sender, EventArgs e)
        {
            uPiaget.SetPositionRobot(50,50,90);
            //uGalil.ExecuterCommandeGalil("DP 50,50");
        }

        private void BMvP_Click(object sender, EventArgs e)
        {
            //uPanel.CarLu = 'i';
            uPiaget.ClearCheckBoard();
        }

        private void pDirection_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pRobot_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            uPiaget.ClearCheckBoard();
        }

        private void TrialBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void bOP12Y_Click(object sender, EventArgs e)
        {
            uPanel.Platform = uPanel.tPlatform.OP12Y;
            ToggleModeRHYorOPYlow();// a verifier SL2013
            #if (!SimulationOnly)
                uGalil.SetAddressGalil(uGalil.AddressGalilOP12Y);
                uGalil.CheckConnectionGalil();
            #endif
        }

        private void bSO6_Click(object sender, EventArgs e)
        {
            // ComplementerSO(6);   // Moteur Milieu Sol
            if (uPanel.SignauxOut[6].EtatVF)
                { uPanel.SignauxOut[6].EtatVF = false; }
            else
                { uPanel.SignauxOut[6].EtatVF = true; }

            uPanel.DemandeRefreshSortie = true;
            
            /*
             // ComplementerSO(6);   // Moteur Milieu Sol
  if (SignauxOut[6].EtatVF)
   { SignauxOut[6].EtatVF=false;}
   else
   { SignauxOut[6].EtatVF=true;}

  DemandeRefreshSortie = true ;
             */
        }

        private void bSO7_Click(object sender, EventArgs e)
        {

            // ComplementerSO(7);   // Moteur Milieu Ciel
            if (uPanel.SignauxOut[7].EtatVF)
                { uPanel.SignauxOut[7].EtatVF = false; }
            else
                {uPanel.SignauxOut[7].EtatVF = true;}

            uPanel.DemandeRefreshSortie = true;
            
            /* extrait c++ SL 2013
             // ComplementerSO(7);   // Moteur Milieu Ciel
  if (SignauxOut[7].EtatVF)
   { SignauxOut[7].EtatVF=false;}
   else
   {
      SignauxOut[7].EtatVF=true;}

  DemandeRefreshSortie = true ;
             */
        }

        private void bSO8_Click(object sender, EventArgs e)
        {
            //ComplementerSO(8);   // Moteur Haut ON
            if (uPanel.SignauxOut[8].EtatVF)
            { uPanel.SignauxOut[8].EtatVF = false; }
            else
            {
                //SignauxOut[6].EtatVF=false;
                uPanel.SignauxOut[8].EtatVF = true;
            }

            uPanel.DemandeRefreshSortie = true;
            
            
            
            /* extrait SL 2013
             //ComplementerSO(8);   // Moteur Haut ON
  if (SignauxOut[8].EtatVF)
   { SignauxOut[8].EtatVF=false;}
   else
   {
   //SignauxOut[6].EtatVF=false;
      SignauxOut[8].EtatVF=true;}

  DemandeRefreshSortie = true ;
             */
        }

        private void bSO9_Click(object sender, EventArgs e)
        {
            //ComplementerSO(9);  // Moteur Haut Direction Sol
            if (uPanel.SignauxOut[9].EtatVF)
            { uPanel.SignauxOut[9].EtatVF = false; }
            else
            { uPanel.SignauxOut[9].EtatVF = true; }
            uPanel.DemandeRefreshSortie = true;
            /*
             //ComplementerSO(9);  // Moteur Haut Direction Sol
  if (SignauxOut[9].EtatVF)
   { SignauxOut[9].EtatVF=false;}
   else
   {
   //SignauxOut[6].EtatVF=false;
      SignauxOut[9].EtatVF=true;}

  DemandeRefreshSortie = true ;
             */
        }

        private void bSO10_Click(object sender, EventArgs e)
        {   //ComplementerSO(10);
            if (uPanel.SignauxOut[10].EtatVF)
            { uPanel.SignauxOut[10].EtatVF = false; }
            else
            { uPanel.SignauxOut[10].EtatVF = true; }

            uPanel.DemandeRefreshSortie = true;
            /*
             //ComplementerSO(10);
  if (SignauxOut[10].EtatVF)
   { SignauxOut[10].EtatVF=false;}
   else
   {
   //SignauxOut[6].EtatVF=false;
      SignauxOut[10].EtatVF=true;}

  DemandeRefreshSortie = true ;
             */
        }

        private void bSO11_Click(object sender, EventArgs e)
        {   // ComplementerSO(11);
            //Work[NTActionTemporiseeDoigt].TaskStatus=Demandee;
            if (uPanel.SignauxOut[11].EtatVF)
            { uPanel.SignauxOut[11].EtatVF = false; }
            else
            {uPanel.SignauxOut[11].EtatVF = true;}

            uPanel.DemandeRefreshSortie = true;

            /* extrait C++ SL2013
             // ComplementerSO(11);
//Work[NTActionTemporiseeDoigt].TaskStatus=Demandee;
  if (SignauxOut[11].EtatVF)
   { SignauxOut[11].EtatVF=false;}
   else
   {
   //SignauxOut[6].EtatVF=false;
      SignauxOut[11].EtatVF=true;}

  DemandeRefreshSortie = true ; 
             */
        }

        private void bSO12_Click(object sender, EventArgs e)
        {
            //ComplementerSO(12);
            if (uPanel.SignauxOut[12].EtatVF)
                { uPanel.SignauxOut[12].EtatVF = false; }
            else
                {uPanel.SignauxOut[12].EtatVF = true;}

            uPanel.DemandeRefreshSortie = true;

            /*
             //ComplementerSO(12);
  if (SignauxOut[12].EtatVF)
   { SignauxOut[12].EtatVF=false;}
   else
   {
   //SignauxOut[6].EtatVF=false;
      SignauxOut[12].EtatVF=true;}

  DemandeRefreshSortie = true ; 
             */
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {


            if (!checkBox1.Checked)
            {
                uPanel.SignauxOut[2].EtatVF = false;
                uPanel.SignauxOut[1].EtatVF = false;
            }
            else
            {
                uPanel.SignauxOut[2].EtatVF = true;
                uPanel.SignauxOut[1].EtatVF = true;
            }
            /* Extrait C++ SL 2013
             LightsON = Form1->CheckBox1->Checked;
    if(!Form1->CheckBox1->Checked){
    SignauxOut[2].EtatVF=false;
    SignauxOut[1].EtatVF=false;}
    else {
    SignauxOut[2].EtatVF=true;
    SignauxOut[1].EtatVF=true;
             */
        }

        private void MyTimer_Tick(object sender, EventArgs e)
        {
            BouclePrincipale(true);
        }

        private void PAIn2_Click(object sender, EventArgs e)
        {
            ToggleEtatSAIn(2);
        }

        private void PAInNew_Click(object sender, EventArgs e)
        {
            ToggleEtatSAIn(2);
        }

        private void PAIn1_Click(object sender, EventArgs e)
        {
            ToggleEtatSAIn(1);
        }

        private void PAIn3_Click(object sender, EventArgs e)
        {
            ToggleEtatSAIn(3);
        }

        private void PAIn4_Click(object sender, EventArgs e)
        {
            ToggleEtatSAIn(4);
        }

        private void PAIn5_Click(object sender, EventArgs e)
        {
            ToggleEtatSAIn(5);
        }

        private void pIntroduce_Click(object sender, EventArgs e)
        {
            uPanel.ModeTestRAH = uPanel.tModeTestRAH.Introduce;
            uPanel.ModeTestRAH_Number = 4;
            UpdateColorButtonsModeTestRAH();
        }

        private void pOpenChallenge_Click(object sender, EventArgs e)
        {
            uPanel.ModeTestRAH = uPanel.tModeTestRAH.OpenChallenge;
            uPanel.ModeTestRAH_Number = 6;
            UpdateColorButtonsModeTestRAH();
        }

        public void UpdateColorButtonsModeTestRAH()
        {
            
            if (uPanel.ModeTestRAH == uPanel.tModeTestRAH.FastFollow)
                pFastFollow.BackColor = uPanel.clLime;
            else
                pFastFollow.BackColor = uPanel.clRed;
          
            //---------------------------------------------------------------
            if (uPanel.ModeTestRAH == uPanel.tModeTestRAH.FetchAndCarry)
                pFetchAndCarry.BackColor = uPanel.clLime;
            else
                pFetchAndCarry.BackColor = uPanel.clRed;
            //---------------------------------------------------------------
            if (uPanel.ModeTestRAH == uPanel.tModeTestRAH.FollowAndGuide07)
                ;//pFollowAndGuide07.BackColor = uPanel.clLime;
            else
                ;//pFollowAndGuide07.BackColor = uPanel.clRed;
            //--------------------------------------------------------------
            if (uPanel.ModeTestRAH == uPanel.tModeTestRAH.Introduce)
                pIntroduce.BackColor = uPanel.clLime;
            else
                pIntroduce.BackColor = uPanel.clRed;
            //--------------------------------------------------------------
            if (uPanel.ModeTestRAH == uPanel.tModeTestRAH.Bartender)
                pBartender.BackColor = uPanel.clLime;
            else
                pBartender.BackColor = uPanel.clRed;
            //--------------------------------------------------------------
            if (uPanel.ModeTestRAH == uPanel.tModeTestRAH.SuperMarket)
                pSuperMarket.BackColor = uPanel.clLime;
            else
                pSuperMarket.BackColor = uPanel.clRed;
            //--------------------------------------------------------------
            if (uPanel.ModeTestRAH == uPanel.tModeTestRAH.OpenChallenge)
                pOpenChallenge.BackColor = uPanel.clLime;
            else
                pOpenChallenge.BackColor = uPanel.clRed;
            //--------------------------------------------------------------
            if (uPanel.ModeTestRAH == uPanel.tModeTestRAH.WhoIsWho)
                pWhoIsWho.BackColor = uPanel.clLime;
            else
                pWhoIsWho.BackColor = uPanel.clRed;
            //---------------------------------------------------------------
            if (uPanel.ModeTestRAH == uPanel.tModeTestRAH.LostAndFound)
                pLostAndFound.BackColor = uPanel.clLime;
            else
                pLostAndFound.BackColor = uPanel.clRed;
            //---------------------------------------------------------------
            if (uPanel.ModeTestRAH == uPanel.tModeTestRAH.FollowWall)
                ;//pFollowWall.BackColor = uPanel.clLime;
            else
                ;//pFollowWall.BackColor = uPanel.clRed;
            //---------------------------------------------------------------
            if (uPanel.ModeTestRAH == uPanel.tModeTestRAH.FastFollow2010)
                ;//pFastFollow2010.BackColor = uPanel.clLime;
            else
                ;//pFastFollow2010.BackColor = uPanel.clRed;
            //---------------------------------------------------------------
            if (uPanel.ModeTestRAH == uPanel.tModeTestRAH.GoAndGet)
                ;//pGoAndGet.BackColor = uPanel.clLime;
            else
                ;//pGoAndGet.BackColor = uPanel.clRed;
            //---------------------------------------------------------------
            if (uPanel.ModeTestRAH == uPanel.tModeTestRAH.ShowEmBo)
                ;//pShowEmBo.BackColor = uPanel.clLime;
            else
                ;//pShowEmBo.BackColor = uPanel.clRed;
            //----------------------------------------------------------------
            if (uPanel.ModeTestRAH == uPanel.tModeTestRAH.Gamepad)
                pGamepad.BackColor = uPanel.clLime;
            else
                pGamepad.BackColor = uPanel.clRed;
            //---------------------------------------------------------------
            if (uPanel.ModeTestRAH == uPanel.tModeTestRAH.WhoIsWho2010)
                ;//pWhoIsWho2010.BackColor = uPanel.clLime;
            else
                ;//pWhoIsWho2010.BackColor = uPanel.clRed;
            //--------------------------------------------------------------
            if (uPanel.ModeTestRAH == uPanel.tModeTestRAH.FaceRec)
                ;//pFaceRec.BackColor = uPanel.clLime;
            else
                ;//pFaceRec.BackColor = uPanel.clRed;
            //--------------------------------------------------------------
            if (uPanel.ModeTestRAH == uPanel.tModeTestRAH.RobInspecPS)
                ;//pRobInspecPS.BackColor = uPanel.clLime;
            else
                ;//pRobInspecPS.BackColor = uPanel.clRed;
            //-------------------------------------------------------------
            if (uPanel.ModeTestRAH == uPanel.tModeTestRAH.OpenChallenge2010)
                ;//pOpenChallenge2010.BackColor = uPanel.clLime;
            else
                ;//pOpenChallenge2010.BackColor = uPanel.clRed;
            //-------------------------------------------------------------
            if (uPanel.ModeTestRAH == uPanel.tModeTestRAH.Navigate)
                ;//pNavigate.BackColor = uPanel.clLime;
            else
                ;//pNavigate.BackColor = uPanel.clRed;
            //-------------------------------------------------------------
            if (uPanel.ModeTestRAH == uPanel.tModeTestRAH.Compliance)
                ;//pCompliance.BackColor = uPanel.clLime;
            else
                ;//pCompliance.BackColor = uPanel.clRed;
            //-------------------------------------------------------------
            if (uPanel.ModeTestRAH == uPanel.tModeTestRAH.OpenChallenge2011)
                ;//pOpenChallenge2011.BackColor = uPanel.clLime;
            else
                ;//pOpenChallenge2011.BackColor = uPanel.clRed;
            //-------------------------------------------------------------
            if (uPanel.ModeTestRAH == uPanel.tModeTestRAH.KukaGlue)
                ;//pKukaGlue.BackColor = uPanel.clLime;
            else
                ;//pKukaGlue.BackColor = uPanel.clRed;
            //------------------------------------------------------------
            //StaubliTask, NAOinGE, HeightFrom3D, RandomWay
            if (uPanel.ModeTestRAH == uPanel.tModeTestRAH.TestTask)
                ;//pTestTask.BackColor = uPanel.clLime;
            else
                ;//pTestTask.BackColor = uPanel.clRed;
            //------------------------------------------------------------
            if (uPanel.ModeTestRAH == uPanel.tModeTestRAH.StaubliTask)
                ;//pStaubliTask.BackColor = uPanel.clLime;
            else
                ;//pStaubliTask.BackColor = uPanel.clRed;
            //------------------------------------------------------------
            if (uPanel.ModeTestRAH == uPanel.tModeTestRAH.NAOinGE)
                ;//pNAOinGE.BackColor = uPanel.clLime;
            else
                ;//pNAOinGE.BackColor = uPanel.clRed;
            //-----------------------------------------------------------
            if (uPanel.ModeTestRAH == uPanel.tModeTestRAH.HeightFrom3D)
                ;//pHeightFrom3D.BackColor = uPanel.clLime;
            else
                ;//pHeightFrom3D.BackColor = uPanel.clRed;
            //----------------------------------------------------------
            if (uPanel.ModeTestRAH == uPanel.tModeTestRAH.CogniMeasure)
                ;//pCogniMeasure.BackColor = uPanel.clLime;
            else
                ;//pCogniMeasure.BackColor = uPanel.clRed;
            //----------------------------------------------------------
            if (uPanel.ModeTestRAH == uPanel.tModeTestRAH.RandomWay)
                ;//pRandomWay.BackColor = uPanel.clLime;
            else
                ;//pRandomWay.BackColor = uPanel.clRed;
            //----------------------------------------------------------
            if (uPanel.ModeTestRAH == uPanel.tModeTestRAH.DemoKatana)
                ;//pDemoKatana.BackColor = uPanel.clLime;
            else
                ;//pDemoKatana.BackColor = uPanel.clRed;
            //----------------------------------------------------------
            if (uPanel.ModeTestRAH == uPanel.tModeTestRAH.KinectNavigation)
                ;// pKinectNavigation.BackColor = uPanel.clLime;
            else
                ;//pKinectNavigation.BackColor = uPanel.clRed;
            //----------------------------------------------------------
            if (uPanel.ModeTestRAH == uPanel.tModeTestRAH.DemoEnergy)
                ;//pDemoEnergy.BackColor = uPanel.clLime;
            else
                ;//pDemoEnergy.BackColor = uPanel.clRed;
            //----------------------------------------------------------
            if (uPanel.ModeTestRAH == uPanel.tModeTestRAH.TeleGrab)
                ;//pTeleGrab.BackColor = uPanel.clLime;
            else
                ;//pTeleGrab.BackColor = uPanel.clRed;
            //----------------------------------------------------------
            if (uPanel.ModeTestRAH == uPanel.tModeTestRAH.DemoOP12Y)
                ;//pDemoOP12Y.BackColor = uPanel.clLime;
            else
                ;//pDemoOP12Y.BackColor = uPanel.clRed;
            //----------------------------------------------------------
            if (uPanel.ModeTestRAH == uPanel.tModeTestRAH.RobocupAtWork)
                ;//pRobocupAtWork.BackColor = uPanel.clLime;
            else
                ;//pRobocupAtWork.BackColor = uPanel.clRed;
            //----------------------------------------------------------
            
            if (uPanel.ModeTestRAH == uPanel.tModeTestRAH.ShowEmBo)//???? SL 2013
                pShowEmBo.BackColor = uPanel.clLime;
            else
                pShowEmBo.BackColor = uPanel.clRed;
            //---------------------------------------------------------
            
            /* Extrait code C++ SL2013
             if (ModeTestRAH==FastFollow)
        Form1->PFastFollow->Color=clLime;
    else
       Form1->PFastFollow->Color=clRed;
 if (ModeTestRAH==FetchAndCarry)
        Form1->PFetchAndCarry->Color=clLime;
    else
       Form1->PFetchAndCarry->Color=clRed;
 if (ModeTestRAH==FollowAndGuide07)
        Form1->PFollowAndGuide07->Color=clLime;
    else
       Form1->PFollowAndGuide07->Color=clRed;
 if (ModeTestRAH==Introduce)
        Form1->PIntroduce->Color=clLime;
    else
       Form1->PIntroduce->Color=clRed;
 if (ModeTestRAH==Bartender)
        Form1->PBartender->Color=clLime;
    else
       Form1->PBartender->Color=clRed;
 if (ModeTestRAH==SuperMarket)
        Form1->PSuperMarket->Color=clLime;
    else
       Form1->PSuperMarket->Color=clRed;
 if (ModeTestRAH==OpenChallenge)
        Form1->POpenChallenge->Color=clLime;
    else
       Form1->POpenChallenge->Color=clRed;
 if (ModeTestRAH==WhoIsWho)
        Form1->PWhoIsWho->Color=clLime;
    else
       Form1->PWhoIsWho->Color=clRed;
  if (ModeTestRAH==LostAndFound)
        Form1->PLostAndFound->Color=clLime;
    else
       Form1->PLostAndFound->Color=clRed;
  if (ModeTestRAH==FollowWall)
        Form1->PFollowWall->Color=clLime;
    else
       Form1->PFollowWall->Color=clRed;
  if (ModeTestRAH==FastFollow2010)
        Form1->PFastFollow2010->Color=clLime;
    else
       Form1->PFastFollow2010->Color=clRed;
  if (ModeTestRAH==GoAndGet)
        Form1->PGoAndGet->Color=clLime;
    else
       Form1->PGoAndGet->Color=clRed;
    if (ModeTestRAH==ShowEmBo)
        Form1->PShowEmBo->Color=clLime;
    else
       Form1->PShowEmBo->Color=clRed;
    if (ModeTestRAH==Gamepad)
        Form1->PGamepad->Color=clLime;
    else
       Form1->PGamepad->Color=clRed;
    if (ModeTestRAH==WhoIsWho2010)
        Form1->PWhoIsWho2010->Color=clLime;
      else
       Form1->PWhoIsWho2010->Color=clRed;
    if (ModeTestRAH==FaceRec)
        Form1->PFaceRec->Color=clLime;
      else
       Form1->PFaceRec->Color=clRed;
    if (ModeTestRAH==RobInspecPS)
        Form1->PRobInspecPS->Color=clLime;
      else
       Form1->PRobInspecPS->Color=clRed;
     if (ModeTestRAH==OpenChallenge2010)
        Form1->POpenChallenge2010->Color=clLime;
      else
       Form1->POpenChallenge2010->Color=clRed;
     if (ModeTestRAH==Navigate)
        Form1->PNavigate->Color=clLime;
      else
       Form1->PNavigate->Color=clRed;
     if (ModeTestRAH==Compliance)
        Form1->PCompliance->Color=clLime;
      else
       Form1->PCompliance->Color=clRed;
     if (ModeTestRAH==OpenChallenge2011)
        Form1->POpenChallenge2011->Color=clLime;
      else
       Form1->POpenChallenge2011->Color=clRed;
     if (ModeTestRAH==KukaGlue)
        Form1->PKukaGlue->Color=clLime;
      else
       Form1->PKukaGlue->Color=clRed;
 //StaubliTask, NAOinGE, HeightFrom3D, RandomWay
     if (ModeTestRAH==TestTask)
        Form1->PTestTask->Color=clLime;
      else
       Form1->PTestTask->Color=clRed;
     if (ModeTestRAH==StaubliTask)
        Form1->PStaubliTask->Color=clLime;
      else
       Form1->PStaubliTask->Color=clRed;
     if (ModeTestRAH==NAOinGE)
        Form1->PNAOinGE->Color=clLime;
      else
       Form1->PNAOinGE->Color=clRed;
     if (ModeTestRAH==HeightFrom3D)
        Form1->PHeightFrom3D->Color=clLime;
      else
       Form1->PHeightFrom3D->Color=clRed;
     if (ModeTestRAH==CogniMeasure)
        Form1->PCogniMeasure->Color=clLime;
      else
       Form1->PCogniMeasure->Color=clRed;
     if (ModeTestRAH==RandomWay)
        Form1->PRandomWay->Color=clLime;
      else
       Form1->PRandomWay->Color=clRed;
     if (ModeTestRAH==DemoKatana)
        Form1->PDemoKatana->Color=clLime;
      else
       Form1->PDemoKatana->Color=clRed;
     if (ModeTestRAH==KinectNavigation)
        Form1->PKinectNavigation->Color=clLime;
      else
       Form1->PKinectNavigation->Color=clRed;
     if (ModeTestRAH==DemoEnergy)
        Form1->PDemoEnergy->Color=clLime;
      else
       Form1->PDemoEnergy->Color=clRed;
     if (ModeTestRAH==TeleGrab)
        Form1->PTeleGrab->Color=clLime;
      else
       Form1->PTeleGrab->Color=clRed;
     if (ModeTestRAH==DemoOP12Y)
        Form1->PDemoOP12Y->Color=clLime;
      else
       Form1->PDemoOP12Y->Color=clRed;
     if (ModeTestRAH==RobocupAtWork)
        Form1->PRobocupAtWork->Color=clLime;
      else
       Form1->PRobocupAtWork->Color=clRed;
             */
        }

        private void pFastFollow_Click(object sender, EventArgs e)
        {
            uPanel.ModeTestRAH = uPanel.tModeTestRAH.FastFollow;
            uPanel.ModeTestRAH_Number = 1;
            UpdateColorButtonsModeTestRAH();
            
            /*
             ModeTestRAH=FastFollow;
        ModeTestRAH_Number=1;
        UpdateColorButtonsModeTestRAH();
             */
        }

        private void pFetchAndCarry_Click(object sender, EventArgs e)
        {
            uPanel.ModeTestRAH = uPanel.tModeTestRAH.FetchAndCarry;
            uPanel.ModeTestRAH_Number = 2;
            UpdateColorButtonsModeTestRAH();
        }

        private void pLostAndFound_Click(object sender, EventArgs e)
        {
            uPanel.ModeTestRAH = uPanel.tModeTestRAH.LostAndFound;
            uPanel.ModeTestRAH_Number = 8;
            UpdateColorButtonsModeTestRAH();
        }

        private void pWhoIsWho_Click(object sender, EventArgs e)
        {
            uPanel.ModeTestRAH = uPanel.tModeTestRAH.WhoIsWho;
            uPanel.ModeTestRAH_Number = 7;
            UpdateColorButtonsModeTestRAH();
        }

        private void pBartender_Click(object sender, EventArgs e)
        {
            uPanel.ModeTestRAH = uPanel.tModeTestRAH.Bartender;
            uPanel.ModeTestRAH_Number = 5;
            UpdateColorButtonsModeTestRAH();
        }

        private void pSuperMarket_Click(object sender, EventArgs e)
        {
            uPanel.ModeTestRAH = uPanel.tModeTestRAH.SuperMarket;
            uPanel.ModeTestRAH_Number = 9;
            UpdateColorButtonsModeTestRAH();
        }

        private void pShowEmBo_Click(object sender, EventArgs e)
        {
            uPanel.ModeTestRAH = uPanel.tModeTestRAH.ShowEmBo;
            uPanel.ModeTestRAH_Number = 13;
            UpdateColorButtonsModeTestRAH();
        }

        private void pGamepad_Click(object sender, EventArgs e)
        {
            uPanel.ModeTestRAH = uPanel.tModeTestRAH.Gamepad;
            uPanel.ModeTestRAH_Number = 14 ;
            UpdateColorButtonsModeTestRAH();
        }

        private void pTable_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (uPanel.Choix[uPanel.NCSimulation].Etat == false)
            {
                if (!uPanel.KinectConnection)
                {
                    Console.WriteLine("You need to connect a kinect and then activate Kinect Button!!! \r\n");
                }
                else
                {
                    System.Diagnostics.Process.Start("KinectApp.exe");
                }
            }
        }

        private void Tr_Click(object sender, EventArgs e)
        {
        
            if (videoSourceClr != null && uPanel.Choix[uPanel.NCSimulation].Etat)
            { videoSourceClr.Stop(); }
 
            videoSourceTr = new MJPEGStream("http://10.192.49.216//axis-cgi/mjpg/video.cgi");////// Thermal camera 172.16.17.8 ("http://10.192.49.216//axis-cgi/mjpg/video.cgi" is use to test)
            videoSourceTr.NewFrame += new NewFrameEventHandler(video_NewFrame);
            videoSourceTr.Start();
            Tr.BackColor = Color.Lime;
            Clr.BackColor = Color.Red;

        }

        private void Clr_Click(object sender, EventArgs e)
        {
            if (videoSourceTr != null && uPanel.Choix[uPanel.NCSimulation].Etat)
            { videoSourceTr.Stop(); }

            videoSourceClr = new MJPEGStream("http://172.16.17.7/axis-cgi/mjpg/video.cgi");
            videoSourceClr.NewFrame += new NewFrameEventHandler(video_NewFrame);
            videoSourceClr.Start();
            Tr.BackColor = Color.Red;
            Clr.BackColor = Color.Lime;

        }
        public void video_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            try
            {
               
                img = (Bitmap)eventArgs.Frame.Clone();
                //do processing here
                // picBox.Image = img;
                if (!uPanel.Choix[uPanel.NCSimulation].Etat)
                {             
                pictureBox1.Image = img;
                }
            }
            catch
            {
            }
        }

        private void tBMemo1_TextChanged(object sender, EventArgs e)
        {

        }
            


        /////////////////////////////////////////////////////////////////////////////////
        //keyboards input////////////////////////////////////////////////////////////////
        /// <summary>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        private void tBTicks_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e) 
        {

           /* if ( e.KeyCode == Keys.Q  && e.Shift)
            {
                FPiaget.ActiveForm.Close();
            }*/

            ////////////////////
            // hotkey to quit //
            ////////////////////
            if (e.KeyCode == Keys.Q)  
            {
                //FPiaget.ActiveForm.Close();
                uPanel.CarLu = 'q';
                uPanel.Done1 = true;

            }

            ///////////////////////
            // hotkey to restart //
            ///////////////////////
            if (e.KeyCode == Keys.R)   
            {
                uPiaget1.Initialiser();
                uPiaget.FermerLiaisons();
                uPanel.InitialiserLaser = false;

            }

            //////////////////////
            // movement hotkeys //
            //////////////////////
            if (e.KeyCode == Keys.T)    
            {
                uPanel.CarLu = 't';
                uPanel.OPDeplacement += 10;
            }
            if (e.KeyCode == Keys.V)
            {
                uPanel.CarLu = 'v';
                uPanel.OPDeplacement -= 10;
            }
            if (e.KeyCode == Keys.F)
            {
                uPanel.CarLu = 'f';
            }
            if (e.KeyCode == Keys.G)
            {
                uPanel.CarLu = 'g';
            }
            if ( e.KeyCode == Keys.T  && e.Shift) 
            {
                uPanel.CarLu = 'T';
                uPanel.OPDeplacementCrabeX -= 10;     // cm
                uPanel.OPDeplacementCrabeY += 10;     // cm




            }
            if (e.KeyCode == Keys.V && e.Shift) 
            {
                uPanel.CarLu = 'V';
                uPanel.OPDeplacementCrabeX += 10;     // cm
                uPanel.OPDeplacementCrabeY -= 10;     // cm
            }
            if (e.KeyCode == Keys.F && e.Shift) 
            {
                uPanel.CarLu = 'F';
                uPanel.OPDeplacementCrabeX -= 10;     // cm
                uPanel.OPDeplacementCrabeY -= 10;     // cm
            }
            if (e.KeyCode == Keys.G && e.Shift) 
            {
                uPanel.CarLu = 'G';
                uPanel.OPDeplacementCrabeX += 10;     // cm
                uPanel.OPDeplacementCrabeY += 10;     // cm
            }
            ///////////////////////////
            //  end movement hotkeys //
            ///////////////////////////

            ///////////////////////
            //  hotkey for save  //
            ///////////////////////
            if (e.KeyCode == Keys.H)      
            {
                uParam.SauverParametres();
            }

        }

        Galil.Galil g = new Galil.Galil();



        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (uPanel.Choix[uPanel.NCSimulation].Etat == false)
            {

                if (e.KeyChar == (char)Keys.Return)
                {
                    Console.WriteLine(MyGlobals.str1); //check input//

                    g.address = "172.16.17.31";
                    if (MyGlobals.str1 == "TP")
                    {
                        MyGlobals.str1 = g.command("TP", "\r\n", ":", true);
                    }
                    else
                    {
                        g.command(MyGlobals.str1);
                    }
                    //g.command("BG");
                    MyGlobals.str2 = ": " + MyGlobals.str1 + "\r\n" + MyGlobals.str2;
                    textBox3.Text = MyGlobals.str2;
                    textBox2.Text = "";

                    MyGlobals.str1 = "";
                    MyGlobals.check = 0;
                }
                else
                    if (e.KeyChar == (char)Keys.Back && MyGlobals.check == 0)
                    {
                        if (MyGlobals.str1 == "")
                            MyGlobals.str1 = "";
                        else
                            MyGlobals.str1 = MyGlobals.str1.Remove(MyGlobals.str1.Length - 1);
                    }
                    else
                        MyGlobals.str1 += e.KeyChar;
            }
            else
                textBox2.Text = " ";       
        }

        private void bKinect_Click(object sender, EventArgs e)
        {
            uPanel.KinectConnection = !uPanel.KinectConnection;
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            uPanel.VitesseMaxCourante = uPanel.VitesseMaxCourante + 10;
            Console.WriteLine(uPanel.VitesseMaxCourante);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            uPanel.AccelerationMaxCourante = uPanel.AccelerationMaxCourante + 10;
            Console.WriteLine(uPanel.AccelerationMaxCourante);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            uPanel.VitesseMaxCourante = uPanel.VitesseMaxCourante - 10;
            Console.WriteLine(uPanel.VitesseMaxCourante);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            uPanel.AccelerationMaxCourante = uPanel.AccelerationMaxCourante - 10;
            Console.WriteLine(uPanel.AccelerationMaxCourante);
        }

        private void IDAcc_Click(object sender, EventArgs e)
        {
            uPanel.DecelerationMaxCourante = uPanel.DecelerationMaxCourante + 10;
            Console.WriteLine(uPanel.DecelerationMaxCourante);
        }

        private void DDAcc_Click(object sender, EventArgs e)
        {
            uPanel.DecelerationMaxCourante = uPanel.DecelerationMaxCourante - 10;
            Console.WriteLine(uPanel.DecelerationMaxCourante);
        }
            
        private void LargeControl_Click(object sender, EventArgs e)
        {
            LargeControl f2 = new LargeControl();
            f2.Show(); // Shows form LargeControl
        }

        private void Manip_25_Click(object sender, EventArgs e)
        {
            //            Manip_25.Enabled = false;
            FApiBC9020 m25 = new FApiBC9020();
            m25.Show();
            //            Manip_25.Enabled = true;
        }

        private void bManip25_Click(object sender, EventArgs e)
        {
            

            bool createdNew;
//            Mutex mutex25 = new Mutex(true, this.GetType().GUID.ToString(), out createdNew);
            Mutex mutex25 = new Mutex(true,"Manip25", out createdNew);

            if (createdNew)
            {
                if (uPanel.Choix[uPanel.NCSimulation].Etat)
                    FApiBC9020.simulation_BC9020 = true;

                FApiBC9020 m25 = new FApiBC9020();
                m25.FormClosed += (sender2, args) => mutex25.Close();
                m25.Show(this); // Shows Form Manip. 25 
//                    if (FApiBC9020.simulation_BC9020)
//                        uPanel.Choix[uPanel.NCSimulation].Etat = true;
            }
            else
            {
                MessageBox.Show("Application est déjà en cours d'exécution");
                mutex25.Close();
            }
        }

        private void bManip27_Click(object sender, EventArgs e)
        {
            bool createdNew;
//            Mutex mutex27 = new Mutex(true, this.GetType().GUID.ToString(), out createdNew);
            Mutex mutex27 = new Mutex(true, "Manip27", out createdNew);

            if (createdNew)
            {
                if (uPanel.Choix[uPanel.NCSimulation].Etat) // <============================
                    FManip27Main.simulation_Manip27 = true;    // <============================

                FManip27Main m27 = new FManip27Main();
                m27.FormClosed += (sender2, args) => mutex27.Close();
                m27.Show(this); // Shows Form Manip. 27
            }
            else
            {
                MessageBox.Show("Application est déjà en cours d'exécution");
                mutex27.Close();
            }

        }


        private void bGalilM27_Click(object sender, EventArgs e)
        {
          //  uPanel.Choix[uPanel.NCGalil].Etat = !uPanel.Choix[uPanel.NCGalil].Etat;
            uPanel.Choix[uPanel.NCGalilM27].Etat = !uPanel.Choix[uPanel.NCGalilM27].Etat; // Code & JD 016.05.11 

            uPanel.Choix[uPanel.NCGalil].Etat = false; //Code 016.05.12
            uPanel.ChoixGalilFront = false; //Code 016.05.12
            uPanel.ChoixGalilBack = false; //Code 016.05.12



            if (bGalilM27.BackColor == System.Drawing.Color.Lime || bGalilM27.BackColor == System.Drawing.Color.Fuchsia)  //Code 016
            {
                bGalilM27.BackColor = System.Drawing.Color.Red;
                label8.Text = "";

            }
            else
            {
                if (uPanel.Choix[uPanel.NCSimulation].Etat)
                {
                    bGalilM27.BackColor = System.Drawing.Color.Fuchsia;

                    /*
                    //bGalilM27.BackColor = System.Drawing.Color.Red;
                    bGalil.BackColor = System.Drawing.Color.Red;
                    bGalilFront.BackColor = System.Drawing.Color.Red;
                    bGalilBack.BackColor = System.Drawing.Color.Red;*/
                }
                else
                {
                    bGalilM27.BackColor = System.Drawing.Color.Lime;
                   /* //bGalilM27.BackColor = System.Drawing.Color.Red;
                    bGalil.BackColor = System.Drawing.Color.Red;
                    bGalilFront.BackColor = System.Drawing.Color.Red;
                    bGalilBack.BackColor = System.Drawing.Color.Red;*/
                }
                label8.Text = "Galil M27";

            }
        }

        private void closeMainFrom()
        {
        }

        private void bGo900_Click(object sender, EventArgs e)
        {
            uPanel.ModeTest = !uPanel.ModeTest;
            if (!uPanel.ModeTest)
                uMTasks.Work[5].StateNo = 1;
            else
            {
                uMTasks.Work[5].StateNo = 900;

            }
        }

        private void bTest2016_Click(object sender, EventArgs e)    //Code 016
        {
            Test2016 f1 = new Test2016();
            f1.ShowDialog();
        }

        private void Forms_Enter(object sender, EventArgs e)
        {

        }

        private void button5_Click_2(object sender, EventArgs e)
        {

        }





        private void testlabel_Click(object sender, EventArgs e)
        {


            MessageBox.Show(testlabel.Text);
        }

        private void bZoom_Click(object sender, EventArgs e)
        {
                 
        }

        private void bComm_Click(object sender, EventArgs e)
        {
            FChat f1 = new FChat();
            f1.ShowDialog();
        }

        private void bResetGalil_Click(object sender, EventArgs e)
        {

            // Code 016
            bGalilM27.BackColor = System.Drawing.Color.Red;

            if (bGalil.BackColor != System.Drawing.Color.Red)
            {
                this.bGalil.PerformClick();
            }

            if (bGalilFront.BackColor != System.Drawing.Color.Red)
            {
                this.bGalilFront.PerformClick();
            }
            if (bGalilBack.BackColor != System.Drawing.Color.Red)
            {
                this.bGalilBack.PerformClick();
            }


            textBox3.Text = "";
            textBox2.Text = "";
            label8.Text = "";
        }

 





     }  // partial class FPiaget
} // end of namespace
