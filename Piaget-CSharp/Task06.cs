using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


// using BC9020.FApiBC9020;



namespace Piaget_CSharp
{
    class Task06
    {
        public void Task06c()
        {
            const int TaskNumber = 6;
            uMTasks.ActiveTask = TaskNumber;

            switch (uMTasks.Work[TaskNumber].StateNo)
            {
                case
                    1:
                    //uMTasks.SleepAGN(0.61F);     // 0.4 + TaskNumber*0.01 secondes .. ou n'importe quoi d'autre
                    uMTasks.Work[TaskNumber].StateNo = 2;
                    break;
                case
                2:
                    if ((!uPanel.Choix[uPanel.NCSimulation].Etat) && (uPanel.SupportPhysiqueES) && (uPanel.Choix[uPanel.NCBeckhoff].Etat))
                    {
                        uMTasks.Work[TaskNumber].TaskStatus = uMTasks.tPhase.Demandee;
                        uMTasks.Work[TaskNumber].StateNo = 3;
                    }
                    else
                    {
                        if (uMTasks.Work[TaskNumber].TaskStatus == uMTasks.tPhase.Faite)
                        {
                            uMTasks.Work[TaskNumber].TaskStatus = uMTasks.tPhase.EnAction;

                            ThBeck.BeckhoffDelegate beckhoff_off = new ThBeck.BeckhoffDelegate(ThBeck.Beckhoff);
                            beckhoff_off.BeginInvoke("BC9020_OFF", null, null); //retour: uMTasks.tPhase.Suspendue!

                            uMTasks.Work[TaskNumber].StateNo = 3;
                        }
                        else
                        {
                            uMTasks.Work[TaskNumber].StateNo = 4;
                        }
                    }
                    break;

                case
                3: 
                        switch (uMTasks.Work[TaskNumber].TaskStatus)
                        { 
                            case
                            uMTasks.tPhase.Demandee: uMTasks.Work[TaskNumber].TaskStatus = uMTasks.tPhase.EnAction;

                                ThBeck.BeckhoffDelegate beckhoff = new ThBeck.BeckhoffDelegate(ThBeck.Beckhoff);
                                beckhoff.BeginInvoke("BC9020_ON", null, null);

                                break; 
                            case
                            uMTasks.tPhase.Faite: //uMTasks.Work[TaskNumber].StateNo = 20;
                            uPiaget.GoNext();
                                        break; 
                            case
                            uMTasks.tPhase.EnAction: uMTasks.Work[TaskNumber].StateNo = 3;
                                        break; 
                            case
                            uMTasks.tPhase.Suspendue: 

                                  // uPiaget.GoNext();
                                   uMTasks.Work[TaskNumber].StateNo = 4;
                                

                                
                            break;

//                            default: ;
                        }

               
                break;
                case
                4:
                    uPiaget.GoState(1000);
                    break;
                case



                    1000: uPiaget.GoState(1); break;
                default:
                    {
                        uPanel.MessageErreur = "Task" + TaskNumber.ToString() + " - Line missing: " + uMTasks.Work[TaskNumber].StateNo.ToString();// uPanel.MessageErreur.Length;
                    } break;
            } // end switch

        } // end void Task06c
      
    }// end of Task06
}
