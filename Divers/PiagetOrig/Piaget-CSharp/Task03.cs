using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Piaget_CSharp
{
    class Task03   //  reads keyboard  Copyright HESSO.HEIG-VD.iAi.LaRA 1998, 2009-, JD Dessimoz 14.7.2009, Yverdon-les-Bains
    {
        /*
         * Lire clavier - read keyboard
         */
        public void Task03c()
        {
            const int TaskNumber = 3;
            uMTasks.ActiveTask = TaskNumber;

            switch (uMTasks.Work[TaskNumber].StateNo)
            { 
                case
                1 :     uMTasks.SleepAGN(0.03F); // s
                        break;  
                case
                2 :
                        //     extern void ToggleEtatSI(int NS);
                        if ((uPanel.CarLu=='d')||(uPanel.CarLu=='D'));// ToggleEtatSI(1);//{SignauxIn[NSDemarrer].EtatVF  = true ;}
                        if (uPanel.CarLu=='l')
                            uParam.LireParametres();
                        if (uPanel.CarLu=='n')
                        {   uPanel.LireFichierReserve=true;
                            uParam.LireParametres();
                        };
                        if (uPanel.CarLu=='h')uParam.SauverParametres();
                          //    if (CarLu=='r'){Initialise=false;}
                        if (uPanel.CarLu=='s')
                        {   uPanel.Choix[uPanel.NCSimulation].Etat=! uPanel.Choix[uPanel.NCSimulation].Etat;
                            FPiaget.CheckSupportPhysiqueES();
                        }
                        if (uPanel.CarLu=='a'){uPanel.Choix[uPanel.NCMusique].Etat=! uPanel.Choix[uPanel.NCMusique].Etat;}
                        
                        if ((uPanel.CarLu=='y')||(uPanel.CarLu=='Y'))uMTasks.Work[uPanel.NTVision].TaskStatus = uMTasks.tPhase.Demandee;
                        
                        if (uPanel.CarLu=='z')uPanel.Choix[uPanel.NCStepSound].Etat=! uPanel.Choix[uPanel.NCStepSound].Etat;

                        if (uPanel.CarLu=='b')uPanel.Choix[uPanel.NCVisionContinue].Etat=! uPanel.Choix[uPanel.NCVisionContinue].Etat;

                        if ((uPanel.CarLu=='c')||(uPanel.CarLu=='C'))uPanel.Choix[uPanel.NCCalibration].Etat=! uPanel.Choix[uPanel.NCCalibration].Etat;
 
                        if ((uPanel.CarLu=='+')||(uPanel.CarLu=='-'))
                        {   uPanel.DeltaTPas=1.5F;
                            uMouv.PasGauche=true; uMouv.SensGauche=(uPanel.CarLu=='+');
                            uMouv.PasDroit =true; uMouv.SensDroit=(uPanel.CarLu=='+');
                            uMTasks.Work[uPanel.NTPas].TaskStatus = uMTasks.tPhase.Demandee;
                        }

                        uPiaget.GoNext();
                        break;  
                case
                3:
                    if (uPanel.Done1)
                    if ((uPanel.CarLu!='q') && (uPanel.CarLu!=',')) {
                        uPanel.Done1=false;
                       /* if (FPiaget.ActiveForm != null) tBControl.Text = "";*/
                    }// Form1->MControl->Lines->Text = "                                ";
                    
                    if (uPanel.CarLu == 'q')
                    {
                        if (uPanel.Done1 == true) FPiaget.ActiveForm.Close();// Controls["BQuit"];
                        else
                        { uPanel.Done1 = true;
                        ///*if (FPiaget.ActiveForm != null) */FPiaget.ActiveForm.Controls["*/tBControl"].Text = "Voulez-vous vraiment quitter (q) ?";
                        }
                    }
                    uPiaget.GoNext();
                    break;  
                case
                4:
                    if ((uPanel.CarLu == '*') || (uPanel.CarLu == '/')){
                        uPanel.Mouvement.NPas=50;
                        uPanel.Mouvement.VitesseMaxM = uPanel.VitesseMaxCourante;
                        uPanel.Mouvement.Etat = uPanel.tEtat.AFaire;
                        if (uPanel.CarLu == '*'){
                            uPanel.Mouvement.IncrGauche = 1;
                            uPanel.Mouvement.IncrDroit = 1;
                        }
	                    else{
                            uPanel.Mouvement.IncrGauche = -1;
                            uPanel.Mouvement.IncrDroit = -1;
                        } // (* if *)
                        uMTasks.Work[uPanel.NTMouvementPTP].TaskStatus = uMTasks.tPhase.Demandee;
                    }  // (* '*', '/'   *)

                    uPiaget.GoNext();
                    break;  
                case
                5 :/*
                    * Deplacement relatif
                    */
                    switch (uPanel.CarLu)       {      
                        case
                        't':    // (* avance 10 cm *)
                                if (uPanel.Choix[uPanel.NCCalibration].Etat)
                                    uMouv.P0RobotFutur.ds = uPanel.CalibrationDs; //(*DistancePourCalibration*)
                                else uMouv.P0RobotFutur.ds=10;
                                uMouv.LancerMouvement(uPanel.tModeDeMouvement.MDMds, uMouv.P0RobotFutur);
                                // (*  t *)
                                break;  

                         //Code 016.02.24
                        /*case

                        'T':   // (* pivote … gauche de 22.5 degr‚s autour du bord gauche *)
                            uMouv.P0RobotFutur.RayonTrajectoire=-15; //(* cm; <> DemiEcartRouesExt*);
                            if (uPanel.Choix[uPanel.NCCalibration].Etat)
                                uMouv.P0RobotFutur.AngleTrajectoire = uPanel.CalibrationAngle;
                            else
                                uMouv.P0RobotFutur.AngleTrajectoire=23 ;    // (* 45 div 2 *)
                            uMouv.LancerMouvement(uPanel.tModeDeMouvement.RotExc, uMouv.P0RobotFutur);
                            break;*/

                        case

                          'T':   // (* pivote … gauche de 22.5 degr‚s autour du bord gauche *)
                            uMouv.P0RobotFutur.RayonTrajectoire = 15; //(* cm; <> DemiEcartRouesExt*);

                            if (uPanel.Choix[uPanel.NCCalibration].Etat)
                                uMouv.P0RobotFutur.AngleTrajectoire = -uPanel.CalibrationAngle;

                            else
                                uMouv.P0RobotFutur.AngleTrajectoire = -23;    // (* 45 div 2 *)


                            uMouv.LancerMouvement(uPanel.tModeDeMouvement.RotExc, uMouv.P0RobotFutur);
                            break;  



                        case
                        'v':  //   (* recule 10 cm *)
                            if (uPanel.Choix[uPanel.NCCalibration].Etat)
                                uMouv.P0RobotFutur.ds = -uPanel.CalibrationDs;
                            else uMouv.P0RobotFutur.ds=-10;
                                uMouv.LancerMouvement(uPanel.tModeDeMouvement.MDMds, uMouv.P0RobotFutur);
                            //   (* V *)
                            break;


                      /*  case
                        'V':   // (* pivote arriŠre droite de 22.5 degr‚s autour du bord droit *)
                            uMouv.P0RobotFutur.RayonTrajectoire = 15; //(* cm; <> DemiEcartRouesExt*);
                            if (uPanel.Choix[uPanel.NCCalibration].Etat)
                                uMouv.P0RobotFutur.AngleTrajectoire = uPanel.CalibrationAngle;
                            else
                                uMouv.P0RobotFutur.AngleTrajectoire = 23;   //  (* 45 div 2 *)
                            uMouv.LancerMouvement(uPanel.tModeDeMouvement.RotExc, uMouv.P0RobotFutur);
                            //   (* V *)
                            break;  */
                        case
                        'V':   // (* pivote arriŠre droite de 22.5 degr‚s autour du bord droit *)
                            uMouv.P0RobotFutur.RayonTrajectoire=-15; //(* cm; <> DemiEcartRouesExt*);
                            if (uPanel.Choix[uPanel.NCCalibration].Etat)
                                   uMouv.P0RobotFutur.AngleTrajectoire = -uPanel.CalibrationAngle;
                            else
                                uMouv.P0RobotFutur.AngleTrajectoire = -23;   //  (* 45 div 2 *)
                            uMouv.LancerMouvement(uPanel.tModeDeMouvement.RotExc, uMouv.P0RobotFutur);
             	            //   (* V *)
                            break;  
                        /*case
                        'f':  //  (* tourne … gauche de 22.5 degr‚s *)
                            if (uPanel.Choix[uPanel.NCCalibration].Etat)
                                uMouv.P0RobotFutur.ThetaRobotDegres =uMouv.P0Robot.ThetaRobotDegres + uPanel.CalibrationAngle;
                            else
                                uMouv.P0RobotFutur.ThetaRobotDegres = Convert.ToInt32(uMouv.P0Robot.ThetaRobotDegres + 22.5);   //  (* 45 div 2 *)
                            uMouv.LancerMouvement(uPanel.tModeDeMouvement.Rot, uMouv.P0RobotFutur);
                            //   (* f *)
                            break;  */

                        case
                        'f':  //  (* tourne … gauche de 22.5 degr‚s *)
                            if (uPanel.Choix[uPanel.NCCalibration].Etat)
                                uMouv.P0RobotFutur.ThetaRobotDegres = uMouv.P0Robot.ThetaRobotDegres - uPanel.CalibrationAngle;
                            else
                                uMouv.P0RobotFutur.ThetaRobotDegres = Convert.ToInt32(uMouv.P0Robot.ThetaRobotDegres - 22.5);   //  (* 45 div 2 *)
                            uMouv.LancerMouvement(uPanel.tModeDeMouvement.Rot, uMouv.P0RobotFutur);
                            //   (* f *)
                            break;  
                    /*      case

                       'F':  //   (* pivote arrière gauche de 22.5 degrés autour du bord gauche *)
                            uMouv.P0RobotFutur.RayonTrajectoire=-15; // (* cm; <> DemiEcartRouesExt*);
                            if (uPanel.Choix[uPanel.NCCalibration].Etat)
                                uMouv.P0RobotFutur.AngleTrajectoire = -uPanel.CalibrationAngle;
                            else
                                uMouv.P0RobotFutur.AngleTrajectoire = -23; // (* 45 div 2 *)
                            uMouv.LancerMouvement(uPanel.tModeDeMouvement.RotExc, uMouv.P0RobotFutur);
             	            //  (* F *)
                            break;*/
                        case
                         'F':  //   (* pivote arrière gauche de 22.5 degrés autour du bord gauche *)
                            uMouv.P0RobotFutur.RayonTrajectoire=15; // (* cm; <> DemiEcartRouesExt*);
                            if (uPanel.Choix[uPanel.NCCalibration].Etat)
                                uMouv.P0RobotFutur.AngleTrajectoire = uPanel.CalibrationAngle;
                            else
                                uMouv.P0RobotFutur.AngleTrajectoire = 23; // (* 45 div 2 *)
                            uMouv.LancerMouvement(uPanel.tModeDeMouvement.RotExc, uMouv.P0RobotFutur);
             	            //  (* F *)
                            break;  
                        case
                        'g':  //   (* tourne … droite de 22.5 degrés *)
                            if (uPanel.Choix[uPanel.NCCalibration].Etat)
                                uMouv.P0RobotFutur.ThetaRobotDegres = uMouv.P0Robot.ThetaRobotDegres + uPanel.CalibrationAngle; //(* 45 div 2 *)
                            else
                                uMouv.P0RobotFutur.ThetaRobotDegres = (float)(uMouv.P0Robot.ThetaRobotDegres + 22.5); // (* 45 div 2 *)   
                         
                                uMouv.LancerMouvement(uPanel.tModeDeMouvement.Rot, uMouv.P0RobotFutur);
             	            //   (* g *)
                            break;

                        //Code 016.02.24
                       /* case
                        'G':  //   (* pivote … droite de 22.5 degrés autour du bord droit *)
                            uMouv.P0RobotFutur.RayonTrajectoire = 15; //(* cm; <> DemiEcartRouesExt*);
                            if (uPanel.Choix[uPanel.NCCalibration].Etat)
                                uMouv.P0RobotFutur.AngleTrajectoire = -uPanel.CalibrationAngle;
                            else
                                uMouv.P0RobotFutur.AngleTrajectoire = -23;  //(* 45 div 2 *)
                            uMouv.LancerMouvement(uPanel.tModeDeMouvement.RotExc, uMouv.P0RobotFutur);
             	            //   (* G *)
                            break;  */

                        case
                        'G':  //   (* pivote … droite de 22.5 degrés autour du bord droit *)
                            uMouv.P0RobotFutur.RayonTrajectoire = -15; //(* cm; <> DemiEcartRouesExt*);
                            if (uPanel.Choix[uPanel.NCCalibration].Etat)
                                uMouv.P0RobotFutur.AngleTrajectoire = +uPanel.CalibrationAngle;
                            else
                                uMouv.P0RobotFutur.AngleTrajectoire = +23;  //(* 45 div 2 *)
                            uMouv.LancerMouvement(uPanel.tModeDeMouvement.RotExc, uMouv.P0RobotFutur);
                            //   (* G *)
                            break;  
                            //  'i', 'I':  //   (*    va au centre  *)
                        case  'i':  //   (*    va au centre  *)
                        case  'I':  // no break, same case
                            uMouv.P0RobotFutur.x = 100;
                            uMouv.P0RobotFutur.y = 150;
                            uMouv.P0RobotFutur.ThetaRobotDegres = 90;
                            uMouv.LancerMouvement(uPanel.tModeDeMouvement.RXY, uMouv.P0RobotFutur);
             	            //   (* i, I *)
                            break;
                        }//End switch (uPanel.CarLu) 
                        uPiaget.GoNext();
                        break;  
                case
                6: if (uPanel.CarLu == ' ')
                    // à compléter *******  uTask05i.V5CarLu = ' ';
                    uPanel.V5CarLu = ' ';
                    uPiaget.GoNext();
                    break;  
                case
                7:  if (uPanel.CarLu == 'r')
                    {    
                        uPiaget.FermerLiaisons();
                        uPanel.InitialiserLaser = false;
                        uPiaget.GoNext();
                    }
                    else
                    uPiaget.GoState(10);
                    break;  
                case
                8 :
                    uMTasks.SleepAGN(1);  // délai pour reset
                    break;  
                case
                9:
                    uPanel.Initialise = false;  // fin du  reset
                    uPiaget.GoNext();
                    break;  
                case
                10 :
                    uPanel.CarLu = ',';

                    uPanel.InteractionSouhaitee = true;
                    //   Work[TaskNumber].StateNo=1;
                    uPiaget.GoState(1);
                    break;

                    //
                default:
                    {
                        uPanel.MessageErreur = "Task" + TaskNumber.ToString() + " - Line missing: " + uMTasks.Work[TaskNumber].StateNo.ToString();// uPanel.MessageErreur.Length;
                    } break;
            } // end switch (uMTasks.Work[TaskNumber].StateNo)

        } // end void Task03c()


    } // end Class Task03
}
