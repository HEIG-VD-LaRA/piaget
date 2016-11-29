using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms; //***
using System.Drawing;


namespace Piaget_CSharp
{
public partial class FPiaget : Form   //***
 {                                    //***
 
 //   public class Task07
 //   {
        FPiaget FPiaget1;
        float oldX=50, oldY=50, newX, newY,newTRD,oldTRD;
        System.Drawing.SolidBrush sbDelete = new System.Drawing.SolidBrush(System.Drawing.Color.Green);
        System.Drawing.SolidBrush sbR = new System.Drawing.SolidBrush(System.Drawing.Color.Red);
        System.Drawing.SolidBrush sbW = new System.Drawing.SolidBrush(System.Drawing.Color.White);
        System.Drawing.SolidBrush sbB = new System.Drawing.SolidBrush(System.Drawing.Color.Blue);
        





    public void Task07c()
        {
          const int  TaskNumber=7;
          uMTasks.ActiveTask = TaskNumber;

          String LigneVide = "                                   ";

          int j;
          j = uPanel.OffsetLignesTaches;

          int NCarParLigne = 40; // N Caractères par ligne

          float DeltaT = 0.005F;




/////////////////////////


//////////////////

        
          //***************************************************************************************************************************************************
          //***************************************************************************************************************************************************
          // BEGIN BIG SWITCH
          //***************************************************************************************************************************************************
          //***************************************************************************************************************************************************
switch ( uMTasks.Work[TaskNumber].StateNo ){
    case 1:
                uMTasks.SleepAGN(0.4F);     // 0.3
                //   uMTasks1.SleepAGN(0.4F);     // 0.3
                break;
    
    case
    2:
                //     V7NoCycles++;
                //  if (V7NoCycles>V7NCyclesMax)
                //     V7NoCycles=0;
                //       if (FPiaget.ActiveForm !=null)
                //     FPiaget.ActiveForm.Activate();
                //   FPiaget1.Activate();
                uPiaget.GoState(78);
                break;

    //************************************************************************************************************************
    // Display : tBMemo1
    //************************************************************************************************************************
    case
    78:  
               uPanel.Message="Task No    Name         State"+LigneVide;

                for (int i=1; i<uPanel.NLignesVisibles+1; i++) 
                {
                    
                    uPanel.Message =
                        uPanel.Message.Insert((i) * NCarParLigne + 1, (i + j).ToString() + " " + uMTasks.Work[i + j].Name
                            + LigneVide);

                    uPanel.Message =
                            uPanel.Message.Insert((i)*NCarParLigne+23, (uMTasks.Work[i + j].StateNo).ToString() );

                    switch (uMTasks.Work[i+j].SleepingState)
                    {        
                        case true:
                                    uPanel.Message =
                                        uPanel.Message.Insert((i)*NCarParLigne+28, "T            ");
                                    break;
                        case false:
                                uPanel.Message =
                                    uPanel.Message.Insert((i)*NCarParLigne+28, "F            ");
                        break;
                    }// End switch (uMTasks.Work[i+j].SleepingState)

                    switch (uMTasks.Work[i + j].TaskStatus)
                    {
                        case uMTasks.tPhase.Demandee:
                            uPanel.Message =
                                uPanel.Message.Insert((i)*NCarParLigne+30, "Demandée " +LigneVide);
                            break;
                        case uMTasks.tPhase.EnAction:
                                uPanel.Message =
                                    uPanel.Message.Insert((i)*NCarParLigne+30, "EnAction");
                            break;
                        case uMTasks.tPhase.Faite:
                                uPanel.Message =
                                    uPanel.Message.Insert((i)*NCarParLigne+30, "Faite");
                            break;
                        case uMTasks.tPhase.Suspendue:
                                uPanel.Message =
                                    uPanel.Message.Insert((i)*NCarParLigne+30, "Suspendue");
                                break;
                    }// End switch (uMTasks.Work[i + j].TaskStatus)
                }// End for (int i=1; i<uPanel.NLignesVisibles+1; i++) 

               /* if (FPiaget.ActiveForm != null) FPiaget.ActiveForm.Controls["*/tBMemo1.Text = uPanel.Message;
                uPiaget.GoState(88);
                break;
    //************************************************************************************************************************
    //************************************************************************************************************************

    case
    88 : 
                uMTasks.SleepAGN(uPanel.DeltaT);break;

    //************************************************************************************************************************
    // Display : tBTicks & tBTicksPerSecond
    //************************************************************************************************************************
    case
    89:    
                uPanel.SystemTicks = System.DateTime.Now.Ticks;
                uPanel.SystemTicksRel = uPanel.SystemTicks - uPanel.InitialTicks;
                uPanel.Seconds = uPanel.SystemTicksRel / 10000000;

                if (uPanel.Seconds > 0)
                {

                   /* if (FPiaget.ActiveForm != null) FPiaget.ActiveForm.Controls["*/tBTicks.Text = Convert.ToString(uPanel.Ticks) + " ";
               
                    if (uPanel.Seconds <= 2){
                        //uPanel.TicksPerSecond = uPanel.Ticks / (uPanel.Seconds);
                        uPanel.V7TicksParSecondeEstime = uPanel.TicksPerSecond;
                    }
                        else uPanel.V7TicksParSecondeEstime =(long)(0.97 * uPanel.V7TicksParSecondeEstime + (1 - 0.97) * (uPanel.Ticks - uPanel.OldTicks));
                    double TicksTemp = (Int64) ( uPanel.V7TicksParSecondeEstime/1000);
                    
                   /* if (FPiaget.ActiveForm != null) FPiaget.ActiveForm.Controls["*/tBTicksPerSecond.Text =
                                                        Convert.ToString(uPanel.TicksPerSecond) + " / " +
                                                        Convert.ToString(uPanel.Seconds) + " / " +
                                                        Convert.ToString(TicksTemp) +
                                                            " k ";
                    uPanel.OldTicks = uPanel.Ticks;
                } // end if (uPanel.Seconds > 0)
                uPiaget.GoState(108);
                break;
    //************************************************************************************************************************
    //************************************************************************************************************************
/*
         * permet l'affichage du label 'tBTicks'
         */

        /* Extrait de code en C++ : SL2013
         * Form1->MTicks->Lines->Text=IntToStr(Ticks)+" ";
         * //Work[TaskNumber].StateNo=1;
         * Form1->MTaches->Lines->Text=Message;
         * GoState(98);
          break;*/
    case
    108: 
                uMTasks.SleepAGN(uPanel.DeltaT);   break;

    //************************************************************************************************************************
    // Display : tBControl
    //************************************************************************************************************************
    case//-----------------------------------------------------------------------------------------------------------------
    109: 
                uPanel.MessageErreur = " essai 109";
                uPiaget.WriteErreurGalil();
                if (uPanel.MessageErreur != "")tBControl.Text = uPanel.MessageErreur;
                if (uPanel.MessageUser != "") 
               // Form1.MUser.Lines.Text = uPanel.MessageUser;
                tBUser.Text = uPanel.MessageUser;

                uPiaget.GoState(110);  break;
    //************************************************************************************************************************
    //************************************************************************************************************************

    case
    110:        uMTasks.SleepAGN(uPanel.DeltaT); break;

      //************************************************************************************************************************
      // panel pTable : Affichage du robot(cercle),la direction du robot et l'angle de trajectoire
      //************************************************************************************************************************
    case
    111: 
                 
                    /*
                  pRobot.BackColor = System.Drawing.Color.Lime;
                  System.Drawing.Point loc = new System.Drawing.Point((int)uMouv.P0Robot.x, (int)uMouv.P0Robot.y);
                  System.Drawing.Size siz = new System.Drawing.Size(30, 30);
                  pRobot.Size = siz;
                  pRobot.Location = loc;
                  */

                  //pTable est le panneau vert où l'on dessine le robot
                  System.Drawing.Graphics g = this.pTable.CreateGraphics();
                   
                  newX = uMouv.P0Robot.x;
                  newY = uMouv.P0Robot.y;
                  newTRD=uMouv.P0Robot.ThetaRobotDegres;
                  float deltaC = 18;

                  float cX = newX + deltaC;//coordonnéeX du centre du robot
                  float cY = newY + deltaC;//coordonnéeY du centre du robot

                  /*
                   * dessiner un rectange vert
                   */
                    
                  //g.FillRectangle(sbDelete, 0, 0, 140, 200);//permet de simuler l effacement du panel
                  ClearPTable(g);

                  /*
                   * dessiner un cercle blanc representant le robot
                   */
                  DrawRobot(g);

                  /*
                   * dessiner un cercle bleu representant la direction du robot
                   */
                  //uPiaget.WriteOnCheckBoard("Task07 - ThetaRobotDegres : " + (uMouv.P0Robot.ThetaRobotDegres));
                  //uPiaget.WriteOnCheckBoard("Task07 - CorrectionAngle : " + CorrectionAngle(uMouv.P0Robot.ThetaRobotDegres));
                  DrawDirectionRobot(g, cX, cY, CorrectionAngle(uMouv.P0Robot.ThetaRobotDegres));
                  /*
                   * dessiner un triange rouge representant l'angle de trajectoire du robot
                   */
                  DrawTriangleAngleRobotTraj(g, cX, cY+2, CorrectionAngle(uMouv.P0Robot.ThetaRobotDegres));//code juste
                   //DrawTriangleAngleRobotTraj(g, cX, cY, uMouv.P0Robot.ThetaRobotDegres);//test de fonctionnement de l'angle
                  
                  oldX = newX;
                  oldY=newY;
                  oldTRD=newTRD;
                  
                  uPanel.MainForm.Controls["tBUser"].Text = "Du texte écrit depuis Task07 (111)";

                  uPiaget.GoNext(); break;
              
    //************************************************************************************************************************
    //************************************************************************************************************************
    case
    112:
                  uPiaget.GoState(114);
                  break;
    case
    114://------------------------------------------------------------------------------------------------------------ 
                uPiaget.SleepAGN(DeltaT);
                break;
    case
    115://------------------------------------------------------------------------------------------------------------ 
                uPiaget.GoState(119); break;

    //************************************************************************************************************************
    // Handle buttons
    //************************************************************************************************************************

    case
    119 :
                if (! uPanel.SignauxIn[1].actif) {bSI1.BackColor=System.Drawing.Color.Gray; }
                else if (uPanel.SignauxIn[1].EtatVF) {bSI1.BackColor=System.Drawing.Color.Lime; }
                else bSI1.BackColor=System.Drawing.Color.Red;

                if (! uPanel.SignauxIn[2].actif) {bSI2.BackColor=System.Drawing.Color.Gray; }
                else if (uPanel.SignauxIn[2].EtatVF) {bSI2.BackColor=System.Drawing.Color.Lime;
                                 // Form1.PCapteurEntreeBalles.BackColor=System.Drawing.Color.Lime;
                }else {bSI2.BackColor=System.Drawing.Color.Red;
                                 // Form1.PCapteurEntreeBalles.BackColor=System.Drawing.Color.Red;
                }

                if (! uPanel.SignauxIn[3].actif) {bSI3.BackColor=System.Drawing.Color.Gray; }
                else if (uPanel.SignauxIn[3].EtatVF) {bSI3.BackColor=System.Drawing.Color.Lime;
                                 // Form1.PCapteurBalle1.BackColor=System.Drawing.Color.Lime;
                }else {bSI3.BackColor=System.Drawing.Color.Red;
                                 // Form1.PCapteurBalle1.BackColor=System.Drawing.Color.Red;
                }

                if (! uPanel.SignauxIn[4].actif) {bSI4.BackColor=System.Drawing.Color.Gray; }
                else if (uPanel.SignauxIn[4].EtatVF) {bSI4.BackColor=System.Drawing.Color.Lime;
                                // bParchocG.BackColor=System.Drawing.Color.Lime;
                }else {bSI4.BackColor=System.Drawing.Color.Red;
                                // Form1.PParchocG.BackColor=System.Drawing.Color.Red;
                }
                if (! uPanel.SignauxIn[5].actif) {bSI5.BackColor=System.Drawing.Color.Gray; }
                else if (uPanel.SignauxIn[5].EtatVF) {bSI5.BackColor=System.Drawing.Color.Lime;
                                // Form1.PParchocD.BackColor=System.Drawing.Color.Lime;
                }else {bSI5.BackColor=System.Drawing.Color.Red;
                                // Form1.PParchocD.BackColor=System.Drawing.Color.Red;
                }
                
                if (! uPanel.SignauxIn[6].actif) {bSI6.BackColor=System.Drawing.Color.Gray; 
                                // Form1.PRavin_G.BackColor=System.Drawing.Color.Gray;
                }
                else if (uPanel.SignauxIn[6].EtatVF) {bSI6.BackColor=System.Drawing.Color.Lime;
                                // Form1.PRavin_G.BackColor=System.Drawing.Color.Lime;                                  
                                // Form1.PCapteurBalle4.BackColor=System.Drawing.Color.Lime;
                } else {bSI6.BackColor=System.Drawing.Color.Red;
                                // Form1.PRavin_G.BackColor=System.Drawing.Color.Red;                                         
                                // Form1.PCapteurBalle4.BackColor=System.Drawing.Color.Red;
                }

        /*
        if (! uPanel.SignauxIn[7].actif) {Form1.PRavin_D.BackColor=System.Drawing.Color.Gray;
                                   bSI7.BackColor=System.Drawing.Color.Gray;
                                        }
          else
         if (uPanel.SignauxIn[7].EtatVF) {Form1.PRavin_D.BackColor=System.Drawing.Color.Lime;
                                   bSI7.BackColor=System.Drawing.Color.Lime;
                               //   Form1.PCapteurBalle5.BackColor=System.Drawing.Color.Lime;
                                  }
                            else {Form1.PRavin_D.BackColor=System.Drawing.Color.Red;
                                  bSI7.BackColor=System.Drawing.Color.Red;
                              //    Form1.PCapteurBalle5.BackColor=System.Drawing.Color.Red;
                                  }

        if (! uPanel.SignauxIn[8].actif) {bSI8.BackColor=System.Drawing.Color.Gray; }
          else
        if (uPanel.SignauxIn[8].EtatVF) {bSI8.BackColor=System.Drawing.Color.Lime;
                                 // Form1.PCapteurBalle6.BackColor=System.Drawing.Color.Lime;
                                 NBallesEjectees = NBallesEjectees - 1;
           //        Form1.MNbreBalles.Lines.Text=IntToStr(NBallesEjectees);
                                  }
                            else {bSI8.BackColor=System.Drawing.Color.Red;
                             //    Form1.PCapteurBalle6.BackColor=System.Drawing.Color.Red;
                                  }

        if (! uPanel.SignauxIn[9].actif) {bSI9.BackColor=System.Drawing.Color.Gray; }
          else
        if (uPanel.SignauxIn[9].EtatVF) {bSI9.BackColor=System.Drawing.Color.Lime;
                Form1.PComWalter.BackColor=System.Drawing.Color.Lime;
                }
          else { bSI9.BackColor=System.Drawing.Color.Red;
              Form1.PComWalter.BackColor=System.Drawing.Color.Red;
          }
        if (! uPanel.SignauxIn[10].actif) {bSI10.BackColor=System.Drawing.Color.Gray; }
          else
        if (uPanel.SignauxIn[10].EtatVF) {bSI10.BackColor=System.Drawing.Color.Lime;
              //  Form1.PCoco2.BackColor=System.Drawing.Color.Red;
                }
          else { bSI10.BackColor=System.Drawing.Color.Red;
              //  Form1.PCoco2.BackColor=System.Drawing.Color.Gray;
              }

        if (! uPanel.SignauxIn[11].actif) {bSI11.BackColor=System.Drawing.Color.Gray; }
          else
        if (uPanel.SignauxIn[11].EtatVF) {bSI11.BackColor=System.Drawing.Color.Lime;
             }
          else {bSI11.BackColor=System.Drawing.Color.Red;
             }
            */
            uPiaget.GoState(128);
        break;
    //************************************************************************************************************************
    //************************************************************************************************************************
    case
    128://------------------------------------------------------------------------------------------------------------ 
                uMTasks.SleepAGN(DeltaT);
                break;
    //************************************************************************************************************************
    // Handle buttons
    //************************************************************************************************************************
    case
    129:
            /*
        if (! uPanel.SignauxIn[12].actif) {bSI12.BackColor=System.Drawing.Color.Gray;}
          else
         if (uPanel.SignauxIn[12].EtatVF) {bSI12.BackColor=System.Drawing.Color.Lime;}
          else { bSI12.BackColor=System.Drawing.Color.Red;}

        if (! uPanel.SignauxIn[13].actif) {bSI13.BackColor=System.Drawing.Color.Gray; }
          else
        if (uPanel.SignauxIn[13].EtatVF) {bSI13.BackColor=System.Drawing.Color.Lime;
            //    Form1.PContactAvantGauche.BackColor=System.Drawing.Color.Lime;
                 }
          else {bSI13.BackColor=System.Drawing.Color.Red;
                // Form1.PContactAvantGauche.BackColor=System.Drawing.Color.Red;
                 }

        if (! uPanel.SignauxIn[14].actif) {bSI14.BackColor=System.Drawing.Color.Gray; }
          else
         if (uPanel.SignauxIn[14].EtatVF) {bSI14.BackColor=System.Drawing.Color.Lime;
              //  Form1.PContactAvantDroit.BackColor=System.Drawing.Color.Lime;
                }
          else {bSI14.BackColor=System.Drawing.Color.Red;
               //  Form1.PContactAvantDroit.BackColor=System.Drawing.Color.Red;
                 }

        if (! uPanel.SignauxIn[15].actif) {bSI15.BackColor=System.Drawing.Color.Gray; }
          else
         if (uPanel.SignauxIn[15].EtatVF) {bSI15.BackColor=System.Drawing.Color.Lime;
              //  Form1.PContactArriereGauche.BackColor=System.Drawing.Color.Lime;
              //  Form1.PContactArriereDroit.BackColor=System.Drawing.Color.Lime;
                }
          else {bSI15.BackColor=System.Drawing.Color.Red;

              //  Form1.PContactArriereGauche.BackColor=System.Drawing.Color.Red;
              //  Form1.PContactArriereDroit.BackColor=System.Drawing.Color.Red;
                }


        if (! uPanel.SignauxIn[16].actif) {bSI16.BackColor=System.Drawing.Color.Gray; }
          else
        if (uPanel.SignauxIn[16].EtatVF) {bSI16.BackColor=System.Drawing.Color.Lime; }
          else bSI16.BackColor=System.Drawing.Color.Red;
       extern int NSOMoteurCourroie, NSODirectionCourroieIn;
        if (SignauxOut[NSOMoteurCourroie].EtatVF)
            { if (SignauxOut[NSODirectionCourroieIn].EtatVF)
               { Form1.PBarriereEntreeOuverte.BackColor=System.Drawing.Color.Lime;
                 Form1.PBarriereEntreeFermee.BackColor=System.Drawing.Color.LtGray; }
                 else
               { Form1.PBarriereEntreeOuverte.BackColor=System.Drawing.Color.LtGray;
                 Form1.PBarriereEntreeFermee.BackColor=System.Drawing.Color.Red; }
            }
           else
               { Form1.PBarriereEntreeOuverte.BackColor=System.Drawing.Color.LtGray;
                 Form1.PBarriereEntreeFermee.BackColor=System.Drawing.Color.Maroon; }
    */  
        uPiaget.GoState(138);
        break;
    //************************************************************************************************************************
    //************************************************************************************************************************
    case
    138: //------------------------------------------------------------------------------------------------------------
                uMTasks.SleepAGN(DeltaT);
                break;
    //************************************************************************************************************************
    // Handle buttons
    //************************************************************************************************************************
    case
    139:   

       if (! uPanel.SignauxIn[uPanel.NSignauxBoolIn+2].actif)
           {PAInNew.BackColor=System.Drawing.Color.Gray;
        //      bPosHm.BackColor=System.Drawing.Color.Gray;
            }
          else
        if (uPanel.SignauxIn[uPanel.NSignauxBoolIn+2].valeur<50)
        {   PAInNew.BackColor = System.Drawing.Color.Fuchsia;
       //     bPosHm.BackColor=System.Drawing.Color.Fuchsia;
           }
           else
        if (uPanel.SignauxIn[uPanel.NSignauxBoolIn+2].valeur<150)
        {   PAInNew.BackColor = System.Drawing.Color.Yellow;
       //    bPosHm.BackColor=System.Drawing.Color.Yellow;
           }
        else
        {   PAInNew.BackColor = System.Drawing.Color.Aqua;
             //   bPosHm.BackColor=System.Drawing.Color.Aqua;
        }

       PAInNew.Text = "US HG " +
       //  Convert.ToString(uPanel.SignauxIn[uPanel.CaptUSHG].valeur, ffFixed, 3, 0);
        uPanel.SignauxIn[uPanel.NSignauxBoolIn + 2].valeur.ToString(); // uPanel.CaptUSHG

        // ex PAIn2new car PAin2 autrefois squatté par autre signal...
       if (!uPanel.SignauxIn[uPanel.NSignauxBoolIn+1].actif)
       {
           PAIn1.BackColor = System.Drawing.Color.Gray;
           //bPosMM.BackColor=System.Drawing.Color.Gray;
            }
          else
        if (uPanel.SignauxIn[uPanel.NSignauxBoolIn+1].valeur<(40+200/3))
        {
            PAIn1.BackColor = System.Drawing.Color.Fuchsia;
            //bPosMM.BackColor=System.Drawing.Color.Fuchsia;
           }
           else
        if (uPanel.SignauxIn[uPanel.NSignauxBoolIn+1].valeur<(40+2*200/3))
        {
            PAIn1.BackColor = System.Drawing.Color.Yellow;
           //bPosMM.BackColor=System.Drawing.Color.Yellow;
           }
        else
        {
            PAIn1.BackColor = System.Drawing.Color.Aqua;
                //bPosMM.BackColor=System.Drawing.Color.Aqua;
        }
       PAIn1.Text = "US HD " +
         uPanel.SignauxIn[uPanel.NSignauxBoolIn + 1].valeur.ToString(); // uPanel.CaptUSHD
        //  bAIn2 traditionnel
        /*       
         * if (!uPanel.SignauxIn[uPanel.CaptUSMG].actif)   // normalement NSignauxBoolIn+2]
           {bAIn2.BackColor=System.Drawing.Color.Gray;
           //bPosMM.BackColor=System.Drawing.Color.Gray;
            }
          else
        if (uPanel.SignauxIn[uPanel.CaptUSMG].valeur<10)
           {bAIn2.BackColor=System.Drawing.Color.Fuchsia;
            //bPosMM.BackColor=System.Drawing.Color.Fuchsia;
           }
           else
        if (uPanel.SignauxIn[uPanel.CaptUSMG].valeur<25)
           {bAIn2.BackColor=System.Drawing.Color.Yellow;
           //bPosMM.BackColor=System.Drawing.Color.Yellow;
           }
        else { bAIn2.BackColor=System.Drawing.Color.Aqua;
                //bPosMM.BackColor=System.Drawing.Color.Aqua;
        }
        bAIn2.Text="US MG "+
         Convert.ToString(uPanel.SignauxIn[uPanel.CaptUSMG].valeur,ffFixed,1,1);
        */
        /*
        BalleDetectee=  (uPanel.SignauxIn[uPanel.NSignauxBoolIn+1].valeur<0.8)
                ||  (uPanel.SignauxIn[uPanel.NSignauxBoolIn+2].valeur<0.8);
        if (BalleDetectee)
                {//bBalleAvant.BackColor=System.Drawing.Color.Red;

                else {//bBalleAvant.BackColor=System.Drawing.Color.Gray;
             */
        // bAIn3
       if (!uPanel.SignauxIn[uPanel.NSignauxBoolIn+3].actif)
           {bSI8.BackColor=System.Drawing.Color.Gray;
            //bPosBM.BackColor=System.Drawing.Color.Gray;
            }
          else
        if (uPanel.SignauxIn[uPanel.NSignauxBoolIn+3].valeur<45)
           {bSI8.BackColor=System.Drawing.Color.Fuchsia;
            //bPosBM.BackColor=System.Drawing.Color.Fuchsia;
           }
           else
        if (uPanel.SignauxIn[uPanel.NSignauxBoolIn+3].valeur<25)
           {bSI8.BackColor=System.Drawing.Color.Yellow;
            //bPosBM.BackColor=System.Drawing.Color.Yellow;
           }
        else {bSI8.BackColor=System.Drawing.Color.Aqua;
              //bPosBM.BackColor=System.Drawing.Color.Aqua;
        }
        bSI8.Text="US MD "+
         uPanel.SignauxIn[uPanel.NSignauxBoolIn + 3].valeur.ToString(); // uPanel.CaptUSMD

       if (!uPanel.SignauxIn[uPanel.NSignauxBoolIn+4].actif)
           {bSI11.BackColor=System.Drawing.Color.Gray;
            //bPosHG.BackColor=System.Drawing.Color.Gray;
           }
          else
        if (uPanel.SignauxIn[uPanel.NSignauxBoolIn+4].valeur<20)
           {bSI11.BackColor=System.Drawing.Color.Fuchsia;
            //bPosHG.BackColor=System.Drawing.Color.Fuchsia;
           }
           else
        if (uPanel.SignauxIn[uPanel.NSignauxBoolIn+4].valeur<65)
           {bSI11.BackColor=System.Drawing.Color.Yellow;
            //bPosHG.BackColor=System.Drawing.Color.Yellow;
           }
        else {bSI11.BackColor=System.Drawing.Color.Aqua;
               //bPosHG.BackColor=System.Drawing.Color.Aqua;
         }
        bSI11.Text="US BG "+
         uPanel.SignauxIn[uPanel.NSignauxBoolIn + 4].valeur.ToString(); // uPanel.CaptUSBG
        /*
        ObstacleDetecte=  (uPanel.SignauxIn[uPanel.NSignauxBoolIn+3].valeur<0.8)
                ||  (uPanel.SignauxIn[uPanel.NSignauxBoolIn+4].valeur<0.8);
        if (ObstacleDetecte)
                {//bObstacle.BackColor=System.Drawing.Color.Maroon; }
                else {//bObstacle.BackColor=System.Drawing.Color.Gray; }
        */
       if (!uPanel.SignauxIn[uPanel.NSignauxBoolIn+5].actif)
           {bSI12.BackColor=System.Drawing.Color.Gray;
            //bPosBG.BackColor=System.Drawing.Color.Gray;
           }
          else
        if (uPanel.SignauxIn[uPanel.NSignauxBoolIn+5].valeur<20)
           {bSI12.BackColor=System.Drawing.Color.Fuchsia;
            //bPosBG.BackColor=System.Drawing.Color.Fuchsia;
           }
           else
        if (uPanel.SignauxIn[uPanel.NSignauxBoolIn+5].valeur<65)
           {bSI12.BackColor=System.Drawing.Color.Yellow;
         //   bPosBG.BackColor=System.Drawing.Color.Yellow;
           }
        else {bSI12.BackColor=System.Drawing.Color.Aqua;
        //      bPosBG.BackColor=System.Drawing.Color.Aqua;
        }
       if (uPanel.SignauxIn[uPanel.NSignauxBoolIn + 5].valeur >= 24)  // uPanel.CaptUSBD

            bSI12.BackColor = System.Drawing.Color.Lime;
        else
            bSI12.BackColor = System.Drawing.Color.Red;

        bSI12.Text="Bat. "+
         uPanel.SignauxIn[uPanel.NSignauxBoolIn + 5].valeur.ToString() + "." +
          ((uPanel.SignauxIn[uPanel.NSignauxBoolIn + 5].valeur - 
           Math.Floor(uPanel.SignauxIn[uPanel.NSignauxBoolIn + 5].valeur)) * 10).ToString()
         + "V";  // uPanel.CaptUSBD
        /*
        ObstacleDetecte=  (uPanel.SignauxIn[uPanel.NSignauxBoolIn+4].valeur<0.8)
                ||  (uPanel.SignauxIn[uPanel.NSignauxBoolIn+5].valeur<0.8);
        if (ObstacleDetecte)
                {bObstacle.BackColor=System.Drawing.Color.Maroon; }
                else {bObstacle.BackColor=System.Drawing.Color.Gray; }
        */
         /*** A FAIRE    if (USSensorTriggered)
        {
            bUSSensorTriggered->Color = clLime;
        }
        else
        {
            bUSSensorTriggered->Color = clRed;
        };
        */

       uPiaget.GoState(148);
        break;
    //************************************************************************************************************************
    //************************************************************************************************************************
    
    case
    148 : //---------------------------------------------------------------------------------------------------------------
                uMTasks.SleepAGN(DeltaT);
                break;
    //************************************************************************************************************************
    // Handle buttons
    //************************************************************************************************************************
    case
    149:
//            if (!uPanel.SignauxOut[1].actif) { bSI1.BackColor = System.Drawing.Color.Gray; }
//            else 
            if (uPanel.SignauxOut[1].EtatVF) { bSO1.BackColor = System.Drawing.Color.Lime; }
            else bSO1.BackColor = System.Drawing.Color.Red;
        //  Tirs canon
        if (uPanel.SignauxOut[2].EtatVF)
        {
            bSO2.BackColor = System.Drawing.Color.Lime;
    //        bDirection->Color = clAqua;
    //        bCanon->Color = clLime;
        }
        else
        {
            bSO2.BackColor = System.Drawing.Color.Red;
     //       bDirection->Color = clFuchsia;
      //      bCanon->Color = clRed;
        }
        if (uPanel.SignauxOut[3].EtatVF) { bSO3.BackColor = System.Drawing.Color.Lime; }
        else bSO3.BackColor = System.Drawing.Color.Red;
        // if (! SignauxOut[2].EtatVF && ! SignauxOut[3].EtatVF)
        // {bMoteurBalleEntree.BackColor=System.Drawing.Color.Gray;

        //   if (SignauxOut[2].EtatVF)
        // {bMoteurBalleEntree.BackColor=System.Drawing.Color.Yellow;

        //  if (SignauxOut[3].EtatVF)
        //  {bMoteurBalleEntree.BackColor=System.Drawing.Color.Aqua;

        //  MoteurBalle 1
        if (uPanel.SignauxOut[4].EtatVF) { bSO4.BackColor = System.Drawing.Color.Lime; }
        else bSO4.BackColor = System.Drawing.Color.Red;

        if (uPanel.SignauxOut[5].EtatVF) { bSO5.BackColor = System.Drawing.Color.Lime; }
        else bSO5.BackColor = System.Drawing.Color.Red;

        if (uPanel.SignauxOut[6].EtatVF) { bSO6.BackColor = System.Drawing.Color.Lime; }
        else bSO6.BackColor = System.Drawing.Color.Red;

        uPiaget.GoState(159);
        break;
    //************************************************************************************************************************
    //************************************************************************************************************************


    //************************************************************************************************************************
    // Handle buttons
    //************************************************************************************************************************
    case
    159:


               if (uPanel.Choix[uPanel.NCSimulation].Etat)
                {   bSimulation.BackColor=System.Drawing.Color.Lime;
                if (uPanel.Choix[uPanel.NCBeckhoff].Etat) {bBeckhoff.BackColor=System.Drawing.Color.Fuchsia;}
                    else bBeckhoff.BackColor=System.Drawing.Color.Red;
                if (uPanel.Choix[uPanel.NCCamera].Etat) {bCamera.BackColor=System.Drawing.Color.Fuchsia;}
                    else bCamera.BackColor=System.Drawing.Color.Red;
                if (uPanel.Choix[uPanel.NCGalil].Etat) {bGalil.BackColor=System.Drawing.Color.Fuchsia;}
                    else bGalil.BackColor=System.Drawing.Color.Red;
                //       if (uPanel.Choix[uPanel.NCGalil1Or2L].Etat) {bCGalil1Or2L.BackColor=System.Drawing.Color.Fuchsia;}
                //              else bCGalil1Or2L.BackColor=System.Drawing.Color.Red;
                if (uPanel.ChoixGalilFront) bGalilFront.BackColor=System.Drawing.Color.Fuchsia;
                    else bGalilFront.BackColor=System.Drawing.Color.Red;
                if (uPanel.ChoixGalilBack) bGalilBack.BackColor=System.Drawing.Color.Fuchsia;
                    else bGalilBack.BackColor=System.Drawing.Color.Red;

             
                   /*

                if (uPanel.PlatformRHY)
                {
                    bRHY.BackColor=System.Drawing.Color.Lime;
             //       uPanel.Platform = uPanel.tPlatform.RHY;




                   
                }
                else 
                {
                    bRHY.BackColor=System.Drawing.Color.Red;
                    //uPanel.Platform = uPanel.tPlatform.NONE;
                
                }
                  */
                   
                if (uPanel.Choix[uPanel.NCShoulder].Etat) {bShoulder.BackColor=System.Drawing.Color.Fuchsia;}
                    else bShoulder.BackColor=System.Drawing.Color.Red;
                if (uPanel.Choix[uPanel.NCHand].Etat) {bHand.BackColor=System.Drawing.Color.Fuchsia;}
                    else bHand.BackColor=System.Drawing.Color.Red;
                if (uPanel.Choix[uPanel.NCGalilM27].Etat) { bGalilM27.BackColor = System.Drawing.Color.Fuchsia; }
                else bGalilM27.BackColor = System.Drawing.Color.Red;






                }



                else
                {   bSimulation.BackColor=System.Drawing.Color.Red;
                    if (uPanel.Choix[uPanel.NCBeckhoff].Etat) {bBeckhoff.BackColor=System.Drawing.Color.Lime; }
                        else bBeckhoff.BackColor=System.Drawing.Color.Red;
                    if (uPanel.Choix[uPanel.NCCamera].Etat) {bCamera.BackColor=System.Drawing.Color.Lime; }
                        else bCamera.BackColor=System.Drawing.Color.Red;
                    if (uPanel.Choix[uPanel.NCGalil].Etat)
                    {   bGalil.BackColor=System.Drawing.Color.Lime;
                        //    if (uPanel.Choix[uPanel.NCGalil1Or2L].Etat)
                        //        {bCGalil1Or2L.BackColor=System.Drawing.Color.Lime; }
                        //      else bCGalil1Or2L.BackColor=System.Drawing.Color.Red;
                    }
                    else
                    {   //bCGalil1Or2L.BackColor=System.Drawing.Color.BtnFace;
                        bGalil.BackColor=System.Drawing.Color.Red; }
                    if (uPanel.ChoixGalilFront) bGalilFront.BackColor=System.Drawing.Color.Lime;
                     else bGalilFront.BackColor=System.Drawing.Color.Red;
                    if (uPanel.ChoixGalilBack) bGalilBack.BackColor=System.Drawing.Color.Lime;
                        else bGalilBack.BackColor=System.Drawing.Color.Red;

                    if (uPanel.Choix[uPanel.NCShoulder].Etat) {bShoulder.BackColor=System.Drawing.Color.Lime;}
                        else bShoulder.BackColor=System.Drawing.Color.Red;
                    if (uPanel.Choix[uPanel.NCHand].Etat) {bHand.BackColor=System.Drawing.Color.Lime;}
                        else bHand.BackColor=System.Drawing.Color.Red;
                }



                //     if (uPanel.Choix[uPanel.NCMusique].Etat) {bMusique.BackColor=System.Drawing.Color.Lime; }
                //             else bMusique.BackColor=System.Drawing.Color.Red;
                //     if (uPanel.Choix[uPanel.NCStepSound].Etat) {bCStepSound.BackColor=System.Drawing.Color.Lime; }
                //             else bCStepSound.BackColor=System.Drawing.Color.Red;
                if (uPanel.Choix[uPanel.NCCalibration].Etat) {bCalibration.BackColor=System.Drawing.Color.Lime; }
                    else bCalibration.BackColor=System.Drawing.Color.Red;

                if (uPanel.Choix[uPanel.NCVisionContinue].Etat)
                    bVisionContinue.BackColor=System.Drawing.Color.Lime;
                else
                    bVisionContinue.BackColor=System.Drawing.Color.Red;
      /*          if (uPanel.Choix[uPanel.NCGalilM27].Etat)
                {
                    bGalilM27.BackColor = System.Drawing.Color.Lime;
                }
                else
                {
                    bGalilM27.BackColor = System.Drawing.Color.Red;
                }*/

                //      if (ModCoul1)
                //       {bVertOrRL.BackColor=System.Drawing.Color.Lime;}
                //           else
                //       {bVertOrRL.BackColor=System.Drawing.Color.Red;}
                if (uPanel.ModeNewLaser)
                    bModeNewLaser.BackColor = System.Drawing.Color.Lime;
                else
                    bModeNewLaser.BackColor = System.Drawing.Color.Red;

                if (uPanel.ChoixLaserA)
                {
                    if (uPanel.Choix[uPanel.NCSimulation].Etat)
                        bLaserA.BackColor = System.Drawing.Color.Fuchsia;
                    else
                        bLaserA.BackColor = System.Drawing.Color.Lime;
                }
                else
                    bLaserA.BackColor = System.Drawing.Color.Red;
       
                if (uPanel.ChoixLaserB)
                {
                    if (uPanel.Choix[uPanel.NCSimulation].Etat)
                        bLaserB.BackColor = System.Drawing.Color.Fuchsia;
                    else
                        bLaserB.BackColor = System.Drawing.Color.Lime;
                }
                else
                    bLaserB.BackColor = System.Drawing.Color.Red;
       //
                if (uPanel.ChoixLaserC)
                {
                    if (uPanel.Choix[uPanel.NCSimulation].Etat)
                        bLaserC.BackColor = System.Drawing.Color.Fuchsia;
                    else
                        bLaserC.BackColor = System.Drawing.Color.Lime;
                }
                else
                    bLaserC.BackColor = System.Drawing.Color.Red;
       //
                 if (uPanel.ChoixGalilFront)
          {
           if (uPanel.Choix[uPanel.NCSimulation].Etat)
                     bGalilFront.BackColor = System.Drawing.Color.Fuchsia;
                 else
                     bGalilFront.BackColor = System.Drawing.Color.Lime;
           }
             else
                 bGalilFront.BackColor = System.Drawing.Color.Red;


       




       for (int i = 1; i <= 5; i++)
       {
           bImage1.BackColor = System.Drawing.Color.Red;
           bImage2.BackColor = System.Drawing.Color.Red;
           bImage3.BackColor = System.Drawing.Color.Red;
           bImage4.BackColor = System.Drawing.Color.Red;
           bImage5.BackColor = System.Drawing.Color.Red;
           switch (uPanel.SimulationImageNumber)
           {
               case 1: bImage1.BackColor = System.Drawing.Color.Lime;
                   if (!uPanel.Choix[uPanel.NCSimulation].Etat)
                   { 
                   }
                   else
                   {
                       Bitmap image = Properties.Resources.CamImageSim; //image comme ressource FRZ 015.07.13
                       pictureBox1.Image = image;
                       
                       
                   }
                   break;
               case 2: bImage2.BackColor = System.Drawing.Color.Lime;
                   if (!uPanel.Choix[uPanel.NCSimulation].Etat)
                   {  }
                   else
                   {
                       Bitmap image = Properties.Resources.CamImageSim2;
                       pictureBox1.Image = image;
                      
                   }
                   break;
               case 3: bImage3.BackColor = System.Drawing.Color.Lime;
                   if (!uPanel.Choix[uPanel.NCSimulation].Etat)
                   {  }
                   else
                   {
                       Bitmap image = Properties.Resources.CamImageSim3;
                       pictureBox1.Image = image;

                   }
                   break;
               case 4: bImage4.BackColor = System.Drawing.Color.Lime;
                   if (!uPanel.Choix[uPanel.NCSimulation].Etat)
                   {  }
                   else
                   {
                       Bitmap image = Properties.Resources.CamImageSim4;
                       pictureBox1.Image = image;
                       
                   }
                   break;
               case 5: bImage5.BackColor = System.Drawing.Color.Lime;
                   if (!uPanel.Choix[uPanel.NCSimulation].Etat)
                   {  }
                   else
                   {
                       Bitmap image = Properties.Resources.CamImageSim5;
                       pictureBox1.Image = image;
                       
                   }
                   break;
               //   default:
               //          break;
           } // end switch
       } // end 

        //
       uPiaget.GoState(168);
        break;
    //************************************************************************************************************************
    //************************************************************************************************************************
    case
    168 : //----------------------------------------------------------------------------------------------------------------
                uMTasks.SleepAGN(DeltaT);
                break;
    //************************************************************************************************************************
    // Handle buttons
    //************************************************************************************************************************
    case
    169:
       if (uPanel.DebugStep)
            {bDebugStep.BackColor=uPanel.clLime;}
                else
       { bDebugStep.BackColor = uPanel.clRed; }

       if (uPanel.ModeTest)
       { bModeTest.BackColor = uPanel.clLime; }
                else
       { bModeTest.BackColor = uPanel.clRed; }

       if (uPanel.KinectConnection)
       { bKinect.BackColor = uPanel.clLime; }
       else
       { bKinect.BackColor = uPanel.clRed; }


        /*
       switch (uPanel.NCGalilM27)
       {
           case 0:

bGalilM27.BackColor = System.Drawing.Color.Red;
               break;
           case 1:

  bGalilM27.BackColor = System.Drawing.Color.Lime;
               break;
           case 2:

  bGalilM27.BackColor = System.Drawing.Color.Fuchsia;
               break;



       }


        */



           
          switch (uPanel.Platform)
               {
              case uPanel.tPlatform.RHY :

                   bRHY.BackColor = System.Drawing.Color.Lime;
                   bRHYControllerNumber.BackColor = System.Drawing.Color.Lime;
                   uGalil.GalilRHYControllerNumber = Convert.ToInt16(bRHYControllerNumber.Text);

                   bOPY.BackColor = System.Drawing.Color.Red;
                   bOPYControllerFront.BackColor = System.Drawing.Color.Red;
                   bOPYControllerBack.BackColor = System.Drawing.Color.Red;
                   bTrajNormalLeft.Visible = false;
                   bTrajNormalRight.Visible = false;
                   bRTRt.Visible = false;
                   bRTLt.Visible = false;

                   bOP12Y.BackColor = Color.Red;

                   bplatformManip25.BackColor = Color.Red;
                   break;
              case uPanel.tPlatform.OPY :
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

                   bOP12Y.BackColor = Color.Red;

                   bplatformManip25.BackColor = Color.Red;
                   break;
              case uPanel.tPlatform.OP12Y :
                   bRHY.BackColor = System.Drawing.Color.Red;
                   bRHYControllerNumber.BackColor = System.Drawing.Color.Red;

                   bOPY.BackColor = System.Drawing.Color.Red;
                   bOPYControllerFront.BackColor = System.Drawing.Color.Red;
                   bOPYControllerBack.BackColor = System.Drawing.Color.Red;

                   bOP12Y.BackColor = Color.Lime;
                   break;
              case uPanel.tPlatform.MANIP25 :
                  bRHY.BackColor = System.Drawing.Color.Red;
                  bRHYControllerNumber.BackColor = System.Drawing.Color.Red;

                  bOPY.BackColor = System.Drawing.Color.Red;
                  bOPYControllerFront.BackColor = System.Drawing.Color.Red;
                  bOPYControllerBack.BackColor = System.Drawing.Color.Red;

                  bOP12Y.BackColor = Color.Red;

                  bplatformManip25.BackColor = Color.Lime;
                  break;
              case uPanel.tPlatform.NONE :

                  uPanel.PlatformRHY = false;

                  bRHY.BackColor = System.Drawing.Color.Red;
                   bRHYControllerNumber.BackColor = System.Drawing.Color.Red;

                   bOPY.BackColor = System.Drawing.Color.Red;
                   bOPYControllerFront.BackColor = System.Drawing.Color.Red;
                   bOPYControllerBack.BackColor = System.Drawing.Color.Red;

                   bOP12Y.BackColor = Color.Red;

                   bplatformManip25.BackColor = Color.Red;
                   break;
               }



  




       uPiaget.GoState(171);
        break;
    //************************************************************************************************************************
    //************************************************************************************************************************
    
    case
    171 : 
                uMTasks.SleepAGN(DeltaT);
                break;
    
    case
    172 :
        //***************************************************************************************************************************************************
        // Affichage de tBMouvement : Consigne,position
        //***************************************************************************************************************************************************
        string spaceChar = "      ";
        string spaceChar1 = "   ";
        string formatString = "{0,-5}";
        string formatInt = "00";
        string tab = "\t";
        /*
        uPanel.Message = string.Format(formatString, "Consigne") + ": " +                                //Col01
                            "[fX]" + uMouv.P0RobotFutur.x.ToString(formatInt) + spaceChar1 +                   //Col02
                            "[fY]" + uMouv.P0RobotFutur.y.ToString(formatInt) + spaceChar1 +                   //Col03
                            "[fT]" + uMouv.P0RobotFutur.ThetaRobotDegres.ToString(formatInt) + spaceChar1 +    //Col04
                            "[fAngRobTr]" + uMouv.P0RobotFutur.AngleRobotTraj.ToString(formatInt) + spaceChar1 +      //Col05
                            "[fds]" + uMouv.P0RobotFutur.ds.ToString(formatInt) + spaceChar1 +                  //Col06
                            "[fRTr]" + uMouv.P0RobotFutur.RayonTrajectoire.ToString(formatInt) + spaceChar1 +    //Col07
                            "[fAngTr]" + uMouv.P0RobotFutur.AngleTrajectoire.ToString(formatInt) +   //Col08
                            Environment.NewLine;
        */
        uPanel.Message = string.Format(formatString, "Consigne") + ": " +                                //Col01
                            uPiaget.Round(uMouv.P0RobotFutur.x).ToString(formatInt) + spaceChar +                   //Col02
                            uPiaget.Round(uMouv.P0RobotFutur.y).ToString(formatInt) + spaceChar +                   //Col03
                            uMouv.P0RobotFutur.ThetaRobotDegres.ToString(formatInt) + spaceChar +    //Col04
                            uMouv.P0RobotFutur.AngleRobotTraj.ToString(formatInt) + spaceChar +      //Col05
                            uMouv.P0RobotFutur.ds.ToString(formatInt) + spaceChar +                  //Col06
                            uMouv.P0RobotFutur.RayonTrajectoire.ToString(formatInt) + spaceChar +    //Col07
                            uMouv.P0RobotFutur.AngleTrajectoire.ToString(formatInt)  +   //Col08
                            Environment.NewLine;
         
        /*uPanel.Message = uPanel.Message + string.Format(formatString, "Position  ") + ": " +       //Col01
                            "[X]" + uPiaget.round(uMouv.P0Robot.x) + spaceChar1 +                        //Col02
                            "[Y]" + uPiaget.round(uMouv.P0Robot.y) + spaceChar1 +                        //Col03
                            "[T]" + uMouv.P0Robot.ThetaRobotDegres.ToString(formatInt) + spaceChar1 +         //Col04
                            "[AngRobTr]" + uMouv.P0Robot.AngleRobotTraj.ToString(formatInt) + spaceChar1 +           //Col05
                            "[MMvt]" + uPanel.Mouvement.ModeDeMouvement.ToString() + spaceChar1 +           //Col06
                            "[Et]" + uPanel.Mouvement.Etat.ToString() + spaceChar1 +                      //Col07
                            "NPAS:" + " " +                                                //Col08
                            uPanel.Mouvement.NPas.ToString() + spaceChar1 +                      //Col09
                            Environment.NewLine;*/
        uPanel.Message = uPanel.Message + string.Format(formatString, "Position  ") + ": " +       //Col01
                            uPiaget.Round(uMouv.P0Robot.x) + spaceChar +                        //Col02
                            uPiaget.Round(uMouv.P0Robot.y) + spaceChar +                        //Col03
                            uMouv.P0Robot.ThetaRobotDegres.ToString(formatInt) + spaceChar +         //Col04
                            uMouv.P0Robot.AngleRobotTraj.ToString(formatInt) + spaceChar +           //Col05
                            uPanel.Mouvement.ModeDeMouvement.ToString() + spaceChar +           //Col06
                            uPanel.Mouvement.Etat.ToString() + spaceChar +                      //Col07
                            "NPAS" + spaceChar +                                                //Col08
                            uPanel.Mouvement.NPas.ToString() + spaceChar +                      //Col09
                            Environment.NewLine;
        uPanel.Message = uPanel.Message + string.Format(formatString, "NoPasCt") + tab +      //Col01
                            string.Format(formatString, "IncrG") + tab +                        //Col02
                            string.Format(formatString, "IncrD") + tab +                        //Col03
                            string.Format(formatString, "vitesse") + tab +                        //Col04
                            string.Format(formatString, "acc") + tab +                        //Col05
                            string.Format(formatString, "NoPasG") + tab +                        //Col06
                            string.Format(formatString, "NoPasD")  +                       //Col07
                            Environment.NewLine;
        uPanel.Message = uPanel.Message +
                            spaceChar1 + uPanel.Mouvement.NoPasCourant.ToString(formatInt) + tab +      //Col01
                            spaceChar1 + uPanel.Mouvement.IncrGauche.ToString(formatInt) + tab +                        //Col02
                            spaceChar1 + uPanel.Mouvement.IncrDroit.ToString(formatInt) + tab +                        //Col03
                            spaceChar1 + uPanel.Mouvement.VitesseM.ToString(formatInt) + tab +                        //Col04
                            spaceChar1 + uPanel.Mouvement.AccelerationM.ToString(formatInt) + tab +                        //Col05
                            spaceChar1 + uPanel.Mouvement.NoPasGauche.ToString(formatInt) + tab +                        //Col06
                            spaceChar1 + uPanel.Mouvement.NoPasDroit.ToString(formatInt) +                       //Col07
                            Environment.NewLine;
        
        uPanel.Message = uPanel.Message +
                            string.Format(formatString, "Erreur") + tab +  //Col01
                            string.Format(formatString, "G:") + uTasks.V8ErreurGauche.ToString() + tab +           //Col02
                            string.Format(formatString, "D:") + uTasks.V8ErreurDroite.ToString() + tab +           //Col03
                            string.Format(formatString, "Galil: ") + uTasks.WriteGalilStatus() + tab +    //Col04
                           Environment.NewLine;

        uPanel.Message = uPanel.Message +
                            string.Format(formatString, "Vmx : ") + uPanel.VitesseMaxCourante.ToString(formatInt) + " à " + uPanel.FacteurVitesseMax * 100 +" % "+ tab +             //Col01
                            string.Format(formatString, "Amx : ") + uPanel.AccelerationMaxCourante.ToString(formatInt) + " à " + uPanel.FacteurAccelerationMax * 100 + " % " + tab + //Col02
                            string.Format(formatString, "RédAccEnRot : ") +uPanel.ReductionDAccelerationEnRotation + tab +                                                          //Col03
                            Environment.NewLine;

      /*  if (FPiaget.ActiveForm != null) *//*FPiaget.ActiveForm.Controls*/tBMouvement.Text = uPanel.Message;

        uPiaget.GoState(1000); 
        break;
        //***************************************************************************************************************************************************
        //***************************************************************************************************************************************************
        case
        1000://------------------------------------------------------------------------------------------------------------------------------------------- 
                    uPiaget.GoState(1); 
                    break;
        default :
                    uPanel.MessageErreur = "Task" + TaskNumber.ToString() + " - Line missing: " + uMTasks.Work[TaskNumber].StateNo.ToString();// uPanel.MessageErreur.Length;
                    break;
} // END_BIG switch ( uMTasks.Work[TaskNumber].StateNo )

    //***************************************************************************************************************************************************
    //***************************************************************************************************************************************************
    // END BIG SWITCH
    //***************************************************************************************************************************************************
    //***************************************************************************************************************************************************

        } // end void Task07c
 //   }  // end class Task 07
//
    /*
     * dessiner un rectange vert : permet de simuler l effacement du panel
     */
    public void ClearPTable(System.Drawing.Graphics g)
    {
        g.FillRectangle(sbDelete, 0, 0, 140, 200);//permet de simuler l effacement du panel
    }

    /*
     * dessiner un cercle blanc representant le robot
     */
    public void DrawRobot(System.Drawing.Graphics g)
    {
        newX = uMouv.P0Robot.x;
        newY = uMouv.P0Robot.y;
        g.FillEllipse(sbW, newX, newY, 40, 40);//dessin du robot:FillEllipse(color, positionX, positionY, tailleX, tailleY)
        //g.FillEllipse(sbB, newX+18, newY+18, 5, 5);//au centre
        //g.FillEllipse(sbR, newX, newY + 18, 5, 5);//a gauche
        //g.FillEllipse(sbR, newX+18+18, newY+18, 5, 5);//a droite
        //g.FillEllipse(sbR, newX+18, newY+18+18, 5, 5);//en bas
        //g.FillEllipse(sbR, newX+18, newY, 5, 5);//au haut
    }

    /*
     * dessiner un cercle bleu representant la direction du robot
     */
    public void DrawDirectionRobot(System.Drawing.Graphics g, float cX, float cY,float ThRoDe)
    {
        float rayon = 17;// taille du robot

        double trigX = ((float)Math.Cos(uMouv.DegresARadians((int)ThRoDe)));
        double trigy = ((float)Math.Sin(uMouv.DegresARadians((int)ThRoDe)));

        float fX = (float)(rayon * trigX);
        float fY = (float)(rayon * trigy);

        float posX = uPiaget.Round(cX + fX);
        float posY = uPiaget.Round(cY + fY);

        g.FillEllipse(sbB, posX, posY, 6, 6);//dessin de la direction du robot
    }

    /*
     * dessiner un triange pour l'angle de deplacement : uMouv.P0RobotFutur.AngleRobotTraj
     */
    public void DrawTriangleAngleRobotTraj(System.Drawing.Graphics g, float cX, float cY, float AnRoTr)
    {
        
        System.Drawing.Point[] ptri = new System.Drawing.Point[3];

        float rayonART = 7;// taille du triangle
        int ds = 4;//permet de dessiner le triange au centre du robot

        float angleART0 = AnRoTr;//test
        float angleART1 = angleART0 - 90;
        float angleART2 = angleART0 + 90;

        double trigXART0 = ((float)Math.Cos(uMouv.DegresARadians((int)angleART0)));
        double trigYART0 = ((float)Math.Sin(uMouv.DegresARadians((int)angleART0)));

        double trigXART1 = ((float)Math.Cos(uMouv.DegresARadians((int)angleART1)));
        double trigYART1 = ((float)Math.Sin(uMouv.DegresARadians((int)angleART1)));

        double trigXART2 = ((float)Math.Cos(uMouv.DegresARadians((int)angleART2)));
        double trigYART2 = ((float)Math.Sin(uMouv.DegresARadians((int)angleART2)));

        float xART0 = (float)(rayonART * trigXART0);
        float yART0 = (float)(rayonART * trigYART0);

        float xART1 = (float)(rayonART * trigXART1);
        float yART1 = (float)(rayonART * trigYART1);

        float xART2 = (float)(rayonART * trigXART2);
        float yART2 = (float)(rayonART * trigYART2);

        float posX0 = uPiaget.Round(cX + xART0);
        float posY0 = uPiaget.Round(cY + yART0);

        float posX1 = uPiaget.Round(cX + xART1);
        float posY1 = uPiaget.Round(cY + yART1);

        float posX2 = uPiaget.Round(cX + xART2);
        float posY2 = uPiaget.Round(cY + yART2);

        //g.FillEllipse(sbR,dirXART2,dirYART2,5,5);//dessin de la direction du robot
        //------------------------------------------------------------------------------------------
        ptri[0] = new System.Drawing.Point((int)posX0 + ds, (int)posY0);
        ptri[1] = new System.Drawing.Point((int)posX1 + ds, (int)posY1);
        ptri[2] = new System.Drawing.Point((int)posX2 + ds, (int)posY2);
        g.FillPolygon(sbR, ptri);//dessine triange rouge
    }

    public float CorrectionAngle(float angleReal)
    {
        float angle = angleReal * 1;
        float delta = 6;
        float sign;
        if (angle >= 0) sign = 1;
        else sign = -1;

        if (angle >= 360) return CorrectionAngle(angle - 360);
        else if (angle <= -360) return CorrectionAngle(angle + 360);
        else if (Math.Abs(sign * angle - 0) <= delta)   return 0;
        else if (Math.Abs(sign * angle - 45) <= delta)  return sign * 45;
        else if (Math.Abs(sign * angle - 90) <= delta)  return sign * 90;
        else if (Math.Abs(sign * angle - 135) <= delta) return sign * 135;
        else if (Math.Abs(sign * angle - 180) <= delta) return sign * 180;
        else if (Math.Abs(sign * angle - 225) <= delta) return sign * 225;
        else if (Math.Abs(sign * angle - 270) <= delta) return sign * 270;
        else if (Math.Abs(sign * angle - 315) <= delta) return sign * 315;
        else if (Math.Abs(sign * angle - 360) <= delta) return sign * 360;
        else return angle;
    }






}  //***  public partial class FPiaget : Form   //***                               //***
 
//
} // end namespace
