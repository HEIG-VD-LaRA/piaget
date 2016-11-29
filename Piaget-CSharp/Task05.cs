using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;


//**for speak Code 016.02.29
using System.Speech;
using System.Speech.Synthesis;

namespace Piaget_CSharp
{
  //**  class Task05
           public partial class uPiaget  //***

    {
        public void Task05c()
        {
            const int TaskNumber = 5;
            uMTasks.ActiveTask = TaskNumber;


            SpeechSynthesizer reader = new SpeechSynthesizer();//**for speak Code 016.02.29


            switch (uMTasks.Work[TaskNumber].StateNo)
            { case

                    1:
                    SleepAGN(0.45F);     // 0.4 + TaskNumber*0.01 secondes .. ou n'importe quoi d'autre
                    break;
                case

                    2: SleepAGN(1); break;
                case
                   3: SleepAGN(1); break;
                case
                   4: SleepAGN(1); break;
                case
                   5: SleepAGN(1); break;
                case
                   6: SleepAGN(1); break;
                case
                   7: GoState(1000); break;

                ////////////////////////////////////////// CASE 900 //////////////////////////////////////////
                case
                  900:
                   
                /*    for (int i = 1; i <= 2; i++)
                    {
                      //  Console.WriteLine(i);
                    }
                 */

                // Cliquer sur un bouton de l'interface
                    CliquerBouton("bSO4");
            //        CliquerBouton("bLaserC");
                    /*
                    uMouv.P0Robot.x = 20;
                    uMouv.P0Robot.y = 30;
                    uMouv.P0Robot.ThetaRobotDegres = 90;
                     */
                     reader.Dispose();
                reader = new SpeechSynthesizer();
                reader.SpeakAsync("Hello,I am ready !");
      //          string t="Hello,I am ready !";



   
               // frm2.testlabel.Text = ("Hello,I am ready !");
                        GoNext();
                        break;







                ////////////////////////////////////////// END OF CASE 900 //////////////////////////////////////////


                case
                901: 

                        break;

                case
                    1000: GoState(1); break;
                default:
                    {
                        uPanel.MessageErreur = "Task" + TaskNumber.ToString() + " - Line missing: " + uMTasks.Work[TaskNumber].StateNo.ToString();// uPanel.MessageErreur.Length;
                    } break;
            } // end switch

        } // end void Task05c


    } // end class Tak05
}
