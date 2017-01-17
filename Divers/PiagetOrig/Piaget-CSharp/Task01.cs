using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Piaget_CSharp
{
    class Task01
    {
        public void Task01c()
        {
            const int TaskNumber = 1;
            uMTasks.ActiveTask = TaskNumber;

            switch (uMTasks.Work[TaskNumber].StateNo)
            {
                //-----------------------------------------------------------------  
                case
                1 : uMTasks.SleepAGN(0.8F);

                    break;
                case
                2:
                    if(uPanel.Choix[uPanel.NCMusique].Etat)
                        System.Media.SystemSounds.Beep.Play();
                    uPiaget.GoNext();
                    break;
                case
                3:  uPiaget.GoState(1);
                    break;

                default:
                    {
                        uPanel.MessageErreur = "Task" + TaskNumber.ToString() + " - Line missing: " + uMTasks.Work[TaskNumber].StateNo.ToString();// uPanel.MessageErreur.Length;
                    } break;
                //-------------------------------------------------------------------
                /*
                case

                    1:
                    uMTasks.SleepAGN(0.41F);     // 0.4 + TaskNumber*0.01 secondes .. ou n'importe quoi d'autre
                    break;
                case

                    2:
                    uPiaget.GoState(1000);
                    break;
                case





                    1000: uPiaget.GoState(1); break;
                default:
                    {
                        uPanel.MessageErreur = "Task" + TaskNumber.ToString() + " - Line missing: " + uMTasks.Work[TaskNumber].StateNo.ToString();// uPanel.MessageErreur.Length;
                    } break;
                    */
            } // end switch

        } // end void Task01c


    }
}
