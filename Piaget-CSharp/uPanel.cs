using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace Piaget_CSharp
{
    public static class uPanel
    {
      /*  public class tPas
        {
        } // end class tPas  
        public class tDegres
        {  int value;
            int ThetaRobotDegres, AngleTrajectoire, AngleRobotTraj
        } // end class tDegres
       */
        /// typedef float tPas, tRadians;
        // pour permettre l'accès aux contrôles de la fiche principale
        // uPanel.MainForm.Controls["NomDuControle"]

        public static Form MainForm
        {
            get
            {
                if (Application.OpenForms.Count > 0)
                    return Application.OpenForms["FPiaget"];
                else
                    return null;
            }
        }


   /// typedef float tPas, tRadians;
  /// typedef int tCm,          //(* centimètres *)
  /// tDegres;                // (* degrés  *)
  /// 
public static bool  InteractionSouhaitee;

       public struct tSLPoint
        {
            int x, y;
        }    ;
 
    public struct                 // Matthieu et Julien
    tEvitement  {
                        public bool Gauche,Droite,Reculer;
                 }
    public static tEvitement Evitement ; 

 //   public static tEvitement Evitement { get; set; }
   
   

  public struct
  location
  {
    public  float x, y, phi;
  }    ;
  public static location Tool;

// Declaring a 2 D array
static double[,] tArray = new double[4,4];

//            int[] intArray;
//            intArray = new int[100];

//typedef  struct
public struct
 tVecteur2D {
    public float x, y;
             }   
public struct
 tVecteur3D {
    public float x, y, z;
             }   
static  tVecteur3D P3D05;

public struct tMatriceTransf
    { public  tVecteur2D u,v,p;
       }  ;
public static tMatriceTransf TCameraCocotier, T0Robot, T0Cocotier,
  T0Balle, TCameraBalle, TCameraTemp, TRobotCamera;
struct tMatriceTransf3D
    {
        tVecteur3D u,v,w,p;
                 }

public static long TicksPerSecond { get; set; }
public static double V7TicksParSecondeEstime { get; set; }
        
//   public static tEvitement Evitement { get; set; }
public static long Ticks,OldTicks, SecondesPasseesRel;

//public static long Seconds = 0, MilliSeconds, SystemTicks, PastSeconds = -1, IncrSeconds;
public static long Seconds { get; set; }
public static long MilliSeconds { get; set; }
public static long SystemTicks { get; set; }
public static long SystemTicksRel { get; set; }
public static long PastSeconds { get; set; }
public static long IncrSeconds { get; set; }

public static long InitialTicks { get; set; }
public static bool Initialise { get; set; }

public  struct
   tChoixBool  {
 //     string Nom;
public  bool Etat;
  //    int Ligne,colonne: integer; //(*position d'affichage *)
 //     string etiquette[LongueurEtiquetteChoix];
public  char caractere; //(* pour commutation au clavier *)
public string[] nom; ///*-* =new string[12],  AnsiString
     }    // end of struct tChoixBool

public static int NChoix=24; // Code & JDZ 016.05.11 changed from 20
public static tChoixBool[] Choix = new tChoixBool[NChoix];    // NChoix+1 pour effets de bord;  Code & JDZ 016.05.11 changed from 21
public static int   NCSimulation,   NCBeckhoff,         NCCamera,       NCGalil,        NCMusique,          NCStepSound,
                    NCCalibration,  NCVisionContinue,   NCShoulder,     NCHand,         NCImage1Or2L,       NCmNull, 
                    NCmRouge,       NCmVert,            NCmBlanc,       NCmNoir,        NCmIntensite,       NCmSaturation,
                    NCmTeinte,      NCGalil1Or2L,       NCReserve2,     NCGalilM27;

public static bool      ChoixGalilFront,    ChoixGalilBack,         ChoixLaserA,            ChoixLaserB,   
                        ChoixLaserC,        ChoixGalil8AxesFront,   ChoixGalil4AxesBack,    ChoixLaserD;


public static bool PlatformRHY, PlatformOPY, PlatformOP12Y;

public static string MessageErreur, Message, MessageUser;
public static string MessageLu;

public static float DeltaT, DeltaTPas;

public static int OffsetLignesTaches=3, NLignesVisibles = 5;
public static int NCarParLigneWrite = 50;

public static int   NTPas,          NTLireClavier,  NTMouvementPTP,         NTStrategie,
                    NTLireEntrees,  NTShowStatus,   NTMouvementSpat,        NTLED,
                    NTVision,       NTExtras,       NTGestionCollisions,    NTGererDoigt,
                    NTGererBalle,   NTGestionSouris,NTTesterEntree,         NTInterpreteurPiaget;

public static bool ModeRHYorOPYlow, Done1; // à double SupportPhysiqueES, BeckhoffEnLigne
public static char CarLu, V5CarLu;

public enum tModeDeMouvement { XY, Rot, MDMds, RotExc, RXY, Lat } //  tMDM tModeDeMouvement;
   //  (* tous: en coordonnées absolues sauf ds: en relatif *)

public  enum  tEtat  {AFaire, EnCours, Fait}

public enum tPhase {Pret, EnMatch, GameOver};
public static tPhase Phase;

public  struct
   tMouvement  {
    public tModeDeMouvement ModeDeMouvement;
    public tEtat Etat;
    public tPoint2DPlus PFutur;
    public int NPas, NoPasCourant; 
//        single IncrGauche, IncrDroit, IncrCamera,
    public float    IncrGauche,     IncrDroit,  IncrCamera,// tPas
                    NoPasGauche,    NoPasDroit, NoPasCamera,
                    VitesseM,       VitesseMaxM,AccelerationM, 
                    DecelerationM,  NPasAccelM, NPasDecelMx;
     }
public static int CalibrationAngle = 90, CalibrationDs = 150;

public static tMouvement Mouvement;


public static bool TrainMoteurSurLeDos = true,     //Rotation ou     (???)   ProtoDude: false
     InversionAvantArriere = false;  // translation inversée? cf. InverseSensLineaire      */
// single  PasParCmMax, PasParDegreRobotMax,

public static float     PasParCmMax,                PasParDegreRobotMax,     PasParCmGauche,        PasParDegreRobotGauche, 
                        PasParCmGaucheRH,           PasParCmGaucheOP,        PasParDegreGaucheRH,   PasParDegreGaucheOP,
                        PasParCmDroite,             PasParDegreRobotDroite,  PasParCmDroiteRH,      PasParCmDroiteOP, 
                        PasParDegreDroiteRH,        PasParDegreDroiteOPY,    PasParDegreDroiteOP,
                        DemiEcartRouesExt,          DemiEcartRouesExtRH,     DemiEcartRouesExtOP, /*  *****  A VERIFIER **** (Dude 9.6 cm) */
                        PasParDegreRobotGaucheRH,   PasParDegreRobotDroiteRH,PasParDegreRobotGaucheOP,
                        PasParDegreRobotDroiteOP,   PasParCmGaucheOP12Y,   PasParDegreRobotGaucheOP12Y,
                        PasParCmDroiteOP12Y,        PasParDegreRobotDroiteOP12Y,
                        DemiEcartRouesExtOP12Y,     PasParDegreRoueOP12Y;

public static float DemiEcartRouesExtFront = 20; // ****  A CALIBRER **** (Dude 9.6 cm)
// int NSoLedFonctionnement=1 ;


// single   VitesseMaxGlobale=100, VitesseMaxCourante,
public static float VitesseMaxGlobale = 100, VitesseMaxCourante,
   FacteurVitesseMax = 1,
   AccelerationMaxGlobale = 100, AccelerationMaxCourante,
   FacteurAccelerationMax = 1,
      DecelerationMaxCourante, FacteurDecelerationMax = 1,
      ReductionDAccelerationEnRotation = 1.5F;

// cas Ethernet Galil
public static bool InverseSensLineaire,   // géré par fichier paramètres
     InverseSensLineaireFront = true, InverseSensLineaireBack = InverseSensLineaireFront,
     InverseSensRotation, // géré par fichier paramètres
     InverseSensRotationFront = true, InverseSensRotationBack = InverseSensRotationFront,
     InverseCoteRotationXCentree, // géré par fichier paramètres
     InverseCoteRotationXCentreeFront = true, InverseCoteRotationXCentreeBack = InverseCoteRotationXCentreeFront,
     InverseSensLineaireLateral = true;
       
 //
public  struct tSignal  {
    public  bool  EtatVF, AComplementer, actif;
    public byte EtatNum; //(*  Multi ‚tats: n‚g. neutre et positif *)
  //    single valeur;
    public float valeur;
    public bool BoolNotAnaloqique;
  //    DelaiMax, Temporisateur: longint;
  //    Ligne,colonne: integer; (*positions d'affichage *)
  //    etiquette: string[12];
    public char caractere; //(* pour commutation au clavier *)
     }    ;


public static int NSignauxBoolIn = 16,
     NSignauxAnalogiquesIn = 4,
     NSignauxIn = NSignauxBoolIn + NSignauxAnalogiquesIn,
     NSignauxBoolOut = 16, // anciennement 13
     NSignauxAnalogiquesOut = 4,
     NSignauxOut = NSignauxBoolOut + NSignauxAnalogiquesOut;
    
 public static tSignal[]
  SignauxIn=new tSignal[26],   //26= 16+4+1           //  SignauxIn[20],    // 16+4+1  julien
  SignauxOut = new tSignal[20];   //20= 8+4+1            //  SignauxOut[12];   // 8+4+1  julien
 public static int
           NSIDemarrage=1,
           NSISuiviDuBord=2,
           NSIDetectionDuMur=3,
           NSIPartChocGauche=4,
           NSIPartChocDroit=5,
           NSIRavin1=6,
           NSIRavin2=7,
           NSIRavin4=9,
	   NSIChuteBalle=8,
           NSIAimantGaucheHaut=10,
           NSIAimantGaucheBas=11,
           NSIAimantDroiteHaut=12,
           NSIAimantDroiteBas=13,
           NSISocle1=14,
           NSISocle2=15,

           NSAIUSBasGauche=1,
           NSAIUSBasDroit=2,
           NSIAUSHautGauche=3,
           NSIAUSHautDroit=4,

           NSOLEDFonctionnement=1,    //0.5A
           NSOMoteurTirCanon=2,    //0.5A
           NSOInversionMoteurRelevGauche=3,    //0.5A
           NSOInversionMoteurRelevDroite=4,    //0.5A
           NSOInfoWalter1 =5,    //0.5A
           NSOInfoWalter2=6,    //0.5A
           NSOMoteurMilieuCiel =7,  //pas utilisé
           NSOMoteurHautOn =8,  //pas utilisé
           NSOMoteurBalayage=9,
           NSORelevageGauche=11,
	   NSOCarrousel=10,
           NSORelevageDroite=12;

public static  int CaptUSHG = 17,
         CaptUSHD = 18,
         CaptUSMG = 22,
         CaptUSMD = 21,
         CaptUSBG = 20,
         CaptUSBD = 19;

public static bool ModeTest, ModeNewLaser;
public static bool KinectConnection;
public static int SimulationImageNumber = 1;
        //
        /*-* 
  * 

  //virtual sensor
// float DistanceVS=1E10;
 float DistanceVSFR=1E10;
 float DistanceVSFL=1E10;
 float DistanceVSR=1E10;
 float DistanceVSL=1E10;
 bool VSactif=true;


public static  bool ModCoul1=false;
 TColor Coul1=clBlue, Coul2=clRed,
        Coul3=clGreen, Coul4=clMaroon,
        CoulAdv1, CoulAdv2, CoulPropre1, CoulPropre2;
*-*/

//*** TStrings* MessageTS;

public static long TicksParSecondeLu;

public static bool PiagetDone=false;

public static bool EthernetInitialise=false;
public static bool GalilInitialise=false;
public static bool BeckhoffEnLigne=false;
public static bool CameraInitialise=false;
// à double public static bool InteractionSouhaitee=false;
public static bool LireFichierReserve=false;


 

 public static bool BonneVision=false;
// bool Image1Or2L=false;  //    Choix[NCImage1Or2L].Etat=true;
 public static bool UtiliserVision;
 public static bool TentativeEvitementCoco;
 public static int XVisionPixel=0, YVisionPixel=0, DVision=0, ThetaVision=0,
  ColonneBalle, LigneBalle, ColonneCocotier, LigneCocotier,
  ColonneTemp, LigneTemp, ColonneBalise, LigneBalise;
//Graphics::TBitmap *ImgTt;

public static bool DemandeRefreshSortie ;
public static bool SupportPhysiqueES, CameraDisponible,
    BlocBeckhoffDisponible, CommandeGalilDisponible ;
public static bool BalleDetectee, ObstacleDetecte, TimeOut, DebugStep=false; // à double , ModeTest

public enum tModeTestRAH {  FastFollow,     FetchAndCarry,  FollowAndGuide07,   Introduce, 
                            Manipulate,     Bartender,      OpenChallenge,      WhoIsWho,
                            LostAndFound,   SuperMarket,    FollowWall,         FastFollow2010,
                            ShowEmBo, Gamepad, WhoIsWho2010, FaceRec,
                            RobInspecPS, OpenChallenge2010, Navigate, KukaGlue,
                            TestTask, StaubliTask, NAOinGE, HeightFrom3D,
                            CogniMeasure, RandomWay, DemoKatana, KinectNavigation,
                            DemoEnergy, TeleGrab, DemoOP12Y, RobocupAtWork,
                            OpenChallenge2011, Compliance, GoAndGet, Introduce2010
                           }  ;
public static tModeTestRAH ModeTestRAH;
//bool FastFollow, FetchAndCarry, FollowAndGuide07, Introduce,
//        NavigatePlaces07, OpenChallenge, WhoisWho, Manipulate=false;
//bool BalleHaut, BalleMilieu, BalleBas;
public static int CommandeBeckhoff,
    CMDBalle;

public static int
    CMDNulle=0,
    CMDBeckhoffTransparent=0,
    CMDPrendreBalle1DuSol=1,
    CMDPrendreBalle2DuSol=2,
    CMDPrendreBalle3DuSol=3,
    CMDPrendreBalle1DuCiel=4,
    CMDPrendreBalle2DuCiel=5,
    CMDPrendreBalle3DuCiel=6,
    CMDLancerBallesAuSol=7,
    CMDLancerBallesAuFilet=8,
    CMDPreparerPrendreBallesDuSol=9,
    CMDPreparerPrendreBallesDuCiel=10;
    
public static long ThetaGauche, ThetaDroit;

public  enum tDirection{VersAdversaire, VersBase, VersCoteDroit, VersCoteGauche}
public static tDirection Direction;
public  enum tEtape {ChercherBallesAuSol, ChercherCocotiers, ApprocherLesButs}
public static tEtape Etape;
public static bool    CocotiersDetectes=false,
        AdversaireDetecte=false,
        ReglageVision=true,
        AfficherMires=false,
        PrendreUneImage;

public static int ic=180 /* 163 */, il=130/*130,200*/, ir=255/*255*/, iv=127/*150*/, ib=0, R, V, B, I,S,T,
        icolor=ir+256*iv+ib*256*256, iclr, illr,
        GainR=130, GainV=100, GainB=95,   // %
        NRouge,   NRougeMax,   XRouge,
        NVert,    NVertMax,    XVert,
        NBleu,    NBleuMax,    XBleu,
        NMagenta, NMagentaMax, XMagenta,
        NCyan,    NCyanMax,    XCyan,
        NObstacles, NBlanc, NNoir,
        NGris, NJaune;
public static int ALNoLigne=/*50 ou 35*/ 50,ALStartColonne=5, ALStopColonne=70;
public static int ACNoColonne=/*50 ou 35*/ 50,ACStartLigne=5, ACStopLigne=55;

public static int ColLightLeftPixel=33,LigneLightLeftPixel=14,

    ColTopLeftPixel=12,LigneTopLeftPixel=30,
    ColTopLeftCM=-69,  LigneTopLeftCM=135, // f(caméra); 150 f(terrain)

    ColLowLeftPixel=5, LigneLowLeftPixel=42,
    ColLowLeftCM=-39,  LigneLowLeftCM=LigneTopLeftCM-100,

    MilieuLigneC=40, MilieuLigneL=55,
    MilieuLigneCCM=50,  MilieuLigneLCM=LigneLowLeftCM;

public static int P0RobotXCalib=50, P0RobotYCalib=0, P0RobotThetaCalib=84,
    PRobotCameraX=0,   PRobotCameraY=0, PRobotCameraTheta=-84;

public static tPoint2DPlus  P0Rouge, P0Vert;

// à double public static int SimulationImageNumber=1;

public static float iCamCibleX, iCamCibleY;
public static bool AffichageControleAFaire;
public static int CompteurImages=0;
public static bool PareChocsEnPlace=false;

public static int PasDExploration=15;  //  cm;

//*** int ConfigurationPont=0; // a priori inconnue





//*** int VitesseCanon=0;

public  enum tServoCommande {ServoGalilEthernet};


public static tServoCommande ServoCommande = tServoCommande.ServoGalilEthernet;    //

public static int pix_count = 0, PixCountSimule=3000,PixCountSimuleMin=200,
        PixCountSimuleMax=8000,
    bx = 0, by = 0, size_calibre_50cm=PixCountSimuleMax,
     size_calibre_2m=PixCountSimuleMin, AngleMiresCentreBas=Convert.ToInt16(Math.Atan2(1.13,1.7)/3.1416*180);
         // 33.6 degrés poteau hauteur de 1.13 m (centre de l'écran) à 1.7 mètre de distance

public  enum tSens {Avant, Arriere, Gauche, Droite, Stop}
public static tSens Sens = tSens.Stop;

public  enum tModeCommandeCible{CibleEnModeVisuel, CibleEnModeVisuelRAH,
       CibleEnModeManuel,  CibleEnModeUS, CibleEnModeVisuelMagenta,
       CibleEnModeVisuelCyan,CibleEnModeVisuelMouse, CibleEnModeLaser}
public static tModeCommandeCible ModeCommandeCible = tModeCommandeCible.CibleEnModeVisuel;


public static location LRobotLeader;

public  enum tVocalCommand {
        VCHello, VCAry, VCYou, VCStart, VCStop, VCReset,
        VCYes, VCGo, VCNo, VCExit, VCQuit, VCForward, VCBackward,
        VCRight, VCLeft, VCUnindentified, VCNone,
          //vocal command (waypoint names) for Navigate
        VCDoor, VCCups, VCBlackboard, VCComau, VCTX40,
        VCSDoor, VCKitchen, VCLivingroom, VCPlant, VCCouch, VCTable, VCFrige,
        VCStove, VCTelevision, //VC for Walk&Talk
        VCFinish,
	  VCBYes, VCBNo, VCPeach, VCGrapes, VCLemon      // drinks for bartender
	};

public static tVocalCommand VocalCommand = tVocalCommand.VCNone,
    PreviousVocalCommand = tVocalCommand.VCNone;

public static bool nJohn=false, nJason=false, nBen=false, nTom=false, nDick=false;

public static bool nHello=false, nFinish=false;

public static bool ModeEchoVoiceCommand=true, VocalGo, Mute=false, Deaf=false;

public static int OffsX=0, OffsY=0; //cm
public static float Zoom=1;
public static  int LongueurTableCM=300, LongueurTablePixel=161,
        LargeurTableCM=210, LargeurTablePixel=113 ;


//float factx=float(Form1->PTable->Width)/210;
public static float factx=Convert.ToSingle(LargeurTablePixel)/Convert.ToSingle(LargeurTableCM);    // ...113...
// float facty=float(Form1->PTable->Height)/LongueurTable;
public static float facty=Convert.ToSingle(LongueurTablePixel)/LongueurTableCM;


public static int XMinDetect=1, XMaxDetect=79, YMinDetect=1, YMaxDetect=35;
public static bool AutoUpdateMapPosition=true,  UseUSForDistance=true;


public static int DistanceObstacleInMapWithFrontRay;
public static float angle1, angle2, angle3, angle4, angle5, angle6, angle7, angle8, dist1, dist2, dist3, dist4,
dist5, dist6, dist7, dist8;
public static float angle9, dist9, angle10, dist10;
public static int furnnb=0,FurnShape=1;

public static float DistCalibration1, DistCalibration2, DistCalibration3,
        AngleCalibration1, AngleCalibration2, AngleCalibration3,
        AngleCorrection;
public static int DistanceAttendue = 200, AngleRobotCorrige, XRobotCorrige, YRobotCorrige,
DistanceCorrection;
public static bool InitialiserLaser=false,InitialiserLaser1=false,InitialiserLaser2=false;

//#define MapGridWidthCm 1200   // prev. 1000
//#define MapGridHeightCm 1200  // prev. 1000
public static int MapGridWidthCm = 1200; // prev. 1000
public static int MapGridHeightCm = 1200; // prev. 1000

//public static  int MapGridInit[MapGridWidthCm][MapGridHeightCm];  // 1000, 1000
//public static byte MapGrid[MapGridWidthCm][MapGridHeightCm];
public static  int[][] MapGridInit;  // 1000, 1000
public static byte [][] MapGrid;

public static int px2cm=2;
public static bool TraceOn=false;

//public static long laserdistance[769];         // instead of WORD, PFG 090618
public static long [] laserdistance;         // instead of WORD, PFG 090618
public static int NLaserDistances=769;
public static float i2aLaser=0.3515625F;  // imin=angleinf/i2a+387;
public static int iLaserCenter=384;
//public static int MapRadii[769], NMapRadii=NLaserDistances; // for simulation; from Map.
   public static int [] MapRadii; 
   public static int  NMapRadii=NLaserDistances; // for simulation; from Map.
public struct tLaserData  {
    //public static  int r[769]; } 
    public static  int[] r; 
} 

//public static int LaserSearchEnveloppeCM[769];
public static int [] LaserSearchEnveloppeCM;
public static int ModeTestRAH_Number;
public static int ComPortLaserNumber;
public static int Camera_OrientationD1;
public static int ObjectHeight1;
public static String ComPortLaser="\\\\.\\COM" + uPanel.ComPortLaserNumber.ToString(); //   6,   C01X31, with hub: COM9; \\\\.\\ to access port > 9 (also work for 1-9)

                        //FS t4215 19:haut, 22 bbas?
public static bool EnableFiveCoHand, EnableFiveCoArm;
public static long OffsetFiveCoHand=0;


public  
   struct
   tCalibrationPlane{
    //          single x,y,ds, RayonTrajectoire ;
 public static float x,y,phi,length ; // phi is direction of normal vector
        }  
// tCalibrationPlane CP0Door={980, 930, 180, 100};

public static bool USSensorTriggered ;
public static int  USSensorTriggerDistanceCM=100;

public static  float  HShoulder=42;  // cm
public static  float  LArmToWrist=74-42;  // cm
public static  float  AWrist=115; // on the ground, between arm and hand
   //float    LWristToHookTip=;  //  2.5 wrist to beg top,  23.5 wrist to en top
public static  float AngleArmOffVertical, dAngleArmOffVertical, dDistanceOffDoor, AngleInit=0; //degres
public static  float  AngleArmOffVerticalLow=32; //  degree when low , with hook  (  13 degrés wo sans crochet    0 Incr.)
public static  float  AngleArmOffVerticalHigh=169; //  degree when high, with hook  (116'000 Incr.)
public static  float  IncrPerDegree=-(116000-0)
                /(AngleArmOffVerticalHigh-AngleArmOffVerticalLow); // -847
/*
        poignée dessus : 107 cm,
        poignée longueur : 11 cm

        poignée ouverture : 103 cm (extrémité)

        distance crochet main : 18 cm

 pos       hauteur crochet            x  crochet

 0              117                     2
 -10000         115                     30
 -15000         110                     44
 -20000         102                     56
 -25000         93                      60
 -35000         74                      72
 -50000         55                      78

*/

public static int EmotionsOffsetLeft=350,
    EmotionsZoom=4,
    EmotionsMouthCenterLeft=545, EmotionsMouthCenterTop=65,
    EmotionsLeftEyeCenterLeft=530, EmotionsLeftEyeCenterTop=36,
    EmotionsArousal=50,         // %
    EmotionsHappiness=10;        // %

public static bool TargetDetected;


public static bool PLCLEDEnabled=true;    // obsolete, see ModeEyes

//*** A AFIRE Graphics::TBitmap *Img3D  = new Graphics::TBitmap();

public struct tObject {
public  double x, y; }
//public static Object[8000],Target,  ObjPix[100][5000],ObjWrtKatana[100],BottleLeft,BottleRight,HalfwayToGlass;
   public static tObject[] Object;
   public static tObject Target,BottleLeft,BottleRight,HalfwayToGlass; 
   public static tObject[][] ObjPix;
   public static tObject[] ObjWrtKatana;
public struct xyz{
 //   public double x;double y; double z;} 
    public double x, y, z;} 
public static int MinX3D,MinY3D,MaxX3D,MaxY3D ;

// à double public static bool ModeNewLaser = true;

// urg_laser *laser1 = NULL, *laser2 = NULL;      // PFG 09
//*** A FAIRE public static urg_laser *laser1 = NULL;      // PFG 09
//*** A FAIRE public static urg_laser *laser2 = NULL;      // PFG 09


public enum tModeEyes{  NormalMode,     EyesInverse,        EyesAsynchrous, UserMode, RightEyeBlinking,
                        LeftEyeBlinking, BothEyesBlinking,  BatteryMode,    EmotionMode}  
public static tModeEyes ModeEyes;

public enum tPlatform { RHY, OPY, OP12Y, MANIP25, NONE };
public static tPlatform Platform = tPlatform.NONE; 

public static float LeftEyeOnTime=0.5F, LeftEyeOffTime=0.5F, EyeDutyCycleMin=0.2F,EyeDutyCycleMax=2F , // 0.2 .. 2 s
      RightEyeOnTime = 0.5F, RightEyeOffTime = 0.5F;

public static System.Drawing.Color clRed=System.Drawing.Color.Red;
public static System.Drawing.Color clLime=System.Drawing.Color.Lime;
// précédemment dans uTask05:
public static bool BreakpointEnabled = false;
public static int BreakpointNumber = 0, OldBreakpointNumber = 0;

// Simulation
public static float OPDeplacement = 0;                // cm
public static float OPDeplacementCrabeX = 0;          // cm
public static float OPDeplacementCrabeY = 0;          // cm

public struct
   tPoint2DPlus
{
    public float x, y, ds, RayonTrajectoire;

    public float ThetaRobotDegres, AngleTrajectoire, AngleRobotTraj; // tDegres
    //       tDegres ThetaRobotDegres,AngleTrajectoire, AngleRobotTraj;            
}  // tPoint2DPlus 

public static tPoint2DPlus PCameraCocotier, P0Cocotier,
P0Balle, PCameraBalle, PCameraTemp, P0Temp, PCameraCible, P0Cible,
P0CibleVisionRAH,
P0CibleTable, P0CibleManuel, P0CibleUS, P0CibleLaser,
PRobotCamera;
//------------------ P12-Y ---------- SL 2013 ---------
public struct PlatformeP12Y{
	// Paramètres géométriques de la plateforme P12-Y
	public float largeur;                    // Pixels
    public float longueur;                   // Pixels
    public float diagonale;                // Pixels
    public float alpha;			// Degrés



	// Paramètres géométriques des triangles symbolisant les roues du P12-Y
    public float BaseTriangle;               // Pixels
    public float HauteurTriangle;            // Pixels
        // Position initiale du triangle représentant les roues de la rangée de gauche
    public tVecteur2D TGHaut, TGBasGauche, TGBasDroite;
        // Position initiale du triangle représentant les roues de la rangée de droite
    public tVecteur2D TDHaut, TDBasGauche, TDBasDroite;
        // Position après rotation des points
        public tVecteur2D PosTriangleHautPrime,PosTriangleBasGauchePrime,PosTriangleBasDroitePrime;

        // Indique phase de déplacement de type orienté la roue et après avancé
        public bool GoMouvement;


	// Structure contenant les paramètres du centre de gravité de la plateforme P12-Y
	public  struct CDG
	{
          public float PosX;               // Pixels
		  public float PosY;               // Pixels
		  public float Angle;		// Degrés
	} ;				// Centre de Gravité

	// Structure contenant les paramètres des centres de gravité de chaque roue du P12-Y
	// Ainsi que les transformations des coordonnées
	public struct Roues{
		// Paramètres de la roue avant-gauche
		float PosXRAvG;         // Pixels
		float PosYRAvG;         // Pixels
		float AngleRAvG;        // Degrés
                int AngleRAvGenPas;     // Nombre d'incrément

		// Paramètres de la roue avant-droite
		float PosXRAvD;        // Pixels
		float PosYRAvD;        // Pixels
		float AngleRAvD;       // Degrés
		int AngleRAvDenPas;    // Nombre d'incrément

		// Paramètres de la roue milieu-gauche
		float PosXRMG;          // Pixels
		float PosYRMG;          // Pixels
		float AngleRMG;         // Degrés
		int AngleRMGenPas;      // Nombre d'incrément

		// Paramètres de la roue milieu-droite
		float PosXRMD;          // Pixels
		float PosYRMD;          // Pixels
		float AngleRMD;         // Degrés
		int AngleRMDenPas;      // Nombre d'incrément

		// Paramètres de la roue arrière-gauche
		float PosXRArG;         // Pixels
		float PosYRArG;         // Pixels
		float AngleRArG;        // Degrés
		int AngleRArGenPas;     // Nombre d'incrément

		// Paramètres de la roue arrière-droite
		float PosXRArD;         // Pixels
		float PosYRArD;         // Pixels
		float AngleRArD;        // Degrés
		int AngleRArDenPas;     // Nombre d'incrément

                // Ajout SG 13.06.2013
                // Vitesse des roues
                int VRArG;    // Roue arrière gauche
                int VRArD;    // Roue arrière droite
                int VRMG;     // Roue milieu gauche
                int VRMD;     // Roue milieu droite
                int VRAvG;    // Roue avant gauche
                int VRAvD;    // Roue avant droite

                // Accérélation des roues
                int AccRArG;    // Roue arrière gauche
                int AccRArD;    // Roue arrière droite
                int AccRMG;     // Roue milieu gauche
                int AccRMD;     // Roue milieu droite
                int AccRAvG;    // Roue avant gauche
                int AccRAvD;    // Roue avant droite

                // Décélération des roues
                int DecRArG;    // Roue arrière gauche
                int DecRArD;    // Roue arrière droite
                int DecRMG;     // Roue milieu gauche
                int DecRMD;     // Roue milieu droite
                int DecRAvG;    // Roue avant gauche
                int DecRAvD;    // Roue avant droite

                // Distance parcourue des roues
                int DistRArG;    // Roue arrière gauche
                int DistRArD;    // Roue arrière droite
                int DistRMG;     // Roue milieu gauche
                int DistRMD;     // Roue milieu droite
                int DistRAvG;    // Roue avant gauche
                int DistRAvD;    // Roue avant droite

                // Accélération, décélération et vitesse maximum
                int AccMax;
                int DecMax;
                int Vmax;

	} ;
        struct Axes{
                // Ajout SG 13.06.2013
                // Vitesse des axes
                int VRArG;    // Roue arrière gauche
                int VRArD;    // Roue arrière droite
                int VRMG;     // Roue milieu gauche
                int VRMD;     // Roue milieu droite
                int VRAvG;    // Roue avant gauche
                int VRAvD;    // Roue avant droite

                // Accérélation des axes
                int AccRArG;    // Roue arrière gauche
                int AccRArD;    // Roue arrière droite
                int AccRMG;     // Roue milieu gauche
                int AccRMD;     // Roue milieu droite
                int AccRAvG;    // Roue avant gauche
                int AccRAvD;    // Roue avant droite

                // Décélération des axes
                int DecRArG;    // Roue arrière gauche
                int DecRArD;    // Roue arrière droite
                int DecRMG;     // Roue milieu gauche
                int DecRMD;     // Roue milieu droite
                int DecRAvG;    // Roue avant gauche
                int DecRAvD;    // Roue avant droite

	} ;
        struct facteur
        {
                // facteur conversion cm -> incrément
                float ConversionCmEnPas;
                // Correction du facteur
                float CorrectionCmEnPas;
                // facteur conversion Degres -> incrément
                float ConversionDegresEnPas;
                // Correction du facteur
                float CorrectionDegresEnPas;
        } ;
};

//public static PlatformeP12Y P12Y;

    } // end class uPanel
}
