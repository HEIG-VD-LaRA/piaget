using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Piaget_CSharp
{
    class uParam
    {
        public static void LireParametres()
        {
        uPiaget.WriteOnCheckBoard("uParam.LireParametres");
            
            //int TicksTemp;
            /*
             * lire parametre position du robot
             */
            uMouv.P0Robot.AngleRobotTraj      = Properties.Settings.Default.sP0Robot_AngleRobotTraj;
            uMouv.P0Robot.AngleTrajectoire    = Properties.Settings.Default.sP0Robot_AngleTrajectoire;
            uMouv.P0Robot.ds                  = Properties.Settings.Default.sP0Robot_ds;
            uMouv.P0Robot.RayonTrajectoire    = Properties.Settings.Default.sP0Robot_RayonTrajectoire;
            uMouv.P0Robot.ThetaRobotDegres    = Properties.Settings.Default.sP0Robot_ThetaRobotDegres;
            uMouv.P0Robot.x                   = Properties.Settings.Default.sP0Robot_x;
            uMouv.P0Robot.y                   = Properties.Settings.Default.sP0Robot_y;
        // lecture des paramètres
            uPanel.TicksPerSecond = Properties.Settings.Default.sTicksPerSecond;
            uPanel.ModeRHYorOPYlow = Properties.Settings.Default.sModeRHYorOPYlow;

            uPanel.PasParDegreGaucheOP = Properties.Settings.Default.sPasParDegreGaucheOP;
            uPanel.PasParDegreDroiteOP = Properties.Settings.Default.sPasParDegreDroiteOP;
            uPanel.PasParDegreGaucheRH = Properties.Settings.Default.sPasParDegreGaucheRH;
            uPanel.PasParDegreDroiteRH = Properties.Settings.Default.sPasParDegreDroiteRH;

            //uPanel.LireFichierReserve = false;
            // new: fprintf(stream, "%s", "[PasParCmGauche:RH=96.14;OP=...;  PasParCmDroite:RH=96.70;OP=...;]\n");
            uPanel.PasParCmGaucheRH = Properties.Settings.Default.sPasParCmGaucheRH;
            uPanel.PasParCmDroiteRH = Properties.Settings.Default.sPasParCmDroiteRH;
            uPanel.PasParCmGaucheOP = Properties.Settings.Default.sPasParCmGaucheOP;
            uPanel.PasParCmDroiteOP = Properties.Settings.Default.sPasParCmDroiteOP;
            
            // new:  fprintf(stream, "%s", "[PasParDegreRobotGauche:RH=...;OP=...;  PasParDegreRobotDroite:RH=...;OP=...]\n");
            uPanel.PasParDegreRobotGaucheOP = Properties.Settings.Default.sPasParDegreRobotGaucheOP;
            uPanel.PasParDegreRobotDroiteOP = Properties.Settings.Default.sPasParDegreRobotDroiteOP;
            uPanel.PasParDegreRobotDroiteRH = Properties.Settings.Default.sPasParDegreRobotDroiteRH;
            uPanel.PasParDegreRobotGaucheRH = Properties.Settings.Default.sPasParDegreRobotGaucheRH;

            // new: fprintf(stream, "%s", "[DemiEcartRoues:RH=...;OP=...;Dude:9.6cm]\n");
            uPanel.DemiEcartRouesExtRH = Properties.Settings.Default.sDemiEcartRouesExtRH;
            uPanel.DemiEcartRouesExtOP = Properties.Settings.Default.sDemiEcartRouesExtOP;


            uPanel.PasParCmGaucheOP12Y = Properties.Settings.Default.sPasParCmGaucheOP12Y;
            uPanel.PasParCmDroiteOP12Y = Properties.Settings.Default.sPasParCmDroiteOP12Y;
            uPanel.PasParDegreRobotGaucheOP12Y = Properties.Settings.Default.sPasParDegreRobotGaucheOP12Y;
            uPanel.PasParDegreRobotDroiteOP12Y = Properties.Settings.Default.sPasParDegreRobotDroiteOP12Y;
            uPanel.DemiEcartRouesExtOP12Y = Properties.Settings.Default.sDemiEcartRouesExtOP12Y;
            uPanel.PasParDegreRoueOP12Y = Properties.Settings.Default.sPasParDegreRoueOP12Y;
            
            uPanel.InverseSensLineaire = Properties.Settings.Default.sInverseSensLineaire;
            uPanel.InverseSensRotation = Properties.Settings.Default.sInverseSensRotation;
            uPanel.InverseCoteRotationXCentree = Properties.Settings.Default.sInverseCoteRotationXCentree;

            uPanel.VitesseMaxGlobale = Properties.Settings.Default.sVitesseMaxGlobale;
            uPanel.FacteurVitesseMax = 1;
            uPanel.VitesseMaxCourante=uPanel.FacteurVitesseMax*uPanel.VitesseMaxGlobale;

            uPanel.AccelerationMaxGlobale = Properties.Settings.Default.sAccelerationMaxGlobale;
            uPanel.FacteurAccelerationMax = 1;
            uPanel.AccelerationMaxCourante = uPanel.FacteurAccelerationMax * uPanel.AccelerationMaxGlobale;
            uPanel.FacteurDecelerationMax = 1;
            uPanel.DecelerationMaxCourante = uPanel.FacteurDecelerationMax * uPanel.AccelerationMaxGlobale;

            uPanel.ReductionDAccelerationEnRotation = Properties.Settings.Default.sReductionDAccelerationEnRotation;

            uPanel.Choix[uPanel.NCSimulation].Etat  = Properties.Settings.Default.sChoix_NCSimulation_Etat; // Simulation
            uPanel.Choix[uPanel.NCGalil].Etat       = Properties.Settings.Default.sChoix_NCGalil_Etat;      // Code & JDZ 016.05.11
            uPanel.Choix[uPanel.NCGalilM27].Etat    = Properties.Settings.Default.sChoix_NCGalilM27_Etat;   // Code & JDZ 016.05.11
            uPanel.ChoixGalilFront                  = Properties.Settings.Default.sChoixGalilFront;         // Code 016.05.11
            uPanel.ChoixGalilBack                   = Properties.Settings.Default.sChoixGalilBack;          // Code 016.05.11


            uPanel.Choix[uPanel.NCShoulder].Etat    = Properties.Settings.Default.sChoix_NCShoulder_Etat;   // Code 016.05.13
            uPanel.Choix[uPanel.NCHand].Etat        = Properties.Settings.Default.sChoix_NCHand_Etat;       // Code 016.05.13
            uPanel.ChoixLaserA                      = Properties.Settings.Default.sChoixLaserA;             // Code 016.05.13
            uPanel.ChoixLaserB                      = Properties.Settings.Default.sChoixLaserB;             // Code 016.05.13
            uPanel.ChoixLaserC                      = Properties.Settings.Default.sChoixLaserC;             // Code 016.05.13

            uPanel.Choix[uPanel.NCCamera].Etat      = Properties.Settings.Default.sChoix_NCCamera_Etat;     // Code 016.05.31
            uPanel.Choix[uPanel.NCBeckhoff].Etat    = Properties.Settings.Default.sChoix_NCBeckhoff_Etat;   // Code 016.05.31
            uPanel.ModeNewLaser                     = Properties.Settings.Default.sModeNewLaser;            // Code 016.05.31
            uPanel.KinectConnection                 = Properties.Settings.Default.sKinectConnection;        // Code 016.05.31
            uPanel.SimulationImageNumber            = Properties.Settings.Default.sSimulationImageNumber;   // Code 016.05.31

            switch (Properties.Settings.Default.sPlatform)                                                  // Code & JDZ 016.05.12
            {
                case 0: uPanel.Platform = uPanel.tPlatform.RHY;     break;  // RHY
                case 1: uPanel.Platform = uPanel.tPlatform.OPY;     break;  // OPY
                case 2: uPanel.Platform = uPanel.tPlatform.OP12Y;   break;  // OP12Y
                case 3: uPanel.Platform = uPanel.tPlatform.MANIP25; break;  // MANIP25
                case 4: uPanel.Platform = uPanel.tPlatform.NONE;    break;  // NONE
            }
                          
            if (uPanel.ModeRHYorOPYlow)
            {
                uPanel.PasParCmGauche = uPanel.PasParCmGaucheRH;
                uPanel.PasParDegreRobotGauche = uPanel.PasParDegreRobotGaucheRH;
                uPanel.PasParCmDroite = uPanel.PasParCmDroiteRH;
                uPanel.PasParDegreRobotDroite = uPanel.PasParDegreRobotDroiteRH;
                uPanel.DemiEcartRouesExt = uPanel.DemiEcartRouesExtRH;
            }
            else
            {
                uPanel.PasParCmGauche = uPanel.PasParCmGaucheOP;
                uPanel.PasParDegreRobotGauche = uPanel.PasParDegreRobotGaucheOP;
                uPanel.PasParCmDroite = uPanel.PasParCmDroiteOP;
                uPanel.PasParDegreRobotDroite = uPanel.PasParDegreRobotDroiteOP;
                uPanel.DemiEcartRouesExt = uPanel.DemiEcartRouesExtOP;
            }

            if (uPanel.PasParCmGauche>uPanel.PasParCmDroite)
                uPanel.PasParCmMax=uPanel.PasParCmGauche;
            else uPanel.PasParCmMax=uPanel.PasParCmDroite;

            if (uPanel.PasParDegreRobotGauche>uPanel.PasParDegreRobotDroite)
                uPanel.PasParDegreRobotMax=uPanel.PasParDegreRobotGauche;
            else uPanel.PasParDegreRobotMax=uPanel.PasParDegreRobotDroite;
            if (uPanel.PasParDegreRobotMax==0) uPanel.PasParDegreRobotMax=1;



      //      uPanel.NCGalilM27 = Properties.Settings.Default.sGalilM27;



            //FPiaget.CheckSupportPhysiqueES();

   
  } // end of LireParametres()
 //------------------------------------------------

        public static void SauverParametres()
        {
            uPiaget.WriteOnCheckBoard("uParam.SauverParametres");
            // écriture des paramètres (dans l'application)
            Properties.Settings.Default.sTicksPerSecond         = uPanel.TicksPerSecond;
            Properties.Settings.Default.sPasParDegreGaucheOP    = uPanel.PasParDegreGaucheOP;
            Properties.Settings.Default.sModeRHYorOPYlow        = uPanel.ModeRHYorOPYlow;

            
            Properties.Settings.Default.sTicksPerSecond         = uPanel.TicksPerSecond;
            Properties.Settings.Default.sModeRHYorOPYlow        = uPanel.ModeRHYorOPYlow;

            Properties.Settings.Default.sPasParDegreGaucheOP    = uPanel.PasParDegreGaucheOP;
            Properties.Settings.Default.sPasParDegreDroiteOP    = uPanel.PasParDegreDroiteOP;
            Properties.Settings.Default.sPasParDegreGaucheRH    = uPanel.PasParDegreGaucheRH;
            Properties.Settings.Default.sPasParDegreDroiteRH    = uPanel.PasParDegreDroiteRH;

            //uPanel.LireFichierReserve = false;
            // new: fprintf(stream, "%s", "[PasParCmGauche:RH=96.14;OP=...;  PasParCmDroite:RH=96.70;OP=...;]\n");
            Properties.Settings.Default.sPasParCmGaucheRH       = uPanel.PasParCmGaucheRH;
            Properties.Settings.Default.sPasParCmDroiteRH       = uPanel.PasParCmDroiteRH;
            Properties.Settings.Default.sPasParCmGaucheOP       = uPanel.PasParCmGaucheOP;
            Properties.Settings.Default.sPasParCmDroiteOP       = uPanel.PasParCmDroiteOP;

            // new:  fprintf(stream, "%s", "[PasParDegreRobotGauche:RH=...;OP=...;  PasParDegreRobotDroite:RH=...;OP=...]\n");
            Properties.Settings.Default.sPasParDegreRobotGaucheOP= uPanel.PasParDegreRobotGaucheOP;
            Properties.Settings.Default.sPasParDegreRobotDroiteOP= uPanel.PasParDegreRobotDroiteOP;
            Properties.Settings.Default.sPasParDegreRobotDroiteRH= uPanel.PasParDegreRobotDroiteRH;
            Properties.Settings.Default.sPasParDegreRobotGaucheRH= uPanel.PasParDegreRobotGaucheRH;

            // new: fprintf(stream, "%s", "[DemiEcartRoues:RH=...;OP=...;Dude:9.6cm]\n");
            Properties.Settings.Default.sDemiEcartRouesExtRH    = uPanel.DemiEcartRouesExtRH;
            Properties.Settings.Default.sDemiEcartRouesExtOP    = uPanel.DemiEcartRouesExtOP;


            Properties.Settings.Default.sPasParCmGaucheOP12Y        = uPanel.PasParCmGaucheOP12Y;
            Properties.Settings.Default.sPasParCmDroiteOP12Y        = uPanel.PasParCmDroiteOP12Y;
            Properties.Settings.Default.sPasParDegreRobotGaucheOP12Y=uPanel.PasParDegreRobotGaucheOP12Y;
            Properties.Settings.Default.sPasParDegreRobotDroiteOP12Y=uPanel.PasParDegreRobotDroiteOP12Y;
            Properties.Settings.Default.sDemiEcartRouesExtOP12Y     = uPanel.DemiEcartRouesExtOP12Y;
            Properties.Settings.Default.sPasParDegreRoueOP12Y       = uPanel.PasParDegreRoueOP12Y;

            Properties.Settings.Default.sInverseSensLineaire        = uPanel.InverseSensLineaire;
            Properties.Settings.Default.sInverseSensRotation        = uPanel.InverseSensRotation;
            Properties.Settings.Default.sInverseCoteRotationXCentree= uPanel.InverseCoteRotationXCentree;

            Properties.Settings.Default.sVitesseMaxGlobale          = uPanel.VitesseMaxGlobale;
            //uPanel.FacteurVitesseMax = 1;
            //uPanel.VitesseMaxCourante = uPanel.FacteurVitesseMax * uPanel.VitesseMaxGlobale;

            Properties.Settings.Default.sAccelerationMaxGlobale     = uPanel.AccelerationMaxGlobale;
            //uPanel.FacteurAccelerationMax = 1;
            //uPanel.AccelerationMaxCourante = uPanel.FacteurAccelerationMax * uPanel.AccelerationMaxGlobale;
            //uPanel.FacteurDecelerationMax = 1;
            //uPanel.DecelerationMaxCourante = uPanel.FacteurDecelerationMax * uPanel.AccelerationMaxGlobale;

            Properties.Settings.Default.sReductionDAccelerationEnRotation= uPanel.ReductionDAccelerationEnRotation;

            Properties.Settings.Default.sP0Robot_AngleRobotTraj     = uMouv.P0Robot.AngleRobotTraj;
            Properties.Settings.Default.sP0Robot_AngleTrajectoire   = uMouv.P0Robot.AngleTrajectoire;
            Properties.Settings.Default.sP0Robot_ds                 = uMouv.P0Robot.ds;
            Properties.Settings.Default.sP0Robot_RayonTrajectoire   = uMouv.P0Robot.RayonTrajectoire;
            Properties.Settings.Default.sP0Robot_ThetaRobotDegres   = uMouv.P0Robot.ThetaRobotDegres;
            Properties.Settings.Default.sP0Robot_x                  = uMouv.P0Robot.x;
            Properties.Settings.Default.sP0Robot_y                  = uMouv.P0Robot.y;

            Properties.Settings.Default.sChoix_NCSimulation_Etat    = uPanel.Choix[uPanel.NCSimulation].Etat;
            Properties.Settings.Default.sChoix_NCGalil_Etat         = uPanel.Choix[uPanel.NCGalil].Etat;        // Code & JDZ 016.05.11
            Properties.Settings.Default.sChoix_NCGalilM27_Etat      = uPanel.Choix[uPanel.NCGalilM27].Etat;     // Code & JDZ 016.05.11
            Properties.Settings.Default.sChoixGalilFront            = uPanel.ChoixGalilFront;                   // Code 016.05.11
            Properties.Settings.Default.sChoixGalilBack             = uPanel.ChoixGalilBack;                    // Code 016.05.11

            Properties.Settings.Default.sChoix_NCShoulder_Etat      = uPanel.Choix[uPanel.NCShoulder].Etat;     // Code 016.05.13
            Properties.Settings.Default.sChoix_NCHand_Etat          = uPanel.Choix[uPanel.NCHand].Etat;         // Code 016.05.13
            Properties.Settings.Default.sChoixLaserA                = uPanel.ChoixLaserA;                       // Code 016.05.13
            Properties.Settings.Default.sChoixLaserB                = uPanel.ChoixLaserB;                       // Code 016.05.13
            Properties.Settings.Default.sChoixLaserC                = uPanel.ChoixLaserC;                       // Code 016.05.13

            Properties.Settings.Default.sChoix_NCCamera_Etat        = uPanel.Choix[uPanel.NCCamera].Etat;       // Code 016.05.31
            Properties.Settings.Default.sChoix_NCBeckhoff_Etat      = uPanel.Choix[uPanel.NCBeckhoff].Etat;     // Code 016.05.31
            Properties.Settings.Default.sModeNewLaser               = uPanel.ModeNewLaser;                      // Code 016.05.31
            Properties.Settings.Default.sKinectConnection           = uPanel.KinectConnection;                  // Code 016.05.31
            Properties.Settings.Default.sSimulationImageNumber      = uPanel.SimulationImageNumber;             // Code 016.05.31


            switch (uPanel.Platform)        // Code 016.05.13
            {
                case uPanel.tPlatform.RHY:      Properties.Settings.Default.sPlatform = 0; break;   //RHY
                case uPanel.tPlatform.OPY:      Properties.Settings.Default.sPlatform = 1; break;   //OPY
                case uPanel.tPlatform.OP12Y:    Properties.Settings.Default.sPlatform = 2; break;   //OP12Y
                case uPanel.tPlatform.MANIP25:  Properties.Settings.Default.sPlatform = 3; break;   //MANIP25
                case uPanel.tPlatform.NONE:     Properties.Settings.Default.sPlatform = 4; break;   //NONE
            }
  //          Properties.Settings.Default.sGalilM27 = uPanel.NCGalilM27;
            /*

      fprintf(stream, "%s", "[PasParCmGauche=4*17.9500;  PasParCmDroite=4*17.9500]\n");
             * 
      fprintf(stream, "%8f  %8f  \n", PasParDegreRobotGauche, PasParDegreRobotDroite);

      fprintf(stream, "%s", "[DemiEcartRoues=...Dude:9.6cm]\n");     // 005.12.23
      fprintf(stream, "%8f  \n", DemiEcartRouesExt);

      fprintf(stream, "%s%s", "[InverseSensLineaire(x);","Galil:0...]\n");     // 005.12.23
      fprintf(stream, "%d\n", InverseSensLineaire);

      fprintf(stream, "%s%s", "[InverseSensRotation(z);","Galil:0...]\n");     // 005.12.23
      fprintf(stream, "%d\n", InverseSensRotation);

      fprintf(stream, "%s%s", "[InverseCoteRotationXCentree(y);","Galil:0...]\n");     // 005.12.23
      fprintf(stream, "%d\n", InverseCoteRotationXCentree);


      fprintf(stream, "%s", "[VitesseMaxGlobale(typ.:60cm/s)]\n");
      fprintf(stream, "%8f %s", VitesseMaxGlobale,"\n");

      fprintf(stream, "%s", "[AccélérationMaxGlobale(typ.:100cm/s2)]\n");
      fprintf(stream, "%8f %s", AccelerationMaxGlobale,"\n");

      fprintf(stream, "%s", "[ReductionDAccelerationEnRotation(typ. 1.5)]\n");
      fprintf(stream, "%8f %s", ReductionDAccelerationEnRotation,"\n");

      fprintf(stream, "%s", "[NSignauxIn=14]\n");
      fprintf(stream, "%d %s", NSignauxIn,"\n");

       for (int i=1; i<=NSignauxIn; i++)
       {
      fprintf(stream, "%s %d %s", "[Signal No ", i, "actif et vrai]\n");
      fprintf(stream, "%d  %d  %8f5 \n", SignauxIn[i].actif,
          SignauxIn[i].EtatVF, SignauxIn[i].valeur);
       }


      fprintf(stream, "%s", "[NChoix=21]\n");
      fprintf(stream, "%d %s", NChoix,"\n");
       for (int i=0; i<NChoix; i++)
       {
      fprintf(stream, "%s %d %s", "[Choix No ", i, "état et nom]\n");
      fprintf(stream, "%d  %s \n", Choix[i].Etat,
          Choix[i].nom);
       }

      fprintf(stream, "%s", "[OffsetLignesTaches=1]\n");
      fprintf(stream, "%d %s", OffsetLignesTaches,"\n");

       // image et vision
      fprintf(stream, "%s", "[Gain correction image GainR=130, GainV=100, GainB=95]\n");
      fprintf(stream, "%d %d %d %s", GainR, GainV, GainB,"\n");

      fprintf(stream, "%s", "[Position Cible Vision ic=160 il=120]\n");
      fprintf(stream, "%d %d %s", ic, il,"\n");

      fprintf(stream, "%s", "[Couleur Cible Vision R=255 V=200 B=0]\n");
      fprintf(stream, "%d %d %d %s", ir, iv, ib,"\n");

      fprintf(stream, "%s",
      "[Taille Cible Vision PixCountSimule=3000 PixCountSimuleMin=500 à 2m, PixCountSimuleMax=8000 à 50cm]\n");
      fprintf(stream, "%d %d %d %s", PixCountSimule, PixCountSimuleMin, PixCountSimuleMax,"\n");

      fprintf(stream, "%s", "[Taille Cible Vision size_calibre_50cm=8000, size_calibre_2m=500]\n");
      fprintf(stream, "%d %d %s", size_calibre_50cm, size_calibre_2m,"\n");

      fprintf(stream, "%s", "[Couleur référence IST rgb pour I=85 S=250 T=250]\n");
      fprintf(stream, "%d %d %d %s", GetRValue(RAHColorIst),
                         GetGValue(RAHColorIst),GetBValue(RAHColorIst),"\n");

      fprintf(stream, "%s", "[Couleur référence RGB R=200 V=70 B=70]\n");
      fprintf(stream, "%d %d %d %s", GetRValue(RAHColorRgb),
                         GetGValue(RAHColorRgb),GetBValue(RAHColorRgb),"\n");

      fprintf(stream, "%s", "[9 Couleurs RSup=13, VRMin=234, VJMin=13, VVertMin=67,...]\n");
      fprintf(stream, "%d %d %d %d %s", RSup, VRMin, VJMin, VVertMin,"\n");

      fprintf(stream, "%s", "[... VCyanMin=109, VBleuMin=140, VMagentaMin=200,...]\n");
      fprintf(stream, "%d %d %d %s", VCyanMin, VBleuMin, VMagentaMin,"\n");

      fprintf(stream, "%s", "[... VJIntSup=90, VSat=60, VNoir=100, VBlanc=150]\n");
      fprintf(stream, "%d %d %d %d %s", VJIntSup, VSat, VNoir, VBlanc,"\n");

      VTemp=  ModeReglageNoirBlanc;
      VTemp2=  ModeReglageTeinte;
      fprintf(stream, "%s", "[Réglage ModeReglageNoirBlanc=mrBlancMin(0), ModeReglageTeinte=mrRougeMinCyclique (0)]\n");
      fprintf(stream, "%d %d %s", VTemp, VTemp2,"\n");

      VTemp=  ModeImage;
      fprintf(stream, "%s", "[Réglage ModeImage=mRAH1de9 :(12), RAHColor1de9=mrRougeMinCyclique:(0)]\n");
      fprintf(stream, "%d %d %s", VTemp, RAHColor1de9,"\n");

      // Géométrie

      fprintf(stream, "%s", "[ColLightLeftPixel=33,LigneLightLeftPixel=14]\n");
      fprintf(stream, "%d %d %s", ColLightLeftPixel,LigneLightLeftPixel,"\n");

      fprintf(stream, "%s", "[ColTopLeftPixel=12,LigneTopLeftPixel=29]\n");
      fprintf(stream, "%d %d %s", ColTopLeftPixel,LigneTopLeftPixel,"\n");

      fprintf(stream, "%s", "[ColTopLeftCM=-69,  LigneTopLeftCM=95]\n");
      fprintf(stream, "%d %d %s", ColTopLeftCM,  LigneTopLeftCM,"\n");

      fprintf(stream, "%s", "[ColLowLeftPixel=5, LigneLowLeftPixel=42]\n");
      fprintf(stream, "%d %d %s", ColLowLeftPixel, LigneLowLeftPixel,"\n");

      fprintf(stream, "%s", "[ColLowLeftCM=-39,  LigneLowLeftCM=35]\n");
      fprintf(stream, "%d %d %s", ColLowLeftCM,  LigneLowLeftCM,"\n");

      fprintf(stream, "%s", "[MilieuLigneC=40, MilieuLigneL=55]\n");
      fprintf(stream, "%d %d %s", MilieuLigneC, MilieuLigneL,"\n");

      fprintf(stream, "%s", "[MilieuLigneCCM=105,MilieuLigneLCM=LigneLowLeftCM]\n");
                                            // non utlisé
      fprintf(stream, "%d %d %s", MilieuLigneCCM,  MilieuLigneLCM,"\n");

      extern tPoint2DPlus P0Robot;
      P0RobotXCalib=P0Robot.x;
      P0RobotYCalib=P0Robot.y;
      P0RobotThetaCalib=P0Robot.ThetaRobotDegres;
      fprintf(stream, "%s", "[P0RobotXCalib=99, P0RobotYCalib=55, P0RobotThetaCalib=84]\n");
      fprintf(stream, "%d %d %d %s", P0RobotXCalib, P0RobotYCalib, P0RobotThetaCalib,"\n");

      PRobotCameraX=PRobotCamera.x;
      PRobotCameraY=PRobotCamera.y;
      PRobotCameraTheta=PRobotCamera.ThetaRobotDegres;
      fprintf(stream, "%s", "[PRobotCameraX=-4,   PRobotCameraY=-9, PRobotCameraTheta=-84]\n");
      fprintf(stream, "%d %d %d %s", PRobotCameraX, PRobotCameraY, PRobotCameraTheta,"\n");

      fprintf(stream, "%s", "[XMinDetect=1,XMaxDetect=59,YMinDetect=1,YMaxDetect=79]\n");
      fprintf(stream, "%d %d %d %d %s", XMinDetect, XMaxDetect, YMinDetect, YMaxDetect,"\n");

      fprintf(stream, "%s", "[ComPortLaserNumber=8]\n");
      fprintf(stream, "%i %s", ComPortLaserNumber,"\n");

      fprintf(stream, "%s", "[ModeTestRAH=1FF,2FnC,3FnGuide,4I,5NavPlaces,6OpenC,7WsWho]\n");
      fprintf(stream, "%i %s", ModeTestRAH_Number,"\n");

      fprintf(stream, "%s", "[Cam_OrientationD=38]\n");
      fprintf(stream, "%i %s", Camera_OrientationD1,"\n");

       fprintf(stream, "%s", "[ObjectHeight=50mm]\n");
       fprintf(stream, "%i %s", ObjectHeight1,"\n");
  

            *-*/

            //---------------------------------------------------------------------------


            // sauvetage du fichier
            Properties.Settings.Default.Save();
            

        } // end of SauverParametres

    } // end of class uParam
}
