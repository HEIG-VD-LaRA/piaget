using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Piaget_CSharp
{
    class Task04
    {   /*
         * Mouvements PTP - move point to point
         */
        public void Task04c()
        {
            const int TaskNumber = 4;
            uMTasks.ActiveTask = TaskNumber;

            switch (uMTasks.Work[TaskNumber].StateNo)
            {
                //-----------------------------------------------------------------------------------------------
                case
                1:
                        if (uMTasks.Work[TaskNumber].TaskStatus == uMTasks.tPhase.Demandee)
                        {
                            uMTasks.Work[TaskNumber].StateNo = 15;
                            uMTasks.Work[TaskNumber].TaskStatus = uMTasks.tPhase.EnAction;
                            uTasks.V4MouvementGalilFait = false;
                        }
                        break;
                case
                 15://--------------------------------------------------------------------------------
                        if (uPanel.Mouvement.NPas > 0)
                        {   // (* demande de pas et calcul de durée *)
                        
                            uMouv.CalculerImpulsions(ref uMouv.PasGauche, ref uMouv.SensGauche, ref uMouv.PasDroit, ref uMouv.SensDroit);

                            if ((!uPanel.Choix[uPanel.NCSimulation].Etat) && (uPanel.Mouvement.NPas > 0))
                            switch (uPanel.ServoCommande)
                            {
                                case uPanel.tServoCommande.ServoGalilEthernet:
                                    #if (!SimulationOnly)
                                    uGalil.LancerMouvementGalil(uPanel.Mouvement);
                                    #endif
                                    uTasks.V4MouvementGalilFait = false;
                                    break;

                            } // fin switch (uPanel.ServoCommande)
                        } // fin if Mouvement.NPas>0

                        uMTasks.Work[TaskNumber].StateNo = 20;
                        break;
                case
                20://--------------------------------------------------------------------------------

                        if ((uPanel.Mouvement.Etat == uPanel.tEtat.Fait) || (uPanel.Mouvement.NPas == 0)) uMTasks.Work[TaskNumber].StateNo = 50; //(* fin *)
                        else
                        {
                            uMouv.CalculerImpulsions(ref uMouv.PasGauche, ref uMouv.SensGauche, ref uMouv.PasDroit, ref uMouv.SensDroit);
                            //(*      Writeln(' mouv.NoPasCourant ', Mouvement.NoPasCourant:8,
                            //				              Mouvement.NPas:8);  *)

                            uMTasks.Work[TaskNumber].StateNo = 30;
                        } //(* if *)
                        break;
                case
                30://----------------------------------------------------------------------------- 
                        if (!(uMTasks.Work[uPanel.NTPas].TaskStatus == uMTasks.tPhase.EnAction)) //(*;PasEnCours *) then  (* prˆt pour un step? *)
                        {
                            uMTasks.Work[uPanel.NTPas].TaskStatus = uMTasks.tPhase.Demandee;
                            //   (*    writeln(DemandeDUnPas, PasFait, NStepsMouvementPTP:6);  *)
                            uPanel.DeltaTPas = uPanel.DeltaT;
                            uMTasks.Work[TaskNumber].StateNo = 40;
                        }
                        break;
                case
                40: //---------------------------------------------------------------------------
                        if (uMTasks.Work[uPanel.NTPas].TaskStatus == uMTasks.tPhase.Faite) // (*;PasFait*) then
                            uMTasks.Work[TaskNumber].StateNo = 20;  //  (* step termin‚ *)
                        break;
                case
                50: //--------------------------------------------------------------------------- 
                    //  (* attente de fin  *)
                        if (uPanel.Mouvement.NPas > 0)
                            uMTasks.Work[TaskNumber].StateNo = 60; //(* 55 ou 59 *)
                        else
                            uMTasks.Work[TaskNumber].StateNo = 150;
                        break;
                case
                 55://-------------------------------------------------------------------------
                         //*****        if  (MouvementFaitN(MoteurGauche))
                        uMTasks.Work[TaskNumber].StateNo = 59; //(*** Attention, tester autre axe si *)
                        //   (*rotation … gauche de rayon 15 cm environ...*)
                        break;
                case
                60: //------------------------------------------------------------------------
                        //-- uTasks.V4WaitingForEndOfMotion = true;
                        //  MessageErreur=" Waiting for end of motion ";
                        uTasks.V8TimeOut = false;
                        if (uGalil.TesterFinMouvementDApresErreur) uPiaget.GoState(79);
                        
                        else uPiaget.GoState(150);
                        break;
                case
                79: //------------------------------------------------------------------------
                        uTasks.V8Compteur = 0;
                        uPiaget.GoNext();
                        break;
                case
                80://------------------------------------------------------------------------
                        switch (uPanel.ServoCommande)
                        {
                            case uPanel.tServoCommande.ServoGalilEthernet:
                                #if (!SimulationOnly)
                                if (uPanel.Choix[uPanel.NCSimulation].Etat == false) uPiaget.LireErreurGalil();
                                #endif
                                break;

                        }  // end case uPanel.ServoCommande   ********************

                        if (uPanel.ModeRHYorOPYlow)
                            uTasks.V8ErreurMaxTemp = uTasks.V8ErreurMax;
                        else
                            uTasks.V8ErreurMaxTemp = uTasks.V8ErreurMaxOPY;

                        if ((Math.Abs(uTasks.V8ErreurGauche) + Math.Abs(uTasks.V8ErreurDroite)) < uTasks.V8ErreurMaxTemp)  // uPanel.ModeRHYorOPYlow
                        {
                            uPanel.MessageErreur = "  Erreurs gauche: " +
                                uTasks.V8ErreurGauche + "  et droite :" +
                                uTasks.V8ErreurDroite;
                            uPiaget.WriteErreurGalil();
                            uPiaget.GoState(260);
                        }     // ex 180
                        else uPiaget.GoState(82);
                        break;
                case
                 82: //----------------------------------------------------------------------
                        uMTasks.SleepAGN(uTasks.V8Duree / uTasks.V8NCycles);
                        break;
                case
                83: //----------------------------------------------------------------------
                        uTasks.V8Compteur++;
                        if (uTasks.V8Compteur >= uTasks.V8NCycles)
                            uPiaget.GoState(120);
                        else uPiaget.GoState(80);
                        break;
                case
                 120: //----------------------------------------------------------------------
                        uTasks.V8TimeOut = true;
                        uTasks.V8Compteur = 0;

                        if (uPanel.ServoCommande == uPanel.tServoCommande.ServoGalilEthernet)
                        {
                            #if (!SimulationOnly)
                            uGalil.ExecuterCommandeGalil("AB" + uTasks.ACR);      //     Abort
                            uTasks.warningAnsiString();
                            uGalil.ResetPositionGalil();
                            #endif
                            //    UtiliserCoordonneesAbsolues=false;  // suite en relatif
                        }

                        uPiaget.GoState(260);        // ex 180
                        break;
                case
                150: //----------------------------------------------------------------------
                        uMTasks.SleepAGN(uPanel.Mouvement.NPas * 0.00015); //(*********  Attente pour essais ...  ******)
                        break;
                case
                151: //----------------------------------------------------------------------
                        uPiaget.GoState(260);        // ex 180
                        break;
                case
                260://----------------------------------------------------------------------
                        uTasks.V4WaitingForEndOfMotion = false;
                        uTasks.V4MouvementGalilFait = true;

                        if (uMouv.IndicePileMouvement > 0)
                        {
                            //uMouv.PrendreMouvementSurPile(ref uPanel.Mouvement, ref uMouv.IndicePileMouvement);
                            uMouv.PrendreMouvementSurPile();
                            uMTasks.Work[TaskNumber].StateNo = 15;
                        }
                        else
                        {
                            uMTasks.Work[TaskNumber].TaskStatus = uMTasks.tPhase.Faite;
                            uMTasks.Work[TaskNumber].StateNo = 1;
                        } //(* if *)
                        break;
                //-----------------------------------------------------------------------------------------------
                /*
                case
                    1:
                    uMTasks.SleepAGN(0.61F);     // 0.4 + TaskNumber*0.01 secondes .. ou n'importe quoi d'autre
                    break;
                case

                    2:
                    uPiaget.uPiaget.GoState(1000);
                    break;
                case
                    1000: uPiaget.uPiaget.GoState(1); break;
                 */
                default:
                        {
                            uPanel.MessageErreur = "Task" + TaskNumber.ToString() + " - Line missing: " + uMTasks.Work[TaskNumber].StateNo.ToString();// uPanel.MessageErreur.Length;
                        } break;
            } // end switch (uMTasks.Work[TaskNumber].StateNo)

        } // end void Task04c


    } // end of Task04
}
