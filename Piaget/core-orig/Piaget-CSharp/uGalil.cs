using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Piaget_CSharp
{
    static class uGalil
    {
        // signe moins: Inversion Avant-Arriere
        // Inversion de sens de rotation: voir la variable booléenne "SurLeDos"
        public static long FacteurGalil = 20;  // pour RH-Y et anciens robots
        public static long FacteurGalilFront = 20 * 150 / 86, FacteurGalilBack = FacteurGalilFront; // à ajuster pour OP1-Y
        public static float FacteurGalilRotationFront = 1.618F; // selon essais
//        public static Galil.GalilClass g = new Galil.GalilClass();             // O L D   N'est plus possible avec .NET Framework 4.5 !?!
        public static Galil.Galil g = new Galil.Galil();                         // N E W   EHe, 015.01.22

        public static string AddressGalil;

        /* liste d'adresse ci-dessous à clarifier d'apres la platform
         */
        public static string AddressModelSn8349 = "172.16.17.23";// faire reference au donne d controller de DMC Smart Terminal
        public static string AddressModelSn13458 = "172.16.17.5";// faire reference au donne d controller de DMC Smart Terminal
        public static string AddressModelSn5476 = "172.16.17.6";// faire reference au donne d controller de DMC Smart Terminal

        public static string AddressModelSn15202 = "172.16.17.31";// faire reference au donne d controller de DMC Smart Terminal
        public static string AddressGalilMotorTest = "172.16.17.31";// faire reference au donne d controller de DMC Smart Terminal


        public static string AddressGalilTwoWheels = AddressGalilMotorTest;// faire reference au donne d controller de DMC Smart Terminal
        public static string AddressGalilBack = AddressGalilMotorTest;// faire reference au donne d controller de DMC Smart Terminal
        public static string AddressGalil8AxesFront = AddressGalilMotorTest;// faire reference au donne d controller de DMC Smart Terminal
        public static string AddressGalil4AxesBack = AddressGalilMotorTest;// faire reference au donne d controller de DMC Smart Terminal



    
        public static string AddressGalilRHY = "172.16.17.31";// faire reference au donne d controller de DMC Smart Terminal
        public static string AddressGalilOPY = "172.16.17.31";// faire reference au donne d controller de DMC Smart Terminal
        public static string AddressGalilOP12Y = "172.16.17.31";// faire reference au donne d controller de DMC Smart Terminal

        public static bool GalilOpen = false,           GalilOpenFront = false,     GalilOpenBack = false,
                           GalilOpen8AxesFront = false, GalilOpen4AxesBack = false,  GalilInitialise = false;
        public static string ACR = "\r\n", CommandGalil, CmdGalilBack;

        public static float TempX,              TempY,              XGalil = 0, 
                            XGalilBack = 0,     YGalilBack = 0,     XGalil4AxesBack=0,  
                            YGalil4AxesBack=0,  XGalil8AxesFront=0, YGalil8AxesFront=0;
        public static float YGalil = 0, XGalilFront = 0, YGalilFront = 0;
        public static string rcGalilBack;
        public static int FactOPYLinearSense = -1, FactOPYRotationalSense = -1;

        public static string Zouzouaddress = "zouzou";

        public static bool TesterFinMouvementDApresErreur = false,
                            TimeOutMouvement = false,
                            UtiliserCoordonneesAbsolues = true;
        public static float DureeMaxMouvement = 3;
        public static int GalilRHYControllerNumber, GalilOPYControllerFrontNumber, GalilOPYControllerBackNumber;
        //public static bool ModeRHYorOPYlow;
        //-----------------------------------------------------------------
        public static void ActiverPuissanceGalil()
        {//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
           //g.address = AddressGalil;
            g.address = AddressModelSn8349; // Code 016
           // g.address = "172.16.17.23";
            g.command("SH");
            //---ExecuterCommandeGalil("SH");   // Motor Off
            return;
        }
        //-------------------------------------------------------------------
        public static void AttendreFinMouvementGalil()
        {
            uPiaget.WriteOnCheckBoard("uGalil.AttendreFinMouvementGalil");
            g.command("AM");
            //---uGalil.ExecuterCommandeGalil("AM");
            /*
             * rcGalil = DMCWaitForMotionComplete(hDmc, "XY", TRUE);
             */

            return;
        }
        //------------------------------------------------------------------
        public static void ArretMouvementGalil()
        {
            
            g.command("AB");
            //---ExecuterCommandeGalil("AB");   // Motor Off
            return;
        }
        //------------------------------------------------------------------------*******************************************************************************************-
        /*
         * Avance d'une distance en cm pour les roues du milieu avec profil de mouvement (distance en absolue)
         */
        public static void AvancerGalil4Axes(uPanel.tPlatform plateforme)
        {
            //uPanel.Message ="To implement************************************************************************************
            //*****************************************************************************************************************
            //if ((FPiaget.ActiveForm != null) && !FPiaget.ActiveForm.Controls["zouzouPanel"].Text.Contains("AvancerGalil4Axes"))
                FPiaget.ActiveForm.Controls["zouzouPanel"].Text =
                    FPiaget.ActiveForm.Controls["zouzouPanel"].Text +
                    " uGalil.AvancerGalil4Axes " +
                    Environment.NewLine;
            //*****************************************************************************************************************
            //*****************************************************************************************************************
            /*
               // Transformation en nombre de pas des distances
               plateforme.Roues.DistRMG = (int)((float)plateforme.Roues.DistRMG*plateforme.facteur.ConversionCmEnPas*plateforme.facteur.CorrectionCmEnPas);
               plateforme.Roues.DistRMD = (int)((float)plateforme.Roues.DistRMD*plateforme.facteur.ConversionCmEnPas*plateforme.facteur.CorrectionCmEnPas);

               // Envoi des commandes aux axes spécifiques
               ExecuterCommandeGalil4AxesBack("ACC=" + IntToStr(plateforme.Roues.AccRMG) + AnsiString::StringOfChar(13,1) +
                                             "ACD=" + IntToStr(plateforme.Roues.AccRMD) + AnsiString::StringOfChar(13,1) +
                                             "DCC=" + IntToStr(plateforme.Roues.DecRMG) + AnsiString::StringOfChar(13,1) +
                                             "DCD=" + IntToStr(plateforme.Roues.DecRMD) + AnsiString::StringOfChar(13,1) +
                                             "SPC=" + IntToStr(plateforme.Roues.VRMG) + AnsiString::StringOfChar(13,1) +
                                             "SPD=" + IntToStr(plateforme.Roues.VRMD) + AnsiString::StringOfChar(13,1) +
                                             "PAC=" + IntToStr(plateforme.Roues.DistRMG) + AnsiString::StringOfChar(13,1) +
                                             "PAD=" + IntToStr(plateforme.Roues.DistRMD) + AnsiString::StringOfChar(13,1) +
                                             "BGCD" + AnsiString::StringOfChar(13,1));
            */
            return;
        }  // end of AvancerGalil4Axes
        //--------------------------------------------------------------------------
        /*
         * Avance d'une distance en cm pour les roues arrière et avant avec profil de mouvement (distance en absolue)
         */
        public static void AvancerGalil8Axes(uPanel.tPlatform PlateformeP12Y_plateforme)
        {
            //uPanel.Message ="To implement************************************************************************************
            //*****************************************************************************************************************
           // if ((FPiaget.ActiveForm != null) && !FPiaget.ActiveForm.Controls["zouzouPanel"].Text.Contains("AvancerGalil8Axes"))
                FPiaget.ActiveForm.Controls["zouzouPanel"].Text =
                    FPiaget.ActiveForm.Controls["zouzouPanel"].Text +
                    " AvancerGalil8Axes " +
                    Environment.NewLine;
            //*****************************************************************************************************************
            //*****************************************************************************************************************
            /*
               // Transformation en nombre de pas des distances
               plateforme.Roues.DistRArG = (int)((float)plateforme.Roues.DistRArG*plateforme.facteur.ConversionCmEnPas*plateforme.facteur.CorrectionCmEnPas);
               plateforme.Roues.DistRArD = (int)((float)plateforme.Roues.DistRArD*plateforme.facteur.ConversionCmEnPas*plateforme.facteur.CorrectionCmEnPas);
               plateforme.Roues.DistRAvG = (int)((float)plateforme.Roues.DistRAvG*plateforme.facteur.ConversionCmEnPas*plateforme.facteur.CorrectionCmEnPas);
               plateforme.Roues.DistRAvD = (int)((float)plateforme.Roues.DistRAvD*plateforme.facteur.ConversionCmEnPas*plateforme.facteur.CorrectionCmEnPas);

               // Envoi des commandes aux axes spécifiques
               ExecuterCommandeGalil8AxesFront("ACE=" + IntToStr(plateforme.Roues.AccRArG) + AnsiString::StringOfChar(13,1) +
                                              "ACF=" + IntToStr(plateforme.Roues.AccRArD) + AnsiString::StringOfChar(13,1) +
                                              "ACG=" + IntToStr(plateforme.Roues.AccRAvG) + AnsiString::StringOfChar(13,1) +
                                              "ACH=" + IntToStr(plateforme.Roues.AccRAvD) + AnsiString::StringOfChar(13,1) +

                                              "DCE=" + IntToStr(plateforme.Roues.DecRArG) + AnsiString::StringOfChar(13,1) +
                                              "DCF=" + IntToStr(plateforme.Roues.DecRArD) + AnsiString::StringOfChar(13,1) +
                                              "DCG=" + IntToStr(plateforme.Roues.DecRAvG) + AnsiString::StringOfChar(13,1) +
                                              "DCH=" + IntToStr(plateforme.Roues.DecRAvD) + AnsiString::StringOfChar(13,1) +

                                              "SPE=" + IntToStr(plateforme.Roues.VRArG) + AnsiString::StringOfChar(13,1) +
                                              "SPF=" + IntToStr(plateforme.Roues.VRArD) + AnsiString::StringOfChar(13,1) +
                                              "SPG=" + IntToStr(plateforme.Roues.VRAvG) + AnsiString::StringOfChar(13,1) +
                                              "SPH=" + IntToStr(plateforme.Roues.VRAvD) + AnsiString::StringOfChar(13,1) +

                                              "PAE=" + IntToStr(plateforme.Roues.DistRArG) + AnsiString::StringOfChar(13,1) +
                                              "PAF=" + IntToStr(plateforme.Roues.DistRArD) + AnsiString::StringOfChar(13,1) +
                                              "PAG=" + IntToStr(plateforme.Roues.DistRAvG) + AnsiString::StringOfChar(13,1) +
                                              "PAH=" + IntToStr(plateforme.Roues.DistRAvD) + AnsiString::StringOfChar(13,1) +
                                              "BGEFGH" + AnsiString::StringOfChar(13,1));
            */
            return;
        }  // end of AvancerGalil8Axes
        //---------------------------------------------------------------------------
        public static void CouperPuissanceGalil()
        {
            g.command("MO");
            //---ExecuterCommandeGalil("MO");   // Motor Off
            //ExecuterCommandeGalil("MO"+ACR);   // Motor Off SL2013
            return;
        }
        //---------------------------------------------------------------------------
        public static void CheckConnectionGalil()
        {
            if (!uPanel.Choix[uPanel.NCSimulation].Etat && uPanel.Choix[uPanel.NCGalil].Etat)
            {
                uGalil.SetAddressGalil(uGalil.AddressGalilMotorTest);

                //uPiaget.WriteOnCheckBoard("uGalil.CheckConnectionGalil");
                //g.command("OB 3,1");
                //---uGalil.ExecuterCommandeGalil("OB 3,1");//OB 3,0 pour eteindre
                uGalil.ActiverPuissanceGalil();
                g.command("DP 0,0");
                //uGalil.ExecuterCommandeGalil("DP 0,0");
                uGalil.LecturePositionGalil();
                g.command("PR 5000");
                //---uGalil.ExecuterCommandeGalil("PR -5000");
                g.command("BG");
                //---uGalil.ExecuterCommandeGalil("BG");
                //uGalil.AttendreFinMouvementGalil(); 
                //uGalil.LecturePositionGalil();
                //     g.command("PR -5000");
                //---uGalil.ExecuterCommandeGalil("PR 5000");
                //  g.command("BG");
                //uGalil.ExecuterCommandeGalil("BG");
                //uGalil.AttendreFinMouvementGalil();
                // uGalil.LecturePositionGalil();
                //uPiaget.WriteOnCheckBoard("uGalil.CheckConnectionGalil : End");
            }
            return;
        }
         //------------------------------------------------------------------
        public static void ExecutionGalil(String CmdGalil)
        {
            #if (!SimulationOnly)
            //uGalil.ActiverPuissanceGalil();
            uPiaget.WriteOnCheckBoard("uGalil.ExecutionGalil : >>>" + CmdGalil);
            //rcGalilFront = DMCCommand(hDmcFront, C.c_str(),szBufferFront, sizeof(szBufferFront));

            if (uPanel.Choix[uPanel.NCSimulation].Etat==false) uGalil.g.command(CmdGalil, ACR, ":", true);
            #endif
            return;
          
        }
        //------------------------------------------------------------------
        public static string ExecutionGalilAvecReponse(String CmdGalil)
        {
#if (!SimulationOnly)
            if(uGalil.g.address != "")
            {
                uPiaget.WriteOnCheckBoard("uGalil.ExecutionGalilAvecReponse >> " + CmdGalil);
                //rcGalilFront = DMCCommand(hDmcFront, C.c_str(),szBufferFront, sizeof(szBufferFront));

                if (uPanel.Choix[uPanel.NCSimulation].Etat == false)
                {
                    //uGalil.g.command(CmdGalil, ACR, ":", true);
                    // uGalil.AttendreFinMouvementGalil();
                    uGalil.CmdGalilBack = uGalil.g.command(CmdGalil, ACR, ":", true);
                    uPiaget.WriteOnCheckBoard("uGalil.ExecutionGalilAvecReponse : <<" + uGalil.CmdGalilBack);
                    return uGalil.CmdGalilBack;
                }
                /*
                 uPiaget.WriteOnCheckBoard("uGalil.LecturePositionGalil");
                 */
                uPiaget.WriteOnCheckBoard("uGalil.ExecutionGalilAvecReponse : End");
            }
#endif

            return "";
        }
        //-----------------------------------------------------------------------
        public static void ExecuterCommandeGalil(string CmdGalil)
        {   
            uPiaget.WriteOnCheckBoard("uGalil.ExecuterCommandeGalil");


            switch (uPanel.Platform)
            {
                case uPanel.tPlatform.RHY:
                    #if (!SimulationOnly)
                    uGalil.g.address = uGalil.AddressGalilRHY;
                    #endif
                    uGalil.ExecuterCommandeGalilTwoWheels(CmdGalil);
                    break;
                case uPanel.tPlatform.OPY:
                    #if (!SimulationOnly)
                    uGalil.g.address = uGalil.AddressGalilOPY;
                    #endif
                    uGalil.ExecuterCommandeGalilFront(CmdGalil);
                    uGalil.ExecuterCommandeGalilBack(CmdGalil);
                    break;
                case uPanel.tPlatform.OP12Y:
                    #if (!SimulationOnly)
                    uGalil.g.address = uGalil.AddressGalilOP12Y;
                    #endif
                    uGalil.ExecuterCommandeGalil8AxesFront(CmdGalil);
                    uGalil.ExecuterCommandeGalil4AxesBack(CmdGalil);
                    break;
                case uPanel.tPlatform.NONE :
                    break;
            } // end switch
            

        }
        //---------------------------------------------------------------------------
        public static string ExecuterCommandeGalilAvecReponse(string CmdGalil)
        {
            uPiaget.WriteOnCheckBoard("ExecuterCommandeGalilAvecReponse >>" + CmdGalil);
            string CBackTmp;
           if (uPanel.ModeRHYorOPYlow)
              uGalil.CmdGalilBack = uGalil.ExecuterCommandeGalilTwoWheelsAvecReponse(CmdGalil);
           else
           {
               uGalil.CmdGalilBack = uGalil.ExecuterCommandeGalilFrontAvecReponse(CmdGalil);
               CBackTmp = uGalil.ExecuterCommandeGalilBackAvecReponse(CmdGalil);
                uGalil.CmdGalilBack=uGalil.CmdGalilBack+CBackTmp;     
             }
           //uPiaget.WriteOnCheckBoard("uGalil.ExecuterCommandeGalilAvecReponse : " + uGalil.CmdGalilBack);
           return uGalil.CmdGalilBack;
        }
        //-------------------------------------------------------------------------
        public static void ExecuterCommandeGalilBack(string CmdGalil)
        {
            uPiaget.WriteOnCheckBoard("uGalil.ExecuterCommandeGalilBack");
            //rcGalilBack = DMCCommand(hDmcBack, C.c_str(),szBufferBack, sizeof(szBufferBack));
            uGalil.SetAddressGalil(uGalil.AddressGalilBack);
            uGalil.ExecutionGalil(CmdGalil);
            return;
        }
        //---------------------------------------------------------------------------
        public static string ExecuterCommandeGalilBackAvecReponse(string CmdGalil)
        {
            uPiaget.WriteOnCheckBoard("uGalil.ExecuterCommandeGalilBackAvecReponse : " + uGalil.CmdGalilBack);
            uGalil.CmdGalilBack = uGalil.ExecutionGalilAvecReponse(CmdGalil);
            return uGalil.CmdGalilBack;
        }  // end ExecuterCommandeGalilBackAvecReponse
        //-------------------------------------------------------------------------
        public static void ExecuterCommandeGalilFront(String CmdGalil)
        {
            uPiaget.WriteOnCheckBoard("uPiaget.ExecuterCommandeGalilFront");
            uGalil.ExecutionGalil(CmdGalil);
            return;
        }
        //---------------------------------------------------------------------------
        public static string ExecuterCommandeGalilFrontAvecReponse(string CmdGalil)
        {
            uGalil.SetAddressGalil(uGalil.AddressGalil8AxesFront);
            uPiaget.WriteOnCheckBoard("uGalil.ExecuterCommandeGalilFrontAvecReponse : " + uGalil.CmdGalilBack);
            uGalil.CmdGalilBack = uGalil.ExecutionGalilAvecReponse(CmdGalil);
            return uGalil.CmdGalilBack;
        }  // end ExecuterCommandeGalilFrontAvecReponse
        //---------------------------------------------------------------------------
        public static void ExecuterCommandeGalilTwoWheels(string CmdGalil)
        {
            //uPiaget.WriteOnCheckBoard("uPiaget.ExecuterCommandeGalilTwoWheels");

            //uGalil.SetAddressGalil(uGalil.AddressGalilTwoWheels);

            //if (!uPanel.Choix[uPanel.NCSimulation].Etat && uPanel.Choix[uPanel.NCGalil].Etat)  // 010.06.12 JDZ
                //rcGalil = DMCCommand(hDmc, C.c_str(),szBuffer, sizeof(szBuffer));
                uGalil.ExecutionGalil(CmdGalil);
            return;
             
        }
        //-----------------------------------------------------------------------------
        public static string ExecuterCommandeGalilTwoWheelsAvecReponse(string CmdGalil)
        {
            //uPiaget.WriteOnCheckBoard("uGalil.ExecuterCommandeGalilTwoWheelsAvecReponse >> " + CmdGalil);
            uGalil.CmdGalilBack = uGalil.ExecutionGalilAvecReponse(CmdGalil);
            //uPiaget.WriteOnCheckBoard("uGalil.ExecuterCommandeGalilTwoWheelsAvecReponse : " + CmdGalil+"//" + uGalil.CmdGalilBack);
            return uGalil.CmdGalilBack;
        }  // end ExecuterCommandeGalilTwoWheelsAvecReponse
        //---------------------------------------------------------------------------
        public static void ExecuterCommandeGalil4AxesBack(string CmdGalil)
        {
            uPiaget.WriteOnCheckBoard("uPiaget.ExecuterCommandeGalil4AxesBack");

            if (!uPanel.Choix[uPanel.NCSimulation].Etat )  // 013.05.16 SG, JDZ  *****
                //rcGalil4AxesBack = DMCCommand(hDmc4AxesBack, C.c_str(), szBuffer4AxesBack, sizeof(szBuffer4AxesBack));
                uGalil.ExecutionGalil(CmdGalil);
            return;
        }
        //---------------------------------------------------------------------------
        public static string ExecuterCommandeGalil4AxesBackAvecReponse(string CmdGalil, string C4AxesBack)
        {
            uPiaget.WriteOnCheckBoard("uGalil.ExecuterCommandeGalil4AxesBackAvecReponse : " + uGalil.CmdGalilBack);
            uGalil.CmdGalilBack = uGalil.ExecutionGalilAvecReponse(CmdGalil);
            return uGalil.CmdGalilBack;
        }  // end ExecuterCommandeGalil4AxesBackAvecReponse
        //---------------------------------------------------------------------------
        public static string ExecuterCommandeGalil8AxesFrontAvecReponse(string CmdGalil)
        {
            uGalil.CmdGalilBack = uGalil.ExecutionGalilAvecReponse(CmdGalil);
            uPiaget.WriteOnCheckBoard("uGalil.ExecuterCommandeGalil8AxesFrontAvecReponse : " + uGalil.CmdGalilBack);
            return uGalil.CmdGalilBack;
            
        /*
         void EnvoyerCommandeGalil8AxesFrontAvecReponse(AnsiString C, AnsiString &C8AxesFront)
        {
        //  AnsiString as;
        rcGalil8AxesFront=DMCCommand(hDmc8AxesFront,C.c_str(),szBuffer8AxesFront,sizeof(szBuffer8AxesFront));
        if ((Choix[NCSimulation].Etat) || (!ChoixGalil8AxesFront))
             strcpy( szBuffer8AxesFront , "  777,  888" ); // A verifier
        //    as=szBuffer;
        //     CBack=as;
        C8AxesFront=szBuffer8AxesFront;

        }  // end EnvoyerCommandeGalil8AxesFrontAvecReponse
         */
            
        }  // end ExecuterCommandeGalil8AxesFrontAvecReponse
        //-----------------------------------------------------------------------
        public static void ExecuterCommandeGalil8AxesFront(string CmdGalil)
        {
            uPiaget.WriteOnCheckBoard("uGalil.ExecuterCommandeGalil8AxesFront");
            uGalil.ExecutionGalil(CmdGalil);
            /*
          void EnvoyerCommandeGalil4AxesBack(AnsiString C){
            if (!Choix[NCSimulation].Etat && (Form1->PG4->Color==clLime))  // 013.05.16 SG, JDZ  *****
                rcGalil4AxesBack=DMCCommand(hDmc4AxesBack,C.c_str(),szBuffer4AxesBack,sizeof(szBuffer4AxesBack));
            return;
           }
             */
            return;
        }
        //---------------------------------------------------------------------------
        public static void ExecuterProgrammeGalil(string Label)
        {
            uPiaget.WriteOnCheckBoard("uGalil.ExecuterProgrammeGalil");
            //uGalil.ExecutionGalil(CmdGalil);
            uGalil.ExecuterCommandeGalil(";;XQ#" + Label + ";");
        }
        //-----------------------------------------------------------------------
        public static void ResetPositionGalil()
        {
            uPiaget.WriteOnCheckBoard("uGalil.ResetPositionGalil");

            if (uPanel.ModeRHYorOPYlow)
                uGalil.ResetPositionGalilTwoWheels();
            else
            {
                uGalil.ResetPositionGalilFront();
                uGalil.ResetPositionGalilBack();
            }
             
            return;
        }
        //-------------------------------------------------------------------------
        public static void SetAddressGalil(string Address)
        {
            #if (!SimulationOnly)   
            // g.address = Address; -- initiate connection, program crash if the Galil
            // card isn't connected, even in simulation mode 015.07.20 FRZ
            AddressGalil = Address;
            #endif
        }
        //---------------------------------------------------------------------------
        public static void InitialiserGalilTwoWheels()
        {
            uPiaget.WriteOnCheckBoard("uGalil.InitialiserGalilTwoWheels");
            // ModeRHYorOPYlow,
            // Form1->PRHY->Color=clLime;
            // Form1->POPY->Color=clRed;
            // GalilRHYControllerNumber=StrToInt(Form1->PRHYControllerNumber->Caption);}
            // GalilOPYControllerFrontNumber=StrToInt(Form1->POPYControllerFront->Caption);
            // GalilOPYControllerBackNumber=StrToInt(Form1->POPYControllerBack->Caption);}
            // ChoixGalilFront, ChoixGalilBack;

            if (uPanel.Choix[uPanel.NCGalil].Etat)
            {
                GalilOpen = true;

                uGalil.SetAddressGalil(uGalil.AddressGalilTwoWheels);
                g.command("RS");
                //---uGalil.ExecuterCommandeGalil("RS");         //  reset  NON utilisé car coupe la communication
                g.command("DP 0,0");
                //---uGalil.ExecuterCommandeGalil("DP 0,0");     //  mise à zéro des compteurs-position
                g.command("ER 100,100");
                //---uGalil.ExecuterCommandeGalil("ER 100,100"); //  Erreur limite max (Tolérance pour
                                                            //  suivi de trajectoire)  (traditionnellement, 100)
                g.command("EO 0,0");
                //---uGalil.ExecuterCommandeGalil("EO 0,0");     //  005.12.23 JDZ et PFG pas de coupure de courant en cas d'erreur
                                                            //  Default values on Galil card at power on, KP = 300, KD = 500, KI = 100
                                                            //  "old wheels" values : KP = 120, KD = 250, KI = 5
                g.command("KP 500,500");
                //---uGalil.ExecuterCommandeGalil("KP 500,500"); // BEFORE 21.5.2010: 300
                g.command("KD 750,750");
                //---uGalil.ExecuterCommandeGalil("KD 750,750"); // BEFORE 21.5.2010: 500
                g.command("KI 10,10");
                //---uGalil.ExecuterCommandeGalil("KI 10,10");   // BEFORE 21.5.2010: 100
                g.command("TL 9.99,9.99");
                //---uGalil.ExecuterCommandeGalil("TL 9.99,9.99");
                /*
                uGalil.ExecuterCommandeGalil(//"RS"+ACR+    //  reset  NON utilisé car coupe la communication
                              "DP 0,0" + ACR +              // mise à zéro des compteurs-position
                              "ER 100,100" + ACR +          //  Erreur limite max (Tolérance pour
                    //  suivi de trajectoire)  (traditionnellement, 100)
                              "EO 0,0" + ACR +              // 005.12.23 JDZ et PFG pas de coupure de courant en cas d'erreur
                    //       Default values on Galil card at power on, KP = 300, KD = 500, KI = 100
                    //       "old wheels" values : KP = 120, KD = 250, KI = 5
                              "KP 500,500" + ACR +          // BEFORE 21.5.2010: 300
                              "KD 750,750" + ACR +          // BEFORE 21.5.2010: 500
                              "KI 10,10" + ACR +            // BEFORE 21.5.2010: 100
                              "TL 9.99,9.99" + ACR +        //  Tension de commande maximale
                    //  Valeur max = 9.998V
                              "SH" + ACR);                  //  Servo Here; met la puissance
                */
                uGalil.ProgrammerGalil();
            }
            return;
        }     // void InitialiserGalilTwoWheels ()
        //---------------------------------------------------------------------------
        public static void InitialiserGalil()
        {
            uPiaget.WriteOnCheckBoard("uGalil.InitialiserGalil");
            //uGalil.ActiverPuissanceGalil();
            switch (uPanel.Platform)
            {
                case uPanel.tPlatform.RHY:
                    InitialiserGalilTwoWheels();
                    break;
               /* case uPanel.tPlatform.OPY:
                    InitialiserGalilFront();
                    InitialiserGalilBack();
                    break;
                case uPanel.tPlatform.OP12Y:
                    InitialiserGalil8AxesFront();
                    InitialiserGalil4AxesBack();*/
                  //  break;
            } // end switch

        }     // void InitialiserGalil ()
        //---------------------------------------------------------------------------
        public static void InitialiserGalilBack()
        {
            //uPanel.Message ="To implement************************************************************************************
            //*****************************************************************************************************************
            //if ((FPiaget.ActiveForm != null) && !FPiaget.ActiveForm.Controls["zouzouPanel"].Text.Contains("InitialiserGalilBack"))
                FPiaget.ActiveForm.Controls["zouzouPanel"].Text =
                    FPiaget.ActiveForm.Controls["zouzouPanel"].Text +
                    " uGalil.InitialiserGalilBack " +
                    Environment.NewLine;
           
            if (uPanel.ChoixGalilBack)
            {
                //rcGalilBack = DMCOpen(GalilOPYControllerBackNumber,hWndBack,&hDmcBack);
                #if (!SimulationOnly)
                uGalil.g.address = uGalil.AddressGalilBack;//definir l'adresse IP SL2013
                #endif

                GalilOpenBack = true;
                uGalil.SetAddressGalil(uGalil.AddressGalilBack);
                uGalil.ExecuterCommandeGalilBack("DP 0,0,0,0,0,0,0,0");
                uGalil.ExecuterCommandeGalilBack("SH");
                /*
                ExecuterCommandeGalilBack(//"RS"+ACR+            //  reset  NON utilisé car coupe la communication
                                     "DP 0,0,0,0,0,0,0,0" + ACR +        // mise à zéro des compteurs-position
                                     "SH" + ACR);           //  Servo Here; met la puissance
                // ProgrammerGalilBack();   à faire si nécessaire
                 */
            }
            uGalil.XGalilBack = 0; uGalil.YGalilBack = 0;
            uGalil.GalilInitialise=true;
            return;
        }     // void InitialiserGalilBack ()
        //---------------------------------------------------------------------------
        public static void InitialiserGalil4AxesBack()
        {
            //uPanel.Message ="To implement************************************************************************************
            //*****************************************************************************************************************
           // if ((FPiaget.ActiveForm != null) && !FPiaget.ActiveForm.Controls["zouzouPanel"].Text.Contains("InitialiserGalil4AxesBack"))
                FPiaget.ActiveForm.Controls["zouzouPanel"].Text =
                    FPiaget.ActiveForm.Controls["zouzouPanel"].Text +
                    " InitialiserGalil4AxesBack " +
                    Environment.NewLine;
            //*****************************************************************************************************************
            //*****************************************************************************************************************
            
            /*
            if (Form1->PG4->Color == clLime)
                    ChoixGalil4AxesBack = true;
            else
                    ChoixGalil4AxesBack = false;
             */
            if (uPanel.ChoixGalilBack)
            {
                if (!uGalil.GalilOpen4AxesBack)
                {

                  //rcGalil4AxesBack = DMCOpen(GalilOP12YControllerBackNumber,hWnd4AxesBack,&hDmc4AxesBack);

                uGalil.GalilOpen4AxesBack=true;
                uGalil.SetAddressGalil(uGalil.AddressGalil4AxesBack);//On entre l'adresse IP de Galil4AxesBack
                uGalil.ExecutionGalil("RS");
                uGalil.ExecutionGalil("DP 0,0,0,0");
                uGalil.ExecutionGalil("SH");
                    /*
             ExecuterCommandeGalil4AxesBack(//"RS"+ACR+            //  reset  NON utilisé car coupe la communication
                                  "DP 0,0,0,0"+ACR+        // mise à zéro des compteurs-position
                                  "SH"+ACR);           //  Servo Here; met la puissance
            // ProgrammerGalilBack();   à faire si nécessaire
                     */ 
             }
            }
            uGalil.XGalil4AxesBack = 0; 
            uGalil.YGalil4AxesBack = 0; 
            return;
        }     // void InitialiserGalil4AxesBack ()
        //---------------------------------------------------------------------------
        public static void InitialiserGalil8AxesFront()
        {
            //uPanel.Message ="To implement************************************************************************************
            //*****************************************************************************************************************
            //if ((FPiaget.ActiveForm != null) && !FPiaget.ActiveForm.Controls["zouzouPanel"].Text.Contains("InitialiserGalil8AxesFront"))
                FPiaget.ActiveForm.Controls["zouzouPanel"].Text =
                    FPiaget.ActiveForm.Controls["zouzouPanel"].Text +
                    " InitialiserGalil8AxesFront " +
                    Environment.NewLine;
            //*****************************************************************************************************************
            //*****************************************************************************************************************
           
            
            if (uPanel.ChoixGalil8AxesFront)
            { 
                //rcGalil8AxesFront = DMCOpen(GalilOP12YControllerFrontNumber,hWnd8AxesFront,&hDmc8AxesFront);
                uGalil.GalilOpen8AxesFront=true;
                uGalil.SetAddressGalil(uGalil.AddressGalil8AxesFront);
                uGalil.ExecutionGalil("DP 0,0");
                uGalil.ExecutionGalil("SH");
                /*
              ExecuterCommandeGalil8AxesFront(//"RS"+ACR+            //  reset  NON utilisé car coupe la communication
                                  "DP 0,0"+ACR+        // mise à zéro des compteurs-position
                                  "SH"+ACR);           //  Servo Here; met la puissance
             // ProgrammerGalilFront();    à faire si nécessaire
                 */
             }
            uGalil.XGalil8AxesFront=0; 
            uGalil.YGalil8AxesFront=0;
                
            // GalilInitialise=true;
            return;
        }     // end void InitialiserGalil8AxesFront ()
        //----------------------------------------------------------------------------------------------
        public static void InitialiserGalilFront()
        {
            uPiaget.WriteOnCheckBoard("uGalil.InitialiserGalilFront");


            if (uPanel.ChoixGalilFront)
            { 

              //rcGalilFront = DMCOpen(GalilOPYControllerFrontNumber,hWndFront,&hDmcFront);
            uGalil.GalilOpenFront=true;
            uGalil.SetAddressGalil(uGalil.AddressGalil8AxesFront);//pas sure de l'adresse SL 2013
            uGalil.ExecutionGalil("RS");
            uGalil.ExecutionGalil("DP 0,0");
            uGalil.ExecutionGalil("SH");
                /*
          ExecuterCommandeGalilFront(//"RS"+ACR+            //  reset  NON utilisé car coupe la communication
                              "DP 0,0"+ACR+        // mise à zéro des compteurs-position
                              "SH"+ACR);           //  Servo Here; met la puissance
         // ProgrammerGalilFront();    à faire si nécessaire
                 */
         }
        uGalil.XGalilFront=0; uGalil.YGalilFront=0;
            
            // GalilInitialise=true;
            return;
        }     // end void InitialiserGalilFront ()
        //-------------------------------------------------------------------------
        public static void LancerMouvementGalil(uPanel.tMouvement Mouvement)
        {
            uPiaget.WriteOnCheckBoard("uGalil.LancerMouvementGalil");

            float FacteurLateral = 1; // à calibrer
            int FactSLL; //InverseSensLineaireLateral
            uPanel.tMouvement MouvTemp;
            switch (uPanel.Platform)
            {
                case uPanel.tPlatform.RHY:
                    LancerMouvementGalilTwoWheels(Mouvement);
                    break;
                case uPanel.tPlatform.OPY:
                    if (uPanel.Mouvement.ModeDeMouvement != uPanel.tModeDeMouvement.Lat)
                    {
                        LancerMouvementGalilFront(Mouvement);
                        LancerMouvementGalilBack(Mouvement);
                    }
                    else
                    {
                        if (uPanel.InverseSensLineaireLateral) FactSLL = -1;
                        else FactSLL = 1;
                        MouvTemp = Mouvement;
                        MouvTemp.IncrGauche = FactSLL * uPiaget.Round(FacteurLateral * Mouvement.IncrGauche);
                        MouvTemp.IncrDroit = -FactSLL * uPiaget.Round(FacteurLateral * Mouvement.IncrDroit);
                        MouvTemp.VitesseM = uPiaget.Round(FacteurLateral * Mouvement.VitesseM);
                        MouvTemp.VitesseMaxM = uPiaget.Round(FacteurLateral * Mouvement.VitesseMaxM);
                        MouvTemp.AccelerationM = uPiaget.Round(FacteurLateral * Mouvement.AccelerationM);
                        MouvTemp.DecelerationM = uPiaget.Round(FacteurLateral * Mouvement.DecelerationM);
                        LancerMouvementGalilFront(MouvTemp);
                        MouvTemp.IncrGauche = -MouvTemp.IncrGauche;
                        MouvTemp.IncrDroit = -MouvTemp.IncrDroit;
                        LancerMouvementGalilBack(MouvTemp);
                    }  // end case OP-Y
                    break;
                case uPanel.tPlatform.OP12Y:
                    LancerMouvementGalil4AxesBack(Mouvement);
                    break;
            } // end switch

            return;
        }      // end of LancerMouvementGalil
        //---------------------------------------------------------------------------
        public static void LancerMouvementGalilTwoWheels(uPanel.tMouvement Mouvement)
        {
            //uPiaget.WriteOnCheckBoard("uGalil.LancerMouvementGalilTwoWheels");

            long AMin = 10, VMin = 10;
            float TempX = Math.Abs(Mouvement.AccelerationM * Mouvement.IncrGauche * FacteurGalil * uPanel.PasParCmGauche);
            if (TempX < AMin) TempX = AMin;
            TempY = Math.Abs(Mouvement.AccelerationM * Mouvement.IncrDroit * FacteurGalil * uPanel.PasParCmDroite);
            if (TempY < AMin) TempY = AMin;
            //uGalil.SetAddressGalil(uGalil.AddressGalilTwoWheels);
            g.command("AB "); 
            //---uGalil.ExecuterCommandeGalil("AB ");                        //  abort     005.12.23
            
            uGalil.ActiverPuissanceGalil();
            g.command("AC " + TempX + "," + TempY);
            //---uGalil.ExecuterCommandeGalil("AC " + TempX + "," + TempY);  //  accélération
            g.command("DC " + TempX + "," + TempY);
            //---uGalil.ExecuterCommandeGalil("DC " + TempX + "," + TempY);  //  décélération
            

            TempX = Math.Abs(Mouvement.VitesseMaxM * Mouvement.IncrGauche * FacteurGalil * uPanel.PasParCmGauche);

            if (TempX < VMin) TempX = VMin;
            TempY = Math.Abs(Mouvement.VitesseMaxM * Mouvement.IncrDroit * FacteurGalil * uPanel.PasParCmDroite);
            if (TempY < VMin) TempY = VMin;
            g.command("SP " + TempX + "," + TempY);
            //uGalil.ExecuterCommandeGalilTwoWheels("SP " + TempX + "," + TempY); //  vitesse
            
            if (uGalil.UtiliserCoordonneesAbsolues)
            {
                uGalil.XGalil = uGalil.XGalil + uPiaget.Round(Mouvement.NPas * Mouvement.IncrGauche * FacteurGalil);
                YGalil = YGalil + (Mouvement.NPas * Mouvement.IncrDroit * FacteurGalil);
                g.command("PA " + uGalil.YGalil + "," + (uGalil.XGalil * -1));
                //---uGalil.ExecuterCommandeGalil("PA " + uGalil.XGalil + "," + (uGalil.YGalil * -1));
                                                                        //  position absolue & moteurs tête-bêche
                //uGalil.ExecuterCommandeGalil("BGA");
                
            }
            else    // Coordonnées relatives
            {
                uGalil.XGalil = uPiaget.Round(Mouvement.NPas * Mouvement.IncrGauche * FacteurGalil);
                YGalil = (Mouvement.NPas * Mouvement.IncrDroit * FacteurGalil);
                g.command("PR " + uGalil.YGalil + "," + (uGalil.XGalil * -1));
                //---uGalil.ExecuterCommandeGalil("PR " + uGalil.XGalil + "," + (uGalil.YGalil * -1));
                //  position relative & moteurs tête-bêche
                //uGalil.ExecuterCommandeGalil("BGA");
                
            }
            //uPiaget.WriteOnCheckBoard("uGalil.LancerMouvementGalilTwoWheels >> BGA");
           // g.command("BGA");
            g.command("BG");
            //---uGalil.ExecuterCommandeGalil("BGA");
            return;
        }      // end of LancerMouvementGalilTwoWheels
        //--------------------------------------------------------------------------
        public static void LancerMouvementGalilBack(uPanel.tMouvement Mouvement)
        {
            //uPanel.Message ="To implement************************************************************************************
            //*****************************************************************************************************************
         //   if ((FPiaget.ActiveForm != null) && !FPiaget.ActiveForm.Controls["zouzouPanel"].Text.Contains("LancerMouvementGalilBack"))
                FPiaget.ActiveForm.Controls["zouzouPanel"].Text =
                    FPiaget.ActiveForm.Controls["zouzouPanel"].Text +
                    " LancerMouvementGalilBack " +
                    Environment.NewLine;
            //*****************************************************************************************************************
            //*****************************************************************************************************************
            
            long AMin=10, VMin=10;
            long Finv; //InversionAvantArriere   1 OU -1
            if (uPanel.InverseSensLineaireBack) Finv=-1   ;
            else  Finv=1 ;


            TempX = Math.Abs(Mouvement.AccelerationM * Mouvement.IncrGauche * FacteurGalilBack * uPanel.PasParCmGauche);
            if(TempX<AMin) TempX=AMin;
            TempY = Math.Abs(Mouvement.AccelerationM * Mouvement.IncrDroit * FacteurGalilBack * uPanel.PasParCmDroite);
            if(TempY<AMin) TempY=AMin;

            g.command("AB ");
            //---ExecuterCommandeGalil("AB ");//  abort     005.12.23
            g.command("AC " + TempX + "," + TempY);
            //---ExecuterCommandeGalil("AC " + TempX + "," + TempY);//  accélération
            g.command("DC " + TempX + "," + TempY);
            //---ExecuterCommandeGalil("DC " + TempX + "," + TempY);//  décélération
            
            TempX = Math.Abs(Mouvement.VitesseMaxM * Mouvement.IncrGauche * FacteurGalilBack * uPanel.PasParCmGauche);
            if(TempX<VMin) TempX=VMin;
            TempY = Math.Abs(Mouvement.VitesseMaxM * Mouvement.IncrDroit * FacteurGalilBack * uPanel.PasParCmDroite);
            if(TempY<VMin) TempY=VMin;

            g.command("SP " + TempX + "," + TempY);
            //---ExecuterCommandeGalil("SP " + TempX + "," + TempY);//  vitesse
            if (uGalil.UtiliserCoordonneesAbsolues)
             {
                 XGalilBack += uPiaget.Round(Mouvement.NPas * Mouvement.IncrGauche * FacteurGalilBack);
                 YGalilBack+=(Mouvement.NPas*Mouvement.IncrDroit *FacteurGalilBack);

                 g.command("PA " + Finv * XGalilBack + "," + (-1 * Finv * YGalilBack));
                 //---ExecuterCommandeGalil("PA " + Finv * XGalilBack + "," + (-1 * Finv * YGalilBack));//  position absolue
                 g.command("BG");
                 //---ExecuterCommandeGalil("BG");
            }else    // Coordonnées relatives  
            {
                XGalilBack = uPiaget.Round(Mouvement.NPas * Mouvement.IncrGauche * FacteurGalilBack);
                YGalilBack=(Mouvement.NPas*Mouvement.IncrDroit *FacteurGalilBack);

                g.command("PR " + (Finv * XGalilBack) + "," + (-Finv * YGalilBack));
                //---ExecuterCommandeGalil("PR " + (Finv * XGalilBack) + "," + (-Finv * YGalilBack));
                g.command("BG");
                //---ExecuterCommandeGalil("BG");
                }
            return;
        }      // end of LancerMouvementGalilBack
        //--------------------------------------------------------------------------
        public static void LancerMouvementGalil4AxesBack(uPanel.tMouvement Mouvement)
        {
            //uPanel.Message ="To implement************************************************************************************
            //*****************************************************************************************************************
          //  if ((FPiaget.ActiveForm != null) && !FPiaget.ActiveForm.Controls["zouzouPanel"].Text.Contains("LancerMouvementGalil4AxesBack"))
                FPiaget.ActiveForm.Controls["zouzouPanel"].Text =
                    FPiaget.ActiveForm.Controls["zouzouPanel"].Text +
                    " uGalil.LancerMouvementGalil4AxesBack " +
                    Environment.NewLine;
            //*****************************************************************************************************************
            //*****************************************************************************************************************
            
            long AMin=10, VMin=10;
            long Finv; //InversionAvantArriere   1 OU -1
            if (uPanel.InverseSensLineaireBack)Finv=-1   ;
            else   Finv=1 ;

            TempX = Math.Abs(Mouvement.AccelerationM * Mouvement.IncrGauche *FacteurGalilBack*uPanel.PasParCmGauche);
            if(TempX<AMin) TempX=AMin;
            TempY = Math.Abs(Mouvement.AccelerationM * Mouvement.IncrDroit * FacteurGalilBack * uPanel.PasParCmDroite);
            if(TempY<AMin) TempY=AMin;

            g.command("AB ");
            //---uGalil.ExecuterCommandeGalil("AB ");
            g.command("AC " + TempX + "," + TempY);
            //---uGalil.ExecuterCommandeGalil("AC " +TempX+ "," + TempY);
            g.command("DC " + TempX + "," + TempY);
            //---uGalil.ExecuterCommandeGalil("DC " + TempX + "," + TempY);//  décélération


            TempX = Math.Abs(Mouvement.VitesseMaxM * Mouvement.IncrGauche * FacteurGalilBack * uPanel.PasParCmGauche);
            if(TempX<VMin) TempX=VMin;
            TempY = Math.Abs(Mouvement.VitesseMaxM * Mouvement.IncrDroit * FacteurGalilBack * uPanel.PasParCmDroite);
           if(TempY<VMin) TempY=VMin;

           //TempX=100000; // valeur test **** JDZ 013.05.30
           //TempY=100000; // valeur test **** JDZ 013.05.30

           g.command("SP " + TempX + "," + TempY);
           //---uGalil.ExecuterCommandeGalil("SP " + TempX+ "," + TempY);
           if (uGalil.UtiliserCoordonneesAbsolues)
            {
                uGalil.XGalilBack += uPiaget.Round(Mouvement.NPas * Mouvement.IncrGauche * FacteurGalilBack);
                uGalil.YGalilBack+=(Mouvement.NPas*Mouvement.IncrDroit *FacteurGalilBack);

                g.command("PA " + (Finv * XGalilBack) + "," + (-Finv * YGalilBack));
                //---uGalil.ExecuterCommandeGalil("PA " + (Finv * XGalilBack) + "," + (-Finv * YGalilBack));
                g.command("BG");
                //---uGalil.ExecuterCommandeGalil("BG");
               }
            else    // Coordonnées relatives
             {
                uGalil.XGalilBack = uPiaget.Round(Mouvement.NPas * Mouvement.IncrGauche * FacteurGalilBack);
                uGalil.YGalilBack=(Mouvement.NPas*Mouvement.IncrDroit *FacteurGalilBack);

                g.command("PR " + (Finv * XGalilBack) + "," + (-Finv * YGalilBack));
                //---uGalil.ExecuterCommandeGalil("PR " + (Finv * XGalilBack) + "," + (-Finv * YGalilBack));
                g.command("BG");
               //---uGalil.ExecuterCommandeGalil("BG");
               }

           //ExecuterCommandeGalil4AxesBack(Command);
            
            return;
        }      // end of LancerMouvementGalil4AxesBack
        //-----------------------------------------------------------------------******************************************************************************************--
        public static void LecturePositionGalil()
        {
            #if (!SimulationOnly)
            uGalil.AttendreFinMouvementGalil();
            //uPiaget.WriteOnCheckBoard("uGalil.LecturePositionGalil() >> TP");
            string cmdGalilReturn = uGalil.g.command("TP", ACR, ":", true);

            uPiaget.WriteOnCheckBoard("uGalil.LecturePositionGalil() << " + cmdGalilReturn);
            #endif

            return;
        }
        //----------------------------------------------------------------------------
        public static void LecturePositionGalil(int Position, string TCarteGalil_NB_AXES)
        {
            uPiaget.WriteOnCheckBoard("uGalil.LecturePositionGalil +Position+ TCarteGalil_NB_AXES");
            uGalil.rcGalilBack = uGalil.ExecuterCommandeGalilAvecReponse("TP");
            uPiaget.WriteOnCheckBoard("uGalil.LecturePositionGalil : " + uGalil.rcGalilBack);
            /*
                AnsiString LecturePosition;
                TReplaceFlags flags;
                int SpacePlace;

                // Lecture de la position en fonction de la carte souhaitée
                if(NB_AXES == GALIL_QUATRE_AXES)
                        ExecuterCommandeGalil4AxesBackAvecReponse("TP" + AnsiString::StringOfChar(13,1), LecturePosition);
                else if(NB_AXES == GALIL_HUIT_AXES)
                        ExecuterCommandeGalil8AxesFrontAvecReponse("TP" + AnsiString::StringOfChar(13,1), LecturePosition);

                // Mise en forme de la lecture de la position pour pouvoir la traiter
                // La position est donnée sous cette forme Xa, Xb, Xc, Xd:
                LecturePosition = TrimLeft(LecturePosition);                               // Enlève les espaces à gauche
                // Récupère les trois premières valeurs
                for(int i=0; i<NB_AXES-1; i++)
                {
                        // Récupère la position de la roue milieu gauche et converti en entier
                        SpacePlace = LecturePosition.AnsiPos(",");
                        Position[i] = StrToInt(LecturePosition.SubString(1,SpacePlace-1));
                        // Supprimme la valeur récupérer de la chaine de caractère
                        LecturePosition.Delete(1,SpacePlace+1);
                }

                // Récupère la dernière valeur
                SpacePlace = LecturePosition.AnsiPos(":");
                LecturePosition = LecturePosition.SubString(1,SpacePlace-1);
                LecturePosition = TrimRight(LecturePosition);
                Position[NB_AXES-1] = StrToInt(LecturePosition);
            */
        }
        //---------------------------------------------------------------------------
        public static void LancerMouvementGalilFront(uPanel.tMouvement Mouvement)
        {
            uPiaget.WriteOnCheckBoard("uGalil.LancerMouvementGalilFront");

            long AMin = 10, VMin = 10;
            long Finv; //InversionAvantArriere   1 OU -1
            if (uPanel.InverseSensLineaireFront) Finv = -1;
            else Finv = 1;
            long FSurLeDos = -1; //  1 OU -1   ******

            TempX = Math.Abs(Mouvement.AccelerationM * Mouvement.IncrGauche *
            FacteurGalilFront * uPanel.PasParCmGauche);

            if (TempX < AMin) TempX = AMin;
            TempY = Math.Abs(Mouvement.AccelerationM * Mouvement.IncrDroit * FacteurGalilFront * uPanel.PasParCmDroite);

            if (TempY < AMin) TempY = AMin;
            g.command("AB ");
            //---uGalil.ExecuterCommandeGalil("AB ");
            g.command("AC " + TempX + "," + TempY);
            //---uGalil.ExecuterCommandeGalil("AC " + TempX + "," + TempY);//  accélération
            g.command("DC " + TempX + "," + TempY);
            //---uGalil.ExecuterCommandeGalil("DC " + TempX + "," + TempY);//  décélération

            TempX = Math.Abs(Mouvement.VitesseMaxM * Mouvement.IncrGauche * FacteurGalilFront * uPanel.PasParCmGauche);
            if (TempX < VMin) TempX = VMin;
            TempY = Math.Abs(Mouvement.VitesseMaxM * Mouvement.IncrDroit * FacteurGalilFront * uPanel.PasParCmDroite);
            if (TempY < VMin) TempY = VMin;
            g.command("SP " + TempX + "," + TempY);
            //uGalil.ExecuterCommandeGalil("SP " + TempX + "," + TempY);//  vitesse

            if (uGalil.UtiliserCoordonneesAbsolues)
            {
                uGalil.XGalilFront += uPiaget.Round(Mouvement.NPas * Mouvement.IncrGauche * FacteurGalilFront);
                uGalil.YGalilFront += uPiaget.Round(Mouvement.NPas * Mouvement.IncrDroit * FacteurGalilFront);

                g.command("PA " + Finv * XGalilFront + "," + (-Finv * YGalilFront));
                //---uGalil.ExecuterCommandeGalil("PA " + Finv * XGalilFront + "," + (-Finv * YGalilFront));
            }
            else    // Coordonnées relatives
            {
                uGalil.XGalilFront = uPiaget.Round(Mouvement.NPas * Mouvement.IncrGauche * FacteurGalilFront);
                uGalil.YGalilFront = uPiaget.Round(Mouvement.NPas * Mouvement.IncrDroit * FacteurGalilFront);

                g.command("PR " + Finv * XGalilFront + "," + (-Finv * YGalilFront));
                //---uGalil.ExecuterCommandeGalil("PR " + Finv * XGalilFront + "," + (-Finv * YGalilFront));
            }
            g.command("BG");
            //uGalil.ExecuterCommandeGalil("BG");

            return;
        }      // end of LancerMouvementGalilBack
        //------------------------------------------------------------------------------------
        /*
         * Orientation des roues du milieu avec profil de mouvement (Orientation en absolue)
         */
        public static void OrientationGalil4Axes(uPanel.tPlatform PlateformeP12Y_plateforme)
        {
            //uPanel.Message ="To implement************************************************************************************
            //*****************************************************************************************************************
         //  if ((FPiaget.ActiveForm != null) && !FPiaget.ActiveForm.Controls["zouzouPanel"].Text.Contains("OrientationGalil4Axes"))
                FPiaget.ActiveForm.Controls["zouzouPanel"].Text =
                    FPiaget.ActiveForm.Controls["zouzouPanel"].Text +
                    " uGalil.OrientationGalil4Axes " +
                    Environment.NewLine;
            //*****************************************************************************************************************
            //*****************************************************************************************************************
            /*
               // Transformation en nombre de pas des orientations
               plateforme.Roues.AngleRMGenPas = plateforme.Roues.AngleRMG*plateforme.facteur.ConversionDegresEnPas*plateforme.facteur.CorrectionDegresEnPas;
               plateforme.Roues.AngleRMDenPas = plateforme.Roues.AngleRMD*plateforme.facteur.ConversionDegresEnPas*plateforme.facteur.CorrectionDegresEnPas;

               // Envoi des commandes aux axes spécifiques
               ExecuterCommandeGalil4AxesBack("ACA=" + IntToStr(plateforme.Axes.AccRMG) + AnsiString::StringOfChar(13,1) +
                                             "ACB=" + IntToStr(plateforme.Axes.AccRMD) + AnsiString::StringOfChar(13,1) +
                                             "DCA=" + IntToStr(plateforme.Axes.DecRMG) + AnsiString::StringOfChar(13,1) +
                                             "DCB=" + IntToStr(plateforme.Axes.DecRMD) + AnsiString::StringOfChar(13,1) +
                                             "SPA=" + IntToStr(plateforme.Axes.VRMG) + AnsiString::StringOfChar(13,1) +
                                             "SPB=" + IntToStr(plateforme.Axes.VRMD) + AnsiString::StringOfChar(13,1) +
                                             "PAA=" + IntToStr(plateforme.Roues.AngleRMGenPas) + AnsiString::StringOfChar(13,1) +
                                             "PAB=" + IntToStr(plateforme.Roues.AngleRMDenPas) + AnsiString::StringOfChar(13,1) +
                                             "BGAB" + AnsiString::StringOfChar(13,1));
            */
            return;
        }  // end of OrientationGalil4Axes
        //---------------------------------------------------------------------------
        /*
         * Orientation des roues avant et arrière avec profil de mouvement
         */
        public static void OrientationGalil8Axes(uPanel.tPlatform PlateformeP12Y_plateforme)
        {
            //uPanel.Message ="To implement************************************************************************************
            //*****************************************************************************************************************
           // if ((FPiaget.ActiveForm != null) && !FPiaget.ActiveForm.Controls["zouzouPanel"].Text.Contains("OrientationGalil8Axes"))
                FPiaget.ActiveForm.Controls["zouzouPanel"].Text =
                    FPiaget.ActiveForm.Controls["zouzouPanel"].Text +
                    " uGalil.OrientationGalil8Axes " +
                    Environment.NewLine;
            //*****************************************************************************************************************
            //*****************************************************************************************************************
            /*
               // Transformation en nombre de pas des orientations
               plateforme.Roues.AngleRArGenPas = plateforme.Roues.AngleRArG*plateforme.facteur.ConversionDegresEnPas*plateforme.facteur.CorrectionDegresEnPas;
               plateforme.Roues.AngleRArDenPas = plateforme.Roues.AngleRArD*plateforme.facteur.ConversionDegresEnPas*plateforme.facteur.CorrectionDegresEnPas;
               plateforme.Roues.AngleRAvGenPas = plateforme.Roues.AngleRAvG*plateforme.facteur.ConversionDegresEnPas*plateforme.facteur.CorrectionDegresEnPas;
               plateforme.Roues.AngleRAvDenPas = plateforme.Roues.AngleRAvD*plateforme.facteur.ConversionDegresEnPas*plateforme.facteur.CorrectionDegresEnPas;

               // Envoi des commandes aux axes spécifiques
               ExecuterCommandeGalil8AxesFront("ACA=" + IntToStr(plateforme.Axes.AccRArG) + AnsiString::StringOfChar(13,1) +
                                              "ACB=" + IntToStr(plateforme.Axes.AccRArD) + AnsiString::StringOfChar(13,1) +
                                              "ACC=" + IntToStr(plateforme.Axes.AccRAvG) + AnsiString::StringOfChar(13,1) +
                                              "ACD=" + IntToStr(plateforme.Axes.AccRAvD) + AnsiString::StringOfChar(13,1) +

                                              "DCA=" + IntToStr(plateforme.Axes.DecRArG) + AnsiString::StringOfChar(13,1) +
                                              "DCB=" + IntToStr(plateforme.Axes.DecRArD) + AnsiString::StringOfChar(13,1) +
                                              "DCC=" + IntToStr(plateforme.Axes.DecRAvG) + AnsiString::StringOfChar(13,1) +
                                              "DCD=" + IntToStr(plateforme.Axes.DecRAvD) + AnsiString::StringOfChar(13,1) +

                                              "SPA=" + IntToStr(plateforme.Axes.VRArG) + AnsiString::StringOfChar(13,1) +
                                              "SPB=" + IntToStr(plateforme.Axes.VRArD) + AnsiString::StringOfChar(13,1) +
                                              "SPC=" + IntToStr(plateforme.Axes.VRAvG) + AnsiString::StringOfChar(13,1) +
                                              "SPD=" + IntToStr(plateforme.Axes.VRAvD) + AnsiString::StringOfChar(13,1) +

                                              "PAA=" + IntToStr(plateforme.Roues.AngleRArGenPas) + AnsiString::StringOfChar(13,1) +
                                              "PAB=" + IntToStr(plateforme.Roues.AngleRArDenPas) + AnsiString::StringOfChar(13,1) +
                                              "PAC=" + IntToStr(plateforme.Roues.AngleRAvGenPas) + AnsiString::StringOfChar(13,1) +
                                              "PAD=" + IntToStr(plateforme.Roues.AngleRAvDenPas) + AnsiString::StringOfChar(13,1) +
                                              "BGABCD" + AnsiString::StringOfChar(13,1));
            */
            return;
        }  // end of OrientationGalil8Axes
        //---------------------------------------------------------------------------
        /*void AlignementGalil4Axes(int orientation, PlateformeP12Y &plateforme)
         {

                AnsiString LecturePosition;
                TReplaceFlags flags;
                int SpacePlace;
                // Position mesurée des roues
                int PositionRMGenPas, PositionRMDenPas;                 // En incrément
                int PositionRMGenDegres, PositionRMDenDegres;           // En degrès

                // Lecture de la position
                ExecuterCommandeGalil4AxesBackAvecReponse("TP" + AnsiString::StringOfChar(13,1), LecturePosition);

                // Mise en forme de la lecture de la position pour pouvoir la traiter
                // La position est donnée sous cette forme Xa, Xb, Xc, Xd:
                position = TrimLeft(position);                               // Enlève les espaces à gauche
                position = StringReplace(position, ":", " ", flags);         // Enlève le : et le retour à la ligne du terminal
                position = StringReplace(position, ",", " ", flags);         // Enlève le ,
                position = StringReplace(position, ",", " ", flags);         // Enlève le ,
                position = StringReplace(position, ",", " ", flags);         // Enlève le ,
                position = TrimRight(position);                              // Enlève les espaces à droite

                // Récupère la position de la roue milieu gauche et converti en entier
                SpacePlace = LecturePosition.AnsiPos(" ");
                PositionRMGenPas = StrToInt(LecturePosition.SubString(1,SpacePlace-1));
                // Supprimme la valeur récupérer de la chaine de caractère
                LecturePosition.Delete(1,SpacePlace);
                // Récupère la valeur de la roue milieu droite et converti en entier
                SpacePlace = LecturePosition.AnsiPos(" ");
                PositionRMGenPas = StrToInt(LecturePosition.SubString(1,SpacePlace-1));

                // Transformation de la position: incrément -> en degrès
                PositionRMGenDegres = (float)PositionRMGenPas*(360/500)



                //Form3->Edit7->Text = positionNew;
                // Form3->Edit7->Text = reponse;
                //ExecuterCommandeGalil4AxesBackAvecReponse("TP" + AnsiString::StringOfChar(13,1), position);

         }  */
        //----------------------------------------------------------------------------
        /*
         * Oriente les roues et après avance-> nécessite plusieurs cycle pour s'exécuter
         */
        public static void OP12TurnWheelAndAfterGO(uPanel.tPlatform PlateformeP12Y_plateforme)
        {
           uPiaget.WriteOnCheckBoard("uGalil.OP12TurnWheelAndAfterGO");
            /*    
            int LecturePosition4Axes[GALIL_QUATRE_AXES];
                int LecturePosition8Axes[GALIL_HUIT_AXES];
                int ErreurPositionRotation[6]; //,ConsignePosition;
                int ErreurPositionDeplacement[6];
                static bool GoAvance=false;
                static bool GoRotation=true;
                static bool AxeRotationOK[6];
                static bool DeplacementOK[6];


                // Orientation des roues
                if(plateforme.GoMouvement)
                {
                        if(GoRotation)
                        {
                                OrientationGalil4Axes(P12Y);
                                //GoAvance = 1;
                                //OrientationGalil8Axes(P12Y);
                        }
                //}
                //if(plateforme.GoMouvement==1)
                //if(GoAvance)
                //{
                        // Lecture de la position
                        LecturePositionGalil(LecturePosition4Axes, GALIL_QUATRE_AXES);

                        // Calcul de l'erreur sur la carte Galil 4 Axes pour les axes de rotation
                        ErreurPositionRotation[RMG] =  LecturePosition4Axes[AXEA] - plateforme.Roues.AngleRMGenPas;
                        ErreurPositionRotation[RMD] =  LecturePosition4Axes[AXEB] - plateforme.Roues.AngleRMDenPas;

              
                        //Form3->Edit7->Text = ErreurPositionRotation[RMG];

                        // Détermine si le mouvement de rotation est terminée
                        AxeRotationOK[RMG] = (ErreurPositionRotation[RMG] < 20 && ErreurPositionRotation[RMG] > -20);
                        AxeRotationOK[RMD] = (ErreurPositionRotation[RMD] < 20 && ErreurPositionRotation[RMD] > -20);

                        // Déplacement que si le mouvement de rotation est terminé
                        //if(AxeRotationOK[RMG] && AxeRotationOK[RMD] && AxeRotationOK[RArG] && AxeRotationOK[RArD] && AxeRotationOK[RAvG] && AxeRotationOK[RAvD])
                        if(AxeRotationOK[RMG])
                        {
                                GoRotation = false;
                                // Lancement des mouvements
                                AvancerGalil4Axes(plateforme);
                                //AvancerGalil8Axes(plateforme);

                                // Calcul de l'erreur pour le déplacement  -> fais que pour un axe
                                ErreurPositionDeplacement[RMG] = LecturePosition4Axes[AXEC] - (int)(plateforme.Roues.DistRMG*plateforme.facteur.ConversionCmEnPas*plateforme.facteur.CorrectionCmEnPas);
                                // Test
                                Form3->Edit7->Text = IntToStr(ErreurPositionDeplacement[RMG]);

                                // Détermine si le déplacement est terminée  -> fais que pour un axe
                                DeplacementOK[RMG] = (ErreurPositionDeplacement[RMG] < 50 && ErreurPositionDeplacement[RMG] > -50);
                                if(DeplacementOK[RMG])
                                {
                                        // Fin du mouvement
                                        //GoAvance=false;
                                        GoRotation=true;
                                        plateforme.GoMouvement=false;
                                       // Form3->Edit7->Text = IntToStr(GoRotation);
                                }
                        }
                //}
                }*/
            return;
        }
        //---------------------------------------------------------------------------
        public static void ProgrammerGalil()
        {
            uPiaget.WriteOnCheckBoard("uGalil.ProgrammerGalil");

            /*
         ExecuterCommandeGalil("ED 100"+ACR+

        // ******
                              "#DESC"+ACR+    // descendre
                              "SB 1"+ACR+     // direction bas
                              "SB 2"+ACR+     // puissance ON
                              "EN"+ACR+       // fin du progr. Descendre

        // ******
                             "#DESC1N"+ACR+   // descendre d'un niveau
                              "SB 1"+ACR+     // direction bas
                              "SB 2"+ACR+     // puissance ON
                              "AI 1"+ACR+     // attend fin trou 1
                              "AI -1"+ACR+     // attend début trou 2
                              "CB 2"+ACR+     // puissance OFF
                              "EN"+ACR+       // fin du progr. DescendreAuPremier

        // ******
                             "#D1NLENT"+ACR+   // descendre d'un niveau lentement
                              "VON=20; VOFF=20"+ACR+ // délai en ms
                              "SB 1"+ACR+     // direction bas

                              "#DA"+ACR+
                              "SB 2"+ACR+     // puissance ON
                              "WT VON"+ACR+   //
                              "CB 2"+ACR+     // puissance OFF
                              "WT VOFF"+ACR+   //
                              "IF (@IN[1]=1)"+ACR+// attend fin métal
                              "JP #DB"+ACR+
                              "ENDIF"+ACR+
                              "JP #DA"+ACR+

                              "#DB"+ACR+
                              "SB 2"+ACR+     // puissance ON
                              "WT VON"+ACR+   //
                              "CB 2"+ACR+     // puissance OFF
                              "WT VOFF"+ACR+   //
                              "IF (@IN[1]=0)"+ACR+// attend début métal
                              "JP #DC"+ACR+
                              "ENDIF"+ACR+
                              "JP #DB"+ACR+

                              "#DC"+ACR+
                              "EN"+ACR+       // fin du progr. DescendreAuPremier

        // ******
                              "#MONTER"+ACR+
                              "CB 1"+ACR+     // direction haut
                              "SB 2"+ACR+     // puissance ON
                              "EN"+ACR+       // fin du progr. Monter

        // ******
                             "#MONT1N"+ACR+ // Monter d'un niveau
                              "CB 1"+ACR+     // direction haut
                              "SB 2"+ACR+     // puissance ON
                              "AI 1"+ACR+     // attend fin trou 1
                              "AI -1"+ACR+     // attend début trou 2
                              "CB 2"+ACR+     // puissance OFF
                              "EN"+ACR+       // fin du progr. MonterAuDeuxieme

        // ******
                             "#M1NLENT"+ACR+   // monter d'un niveau lentement
                              "VON=20; VOFF=20"+ACR+ // délai en ms
                              "CB 1"+ACR+     // direction haut

                              "#MA"+ACR+
                              "SB 2"+ACR+     // puissance ON
                              "WT VON"+ACR+   //
                              "CB 2"+ACR+     // puissance OFF
                              "WT VOFF"+ACR+   //
                              "IF (@IN[1]=1)"+ACR+// attend fin métal
                              "JP #MB"+ACR+
                              "ENDIF"+ACR+
                              "JP #MA"+ACR+

                              "#MB"+ACR+
                              "SB 2"+ACR+     // puissance ON
                              "WT VON"+ACR+   //
                              "CB 2"+ACR+     // puissance OFF
                              "WT VOFF"+ACR+   //
                              "IF (@IN[1]=0)"+ACR+// attend début métal
                              "JP #MC"+ACR+
                              "ENDIF"+ACR+
                              "JP #MB"+ACR+

                              "#MC"+ACR+
                              "EN"+ACR+       // fin du progr. DescendreAuPremier

        // ******
                              ACntrlQ       // fin de l'édition cntrlQ
                                       );   //
            */
            return;
        }
        //---------------------------------------------------------------------------
        public static void ResetGalilBack()
        {
            uPiaget.WriteOnCheckBoard("uGalil.ResetGalilBack");
            g.command("RS");
            //---uGalil.ExecuterCommandeGalil("RS");  //  Reset
            uGalil.XGalilBack = 0; uGalil.YGalilBack = 0;
        }  // ResetGalilBack
        //---------------------------------------------------------------------------
        public static void ResetGalilFront()
        {
            //uPanel.Message ="To implement************************************************************************************
            //*****************************************************************************************************************
          //  if ((FPiaget.ActiveForm != null) && !FPiaget.ActiveForm.Controls["zouzouPanel"].Text.Contains("ResetGalilFront"))
                FPiaget.ActiveForm.Controls["zouzouPanel"].Text =
                    FPiaget.ActiveForm.Controls["zouzouPanel"].Text +
                    " uGalil.ResetGalilFront " +
                    Environment.NewLine;
            //*****************************************************************************************************************
            //*****************************************************************************************************************
            g.command("RS");
            //---ExecuterCommandeGalilFront("RS");  //  Reset
            XGalilFront = 0; YGalilFront = 0;
        }  // ResetGalilFront
        //---------------------------------------------------------------------------
        public static void ResetGalilTwoWheels()
        {
            //uPanel.Message ="To implement************************************************************************************
            //*****************************************************************************************************************
           // if ((FPiaget.ActiveForm != null) && !FPiaget.ActiveForm.Controls["zouzouPanel"].Text.Contains("ResetGalilTwoWheels"))
                FPiaget.ActiveForm.Controls["zouzouPanel"].Text =
                    FPiaget.ActiveForm.Controls["zouzouPanel"].Text +
                    " uGalil.ResetGalilTwoWheels " +
                    Environment.NewLine;
            //*****************************************************************************************************************
            //*****************************************************************************************************************
            g.command("RS");
            //---ExecuterCommandeGalil("RS");  //  Reset
            XGalil = 0; YGalil = 0;
        }  // ResetGalilTwoWheels
        //---------------------------------------------------------------------------
        public static void ResetGalil()
        {
            //uPanel.Message ="To implement************************************************************************************
            //*****************************************************************************************************************
       //   /*  if ((FPiaget.ActiveForm != null) && !FPiaget.ActiveForm.Controls["zouzouPanel"].Text.Contains("ResetGalil"))
                FPiaget.ActiveForm.Controls["zouzouPanel"].Text =
                    FPiaget.ActiveForm.Controls["zouzouPanel"].Text +
                    " uGalil.ResetGalil " +
                    Environment.NewLine;
            //*****************************************************************************************************************
            //*****************************************************************************************************************
            if (uPanel.ModeRHYorOPYlow)
                ResetGalilTwoWheels();
            else
            {
                ResetGalilFront();
                ResetGalilBack();
            }
        }
        //---------------------------------------------------------------------------
        public static void ResetPositionGalilBack()
        {
            uPiaget.WriteOnCheckBoard("uGalil.ResetPositionGalilBack");
            g.command("AB ");
            //---uGalil.ExecuterCommandeGalil("AB ");
            g.command("DP 0,0");
            //---uGalil.ExecuterCommandeGalil("DP 0,0");
            /*
            ExecuterCommandeGalilBack("AB " + ACR +
                    "DP 0,0" + ACR);   // redéfinit la position courante
             */
            uGalil.XGalilBack = 0;
            uGalil.YGalilBack = 0;
            return;
        }    // ResetPositionGalilBack
        //---------------------------------------------------------------------------
        public static void ResetPositionGalilFront()
        {
            uPiaget.WriteOnCheckBoard("uGalil.ResetPositionGalilFront");
            g.command("AB ");
            //---uGalil.ExecuterCommandeGalil("AB ");
            g.command("DP 0,0");
            //---uGalil.ExecuterCommandeGalil("DP 0,0");
            /*
            ExecuterCommandeGalilFront("AB " + ACR +
                    "DP 0,0" + ACR);   // redéfinit la position courante
             */
            XGalilFront = 0; YGalilFront = 0;
            return;
        }    // ResetPositionGalilFront
        //---------------------------------------------------------------------------
        public static void ResetPositionGalilTwoWheels()
        {
            uPiaget.WriteOnCheckBoard("uGalil.ResetPositionGalilFront");
            //uGalil.SetAddressGalil(uGalil.AddressGalilTwoWheels);
            g.command("AB ");
            //---uGalil.ExecuterCommandeGalil("AB ");
            g.command("DP 0,0");
            //---uGalil.ExecuterCommandeGalil("DP 0,0");
            /*
            ExecuterCommandeGalil("AB " + ACR +
                    "DP 0,0" + ACR);   // redéfinit la position courante
             */
            XGalil = 0; YGalil = 0;
            return;
        }    // ResetPositionGalilTwoWheels
        //---------------------------------------------------------------------------
        public static void SpeedGalilStraightAndTurnBackAGN(float SS, float ST)
        {
            uPiaget.WriteOnCheckBoard("uGalil.SpeedGalilStraightAndTurnBackAGN");



            int S1, S2;


            // Ideally SS should be given in cm/s and ST in degrees per second
            S1 = FactOPYLinearSense * uPiaget.Round(SS + FactOPYRotationalSense * ST); // op-y   009.06.26
            S2 = FactOPYLinearSense * uPiaget.Round(-SS + FactOPYRotationalSense * ST); //
//////////////
            g.command("JG" + S1 + "," + S2);
            //---uGalil.ExecuterCommandeGalil("JG " +S1 + "," +S2);
            g.command("BG");
            //---uGalil.ExecuterCommandeGalil("BG");
            /*
            ExecuterCommandeGalilBack("JG " +
                  S1 + "," +
                  S2 + ACR + "BG" + ACR);
             */
            uPiaget.GoNext();
        }  // end of SpeedGalilStraightAndTurnBackAGN
        //---------------------------------------------------------------------------
        public static void SpeedGalilStraightAndTurnFrontAGN(float SS, float ST)
        {

            uPiaget.WriteOnCheckBoard("uGalil.SpeedGalilStraightAndTurnFrontAGN");


            SpeedGalilStraightAndTurnFront(SS, ST);

            uPiaget.GoNext();
        }  // end of SpeedGalilStraightAndTurnFrontAGN
        //---------------------------------------------------------------------------
        public static void SpeedGalilStraightAndTurnFront(float SS, float ST)
        {
            uPiaget.WriteOnCheckBoard("uGalil.SpeedGalilStraightAndTurnFront");


            long S1, S2;
            // Ideally SS should be given in cm/s and ST in degrees per second
            /* S1=FactOPYLinearSense*round(SS+ST);     // op-y   009.06.25
             S2=FactOPYLinearSense*round(-SS+ST); // FactOPYRotationalSense*   */

            S1 = FactOPYLinearSense * uPiaget.Round(SS + FactOPYRotationalSense * ST); // op-y   009.06.26
            S2 = FactOPYLinearSense * uPiaget.Round(-SS + FactOPYRotationalSense * ST); //

            g.command("JG " + S1 + "," + S2);
            //---uGalil.ExecuterCommandeGalil("JG " + S1 + "," + S2);
            g.command("BG");
            //---uGalil.ExecuterCommandeGalil("BG");
            /*
            ExecuterCommandeGalilFront("JG " +
                  S1 + "," +
                  S2 + ACR + "BG" + ACR);
            */
        }  // end of SpeedGalilStraightAndTurnFront
        //---------------------------------------------------------------------------
        public static void SpeedGalilStraightAndTurnTwoWheelsAGN(float SS, float ST)
        {
            uPiaget.WriteOnCheckBoard("uGalil.SpeedGalilStraightAndTurnTwoWheelsAGN");


            long S1, S2;
            // Ideally SS should be given in cm/s and ST in degrees per second
            S1 = uPiaget.Round(SS + ST);
            S2 = uPiaget.Round(-SS + ST);

            g.command("JG " + S1 + "," + S2);
            //---uGalil.ExecuterCommandeGalil("JG " + S1 + "," + S2);
            g.command("BG");
            //---uGalil.ExecuterCommandeGalil("BG");

            /*
            ExecuterCommandeGalil("JG " +
                  S1 + "," +
                  S2 + ACR + "BG" + ACR);
            */
            uPiaget.GoNext();
        }  // end of SpeedGalilStraightAndTurnTwoWheelsAGN
        //---------------------------------------------------------------------------
        public static void SpeedGalilStraightAndTurnAGN(float SS, float ST)
        {

            uPiaget.WriteOnCheckBoard("uGalil.SpeedGalilStraightAndTurnAGN");


            if (uPanel.ModeRHYorOPYlow)
                SpeedGalilStraightAndTurnTwoWheelsAGN(SS, ST);
            else
            {
                SpeedGalilStraightAndTurnFront(SS, ST);
                SpeedGalilStraightAndTurnBackAGN(SS, ST);
            }
        } // end of  SpeedGalilStraightAndTurnAGN
        //---------------------------------------------------------------------------
        public static void SpeedGalilStraightCMAndTurnDegreeBackAGN(float SSCmPS, float STDegreePS)
        {
            uPiaget.WriteOnCheckBoard("uGalil.SpeedGalilStraightCMAndTurnDegreeBackAGN");

            /*
            float S1,S2, S1abs, S2abs, SMax, SMin, SS, ST, SSabs, STabs, AMax, AMaxRot, Acc;
            float ratio, product;
            AMax = uPanel.AccelerationMaxCourante*FacteurGalil*uPanel.PasParCmGauche;
            AMaxRot = AMax / uPanel.ReductionDAccelerationEnRotation;
          // Ideally SS should be given in cm/s and ST in degrees per second
          //FacteurGalil*PasParCmGauche

    
           SS= SSCmPS*FacteurGalilBack*uPanel.PasParCmGauche;    // left=gauche same as right
           ST= STDegreePS*FacteurGalilBack*uPanel.PasParDegreRobotGauche;

           S1=FactOPYLinearSense*uPiaget.round(SS+FactOPYRotationalSense*ST); // op-y   009.06.26
           S2=FactOPYLinearSense*uPiaget.round(-SS+FactOPYRotationalSense*ST); //

           product=S1*S2;


          // using weighted mean for the computation of acceleration
           STabs=abs(ST);
           SSabs=abs(SS);
          if( STabs + SSabs > 0)
          {
              Acc = (STabs*AMaxRot + SSabs*AMax) / (STabs + SSabs);
          }
          else  Acc = AMax;


           Command= "AC " +     //  accélération
                  IntToStr(Acc)+","+IntToStr(Acc)+ACR;
           Command=Command+ "DC "+      //  décélération
                  IntToStr(Acc)+","+IntToStr(Acc)+ACR;

           extern long V8ErreurGauche, V8ErreurDroite;
           int Errormax=1000;
           if ((abs(V8ErreurGauche)+abs(V8ErreurDroite))>Errormax)    //  errmax to be checked

             if( (V8ErreurGauche>Errormax && S1>0)  ||       // checked OK with right wheel from robot perspective
              (V8ErreurGauche<-Errormax && S1<0)  ||
              (V8ErreurDroite>Errormax && S2>0)  ||
              (V8ErreurDroite<-Errormax && S2<0) )

                        { S1=0;
                         S2=0;}


           //---  ***009.01.20

           Command=Command+ "JG "+
                 IntToStr(S1)+","+
                 IntToStr(S2)+ACR+"BG"+ACR;   // BG une fois devrait suffire

           ExecuterCommandeGalilBack( Command);

          //---
           GoNext();
              */
        } // end of  SpeedGalilStraightCMAndTurnDegreeBackAGN
        //---------------------------------------------------------------------------
        public static void SpeedGalilStraightCMAndTurnDegreeFrontAGN(float SSCmPS, float STDegreePS)
        {
            uPiaget.WriteOnCheckBoard("uGalil.SpeedGalilStraightCMAndTurnDegreeFrontAGN");

            /*
            SpeedGalilStraightCMAndTurnDegreeFront(SSCmPS, STDegreePS) ;
            GoNext();
            */
        } // end of  SpeedGalilStraightCMAndTurnDegreeFrontAGN
        //---------------------------------------------------------------------------
        public static void SpeedGalilStraightCMAndTurnDegreeFront(float SSCmPS, float STDegreePS)
        {

            uPiaget.WriteOnCheckBoard("uGalil.SpeedGalilStraightCMAndTurnDegreeFront");

            /*
          long S1,S2, S1abs, S2abs, SMax, SMin, SS, ST, SSabs, STabs, AMax, AMaxRot, Acc;
          float ratio, product;
          AMax = AccelerationMaxCourante*FacteurGalil*PasParCmGauche;
          AMaxRot = AMax / ReductionDAccelerationEnRotation;
        // Ideally SS should be given in cm/s and ST in degrees per second
        //FacteurGalil*PasParCmGauche


         SS= SSCmPS*FacteurGalilFront*PasParCmGauche;    // left=gauche same as right
         ST= STDegreePS*FacteurGalilFront*PasParDegreRobotGauche;

         S1=FactOPYLinearSense*round(SS+FactOPYRotationalSense*ST); // op-y   009.06.26
         S2=FactOPYLinearSense*round(-SS+FactOPYRotationalSense*ST); //

         product=S1*S2;


        // using weighted mean for the computation of acceleration
         STabs=abs(ST);
         SSabs=abs(SS);
        if( STabs + SSabs > 0)
        {
            Acc = (STabs*AMaxRot + SSabs*AMax) / (STabs + SSabs);
        }
        else  Acc = AMax;


         Command= "AC " +     //  accélération
                IntToStr(Acc)+","+IntToStr(Acc)+ACR;
         Command=Command+ "DC "+      //  décélération
                IntToStr(Acc)+","+IntToStr(Acc)+ACR;

         extern long V8ErreurGauche, V8ErreurDroite;
         int Errormax=1000;
         if ((abs(V8ErreurGauche)+abs(V8ErreurDroite))>Errormax)    //  errmax to be checked

           //MessageErreur="  Erreurs gauche: "+
           //(V8ErreurGauche)+"  et droite :"+
           //     IntToStr(V8ErreurDroite);
               if( (V8ErreurGauche>Errormax && S1>0)  ||       // checked OK with right wheel from robot perspective
            (V8ErreurGauche<-Errormax && S1<0)  ||
            (V8ErreurDroite>Errormax && S2>0)  ||
            (V8ErreurDroite<-Errormax && S2<0) )

                      { S1=0;
                       S2=0;}


         //---  ***009.01.20

         Command=Command+ "JG "+
               IntToStr(S1)+","+
               IntToStr(S2)+ACR+"BG"+ACR;   // BG une fois devrait suffire

         ExecuterCommandeGalilFront( Command);
             */

        } // end of  SpeedGalilStraightCMAndTurnDegreeFront
        //-----------------------------------------------------------------------------
        public static void SpeedGalilStraightCMAndTurnDegreeTwoWheelsAGN(float SSCmPS, float STDegreePS)
        {
            uPiaget.WriteOnCheckBoard("uGalil.SpeedGalilStraightCMAndTurnDegreeTwoWheelsAGN");


            /*
        long S1,S2, S1abs, S2abs, SMax, SMin, SS, ST, SSabs, STabs, AMax, AMaxRot, Acc;
         // float S1,S2, S1abs, S2abs, SMax, SMin, SS, ST, SSabs, STabs, AMax, AMaxRot, Acc;   // 010.06.11 Champ JDZ       to be tempted once??
          float ratio, product;
          AMax = AccelerationMaxCourante*FacteurGalil*PasParCmGauche;
          AMaxRot = AMax / ReductionDAccelerationEnRotation;


         SS= SSCmPS*FacteurGalil*PasParCmGauche;    // left=gauche same as right
         ST= STDegreePS*FacteurGalil*PasParDegreRobotGauche;

         S1=round(SS+ST);
         S2=round(-SS+ST);

         product=S1*S2;
         STabs=abs(ST);
         SSabs=abs(SS);
        if( STabs + SSabs > 0)
        {
            Acc = (STabs*AMaxRot + SSabs*AMax) / (STabs + SSabs);
        }
        else  Acc = AMax;

         Command= "AC " +     //  accélération
                IntToStr(Acc)+","+IntToStr(Acc)+ACR;
         Command=Command+ "DC "+      //  décélération
                IntToStr(Acc)+","+IntToStr(Acc)+ACR;
         //--- ***009.01.20
 
         int Errormax=1000;
         if ((abs(uTasks.V8ErreurGauche)+abs(uTasks.V8ErreurDroite))>Errormax)    //  errmax to be checked
     
   

            if ( InverseSpeedToWheelErrorSignsRH)
              { if( (V8ErreurGauche>Errormax && S1<0)  ||       //
                (V8ErreurGauche<-Errormax && S1>0)  ||
                (V8ErreurDroite>Errormax && S2<0)  ||
                (V8ErreurDroite<-Errormax && S2>0) )

                      { S1=0;
                       S2=0;}
              }
              else
               { if( (V8ErreurGauche>Errormax && S1>0)  ||       // checked OK with right wheel from robot perspective
                (V8ErreurGauche<-Errormax && S1<0)  ||
                (V8ErreurDroite>Errormax && S2>0)  ||
                (V8ErreurDroite<-Errormax && S2<0) )

                      { S1=0;
                       S2=0;}
               }  // end if if errormax

         //---  ***009.01.20

         Command=Command+ "JG "+
               IntToStr(S1)+","+
               IntToStr(S2)+ACR+"BG"+ACR;   // BG une fois devrait suffire

         ExecuterCommandeGalil( Command);

         GoNext();
            */
        } // end of  SpeedGalilStraightCMAndTurnDegreeTwoWheelsAGN
        //---------------------------------------------------------------------------
        public static void SpeedGalilStraightCMAndTurnDegreeAGN(float SSCmPS, float STDegreePS)
        {
            uPiaget.WriteOnCheckBoard("uGalil.SpeedGalilStraightCMAndTurnDegreeAGN");

            /*
             if (uPanel.ModeRHYorOPYlow)
               SpeedGalilStraightCMAndTurnDegreeTwoWheelsAGN(SSCmPS, STDegreePS);
            else
              {SpeedGalilStraightCMAndTurnDegreeFront(SSCmPS, STDegreePS);
               SpeedGalilStraightCMAndTurnDegreeBackAGN(SSCmPS, STDegreePS);
              }
             */
        }
        //------------------------------------------------------------------------
        
        //------------------------------------------------------------------------

    }
}
