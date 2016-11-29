using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Piaget_CSharp
{
    class Task08
    {
        //public uPanel uPanneauAux = new uPanel();
        public void Task08c()
        {
            const int TaskNumber = 8;
            uMTasks.ActiveTask = TaskNumber;

            switch (uMTasks.Work[TaskNumber].StateNo)
            {
                case

                1:

                    if ((uMTasks.Work[TaskNumber].TaskStatus == uMTasks.tPhase.Demandee) && uPanel.Phase != uPanel.tPhase.GameOver)
                    {
                        uMTasks.Work[TaskNumber].TaskStatus = uMTasks.tPhase.EnAction;
                        uMTasks.Work[TaskNumber].V4MouvementGalilFait = false;
                        uMouv.CinematiqueInverse();

                        switch (uPanel.Mouvement.ModeDeMouvement)
                        {
                            case uPanel.tModeDeMouvement.XY:
                                uMTasks.Work[TaskNumber].StateNo = 20;
                                break;
                            case uPanel.tModeDeMouvement.MDMds:
                                uMTasks.Work[TaskNumber].StateNo = 40;     // 20
                                break;
                            case uPanel.tModeDeMouvement.Rot:
                                uMTasks.Work[TaskNumber].StateNo = 50;     // 20
                                break;
                            case uPanel.tModeDeMouvement.RotExc:
                                uMTasks.Work[TaskNumber].StateNo = 58;     //  15
                                break;
                        } // fin switch  uPanel.Mouvement.ModeDeMouvement       
                        if (uPanel.Mouvement.ModeDeMouvement == uPanel.tModeDeMouvement.RotExc)
                                uMTasks.Work[TaskNumber].StateNo = 15;
                        else    uMTasks.Work[TaskNumber].StateNo = 20;
                    }
                    else uPiaget.GoNext();
                    break;
                case
                   
                2:
                    uMTasks.SleepAGN(0.05F);
                    //uPiaget.GoState(1000);
                    break;
                //uPanel.ServoCommande
                //uPanel.tServoCommande.ServoGalilEthernet
               case
               3: 
                switch (uPanel.ServoCommande)
                {
                    case uPanel.tServoCommande.ServoGalilEthernet:
                        #if (!SimulationOnly)
                        if (uPanel.Choix[uPanel.NCSimulation].Etat == false) uPiaget.LireErreurGalil();
                        #endif
                        break;
                }  // end case Servocommande   ********************
                uPanel.MessageErreur = "  Erreurs gauche: " + uTasks.V8ErreurGauche.ToString() +
                                       "  et droite : " + uTasks.V8ErreurDroite.ToString();
                uTasks.V8Compteur++;
                if (uTasks.V8Compteur >= uTasks.V8NCycles)
                {
                    uTasks.V8TimeOut = false;
                    uTasks.V4MouvementGalilFait = true;
                }
                uPiaget.GoState(1);
                break;  case
                15:
                    uMouv.CalculerMouvementCourbe();
                    uPiaget.GoState(60);
                    break;  case
                20:
                    uMouv.CalculerMouvementDroit();

                    //uMouv.EmpilerMouvement(uPanel.Mouvement, uMouv.IndicePileMouvement);
                    uMouv.EmpilerMouvement();

                    uMTasks.Work[TaskNumber].StateNo = 50;

                        break;  case
                40:  // MDMds
                    uMouv.CalculerMouvementDroit();
                    uMTasks.Work[TaskNumber].StateNo=60;

                        break;  case
                50:  //  Rot ou partie Rot de XY
                    uPanel.Mouvement.ModeDeMouvement=uPanel.tModeDeMouvement.Rot;   
                    uMouv.CalculerMouvementRotatif();  //(* fait en premier *)
                    uMTasks.Work[TaskNumber].StateNo = 60;
                    break;  case
                58:  // RotExc
                    uMouv.CalculerMouvementCourbe();
                    uPiaget.GoState(60);
                        break;  case
                60:  // lancement de mouvement
                        if (!(uMTasks.Work[uPanel.NTMouvementPTP].TaskStatus == uMTasks.tPhase.EnAction)) // (*EnMouvementPTP*)
                            //  (* prˆt pour un mouvement PTP? *)
                        {   					     //	  (*   impulsions *)
                            uMTasks.Work[uPanel.NTMouvementPTP].TaskStatus = uMTasks.tPhase.Demandee;
                            //  (*    writeln(DemandeDUnPas, PasFait, NStepsMouvementPTP:6);  *)
                            uMTasks.Work[TaskNumber].StateNo = 70;
                        }
                        break;  case
                70: if (uMTasks.Work[uPanel.NTMouvementPTP].TaskStatus == uMTasks.tPhase.Faite)
                    {
                        // Mouvement.Etat=Fait;
                        uMTasks.Work[TaskNumber].StateNo = 72;  //  (* mvmt PTP terminé *)
                    }
                        break;  case
                72: uPiaget.GoState(180);
                         break;  case
                180:
                    uMouv.MiseAJourPosition();
                    uPanel.Mouvement.Etat = uPanel.tEtat.Fait;
                    uMTasks.Work[TaskNumber].TaskStatus = uMTasks.tPhase.Faite;
                    uMTasks.Work[TaskNumber].StateNo = 1;
                    break;case
                    
                1000: uPiaget.GoState(1); break;
                default:
                    {
                        uPanel.MessageErreur = "Task" + TaskNumber.ToString() + " - Line missing: " + uMTasks.Work[TaskNumber].StateNo.ToString();// uPanel.MessageErreur.Length;
                    } break;
            } // end switch

        } // end void Task08c


    }// end of Task08
}
