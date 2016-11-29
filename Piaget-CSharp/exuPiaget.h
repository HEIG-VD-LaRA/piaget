//---------------------------------------------------------------------------

#ifndef uPiagetH
#define uPiagetH
 AnsiString MessageUser;
 location /*Here,*/ Tool, Transf;
// single AngleMove, AngleMove2;
 float AngleMove, AngleMove2;
 tPoint2DPlus uPPTemp; // (*, uPP1Temp, uPP2Temp*);
// tMatriceTransf T0R, T0C, TRC, TTemp;
 bool uPEchec;
 location  L0CibleTable,L0Cible, PAux;
 AnsiString AffichageType, uPMessage, uPss;
 int uPiPos, uPiPos2, uPNCycles, uPNSI;
 float uPDureeMax;
 long uPConsigneFiveCoShoulder,uPConsigneFiveCoHand;

//  float DistanceCamera(int size_2m, int size_50cm, int size_measure);
  void AcquireDistancesWithLaser ();
  float AIOIn(int NS) ;
  void AllerEnXYAGN(float x, float y); //(* iSv, Position librement définie *)
  void AllumerMoteurBasCielAGN();
  void AllumerMoteurBasSolAGN();
  void AllumerMoteurEntreeCielAGN();
  void AllumerMoteurEntreeSolAGN();
  void AllumerMoteurHautCielAGN();
  void AllumerMoteurHautSolAGN();
  void AllumerMoteurMilieuCielAGN();
  void AllumerMoteurMilieuSolAGN();
 float AngleEntreM180etP180(float A);
  void ApproAGN(location &P, float d); //(* iSv, Position librement définie *)
  void ApproToolAGN(location &P, float d); ///* iSv, Position librement définie */
  void ApprocherDUnPasAGN(location L1, int LongueurPasCm, bool &pPointAtteint);
  void ArreterActionDoigtAGN();
  int Arrondir(float f);
  void AttendreFinGestionBallesAGN ();
  void AttendreFinMouvement();
  void AttendreFinMouvementAGN ();
  void AvancerAGN(tCm distance);  //  (*  iSv *)
  void AvancerADroiteAGN(tCm RayonTrajectoire, tDegres AngleTrajectoire); // * iSv, cm et degres *)
  void AvancerAGaucheAGN(tCm RayonTrajectoire, tDegres AngleTrajectoire); // * iSv, cm et degres *)
  void BackLocationAGN(location L1);
  void CalibrateFrom2Points(location LP1, location LP2, int L1, int L2, location &LHere);
  void CalibrationDistanceAGN();
  void CallCalibrationSub(tCalibrationPlane CP0location);
  void CallAGN (int StateNoSub);
  void CallIP(int const StateNoSub);
      // (* CallIP appelle l'interpréteur Piaget depuis la tâche 5 *)
  void DecomposeAGN(location P, float  &X,float &Y,float &phi);
  void DefineSearchEnveloppeAGN(/*int *LaserSearchEnveloppeCM[769],*/ int pLeftSearchMargin, int pFrontSearchMargin,
              int pRightSearchMargin);
  bool DemandeDeDemarrage();    /* iS et IP */
  void DemarrerMatchAGN();
//tDegres DirectionButDegres(tCm x0But, tCm y0But)  Défini dans uMouv
  void DisplayLaserDistances();
  tCm  Distance(location P0P); // en Cm, entre robot et P0P
  float DistanceCameraCibleCM(int size_2m, int size_50cm, int size_measure);
  int DistanceEntreLocations(location L1, location L2);
  int DistanceUSHautGaucheCM ();
  void EnvoyerCommandeAuBeckhoff(int CMD);
  void EnvoyerCommandeAuBeckhoffAGN(int CMD);
  void EstimerPositionGuideParLaser(float &x, float &y,float &Myangletrouve/*=NULL*/,
        float angleinf/*=-120*/, float anglesup/*=120*/, float ecartmax/*=20*/, int minvals/*=0*/ );
   void EstimerPositionObstacleParCapteurUS(float &x, float &y);
  void EstimerPositionObstacleParVisionRAH(float &x, float &y);
//  void EteindreMoteurBasAGN();
  void EteindreMoteurEntreeAGN();
  void EteindreMoteurHautAGN();
  void EteindreMoteurMilieuAGN();
  void FermerLiaisons();
  void FreeFivecoShoulderAGN();
  float GetLaserMindist(float *angletrouve=NULL,float angleinf=-110,
         float anglesup=110, float ecartmax=20, int minvals=1);
  float GetLaserMindistReversed(float *angletrouve/*=NULL*/,float angleinf=-110,
         float anglesup=110, float ecartmax=20, int minvals=1);
  float GetLaserDistFromLine(float *angletrouve=NULL,float angleinf=-110, float anglesup=110, float ecartmax=20, int minvals=1);
  int GetMedianDistance(int ind, int length);
  void GoNext();
  void GoState(int const &TargetState);
  void GoSubAGN (int StateNoSub) ;
  location Here();
  void InitialiserFiveCoShoulderAGN();
  void InitialiserFiveCoHandAGN();
  void InitLaser();
  void LancerActionDoigtAGN();
  void LancerGestionBallesAGN(int pCMD);
  void LireErreurGalil(long &pErreurGauche, long &pErreurDroite);
  void LirePositionGalil(long &pThetaGauche, long &pThetaDroit);
  void LocaliserBaliseAGN();
  void LocaliserBalleAGN();
  void LocaliserCocotierAGN();
  void LocaliserObjetAGN();
  tMatriceTransf LocationAMatrice(location &L);
  tPoint2DPlus  LocationToPoint(location &pL) ;
  location MatriceALocation(tMatriceTransf &M);
//void PointAMatrice(tPoint2DPlus &pt, tMatriceTransf &M);
//void InverserM( tMatriceTransf &m, tMatriceTransf &MInv);
//void MultiplierM(tMatriceTransf &m1, tMatriceTransf &m2,  tMatriceTransf &M);
//void MatriceAPoint( tMatriceTransf &m, tPoint2DPlus &pt);
  void MettreAJourChoixModeImage();
  //void MettreAJourDistanceVirtuelle(int xmap,int ymap,int xm,int ym, bool reset=false, TColor col=clGreen);
  void MettreAJourDistanceVirtuelle(int xm,int ym, float *Capteur,bool reset=false,byte col=0);
  bool MouvementGalilFait();
  bool MouvementFini();
  void MoveAGN(location &P); // (* iSv, Position librement d‚finie *)
  void MoveFiveCoShoulderAGN( int pConsigne);
  void MoveFiveCoHandAGN( int pConsigne);
  void MoveToolAGN(location &P); // (* iSv, Position librement d‚finie *)
  void MoveToolToXYAGN(location &P); // /* iSv, Position librement définie */
  void MoveToAngleAGN(tDegres phi);
  void MoveToXYAGN(location &P); ///* iSv, Position librement définie */
  void ObserverColonneAGN(int ALNoColonne,int ALStartLigne, int ALStopLigne) ;
  void ObserverLigneAGN(int ALNoLigne,int ALStartColonne, int ALStopColonne);
  void OuvrirEntreeAGN();
  void PasserDeLImageAuTerrain(int pColonne, int pLigne,tPoint2DPlus &pP0Temp);
  location PasserDeLocationRobotALocationTerrain(location &pLR);
  location PasserDeLocationTerrainALocationRobot(location &pLT);
  location  PointToLocation(tPoint2DPlus &pP);
  void PrendreUneImageAGN();
  void ObjectCheckT();
  void PromptIntegerAGN(AnsiString MyText, int i);
  void ReculerAGN(tCm distance);   //    (*  iS v  *)
  void ReculerADroiteAGN(tCm RayonTrajectoire,tDegres AngleTrajectoire);//(* iS *)
  void ReculerAGaucheAGN(tCm RayonTrajectoire,tDegres AngleTrajectoire);//(* iS *)
  void RentrerBrasAGN();
  void RentrerDoigtAGN();
  void ResetGalilAGN();
  void ReturnFromIP();
      // (* ReturnFromIP retourne de l'interpréteur Piaget à la tâche 5 *)
  void ReturnFromSub();
 int round(float x);
tVecteur2D Transform(tVecteur2D XYZ);
 void SayString(AnsiString t);
 void SayStringAndWait(AnsiString t);
 void SearchEnveloppeAGN( int pLeftSearchMargin,int pFrontSearchMargin,int pRightSearchMargin,         //cm
        float pSearchAngleMin,float pSearchAngleMax,
        bool &pObjectFound, int &pObstDistMin,
           float &pObstAngleMin, int &pObstWidthCm,
           int &pObstMeasuredMarginLeftCm,
            int &pObstMeasuredMarginRightCm ,
            int &pObstMeasuredMarginFrontCm   );
 void SetAGN(location &P, location &Exp); // cf. V+:  Set P=expression;
 void SetEyeModeBatteryMode() ;
 void SetEyeModeBothEyesBlinking() ;
 void SetEyeModeEyesInverse() ;
 void SetEyeModeLeftBlinking() ;
 void SetEyeModeNormal() ;
 void SetEyeModeRightBlinking();
 void SetEyeModeUserMode() ;
 void SetEyeModeWithDutyCycle(float ton, float toff);
 //void SetHereAGN()    // Remplacé par Here()
 void SetPositionRobotAGN(int const x, int y, int ThetaRobotDegres);
              // (re)définit la position nominale courante du robot
// void SetSpeedControlHand();
 void SetToolAGN(float const x, float y, float phi);
 void SetTransfAGN(float const x, float y, float phi);
 bool SignalActifEtVrai(int NS);
 bool SignalIn(int NS);
 void SignalOut(int NS, bool etat);
 void SignalOutAGN(int NS, bool etat);
 void SortirDoigtAGN();
 void ToggleEtatSI(int NS);
 void TournerSurPlaceAGN(tDegres Angle);          // * iS+iIP *)
 location Trans(float const x, float y, float phi);
 void TurnEyesOff(); //
 void TurnEyesOn(); //
 void  TurnStatusDiodeGreen() ;
 void  TurnStatusDiodeGreenAGN()  ;
 void  TurnStatusDiodeGreenAndRed()  ;
 void  TurnStatusDiodeGreenAndRedAGN()   ;
 void  TurnStatusDiodeRed()  ;
 void  TurnStatusDiodeRedAGN() ;
 void  TurnStatusDiodeOff() ;
 void  TurnStatusDiodeOffAGN() ;
 void TypeAnsiStringAGN(AnsiString A);
 void TypeIntegerAGN(int I);
 void TypeRealAGN(float R);
 //void  TypeStringAGN(AnsiString T);
 void  TypeStringAGN(char* T);
 void VirerAGN(tCm RayonTrajectoire, tDegres AngleTrajectoire);
                                // (* cm et degres *)
 void ViserLocationAGN(location L1);
 void WaitAGN(int NSignalIn);
 void WaitWhileSpeaking();
 void WaitWhileSpeakingAGN();
 void WaitWithTimeoutAGN(int NSignalIn, float pDureeMax);
           // retour dans Timeout

 //---------------------------------------------------------------------------
#endif

/*
Const uPDemiImpulsion=0.1;
var

     uPLargeurLigneVue,
     uPLargeurLigneMax,
     uPDistanceMin, uPDistanceMax: tCm;

     uPDistanceParcourue, uPK: single;
     uPCroisementAtteint: boolean;

     uPEtOuOuL, uPCondFXGauche, uPCondFXDroite: boolean;
     uPAngleMax:tDegres;
     uPAngleLigne: single;
     uPAngleTourne:single;

     uPFibreGauche, uPFibreDroite, uPFibreStop,
	     uPFibreActive: tIndiceSignalIn;
(* pour FlasherPMI *)
     uPNoSortie, uPNFois: integer;
       uPTOn,uPTOff:single;
(*  Instructions du langage Piaget   *)
 (* iS: instruction appelable de la tƒche "Strat‚gie" uniquement   *)
 (* iIP: instruction appelable de la tƒche "Interpr‚teur Piaget" uniquement *)
 (* iS+IP: instruction appelable des deux tƒches  *)
 (* v: test‚ *)

   (*  AfficherStrategieSurDiodes   *)
 void AccelererFreinerAGN(distanceAcc, distanceDec:tCm); (* iS, dsAcc, dsDec *)
 void ActiverFuseeDroiteAGN;
 void ActiverFuseeGaucheAGN;
 void AllerAuBordBlancNoirAGN; (* iSv, blanc sous le robot, noir devant *)
 void AllerAuBordNoirBlancAGN; (* iSv, en particulier travers‚e  *)
 void AllerEnAGN(P: tPoint2DPlus); (* iSv, Position librement d‚finie *)
 void AllerEnPositionAGN(NP: tindicePosition); (* iSv, Position pr‚d‚finie */
// void AllerEnXYAGN(float x,float y); (* iSv, Position librement définie *)
 /*
 void AllerPrendrePaletAGN(P: tPoint2DPlus); (* iSv, Position de la Palet NP
                                      (*ex AllerPercerBallon AGN et AllerPrendreBouletAGN*)
 void ApproAGN(P: location; d: real); (* iSv, Position librement d‚finie *)
 void ApprocherPaletAGN(NP: tIndicePosition; marge:single);
                                               (* iSv, Position del'Palet NP
                                      (*ex AllerPercerBallonAGN*)
                                      (*ex AllerPrendreBouletAGN*)
 void ApprocherEtoileAGN(marge:single);
 void xAllumerPharesAGN;
 void AttendreAGN(Duree:single);   (* s *)
 void AttendreFinActionBouletsAGN;
 void AttendreFinMouvementAGN;   (* iS+IP *)
*/
/*
 void AvancerRobotSurBordAGN(EtouOuL, CondFXGauche, CondFXDroite: boolean;
    DistanceMax: tCm; var DistanceParcourue:single; var Echec: boolean); (* iSv *)
 void CalerSurLignesAGN; (* ex TraverserLePont avec fibres  *) (* iS *)
 void CallIP(StateNoSub:Integer);   (* iSv appelle l'interpr‚teur Piaget *)
 void CentrerDoigtAGN;  (* iSv *)
 void ChangerPhaseAGN(NouvellePhase:tindicePhase);  (* iS+IPv *)
 void ChoisirLePontVisuellementAGN; (* iS (v en simul.)  *)
 Function  CroisementAtteint: boolean;    (* iS et IP *)
 void DecomposeAGN(P :location ; var  X, Y, phi: real);
 Function  DemandeDeDemarrage: boolean;    (* iS et IP *)
 void DescendreSabotAGN;
 Function  EchoCapteurUSBasGauche: boolean;    (* iS et IP *)
 Function  EchoCapteurUSCentre: boolean;    (* iS et IP *)
 Function  EchoCapteurUSBasDroite: boolean;    (* iS et IP *)
 Function  EchoCapteurUSHautGauche: boolean;    (* iS et IP *)
 Function  EchoCapteurUSHautDroite: boolean;    (* iS et IP *)
 void FixerVitesseMaxEnPourcent(Valeur:integer);
 void FixerAccelerationMaxEnPourcent(Valeur:integer);
 void FixerDecelerationMaxEnPourcent(Valeur:integer);
 void FrapperADroiteAGN;     (*  iSv *)
 void FrapperAGaucheAGN;     (*  iS  *)
 void GoNext;                (* iS+IP v *)
 void GoState(TargetState:integer);   (* iS+IPv *)
 void GoSubAGN (StateNoSub:Integer);  (* iS+IP  (v dans S *)
 void DeclencherPMIArriereAGN;  (*  *)
 void DeclencherPMIEtoileAGN;  (*  *)
 void DeclencherPMIAvantAGN;  (*  *)
 void DeclencherVentouseDroiteAGN;  (*  *)
 void DeclencherVentouseGaucheAGN;  (*  *)
 void xEteindrePharesAGN;
 void FlasherPMIAGN(NoSortie, NFois: integer; TOn,TOff:single); (*  *)
 void SetTransfAGN(x,y, phi: real);
 void LacherPMIDroiteAGN;  (*  *)
 void LacherPMIGaucheAGN;  (*  *)
 void LancerActiverFusees(NSo:tIndiceSignauxOut);
 void LancerLacherPMI(NSo:tIndiceSignauxOut);
 void LancerMonterPlateForme;
 void MonterPlateFormeAGN;
 void MoveAGN(P: location); (* iSv, Position librement d‚finie *)
 void PrendrePaletAGN;
 void PromptIntegerAGN(Text:string;var i: integer);
 void LancerMouvementCompactAGN(MM:tModeDeMouvement;PF:tPoint2DPlus);(*iS+IP *)  */
/*
 Function  SignalIn(NoIn: tIndiceSignalIn): boolean;    (* iS et IP *)
 void SignalOutAGN(NoOut: tIndiceSignauxOut; etat: boolean);    (* iS et IP *)
 void SortirDoigtADroiteAGN;                     (* iS *)
 void SortirDoigtAGaucheAGN;                     (* iS *)
 void SuivreLigneADroiteAGN(DistanceMax: tCm) (*   *);
 void SuivreLigneAGaucheAGN(DistanceMax: tCm) (*   *);
 void SuivreLigneAuCentreAGN(DistanceMax: tCm; FibreStop:tindiceSignalIn);
 void SuivreLigneAuCentre2AGN
      (DistanceMin,DistanceMax: tCm;
		 FibreActive, FibreStop:tindiceSignalIn)
                      (* la ligne est de part et d'autre de la roue avant  *);
 void SuivreLigneVisuellementAGN(AngleLigne, K: single;
             LargeurLigneMax,  DistanceMax: tCm (*;
                  var CroisementAtteint:boolean*));
 void TirerSurTourAGN(NoTour: tindicePosition);  (* iS */
 /*
 void TypeIntegerAGN(i: integer);
 void TypeLocationAGN(l: location);
 void TypeRealAGN(r: real);
 void TypeStringAGN(s: string);  */
/*
 void ViserPositionAGN(P: tPoint2DPlus);
 Function  VoieLibre: boolean;    (* iS et IP *)

(* Remarques:

   -  Les instructions avec suffixe AGN (and go next) font passer
      … l'ETAT suivant
   -  Les variables LOCALES, y c. les PARAMETRES de routines, ne
      sont PAS MAINTENUS d'un ‚tat … l'autre; si n‚cessaire, il faut
      les copier dans des variables d'unit‚s.
   -  Les instructions pr‚c‚d‚es d'une ‚toile sont utiles en interne
      seulement. Elles peuvent ˆtre ignor‚es en exploitation ordinaire.

*/
