using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Piaget_CSharp
{
    class uTasks
    {

        string fileVoiceIn = "sound\\voicein.txt";
        string fileVoiceOut = "voiceout.txt";
        string exeVoiceDic = "sound\\ExSapi.exe";
        string Cam3D = "3dcam\\SwissRangerSampleGui.exe";
        string strHello;
        int nbStrHello = 4;
        int maxStrHelloLen = 1000;
        //ifstream is;

        public static bool V4MouvementGalilFait;
        public static bool V4WaitingForEndOfMotion;
        public static bool V8TimeOut;
        public static float V1Duree;
        public static float V2Duree;
        public static int V8Compteur, V8NCycles = 20;
        public static float V8Duree = 2;
        public static long  errd,errg, 
                            V8ErreurGauche, V8ErreurDroite, V8ErreurMax = 2 * 20,  // 70
                              V8ErreurMaxOPY = 2 * 100, V8ErreurMaxTemp;  // valeur à tester *****
        //char tempstring[100];
        int CR=13; // code ascii du "Enter" ou "Carriage return"
        public static string ACR;//AnsiString ACR=AnsiString::StringOfChar(CR,1);
        public static void warningAnsiString()
        {
           // if ((FPiaget.ActiveForm != null) && !FPiaget.ActiveForm.Controls["tBUser"].Text.Contains("AnsiString"))
            FPiaget.ActiveForm.Controls["tBUser"].Text = FPiaget.ActiveForm.Controls["tBUser"].Text + "To do UTasks.AnsiString" + Environment.NewLine;
        }

        public static string WriteGalilStatus()
        {
            if (uTasks.V4MouvementGalilFait)
            {
                if (!V8TimeOut)
                    return "Galil:Mouvmt fait";
                else
                    return "Galil:  Timeout  ";
            }
            else
            {
                if (!V4WaitingForEndOfMotion)
                    return "Galil:MvmtEnCours";
                else
                    return "Galil:Waiting....";
            }
            if (V8TimeOut) uPanel.MessageErreur = "Galil: Timeout";
            return " ";
        }

    }// end of UTasks
    
}
