using System;
using System.Windows.Forms;

namespace Piaget_CSharp
{
    public partial class uPiaget  //***
    {
        uMTasks uMTasks1 = new uMTasks();

        //	public uPiaget()
        //    {
        public int uPiagetVar = 1; // for test purpose
        //	}
/// 
        //---------------------------------------------------------------------------
        public static void FermerLiaisons()
        {
            uPanel.Choix[uPanel.NCBeckhoff].Etat = false;
            uPanel.Choix[uPanel.NCGalil].Etat = false;
            uPanel.Choix[uPanel.NCGalilM27].Etat = false;       // Code & JDZ 016.05.11
    //        uPanel.Choix[uPanel.NCGalilFront].Etat = false;     // Code 016.05.11

            uPanel.Choix[uPanel.NCCamera].Etat = false;
            uPanel.Choix[uPanel.NCSimulation].Etat = true;
            uPanel.BeckhoffEnLigne = false;
            return;
        }
//---------------------------------------------------------------------------
public static void GoNext()
  {
      uMTasks.Work[uMTasks.ActiveTask].StateNo++;
    return ;
  }
//---------------------------------------------------------------------------
public static void GoState(int TargetState)
  {
      uMTasks.Work[uMTasks.ActiveTask].StateNo = TargetState;
    return ;
  }
//---------------------------------------------------------------------------
public static void GoSubAGN(int StateNoSub)
 {
     if (uMTasks.Work[uMTasks.ActiveTask].IndicePile < uMTasks.TaillePile)
      {
          uMTasks.Work[uMTasks.ActiveTask].IndicePile++;
          uMTasks.Work[uMTasks.ActiveTask].Pile[uMTasks.Work[uMTasks.ActiveTask].IndicePile] =
                uMTasks.Work[uMTasks.ActiveTask].StateNo;
       GoState(StateNoSub);
      }
     else
          {
     uPanel.MessageLu=" uPiaget - Gosub - Pile trop pleine, niveau= " +
             uMTasks.Work[uMTasks.ActiveTask].IndicePile.ToString() +
              "Tâche active: "+uMTasks.ActiveTask.ToString() ;
        }
      return;
 }
//--------------------------------------------------------------------------- 
public void Initialiser(){
    
    uPiaget.WriteOnCheckBoard("uPiaget.Initialiser");

    //uParam.LireParametres();
    

    //FPiaget.CheckSupportPhysiqueES();
    // System.Drawing.Color color = B;
    /*
           if (FPiaget.ActiveForm != null)
            {
             //   FPiaget.ActiveForm.Controls["pDirection"].Size.Height = 4;
            //    FPiaget.ActiveForm.Controls["pDirection"].Location.Y = 5;
           //    FPiaget.ActiveForm.Controls["pDirection"].ForeColor = (System.Drawing.Color)255L;
                FPiaget.ActiveForm.Controls["pDirection"].BackColor =#0000FF;
            //    FPiaget.ActiveForm.Controls["pDirection"].BackColor;
        //        FPiaget.ActiveForm.Controls["pTable"].BackColor;
            }


   */ 
     //uMouv.P0Robot.x = 20;
     //uMouv.P0Robot.y = 20;
     //uMouv.P0Robot.ThetaRobotDegres = 45;
     uPanel.Tool.x = 0;
     uPanel.Tool.y = 0;
     uPanel.Tool.phi = 0;
     // initialisation du temps relatif

     uPanel.SystemTicks = System.DateTime.Now.Ticks;
     uPanel.InitialTicks = uPanel.SystemTicks;

     //          uPanel.PastSeconds = System.DateTime.Now.Second;
     //      uPanel.PastSeconds = System.DateTime.Now.Second;

     uPanel.Ticks = 0;
     //    uPanel.SecondesPasseesRel = 0;
    
     //    uMTasks.Work[5].TaskStatus = uMTasks.EnAction;

     uMTasks.Work[5].TaskStatus = uMTasks.tPhase.EnAction;

     InitialisationChoix();
     InitialisationTasks();
     uParam.LireParametres();
       #if (!SimulationOnly)
       if (uPanel.Choix[uPanel.NCSimulation].Etat == false) uGalil.CheckConnectionGalil();//On controle si la connection au moteur fonctionne
        #endif
            /*
                    ///
                    /// ancien cpp
                    /// 
                    Form1->PDirection->Width = 8;
                    Form1->PDirection->Height = 8;
                    PhaseMatch = Pret;
                    TirBoule = false;
                    TirBalles = false;


  
                  Work[5].TaskStatus = EnAction;

                   for (int i = 1; i <= NSignauxBoolIn; i++)
                   {
                       SignauxIn[i].BoolNotAnalogique = true;
                       SignauxIn[i].AComplementer = false;
                       switch (i)
                       {
                           case 1: break;
                           case 2: break;
                           case 3: break;
                           case 4: break;
                           case 5: break;
                           case 6: break;
                           case 7: break;
                           case 8: break;	//SignauxIn[i].AComplementer=true;  // tests...
                           case 9: break;	//SignauxIn[i].AComplementer=true;  // balle coco
                               break;
                       }
                   }
                   for (int i = 1; i <= NSignauxAnalogiquesIn; i++)
                   {
                       SignauxIn[NSignauxBoolIn + i].BoolNotAnalogique = false;
                   }
                   //   extern void LireParametres();
                   CreerPalettes();
                   LireParametres();
                   Form1->CSpinEditPort->Value = ComPortLaserNumber;
                   Form1->Cam3DAngle->Value = Camera_OrientationD1;
                   Form1->ObjectHeight->Value = ObjectHeight1;


                   for (int i = 1; i <= NSignauxBoolOut; i++)
                   {
                       SignauxOut[i].EtatVF = false;
                       SignauxOut[i].AComplementer = false;
                       switch (i)
                       {
                           case
                           12: SignauxOut[i].AComplementer = false;  // tests...
                               break;
                       }

                   };

                   for (int i = 1; i <= NPalets; i++)
                   {
                       Palet[i].APrendre = true;
                       switch (i)
                       {
                           case
                               1:
                               if (Choix[NCVisionContinue].Etat)
                               {
                                   Palet[i].CouleurAPrendre = clLime;
                                   Palet[i].CouleurPris = clGreen;
                               }
                               else
                               {
                                   Palet[i].CouleurAPrendre = clRed;
                                   Palet[i].CouleurPris = clMaroon;
                               }
                               break;
                           case
                               2: if (Choix[NCVisionContinue].Etat)
                               {
                                   Palet[i].CouleurAPrendre = clLime;
                                   Palet[i].CouleurPris = clGreen;
                               }
                               else
                               {
                                   Palet[i].CouleurAPrendre = clRed;
                                   Palet[i].CouleurPris = clMaroon;
                               }
                               break;
                           case
                               11:
                               if (!Choix[NCVisionContinue].Etat)
                               {
                                   Palet[i].CouleurAPrendre = clLime;
                                   Palet[i].CouleurPris = clGreen;
                               }
                               else
                               {
                                   Palet[i].CouleurAPrendre = clRed;
                                   Palet[i].CouleurPris = clMaroon;
                               }
                               break;
                           case
                               12:
                               if (!Choix[NCVisionContinue].Etat)
                               {
                                   Palet[i].CouleurAPrendre = clLime;
                                   Palet[i].CouleurPris = clGreen;
                               }
                               else
                               {
                                   Palet[i].CouleurAPrendre = clRed;
                                   Palet[i].CouleurPris = clMaroon;
                               }
                               break;
                           default:
                               Palet[i].CouleurAPrendre = clYellow;
                               Palet[i].CouleurPris = clDkGray;

                       }   // case
                   }     // for

                   if (Choix[NCmNull].Etat) ModeImage = mNull;
                   if (Choix[NCmRouge].Etat) ModeImage = mRouge;
                   if (Choix[NCmVert].Etat) ModeImage = mVert;
                   if (Choix[NCmBlanc].Etat) ModeImage = mBlanc;
                   if (Choix[NCmNoir].Etat) ModeImage = mNoir;
                   if (Choix[NCmIntensite].Etat) ModeImage = mIntensite;
                   if (Choix[NCmSaturation].Etat) ModeImage = mSaturation;
                   if (Choix[NCmTeinte].Etat) ModeImage = mTeinte;



                   //  if  (!Initialise && !Choix[NCSimulation].Etat)
                   //      CheckSupportPhysiqueES();
                   //   else
                   // {
                   SupportPhysiqueES = !Choix[NCSimulation].Etat;

                   ToggleSupportPhysique();
                   //  }

                   if (!Choix[NCSimulation].Etat)
                   {
                       switch (ServoCommande)
                       {
                           case ServoGalilEthernet:
                               //  Réglé par le fichier de paramètres
                               //   InverseSensLineaire=false;    // cas Ethernet Galil
                               //   InverseSensRotation=false;
                               //   InverseCoteRotationXCentree=false;

                               //  if (!EthernetInitialise)
                               //        InitialiserEthernet();
                               //  if (!GalilInitialise)
                               if (Choix[NCGalil].Etat || ChoixGalilFront
                               || ChoixGalilBack)
                                   InitialiserGalil();
                               break;
                       } // fin case
                   } // fin if simulation

                   P0Cocotier = P0Robot;
                   P0Cocotier.x = 150;
                   P0Cocotier.y = 120;

                   CommandeBeckhoff = CMDBeckhoffTransparent;
                   CMDBalle = CMDNulle;
                   NBallesPrises = 0;
                   BalleHaut = false;
                   BalleMilieu = false;
                   BalleBas = false;

                   CreerPalettes();
                   //   ModeImage=mNull;
                   PRobotCamera.x = PRobotCameraX;
                   PRobotCamera.y = PRobotCameraY;
                   PRobotCamera.ThetaRobotDegres = PRobotCameraTheta;

             */
            //FPiaget.CheckSupportPhysiqueES();
            
        }  // fin Initialiser
 //-----------------------------------------------------------------------
public void InitialisationChoix()
{
    /*
     * Initialisation des choix
     */
    for (int i = 0; i < uPanel.NChoix; i++)
    {//for_01  
        /// A FAIRE *****      uPanel.Choix[i].nom = string("C Choix"); // AnsiString

        switch (i)
        {//switch_01
            case 1:
                /// A FAIRE *****  uPanel.Choix[i].nom = AnsiString("S Simulation");
                //    Choix[NCMusique].caractere+": son)";
                uPanel.NCSimulation = i;
                break;
            case
                2:
                /// A FAIRE *****  uPanel.Choix[i].nom = AnsiString("E Beckhoff");
                uPanel.NCBeckhoff = i;
                break;
            case
                3:
                /// A FAIRE *****  uPanel.Choix[i].nom = AnsiString("J Caméra");
                uPanel.NCCamera = i;
                break;
            case
                4:
                /// A FAIRE *****  uPanel.Choix[i].nom = AnsiString("K Galil");
                uPanel.NCGalil = i;
                break;
            case
                5:
                /// A FAIRE *****  uPanel.Choix[i].nom = AnsiString("A Musique");
                uPanel.NCMusique = i;
                break;
            case
                6:
                /// A FAIRE *****  uPanel.Choix[i].nom = AnsiString("Z StepSound");
                uPanel.NCStepSound = i;
                break;
            case
                7:
                /// A FAIRE *****  uPanel.Choix[i].nom = AnsiString("C Calibration");
                uPanel.NCCalibration = i;
                break;
            case
                8:
                /// A FAIRE *****  uPanel.Choix[i].nom = AnsiString("B VisionC");
                uPanel.NCVisionContinue = i;
                break;
            case
                9:
                /// A FAIRE *****  uPanel.Choix[i].nom = AnsiString("- Korebot");      // deleted
                //    NCKorebot=i;
                break;
            case
                10:
                /// A FAIRE *****  uPanel.Choix[i].nom = AnsiString("- Shoulder");
                uPanel.NCShoulder = i;
                break;
            case
                11:
                /// A FAIRE *****  uPanel.Choix[i].nom = AnsiString("- Hand");
                uPanel.NCHand = i;
                break;
            case
                12:
                /// A FAIRE *****  uPanel.Choix[i].nom = AnsiString("- Null");
                uPanel.NCmNull = i;
                break;
            case
                13:
                /// A FAIRE *****  uPanel.Choix[i].nom = AnsiString("- mRouge");
                uPanel.NCmRouge = i;
                break;
            case
                14:
                /// A FAIRE *****  uPanel.Choix[i].nom = AnsiString("- mVert");
                uPanel.NCmVert = i;
                break;
            case
                15:
                /// A FAIRE *****  uPanel.Choix[i].nom = AnsiString("- mBlanc");
                uPanel.NCmBlanc = i;
                break;
            case
                16:
                /// A FAIRE *****  uPanel.Choix[i].nom = AnsiString("- mNoir");
                uPanel.NCmNoir = i;
                break;
            case
                17:
                /// A FAIRE *****  uPanel.Choix[i].nom = AnsiString("- mIntensite");
                uPanel.NCmIntensite = i;
                break;
            case
                18:
                /// A FAIRE *****  uPanel.Choix[i].nom = AnsiString("- mSaturation");
                uPanel.NCmSaturation = i;
                break;
            case
                19:
                /// A FAIRE *****  uPanel.Choix[i].nom = AnsiString("- mTeinte");
                uPanel.NCmTeinte = i;
                break;
            case
                20:
                /// A FAIRE *****  uPanel.Choix[i].nom = AnsiString("- Galil1Or2L");
                uPanel.NCGalil1Or2L = i;
                break;
            case
                21:
                /// A FAIRE *****  uPanel.Choix[i].nom = AnsiString("- NCImage1Or2L");
                uPanel.NCImage1Or2L = i;

                break;
            case
                22:
                /// A FAIRE *****  uPanel.Choix[i].nom = AnsiString("- NCGalilM27");
                uPanel.NCGalilM27 = i;

                break;

        } // end_switch_01 : end of switch NChoix
    }  // end for Choix
}
 //---------------------------------------------------------------------
 public void InitialisationTasks(){
     /*
          * Initialisation des Tasks
          */
     for (int i = 1; i <= uMTasks.NTasks; i++)
     {//For_02

         uMTasks.Work[i].StateNo = 1;
         uMTasks.Work[i].SleepingState = false;
         uMTasks.Work[i].TaskStatus = uMTasks.tPhase.Faite;
         uMTasks.Work[i].IndicePile = 0;
         uMTasks.Work[i].ForData.InLoop = false;


         switch (i)
         {
             case
                 1: uMTasks.Work[i].Name = "Gestion du son"; // +
                 //    Choix[NCMusique].caractere+": son)";
                 //     NTSon=i;
                 break;
             case
                 2: uMTasks.Work[i].Name = "FaireUnPas(+,-)";
                 uPanel.NTPas = i;
                 break;
             case
                 3: uMTasks.Work[i].Name = "Lire clavier";
                 uPanel.NTLireClavier = i;
                 break;
             case
                 4: uMTasks.Work[i].Name = "MouvementPTP/*,/)";
                 uPanel.NTMouvementPTP = i;
                 break;
             case
                 5: uMTasks.Work[i].Name = "Stratégie";
                 uPanel.NTStrategie = i;
                 break;
             case
                 6: uMTasks.Work[i].Name = "LitEntréesRéelles";
                 uPanel.NTLireEntrees = i;
                 break;
             case
                 7: uMTasks.Work[i].Name = "Show status";
                 uPanel.NTShowStatus = i;
                 break;
             case
                 8: uMTasks.Work[i].Name = "Mouv(IM, TVFG)";
                 uPanel.NTMouvementSpat = i;
                 break;
             case
                 9: uMTasks.Work[i].Name = "ClignoteLED";
                 uPanel.NTLED = i;
                 break;
             case
                 10: uMTasks.Work[i].Name = "AnalyseImage(Y)";
                 uPanel.NTVision = i;
                 break;
             case
                 11: uMTasks.Work[i].Name = "Coordonner Moteurs";
                 uPanel.NTGererDoigt = i;
                 break;
             case
                 12: uMTasks.Work[i].Name = "";
                 uPanel.NTGererBalle = i;
                 break;
             case
                 13: uMTasks.Work[i].Name = " Tester entree  ";
                 uPanel.NTTesterEntree = i;
                 break;
             case
                 14: uMTasks.Work[i].Name = "  ";
                 //       NTActionTemporiseeDoigt=i;
                 break;
             case
                 15: uMTasks.Work[i].Name = "Detect. obstacles";
                 uPanel.NTGestionSouris = i;
                 break;
             case
                 16: uMTasks.Work[i].Name = "";
                 //           NTGestionDoigt=i;
                 break;
             case
                 17: uMTasks.Work[i].Name = "";
                 //           NTRefreshSorties=i;
                 break;
             case
                 18: uMTasks.Work[i].Name = "Interprète Piaget";
                 uPanel.NTInterpreteurPiaget = i;
                 break;
             case
                 19: uMTasks.Work[i].Name = "Vocal word agent";
                 //           NTAffichageGraphique=i;
                 break;
             case
                 20: uMTasks.Work[i].Name = "Dialogue manager";
                 break;
             case
                 21: uMTasks.Work[i].Name = "Map manager";

                 break;
         } // switch NTasks 

     } //End_For_02 for NTasks
 }
 //---------------------------------------------------------------------
 public static void CliquerBouton(string nomBouton, Form fenetre = null)
 {
     if (fenetre == null)
         (FPiaget.ActiveForm.Controls.Find(nomBouton, true)[0] as Button).PerformClick();
     else
         (fenetre.Controls.Find(nomBouton, true)[0] as Button).PerformClick();
 }
 //---------------------------------------------------------------------
public static void LireErreurGalil()
{
    uPiaget.WriteOnCheckBoard("uPiaget.LireErreurGalil");

    uTasks.errg = 0;
    uTasks.errd = 0;
    int FactSenseOPY= -1; // inversion de signe...
    
    switch(uPanel.Platform){ 
        case uPanel.tPlatform.RHY:
            uPiaget.LireErreurGalilTwoWheels();
            break;
        case uPanel.tPlatform.OPY:
            uPiaget.LireErreurGalilBack();
            uPiaget.LireErreurGalilFront();
            uTasks.V8ErreurGauche += uTasks.errg;
            uTasks.V8ErreurDroite += uTasks.errd;
            uTasks.V8ErreurGauche *= FactSenseOPY;
            uTasks.V8ErreurDroite *= FactSenseOPY;
            break;
        case uPanel.tPlatform.OP12Y:
            LireErreurGalil4AxesBack();
            LireErreurGalilFront();
            uTasks.V8ErreurGauche += uTasks.errg;
            uTasks.V8ErreurDroite += uTasks.errd;
            uTasks.V8ErreurGauche *= FactSenseOPY;
            uTasks.V8ErreurDroite *= FactSenseOPY;
            break;
   }  // end switch
    uPiaget.WriteErreurGalil();
}   // LireErreurGalil
//---------------------------------------------------------------------------
public static void LireErreurGalilTwoWheels()
{
    //uPiaget.WriteOnCheckBoard("uPiaget.LireErreurGalilTwoWheels");

    uPiaget.LireErreurGalilV8Erreur();
        /* Extrait code en C++
         
         void LireErreurGalilTwoWheels(long &pErreurGauche, long &pErreurDroite)
{
         //ATD
        char*   ptr = NULL;
        ExecuterCommandeGalilTwoWheelsAvecReponse("TEAB;", uPMessage) ;
        // Tell Error A et B
        uPiPos=AnsiPos(",",uPMessage);

        //ATD
        if( ptr = strstr( uPMessage.c_str(), "\r" ) )
        {
                *ptr = '\0';
        }
        uPss=uPMessage.SubString(1, uPiPos-1);
        pErreurGauche=StrToIntDef(uPss,1111);
        uPss=uPMessage.SubString(uPiPos+1, uPMessage.Length()-uPiPos);
        pErreurDroite=StrToIntDef(uPss,2222);
        if( Choix[NCSimulation].Etat )
        {
                pErreurGauche   = 5;
                pErreurDroite   = 10;
        }

        return;
}   // LireErreurGalilTwoWheels
         */

        return;
}   // LireErreurGalilTwoWheels
//---------------------------------------------------------------------------
public static void LireErreurGalilBack()
{//LireErreurGalilBack(long ErreurGauche, long ErreurDroite)
     
    uPiaget.WriteOnCheckBoard("uPiaget.LireErreurGalilBack");
    uPiaget.LireErreurGalilErreur();
    /*
     void LireErreurGalilBack(long &pErreurGauche, long &pErreurDroite)
{
         //ATD
        char*   ptr = NULL;
        ExecuterCommandeGalilBackAvecReponse("TEAB;", uPMessage) ;
        // Tell Error A et B
        uPiPos=AnsiPos(",",uPMessage);

        //ATD
        if( ptr = strstr( uPMessage.c_str(), "\r" ) )
        {
                *ptr = '\0';
        }
        uPss=uPMessage.SubString(1, uPiPos-1);
        pErreurGauche=StrToIntDef(uPss,1111);
        uPss=uPMessage.SubString(uPiPos+1, uPMessage.Length()-uPiPos);
        pErreurDroite=StrToIntDef(uPss,2222);
        if( Choix[NCSimulation].Etat )
        {
                pErreurGauche   = 5;
                pErreurDroite   = 10;
        }

        return;
}   // LireErreurGalilBack
     */
    return;
    }
 //---------------------------------------------------------------------------
public static void LireErreurGalilFront()
{//LireErreurGalilFront(long ErreurGauche, long ErreurDroite)
    
    uPiaget.WriteOnCheckBoard("uPiaget.LireErreurGalilFront");
    uPiaget.LireErreurGalilV8Erreur();

    /*
     void LireErreurGalilFront(long &pErreurGauche, long &pErreurDroite)
{
         //ATD
        char*   ptr = NULL;
        ExecuterCommandeGalilFrontAvecReponse("TEAB;", uPMessage) ;
        // Tell Error A et B
        uPiPos=AnsiPos(",",uPMessage);

        //ATD
        if( ptr = strstr( uPMessage.c_str(), "\r" ) )
        {
                *ptr = '\0';
        }
        uPss=uPMessage.SubString(1, uPiPos-1);
        pErreurGauche=StrToIntDef(uPss,1111);
        uPss=uPMessage.SubString(uPiPos+1, uPMessage.Length()-uPiPos);
        pErreurDroite=StrToIntDef(uPss,2222);
        if( Choix[NCSimulation].Etat )
        {
                pErreurGauche   = 5;
                pErreurDroite   = 10;
        }

        return;
}   // LireErreurGalilFront
     */
}
 //-------------------------------------------------------------------------
public static void LireErreurGalil4AxesBack()
{//LireErreurGalil4AxesBack(long ErreurGauche, long ErreurDroite)

        uPiaget.WriteOnCheckBoard("uPiaget.LireErreurGalil4AxesBack");
        uPiaget.LireErreurGalilErreur();
    /*
     void LireErreurGalil4AxesBack(long &pErreurGauche, long &pErreurDroite)
{
         //ATD
        char*   ptr = NULL;
        ExecuterCommandeGalil4AxesBackAvecReponse("TEAB;", uPMessage) ;
        // Tell Error A et B
        uPiPos=AnsiPos(",",uPMessage);

        //ATD
        if( ptr = strstr( uPMessage.c_str(), "\r" ) )
        {
                *ptr = '\0';
        }
        uPss=uPMessage.SubString(1, uPiPos-1);
        pErreurGauche=StrToIntDef(uPss,1111);
        uPss=uPMessage.SubString(uPiPos+1, uPMessage.Length()-uPiPos);
        pErreurDroite=StrToIntDef(uPss,2222);
        if( Choix[NCSimulation].Etat )
        {
                pErreurGauche   = 5;
                pErreurDroite   = 10;
        }

        return;
}   // LireErreurGalil4AxesBack
     */
    return;
}
//-----------------------------------------------------------------------
public static void LireErreurGalilV8Erreur()
{
    uPiaget.WriteOnCheckBoard("uPiaget.LireErreurGalilV8Erreur");
    string ErreurGalilTwoWheelsCmd = uGalil.ExecuterCommandeGalilTwoWheelsAvecReponse("TEAB");

    string[] ErreurGalilTwoWheelsPart = ErreurGalilTwoWheelsCmd.Split(',');

    uTasks.V8ErreurGauche = (long)Convert.ToDecimal(ErreurGalilTwoWheelsPart[0]);
    uTasks.V8ErreurDroite = (long)Convert.ToDecimal(ErreurGalilTwoWheelsPart[1]);
}
//-------------------------------------------------------------------------
public static void LireErreurGalilErreur()
{
    uPiaget.WriteOnCheckBoard("uPiaget.LireErreurGalilErreur");
    string ErreurGalilTwoWheelsCmd = uGalil.ExecuterCommandeGalilTwoWheelsAvecReponse("TEAB");

    string[] ErreurGalilTwoWheelsPart = ErreurGalilTwoWheelsCmd.Split(',');
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    uTasks.errg = (long)Convert.ToDecimal(ErreurGalilTwoWheelsPart[0]);
    uTasks.errd = (long)Convert.ToDecimal(ErreurGalilTwoWheelsPart[1]);
}
//-------------------------------------------------------------------------
public static  int Round(float x)
        {
            return Convert.ToInt32(Math.Floor(x + 0.5));
        }
 //--------------------------------------------------------------------------
public static void SetPositionRobot(int x, int y, int ThetaRobotDegres){
              // (re)définit la position nominale courante du robot
   
       uMouv.P0Robot.x = x;
       uMouv.P0Robot.y = y;
       uMouv.P0Robot.ThetaRobotDegres = ThetaRobotDegres;

        return ;
  }     
//---------------------------------------------------------------------------
public static void SleepAGN(float delay){
    uMTasks.SleepAGN(delay);
    return;
}
//----------------------------------------------------------------------------
public static void ToggleEtatSI(int NS){
    if (!uPanel.SignauxIn[NS].actif)
        uPanel.SignauxIn[NS].EtatVF = !uPanel.SignauxIn[NS].EtatVF;
    uPanel.SignauxIn[NS].actif = !uPanel.SignauxIn[NS].actif;
}
//-------------------------------------------------------------------------
public static void ClearCheckBoard()
{
    //uPanel.Message ="To implement************************************************************************************
    //*****************************************************************************************************************
    //if ((FPiaget.ActiveForm != null) )
        FPiaget.ActiveForm.Controls["zouzouPanel"].Text ="";
    //*****************************************************************************************************************
    //*****************************************************************************************************************
}
//---------------------------------------------------------------------------
public static void WriteOnCheckBoard(string zouzou)
{
    //uPanel.Message ="To implement************************************************************************************
    //*****************************************************************************************************************

   /*if ((FPiaget.ActiveForm != null) &&!FPiaget.ActiveForm.Controls["zouzouPanel"].Text.Contains(zouzou))
        FPiaget.ActiveForm.Controls["zouzouPanel"].Text =
            FPiaget.ActiveForm.Controls["zouzouPanel"].Text +
            " " + zouzou + " " +
            Environment.NewLine;*/
    //*****************************************************************************************************************
    //*****************************************************************************************************************
}
//---------------------------------------------------------------------------
public static void WriteErreurGalil()
{
    string tab = "\t";
    
    //uPiaget.WriteOnCheckBoard("uPiaget.WriteErreurGalil");
    uPanel.MessageErreur = " Erreurs gauche : " +tab+uTasks.V8ErreurGauche.ToString("00") +  Environment.NewLine;
    uPanel.MessageErreur = uPanel.MessageErreur + " Erreurs droite : " + tab + uTasks.V8ErreurDroite.ToString("00") + Environment.NewLine;
   // if (FPiaget.ActiveForm != null) FPiaget.ActiveForm.Controls["tBControl"].Text = uPanel.MessageErreur;
}

    } // fin Class uPiaget
}