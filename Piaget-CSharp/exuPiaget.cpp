//--------------------------------------------------------------------------

#include <vcl.h>
#include "uPanneauAux.h"
#include "UMain.h"
#include "math.h"

#include "uParam.h"

#include "uMTasksAux.h"
#include "uMouvAux.h"
#include "uGalilAux.h"
#include "uVisionAux.h"
#include "uCalTrnsAux.h"

#include "uFrmTTS.h"
#include "hokuyo_main.h"

#include "uPiaget.h"

#pragma hdrstop

 using namespace std;



//---------------------------------------------------------------------------
void AcquireDistancesWithLaser()
{
        if (!ModeNewLaser)
                fmRadar->BScan->OnClick(NULL);
        else {
           extern bool  WsWStopLaser;
           if (!WsWStopLaser)
               { int CSESensorNum;
                 CSESensorNum=Form1->CSESensor->Value;
//---
                 if  (CSESensorNum==1)
                  { if ((Choix[NCSimulation].Etat) || (bSImulationLaser1->Color==clLime) ) {
                                if (Form1->PSpiralNoisy1->Color==clLime) {
                                        for(int i=0;i<769;i++)  {
                                        //Decode the received data into distance and save
		                                if (i<384)
                                                        laserdistance[i] = 480+random(40)+(i/3);  // mm??
		                                else
                                                        laserdistance[i] = 500+(i/3);  // mm??
                                        }  // for
		                        laserdistance[149]=laserdistance[149]-50;  // mm
		                        laserdistance[150]=laserdistance[150]-50;  // mm
			                laserdistance[151]=laserdistance[151]-50;  // mm
			                laserdistance[152]=laserdistance[152]-50;  // mm
			                laserdistance[153]=laserdistance[153]-50;  // mm
			                laserdistance[381]=laserdistance[381]-50;  // mm
			                laserdistance[382]=laserdistance[382]-50;  // mm
			                laserdistance[383]=laserdistance[383]-50;  // mm
			                laserdistance[384]=laserdistance[384]-50;  // mm
			                laserdistance[385]=laserdistance[385]-50;  // mm
		                        laserdistance[386]=laserdistance[386]-50;  // mm
		                        laserdistance[387]=laserdistance[387]-50;  // mm
                                } // end if spirale
                                else { // if not a spirale
                                        for(int i=0;i<769;i++) {     // from map
		 	                        laserdistance[i] = MapRadii[i];
                                        }  // for
                                }
                        } // end if simulation
                        else {  // if not simulation
	                        int first = laser1->degree_to_step(-120);	// max +/- 120 deg    //44
	                        int last = laser1->degree_to_step(120);                                // 724
	                        long* data = new long [last - first + 1];
                        	if (laser1->get_data(data, first, last) < 0) {
		                        Form1->MControl->Lines->Add("Unable to get data from laser # " + AnsiString(laser1->urg_serial));
		                        delete [] data;
		                        laser1->urg_disconnect();
		                        delete laser1;
                                        laser1 = NULL;
                                        bSImulationLaser1->Color=clLime;
		                        return;
	                        }	// exit here if unable to get data from laser
                                int inc = 0;
                                memcpy(laserdistance+44, data, sizeof(long)*(last-first+1));
	                        delete [] data;
                               for (int k= first; k<=last; k++)    //*** 009.06.25
                                if (laserdistance[k] < 19)
                                  laserdistance[k] = 9999;

                        } // end if  simulation
//                extern void MarkLaserDistancesOnMap(int AngularStepSize ) ; // in radii, with interpolation
//                if (fMap->PTrace->Color==clLime)   //ProxS
//                        MarkLaserDistancesOnMap(5); // marquer chaque 10 rayons
      } // end of  if  (CSESensorNum==1)
//---
                 if  (CSESensorNum==2)
                  { if ((Choix[NCSimulation].Etat) || (bSImulationLaser2->Color==clLime) ) {
                                if (Form1->PSpiralNoisy2->Color==clLime) {
                                        for(int i=0;i<769;i++)  {
                                        //Decode the received data into distance and save
		                                if (i<384)
                                                        laserdistance[i] = 480+random(40)+(i/3);  // mm??
		                                else
                                                        laserdistance[i] = 500+(i/3);  // mm??
                                        }  // for
		                        laserdistance[149]=laserdistance[149]-50;  // mm
		                        laserdistance[150]=laserdistance[150]-50;  // mm
			                laserdistance[151]=laserdistance[151]-50;  // mm
			                laserdistance[152]=laserdistance[152]-50;  // mm
			                laserdistance[153]=laserdistance[153]-50;  // mm
			                laserdistance[381]=laserdistance[381]-50;  // mm
			                laserdistance[382]=laserdistance[382]-50;  // mm
			                laserdistance[383]=laserdistance[383]-50;  // mm
			                laserdistance[384]=laserdistance[384]-50;  // mm
			                laserdistance[385]=laserdistance[385]-50;  // mm
		                        laserdistance[386]=laserdistance[386]-50;  // mm
		                        laserdistance[387]=laserdistance[387]-50;  // mm
                                } // end if spirale
                                else { // if not a spirale
                                        for(int i=0;i<769;i++) {     // from map
		 	                        laserdistance[i] = MapRadii[i];
                                        }  // for
                                }
                        } // end if simulation
                        else {  // if not simulation
	                        int first = laser2->degree_to_step(-120);	// max +/- 120 deg    //44
	                        int last = laser2->degree_to_step(120);                                // 724
	                        long* data = new long [last - first + 1];
                        	if (laser2->get_data(data, first, last) < 0) {
		                        Form1->MControl->Lines->Add("Unable to get data from laser # " + AnsiString(laser2->urg_serial));
		                        delete [] data;
		                        laser2->urg_disconnect();
		                        delete laser2;
                                        laser2 = NULL;
                                        bSImulationLaser2->Color=clLime;
		                        return;
	                        }	// exit here if unable to get data from laser
                                int inc = 0;
                                memcpy(laserdistance+44, data, sizeof(long)*(last-first+1));
	                        delete [] data;
                                 for (int k= first; k<=last; k++)    //*** 009.06.25
                                if (laserdistance[k] < 19)
                                  laserdistance[k] = 9999;

                        } // end if  simulation
//                extern void MarkLaserDistancesOnMap(int AngularStepSize ) ; // in radii, with interpolation
//                if (fMap->PTrace->Color==clLime)   //ProxS
//                        MarkLaserDistancesOnMap(5); // marquer chaque 10 rayons
      } // end of  if  (CSESensorNum==2)
//---
    }// end of   if (!WsWStopLaser)
 } // end of if (!ModeNewLaser)
}  // end  AcquireDistancesWithLaser
//---------------------------------------------------------------------------
float  AngleCameraCibleRadians()
{ float a, d, dy, FactPixelARadians;
  extern int incry;
  int HauteurMatPixellr;
    //        MilieuLignellr;    MilieuLigneL
  HauteurMatPixellr=MilieuLigneL-30;
  FactPixelARadians=(float)AngleMiresCentreBas/(incry*HauteurMatPixellr)/180*3.1416;
    // environ 50 degrés (1.2 m à 1 m) pour 15 ligne  à lr
    // caméra -------O
    //          \    I
    //             \ I     1.2 m de hauteur
    //               O

  // d=DistanceCameraCibleCM(size_2m, size_50cm, size_measure);
  a=-FactPixelARadians*bx;
  return a;

} // fin AngleCameraCibleRadians
//---------------------------------------------------------------------------
void  ApproAGN(location &P, float d) ///* iSv, Position librement définie */
{
        PAux.x=P.x-d*cos(P.phi/180*3.1416);
    PAux.y=P.y-d*sin(P.phi/180*3.1416);
    PAux.phi=round(P.phi);
    MoveAGN(PAux);
}
//---------------------------------------------------------------------------
void  ApproToolAGN(location &P, float d) ///* iSv, Position librement définie */
{
	PAux.x=P.x-d*cos(P.phi/180*3.1416);
    PAux.y=P.y-d*sin(P.phi/180*3.1416);
    PAux.phi=round(P.phi);
    MoveToolAGN(PAux);
}
//---------------------------------------------------------------------------
float AIOIn(int NS)
  {
   return SignauxIn[NSignauxBoolIn+NS].valeur;
  }
//---------------------------------------------------------------------------
void AIOOutAGN(int NS, float val)
  {
 //******  SignauxOut[NSignauxBoolOut+NS].valeur =val;
   GoNext();
   return ;
  }
//---------------------------------------------------------------------------
void AllerEnXYAGN(float x, float y) ///* iSv, Position librement définie */
     {
      uPPTemp=P0Robot;
      uPPTemp.x=x;      uPPTemp.y=y;
      P0RobotFutur=uPPTemp; ///* pour affichage de la consigne */
      LancerMouvement(XY, uPPTemp);
      CallIP(1350);
     }
//---------------------------------------------------------------------------
void AllumerMoteurBasSolAGN()
  {
 //  SignauxOut[NSOMoteurBasCiel].EtatVF =false;
  // SignalOutAGN(NSOMoteurBasSol, true) ;
   return ;
  }
//---------------------------------------------------------------------------
void AllumerMoteurBasCielAGN()
  {
 //  SignauxOut[NSOMoteurBasCiel].EtatVF =true;
   //(NSOMoteurBasSol, false) ;
   return ;
  }
//---------------------------------------------------------------------------
void AllumerMoteurEntreeCielAGN()
  {
 //  SignauxOut[NSOMoteurEntreeCiel].EtatVF =true;
 //  SignalOutAGN(NSOMoteurEntreeSol, false) ;
   return ;
  }
//---------------------------------------------------------------------------
void AllumerMoteurEntreeSolAGN()
  {
  // SignauxOut[NSOMoteurEntreeCiel].EtatVF =false;
 //  SignalOutAGN(NSOMoteurEntreeSol, true) ;
   return ;
  }
//---------------------------------------------------------------------------
//---------------------------------------------------------------------------
void AllumerMoteurHautCielAGN()
  {
 //  SignauxOut[NSOMoteurHautDirectionSol].EtatVF =false;
   //(NSOMoteurHautOn, true) ;
   return ;
  }
//---------------------------------------------------------------------------
void AllumerMoteurHautSolAGN()
  {
 //  SignauxOut[NSOMoteurHautDirectionSol].EtatVF =true;
//   SignalOutAGN(NSOMoteurHautOn, true) ;
   return ;
  }
//---------------------------------------------------------------------------
void AllumerMoteurMilieuCielAGN()
  {
 //  SignauxOut[NSOMoteurMilieuCiel].EtatVF =true;
  // SignalOutAGN(NSOMoteurMilieuSol, false) ;
   return ;
  }
//---------------------------------------------------------------------------
void AllumerMoteurMilieuSolAGN()
  {
  // SignauxOut[NSOMoteurMilieuCiel].EtatVF =false;
  // SignalOutAGN(NSOMoteurMilieuSol, true) ;
   return ;
  }
//---------------------------------------------------------------------------
void  AnalyserColonneAGN( pNoColonne,pStartLigne, pStopLigne)
                // met à jour NRouge, XRouge, NVert, etc.
{    ModeImage=mNull;
     MettreAJourChoixModeImage();
     ACNoColonne=pNoColonne;
     ACStartLigne=pStartLigne;
     ACStopLigne=pStopLigne;
     CallIP(1120);
     return;
};

//---------------------------------------------------------------------------
void  AnalyserLigneAGN( pNoLigne,pStartColonne, pStopColonne)
                // met à jour NRouge, XRouge, NVert, etc.
{    ModeImage=mNull;
     MettreAJourChoixModeImage();
     ALNoLigne=pNoLigne;
     ALStartColonne=pStartColonne;
     ALStopColonne=pStopColonne;
     CallIP(1020);
     return;
};  // AnalyserLigneAGN
//---------------------------------------------------------------------------
float AngleEntreM180etP180(float A)
 { while (A>180) A-=360;
  while (A<-180) {A+=360;}
  return A;
}; //      AngleEntreM180etP180
//---------------------------------------------------------------------------
void ApprocherDUnPasAGN(location L1, int pLongueurPasCm, bool &pPointAtteint)
{   int d;

  d=DistanceEntreLocations(Here(),L1);
  pPointAtteint= d<pLongueurPasCm ;
  if (!pPointAtteint)
   ApproAGN(Trans(L1.x,L1.y,DirectionButDegres(L1.x,L1.y)), d-pLongueurPasCm);
  else
   MoveAGN(L1);
  }   // fin ApprocheDUnPasAGN
//---------------------------------------------------------------------------
void ArreterActionDoigtAGN()
   {
          if( Work[NTGererDoigt].TaskStatus==EnAction)
           {Work[NTGererDoigt].TaskStatus=Faite;
            GoNext();
            }
   }

//---------------------------------------------------------------------------
// fonction d'arrondi
int Arrondir(float f){
        int entier = int(f);
        float diff = (f - entier);
        if( fabs(diff) < 0.5)
                return entier;
        else
                return (f>0) ? entier + 1 : entier - 1;
}

//---------------------------------------------------------------------------
void AttendreFinGestionBallesAGN ()
 {
     if (Work[NTGererBalle].TaskStatus == Faite)
        GoNext();
   return ;
  }
//---------------------------------------------------------------------------
void AttendreFinMouvement()
 {
      if (Work[NTMouvementSpat].TaskStatus==Faite)
   return ;
  }
//---------------------------------------------------------------------------
void AttendreFinMouvementAGN ()
 {
      if (Work[NTMouvementSpat].TaskStatus==Faite)
        GoNext();
   return ;
  }
//---------------------------------------------------------------------------
 void AvancerAGN(tCm distance)
     {
       uPPTemp.ds=distance;
       P0RobotFutur=uPPTemp; ///* pour affichage de la consigne */
       LancerMouvement(MDMds, uPPTemp);
       CallIP(1350);
     }
//---------------------------------------------------------------------------
void AvancerADroiteAGN(tCm RayonTrajectoire, tDegres AngleTrajectoire)
    // /* cm et degres */
     {
       VirerAGN(RayonTrajectoire, -AngleTrajectoire);  /* cm et degres */
     }          /* y c. gosub */
//---------------------------------------------------------------------------
 void AvancerAGaucheAGN(tCm RayonTrajectoire, tDegres AngleTrajectoire)
     /* cm et degres */
     {
       VirerAGN(-RayonTrajectoire, AngleTrajectoire);  /* cm et degres */
     }           /* y c. gosub */
//---------------------------------------------------------------------------
void CalibrateFrom2Points(location LP1, location LP2, int L1/*cm*/, int L2/*cm*/, location &LHere)
 { //  LP1        L3          LP2     -> alpha
   //       A1            A2
   //       L1             L2
   //              A3
   //              LHere
  int x1, y1, x2, y2, x, y, alpha, a1,a2,a3;
  int L3;
  bool test=false;
  float  pi=3.1416, temp;
                                       // test values
  x1=LP1.x;
  if (test) x1=100;  // cm
  y1=LP1.y;
  if (test) y1=500;

  x2=LP2.x;
  if (test) x2=300;
  y2=LP2.y;
  if (test) y2=500;
  L3=sqrt( (x2-x1)*(x2-x1)+(y2-y1)*(y2-y1)); // 200
  if (fabs(x2-x1)>0.001)
    alpha=atan((y2-y1)/(x2-x1));
    else
     if ((x2-x1)*(y2-y1)<0) alpha=-90;
        else alpha=90;                       // 0
  if (test)
   { L1=224;   //cm
     L2=224;
   }
   if (abs(L2*L3)>0)
  temp= (float)(L1*L1-(L2*L2+L3*L3))/(-2*L2*L3);
    else temp=10000;       //****  
  a2=acos(temp) *180 /pi;     // 63.43
  LHere.x=x2+L2*(cos((alpha+180+a2)*pi/180));   //  2
  LHere.y=y2+L2*(sin((alpha+180+a2)*pi/180));   //  3
  LHere.phi=alpha+a2;  // 63.43
 }
//---------------------------------------------------------------------------
void CallAGN (int StateNoSub)
 { GoSubAGN (StateNoSub);
   return;
 }
//---------------------------------------------------------------------------
//---------------------------------------------------------------------------
void CallIP(int const StateNoSub) // /* appelle l'interpréteur Piaget */
  {
    Work[NTStrategie].TaskStatus=Suspendue;
      if (Work[NTInterpreteurPiaget].IndicePile<TaillePile)
       {
        Work[NTInterpreteurPiaget].IndicePile++;
        Work[NTInterpreteurPiaget].Pile[
          Work[NTInterpreteurPiaget].IndicePile]=
           Work[NTStrategie].StateNo;
        Work[NTInterpreteurPiaget].StateNo=  StateNoSub;
        Work[NTInterpreteurPiaget].TaskStatus=EnAction;
      }
     else
     {
     MessageLu=" uPiaget - CallIP - Pile trop pleine, niveau= " ;
            /*  , IntToStr( Work[NTInterpreteurPiaget].IndicePile) */
      }
      return;
 }
//---------------------------------------------------------------------------
 void DecomposeAGN(location P, float  &X,float &Y,float &phi)
   {
     X=P.x;
     Y=P.y;
     phi=P.phi;
     GoNext();
  }//  DecomposeAGN
//---------------------------------------------------------------------------
void DefineSearchEnveloppeAGN(/*int *LaserSearchEnveloppeCM[769],*/ int pLeftSearchMargin, int pFrontSearchMargin,
              int pRightSearchMargin)
 {float fALeft,fARight,fEnvelopeAngleDegreeTmp, SinTmp, CosTmp ;
     fALeft=atan2(pLeftSearchMargin, pFrontSearchMargin)/M_PI*180;
     fARight=-atan2(pRightSearchMargin, pFrontSearchMargin)/M_PI*180;
      for (int i=0;i<NLaserDistances+1;i++)
          { LaserSearchEnveloppeCM[i]=400;  // max possible value
            fEnvelopeAngleDegreeTmp=(i-iLaserCenter) * i2aLaser;
            SinTmp=sin(fEnvelopeAngleDegreeTmp/180*M_PI);
            CosTmp=cos(fEnvelopeAngleDegreeTmp/180*M_PI);
            if (fEnvelopeAngleDegreeTmp>fALeft)
              LaserSearchEnveloppeCM[i]=pLeftSearchMargin/SinTmp;
            else if (fEnvelopeAngleDegreeTmp>fARight)
              LaserSearchEnveloppeCM[i]=pFrontSearchMargin/CosTmp;
            else if (fEnvelopeAngleDegreeTmp<fARight)
              LaserSearchEnveloppeCM[i]=-pRightSearchMargin/SinTmp;
// pour contrôle:
        //    laserdistance[i]=LaserSearchEnveloppeCM[i];
          //    Radii[i]=LaserSearchEnveloppeCM[i];
            } // end for

        GoNext();
} // DefineSearchEnveloppeAGN
//---------------------------------------------------------------------------
   bool  DemandeDeDemarrage()    /* iS et IP */
  {
    return SignalActifEtVrai(NSIDemarrage);
  }
//---------------------------------------------------------------------------
void DemarrerMatchAGN()
 { //extern int SecondesPasseesRel;
   SecondesPasseesRel=0;
   PhaseMatch=EnMatch;
   GoNext();
   return;
 }
//---------------------------------------------------------------------------
void  DeployerBrasAGN()
  {
    SignalOutAGN(10, true) ;
    return ;
  }
//---------------------------------------------------------------------------
void DisplayLaserDistances()
{ int z;
z=Form1->cseZoom->Value;
fmRadar->cseZoomH->Value=z;
//fmRadar->cseZoom->Value=120;
fmRadar->Visible=true;
fmRadar->Button4Click(NULL);  //

} // end  DisplayLaserDistances

//---------------------------------------------------------------------------
tCm Distance(location &P0P) // en Cm, entre robot et point P0P
{ tCm resultat;
 resultat=sqrt((P0P.x-P0Robot.x)*(P0P.x-P0Robot.x)
              +(P0P.y-P0Robot.y)*(P0P.y-P0Robot.y));
 return resultat;
 } // Distance
//---------------------------------------------------------------------------
int DistanceUSHautGaucheCM ()
{ int resultat ;
    resultat=SignauxIn[NSignauxBoolIn+1].valeur;
return resultat;
 } // DistanceUSGaucheCM
//---------------------------------------------------------------------------
float DistanceCameraCibleCM(int size_2m, int size_50cm, int size_measure)
{  int DistanceMin=20, DistanceMax=250; // cm
	float a=0., b=0., y=0., difference;

    if(size_2m && size_50cm)
    {
        difference= (size_50cm-size_2m);
     	if (difference>0) a = 1.5/(size_50cm-size_2m);
           else a=1.5;
        b = a*size_50cm+0.5;
    }

    y =100*( a * size_measure + b);
    if (y<DistanceMin) y=DistanceMin;
    if (y>DistanceMax)y=DistanceMax;

    return(y);
}
//---------------------------------------------------------------------------
int DistanceEntreLocations(location L1, location L2)
{   int d;
  d=sqrt((L1.x-L2.x)*(L1.x-L2.x)+(L1.y-L2.y)*(L1.y-L2.y));
  return(d);
}   // fin DistanceEntreLocations
//---------------------------------------------------------------------------
void  EnvoyerCommandeAuBeckhoff(int CMD)
  {

/*  CMDBeckhoffTransparent,    Définition dans uPanneau
    CMDPrendreBalle1DuSol,
    CMDPrendreBalle2DuSol,
    CMDPrendreBalle3DuSol,
    CMDPrendreBalle1DuCiel,
    CMDPrendreBalle2DuCiel,
    CMDPrendreBalle3DuCiel;    */

    CommandeBeckhoff=CMD;
     return ;
  }

//---------------------------------------------------------------------------
//---------------------------------------------------------------------------
void  EnvoyerCommandeAuBeckhoffAGN(int CMD)
  {
        EnvoyerCommandeAuBeckhoff(CMD);
        GoNext();
        return ;
  }
//---------------------------------------------------------------------------


void EstimerPositionGuideParLaser(float &x, float &y,float &Myangletrouve/*=NULL*/,
        float angleinf/*=-120*/, float anglesup/*=120*/, float ecartmax/*=20*/, int minvals/*=0*/ )
  { location  LRobotCibleTmp, L0CibleTmp;
    tPoint2DPlus P;
    int PRobotLaserX=-21, PRobotLaserY=0;  // top: -21cm  low: +23cm
    float RMin;
     // we assume that laser data are periodically acquired elsewhere (task15?)
        RMin=GetLaserMindist(&Myangletrouve,angleinf,
                anglesup, ecartmax, minvals);
    LRobotCibleTmp.x=PRobotLaserX+RMin*cos(DegresARadians(Myangletrouve));  //
    LRobotCibleTmp.y=PRobotLaserY+RMin*sin(DegresARadians(Myangletrouve));
    LRobotCibleTmp.phi=Myangletrouve; // mieux: corriger en fonction de l'offset...

    L0CibleTmp=PasserDeLocationRobotALocationTerrain(LRobotCibleTmp);
    P0CibleLaser=LocationToPoint(L0CibleTmp);
    x=P0CibleLaser.x;
    y=P0CibleLaser.y;
    return ;
  }


//---------------------------------------------------------------------------
void EstimerPositionObstacleParCapteurUS(float &x, float &y)
  { location  LRobotCibleTmp, L0CibleTmp;
    tPoint2DPlus P;
    LRobotCibleTmp.x=SignauxIn[NSignauxBoolIn+1].valeur;  // RAH: Capteur US Haut Milieu
    LRobotCibleTmp.y=0;
    LRobotCibleTmp.phi=0;

    L0CibleTmp=PasserDeLocationRobotALocationTerrain(LRobotCibleTmp);
    P0CibleUS=LocationToPoint(L0CibleTmp);
    x=P0CibleUS.x;
    y=P0CibleUS.y;
    return ;
  }
//---------------------------------------------------------------------------
void EstimerPositionObstacleParVisionRAH(float &x, float &y)
  { location  LRobotCibleTmp, L0CibleTmp;
    tPoint2DPlus P;
    float DistTempCM;
    DistTempCM=DistanceCameraCibleCM(size_calibre_2m,size_calibre_50cm,
                    pix_count);
    LRobotCibleTmp.x=(float)DistTempCM*cos(AngleCameraCibleRadians());
    LRobotCibleTmp.y=DistTempCM*sin(AngleCameraCibleRadians());
 //   LRobotCibleTmp.y=0;
    LRobotCibleTmp.phi=0;

    L0CibleTmp=PasserDeLocationRobotALocationTerrain(LRobotCibleTmp);
    P0CibleVisionRAH=LocationToPoint(L0CibleTmp);
    x=P0CibleVisionRAH.x;
    y=P0CibleVisionRAH.y;
    return ;
  }
//---------------------------------------------------------------------------
void EteindreMoteurEntreeAGN()
  {
  // SignauxOut[NSOMoteurEntreeCiel].EtatVF =false;
  // SignalOutAGN(NSOMoteurEntreeSol, false) ;
   return ;
  }
//---------------------------------------------------------------------------
void EteindreMoteurHautAGN()
  {
 //  SignauxOut[NSOMoteurHautDirectionSol].EtatVF =false;
//   SignalOutAGN(NSOMoteurHautOn, false) ;
   return ;
  }
//---------------------------------------------------------------------------
void EteindreMoteurMilieuAGN()
  {
 //  SignauxOut[NSOMoteurMilieuCiel].EtatVF =false;
 //  SignalOutAGN(NSOMoteurMilieuSol, false) ;
   return ;
  }

//---------------------------------------------------------------------------
void  FermerEntreeAGN()
  {
    SignalOutAGN(12, false) ;
    return ;
  }


//---------------------------------------------------------------------------

void FreeFivecoShoulderAGN()
{
    if (Choix[NCShoulder].Etat && !Choix[NCSimulation].Etat)
        CallIP(2430);
     else
       GoNext();
     return;
}



//Donne la valeur de la distance la plus proche détectée dans l'arc délimité
//par angleinf et anglesup, compris entre -120° et +120°. Angletrouve est l'angle
//pour lequel le minimum est détecté. Ecartmax symbolise l'écart max autorisé de distance
//en % entre la plus petite distance mesurée et la minvals-ième plus petite valeur
//pour considérer la mesure comme fiable.
//Retourne -1 en cas d'erreur
//Voir /readme/plan laser.txt

float GetLaserMindist(float *angletrouve/*=NULL*/,float angleinf/*=-120*/, float anglesup/*=120*/, float ecartmax/*=20*/, int minvals/*=0*/){
const float i2a=0.3515625;
int imin, imax;
float minval[50],angles[50],absmin=1E10;
bool valid=false;


if(angleinf==-120)
imin=angleinf/i2a+387;
else
imin=angleinf/i2a+384;

imax=anglesup/i2a+384;


(minvals<=48)?minvals:48;
for(int i=0;i<50;i++) minval[i]=1E10; absmin=1E10;
if(imin<0||imax>768) return -1;

        //Classement des distances minimales et angles correspondants
for(int i=imin;i<=imax;i++)
        {
        for(int j=minvals;j>=0;j--)
                if(laserdistance[i]<minval[j])
                        {
                        minval[j+1]=minval[j]; minval[j]=laserdistance[i];
                        angles[j+1]=angles[j]; angles[j]=(i-384)*i2a;
                        }
        if(laserdistance[i]<absmin)
                {
                absmin=laserdistance[i];
                if(angletrouve!=NULL) *angletrouve=(i-384)*i2a;
                }
        }

if(minvals==1) return absmin/10.0;
//Sélection de la première valeur valide
imin=0;
while(!valid)
        {
        if(minval[minvals]-minval[imin]<minval[imin]/100.0*ecartmax) valid=true;
        imin++;
        if(imin>minvals) return -1;
        }
imin--;
return minval[imin]/10.0;
}
//---------------------------------------------------------------------------
float GetLaserMindistReversed(float *angletrouve/*=NULL*/,
  float anglesup/*=120*/,float angleinf/*=-120*/, float ecartmax/*=20*/, int minvals/*=0*/)
                     //reverse order
{ float a, d;
  d=round(GetLaserMindist( &a,-angleinf,  -anglesup, ecartmax, minvals) );
  *angletrouve=-a;
  return d;
  }
//---------------------------------------------------------------------------

//Donne la valeur de la distance la plus proche détectée dans l'arc délimité
//par angleinf et anglesup, compris entre -120° et +120°. Angletrouve est l'angle
//pour lequel le minimum est détecté. Ecartmax symbolise l'écart max autorisé de distance
//en % entre la plus petite distance mesurée et la minvals-ième plus petite valeur
//pour considérer la mesure comme fiable.
//Retourne -1 en cas d'erreur
//Voir /readme/plan laser.txt
int GetMedianDistance(int ind, int length)
        {
         //    filtrage médian

    int i, indice, VTemp,
    SampleTemp[9], SampleIndex[9], LengthMax=9,
    LongueurMedian, DemiLongueurMedian, RMin;
    bool Change;
        if (length<=LengthMax)
                LongueurMedian=length;
                else
                LongueurMedian=LengthMax;

        DemiLongueurMedian=LongueurMedian/2;
        for (i=0; i<LongueurMedian; i++)   // début
         { indice=ind-DemiLongueurMedian+i;
         if (indice<0) indice=0;
         if (indice>NLaserDistances) indice=NLaserDistances;
         SampleTemp[i]=laserdistance[indice];
         SampleIndex[i]=indice;
         } // end for
         Change=true;
         while (Change)
          {Change=false;
          for (i=1; i<LongueurMedian; i++)   // début
           {
            if (SampleTemp[i]< SampleTemp[i-1])
             { VTemp= SampleTemp[i];
               SampleTemp[i]= SampleTemp[i-1];
               SampleTemp[i-1]= VTemp;
  /*             VTemp= SampleIndex[i];
               SampleIndex[i]= SampleIndex[i-1];
               SampleIndex[i-1]= VTemp;  */
               Change=true;
             } // end if
           } // end for
           } // end while


        RMin=SampleTemp[DemiLongueurMedian];
        return RMin;

        }  // end  GetMedianDistance

float GetLaserDistFromLine(float *angletrouve/*=NULL*/,float angleinf/*=-120*/,
        float anglesup/*=120*/, float ecartmax/*=20*/, int minvals/*=1*/)
{

const float i2a=0.3515625;
int imin, imax;
float minval[50],angles[50],absmin=1E10, AngleLaser, Angle, L,
        RAMin,RAMax, ARMin,ARMax, A3AMin, MinDistCM;
bool valid=false;

imin=angleinf/i2a+384;

 //    filtrage médian
RAMin= GetMedianDistance(imin, 7); // median out of 7 neighbours
// laserdistance[imin];
//RAMin=SampleTemp[DemiLongueurMedian];


imax=anglesup/i2a+384;

// RAMax=laserdistance[imax];
RAMax= GetMedianDistance(imax, 7); // median out of 7 neighbours

AngleLaser=(anglesup-angleinf);

//         I
//         IARMin\  RMin , angleinf
//         I   A3AMin\
//         I  ---------- O        AngleLaser=anglesup-angleinf
//      L  I          /
//         I      /
//         I /    RMax , anglesup

// L2=RAMin2+RAMax2-2RAMinRAMaxCos(AngleLaser)
L=sqrt(RAMin*RAMin+RAMax*RAMax-2*RAMin*RAMax*cos(AngleLaser/180*3.14159));
//  RAMax2=L2+RAMin2-2L*RAMinCos(ARMin)
ARMin=acos((L*L+RAMin*RAMin-RAMax*RAMax)/(2*L*RAMin))/3.14159*180;

A3AMin= 180-90-ARMin;

MinDistCM=RAMin*cos(A3AMin/180*3.14159)/10; //cm

*angletrouve=angleinf+A3AMin;

return MinDistCM;
}

 location Here()    // cf V+:  HERE   (sans parenthèses dans V+)
  { location temp;
    temp.x=P0Robot.x;
    temp.y=P0Robot.y;
    temp.phi=P0Robot.ThetaRobotDegres;
    return temp;
  }
//-----------------------------------------------------------------------
 void Initialiser()
  {
 //   CameraDisponible=false;
//    BlocBeckhoffDisponible=false;
//    BlocBeckhoffDisponible=true;
 //   CommandeGalilDisponible =true;
 //   CommandeGalilDisponible =false;
void  InitialiserFiveCoShoulderAGN()
{     AngleArmOffVertical= AngleInit; //degres
    if (Choix[NCShoulder].Etat && !Choix[NCSimulation].Etat)
        CallIP(2530);
     else
       GoNext();
     return;
}
//---------------------------------------------------------------------------
void  InitialiserFiveCoHandAGN()
{
    if (Choix[NCHand].Etat && !Choix[NCSimulation].Etat)
     CallIP(2560);
     else
       GoNext();
     return;
}
//---------------------------------------------------------------------------
void InitLaser()
    { 
      fmRadar->Edit1->Text=ComPortLaser;        // added 008.07.12 JDZ

       if (!Choix[NCSimulation].Etat)
         //    fmRadar->Button1->OnClick(NULL);
             Form1->btInitComLaserClick(Form1) ;

InitialiserLaser=true;                          // added 008.07.12 JDZ
        Form1->btLaserScan->Enabled=true;                       // added 008.07.12 JDZ
        fmRadar->cseZoomH->Value=Form1->cseZoom->Value;

     }  // end  InitLaser
     //---------------------------------------------------------------------------
void LancerActionDoigtAGN()
   {
          if( Work[NTGererDoigt].TaskStatus==Faite)
           {Work[NTGererDoigt].TaskStatus=Demandee;
            GoNext();
            }
   }

//---------------------------------------------------------------------------
void LancerGestionBallesAGN(int pCMD)
 {
     if (Work[NTGererBalle].TaskStatus == Faite)
      {
        CMDBalle=pCMD;
        EnvoyerCommandeAuBeckhoff(CMDBalle);
        Work[NTGererBalle].TaskStatus = Demandee;
        GoNext();
      }
   return ;
  }
//---------------------------------------------------------------------------
void LireErreurGalilBack(long &pErreurGauche, long &pErreurDroite)
{
         //ATD
        char*   ptr = NULL;
        EnvoyerCommandeGalilBackAvecReponse("TEAB;", uPMessage) ;
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
//---------------------------------------------------------------------------
void LireErreurGalilFront(long &pErreurGauche, long &pErreurDroite)
{
         //ATD
        char*   ptr = NULL;
        EnvoyerCommandeGalilFrontAvecReponse("TEAB;", uPMessage) ;
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
//---------------------------------------------------------------------------
void LireErreurGalilTwoWheels(long &pErreurGauche, long &pErreurDroite)
{
         //ATD
        char*   ptr = NULL;
        EnvoyerCommandeGalilTwoWheelsAvecReponse("TEAB;", uPMessage) ;
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
//---------------------------------------------------------------------------
void LireErreurGalil(long &pErreurGauche, long &pErreurDroite)
{ long errd,errg;
  int FactSenseOPY= -1; // inversion de signe...
    if (ModeRHYorOPYlow)
          LireErreurGalilTwoWheels(pErreurGauche, pErreurDroite) ;
      else
      {
          LireErreurGalilBack(pErreurGauche, pErreurDroite);
          LireErreurGalilFront(errg, errd);
          pErreurGauche+= errg;
          pErreurDroite+= errd;
          pErreurGauche*=FactSenseOPY;
          pErreurDroite*=FactSenseOPY;
      }
}   // LireErreurGalil
//---------------------------------------------------------------------------

void LirePositionGalil(long &pThetaGauche, long &pThetaDroit)
  {
   EnvoyerCommandeGalilAvecReponse("TPAB;", uPMessage) ;  // Tell Position A et B
 //   uPMessage=" 101,  102\r";
    uPiPos=AnsiPos(",",uPMessage);

    if( uPiPos )
    {
        uPss=uPMessage.SubString(1, uPiPos-1);
        pThetaGauche=StrToInt(uPss);

        uPiPos2=AnsiPos("\r",uPMessage);
        if( uPiPos2 )
        {
                uPss=uPMessage.SubString(uPiPos+1, uPiPos2-uPiPos-1);
                pThetaDroit=StrToInt(uPss);
        }
    }

    return;
  }   // fin void LirePositionGalil
//---------------------------------------------------------------------------
//---------------------------------------------------------------------------
void  LocaliserBaliseAGN()
{
extern int ColonneBalise, LigneBalise;
          ModeImage=mBaliseMagenta;
          LocaliserObjetAGN();
        return;
};
//---------------------------------------------------------------------------
//---------------------------------------------------------------------------
void  LocaliserBalleAGN()
{
 extern int  ColonneBalle, LigneBalle;
          ModeImage=mRouge;
          LocaliserObjetAGN();
        return;
};
//---------------------------------------------------------------------------
void  LocaliserCocotierAGN()
{
          ModeImage=mVert;
          LocaliserObjetAGN();
        return;
};
//---------------------------------------------------------------------------
void  LocaliserObjetAGN()
{
        MettreAJourChoixModeImage();
        CallIP(1000);
        return;
};
//---------------------------------------------------------------------------
  tMatriceTransf LocationAMatrice( location &L)
{  tMatriceTransf M;
   tPoint2DPlus pt;
 //  PointToLocation(tPoint2DPlus &pP)
    pt.x=L.x;
    pt.y=L.y;
    pt.ThetaRobotDegres=L.phi;
    PointAMatrice( pt, M);
  //  void PointAMatrice(tPoint2DPlus &pt, tMatriceTransf &M);
 //void InverserM( tMatriceTransf &m, tMatriceTransf &MInv);
// void MultiplierM(tMatriceTransf &m1, tMatriceTransf &m2,  tMatriceTransf &M);
// void MatriceAPoint( tMatriceTransf &m, tPoint2DPlus &pt);
   return (M);
};
//---------------------------------------------------------------------------
  location MatriceALocation(tMatriceTransf &M)
{  location L;
   tPoint2DPlus pt;
     MatriceAPoint( M, pt);
     L=PointToLocation(pt);
//void PointAMatrice(tPoint2DPlus &pt, tMatriceTransf &M);
//void InverserM( tMatriceTransf &m, tMatriceTransf &MInv);
//void MultiplierM(tMatriceTransf &m1, tMatriceTransf &m2,  tMatriceTransf &M);
//void MatriceAPoint( tMatriceTransf &m, tPoint2DPlus &pt);
        return (L);
};
//---------------------------------------------------------------------------
void  MettreAJourChoixModeImage() // /*  */
     {
Choix[NCmNull].Etat=ModeImage==mNull;
Choix[NCmRouge].Etat=ModeImage==mRouge;
Choix[NCmVert].Etat=ModeImage==mVert;
Choix[NCmBlanc].Etat=ModeImage==mBlanc;
Choix[NCmNoir].Etat=ModeImage==mNoir;
Choix[NCmIntensite].Etat=ModeImage==mIntensite;
Choix[NCmSaturation].Etat=ModeImage==mSaturation;
Choix[NCmTeinte].Etat=ModeImage==mTeinte;

}
//---------------------------------------------------------------------------
extern float DistanceVS;

void MettreAJourDistanceVirtuelle(/*int xmap,int ymap,*/int xm,int ym,float *Capteur, bool reset, /*TColor*/byte col)
{
float disttmp;
if(reset) {*Capteur=1E10; return;}
if(xm<0||ym<0||xm>MapGridWidthCm||ym>MapGridHeightCm)
        return;
disttmp=sqrt(pow(xm-P0Robot.x,2)+pow(ym-P0Robot.y,2));
//if(disttmp<Capteur&&Form1->ImageCarte->Canvas->Pixels[xmap][ymap]!=col) Capteur=int(disttmp);
if(disttmp<*Capteur&&MapGrid[xm][MapGridHeightCm-ym]!=col) *Capteur=int(disttmp);
}
//---------------------------------------------------------------------------
bool MouvementFini()
 {  bool b;
      b=(Work[NTMouvementSpat].TaskStatus==Faite);
   return(b) ;
  }

//---------------------------------------------------------------------------
bool MouvementGalilFait()
{ bool b ;
  int pSwitchesG, pSwitchesD;
         //ATD
        char*   ptr = NULL;
        EnvoyerCommandeGalilAvecReponse("TSAB;", uPMessage) ;
        // Tell Switches A et B
        uPiPos=AnsiPos(",",uPMessage);

        //ATD
        if( ptr = strstr( uPMessage.c_str(), "\r" ) )
                 { *ptr = '\0';    }
        uPss=uPMessage.SubString(1, uPiPos-1);
        pSwitchesG=StrToIntDef(uPss,0);
        uPss=uPMessage.SubString(uPiPos+1, uPMessage.Length()-uPiPos);
        pSwitchesD=StrToIntDef(uPss,1);
        if( Choix[NCSimulation].Etat )
        {
                pSwitchesG   = 2;
                pSwitchesD   = 3;
        }
    //    Bit 7 Axis in motion if high
    //    Bit 6 Error limit exceeded if high
    //    Bit 5 Motor off if high
    //    Bit 4 Undefined
    //    Bit 3 Forward Limit inactive if high
    //    Bit 2 Reverse Limit inactive if high
    //    Bit 1 State of home switch
    //    Bit 0 Latch not armed if high
    //    Note: The value for bits 1, 2 and 3 depend on the limit switch and home switch configuration
    //    (see CN command). For active low configuration (default), these bits are ‘1’ when the switch
    //    is inactive and ‘0’ when active. For active high configuration, these bits are ‘0’ when the
    //    switch is inactive and ‘1’ when active.
    //    ARGUMENTS: TS xx where
    //    x is X or Y or both, an argument is only required by the DMC-1425

        b=((pSwitchesG<128) && (pSwitchesD<128));
        return(b);
}   // MouvementGalilFait
//---------------------------------------------------------------------------
//---------------------------------------------------------------------------
 void  MoveAGN(location &P) // /* iSv, Position librement d‚finie */
     {
      if (CP)
       { if (NextSegmentKnown)
             ;  // rien à faire
         else
         {if (MouvementFini)
           {
            P0RobotFutur.x=P.x;
            P0RobotFutur.y=P.y;
            AngleMove=round(P.phi);
            tModeDeMouvement MDM=XY;
            LancerMouvement(MDM, P0RobotFutur);
            CallIP(1360);
            }   // fin MouvementFini
           else
             ;  // rien à faire


        }    //   not NextSegmentKnown





         {  NextSegmentKnown=true;
            P0RobotFutur2.x=P.x;
            P0RobotFutur2.y=P.y;
            AngleMove2=round(P.phi);

        if (MouvementFini)
        {
         P0RobotFutur.x=P.x;
         P0RobotFutur.y=P.y;
         AngleMove=round(P.phi);
         tModeDeMouvement MDM=XY;
         LancerMouvement(MDM, P0RobotFutur);
         CallIP(1360);
         } //   not NextSegmentKnown
        } // MouvementFini
      }  // CP
      else
      {
      P0RobotFutur.x=P.x;
      P0RobotFutur.y=P.y;
      AngleMove=round(P.phi);
      tModeDeMouvement MDM=XY;
      LancerMouvement(MDM, P0RobotFutur);
      CallIP(1360);
      } // fin not CP

      return ;
     }
//---------------------------------------------------------------------------
//---------------------------------------------------------------------------
 void MoveAheadAGN(tCm distance)
     {
       uPPTemp.ds=distance;
       P0RobotFutur=uPPTemp; ///* pour affichage de la consigne */
       LancerMouvement(MDMds, uPPTemp);
       CallIP(1350);
     }
//---------------------------------------------------------------------------
void  MoveFiveCoShoulderAGN( int pConsigne)

{
        uPConsigneFiveCoShoulder = round(pConsigne*IncrPerDegree);   // conversion degree - increment

        if (Choix[NCShoulder].Etat && !Choix[NCSimulation].Etat)
                CallIP(2450);
        else
                GoNext();
        return;
}
//---------------------------------------------------------------------------
void  MoveFiveCoHandAGN( int pConsigne)

{
     uPConsigneFiveCoHand=pConsigne;
    if (Choix[NCHand].Etat && !Choix[NCSimulation].Etat)
        CallIP(2510);
     else
       GoNext();
     return;
}
//---------------------------------------------------------------------------
 void  MoveToolAGN(location &P) // /* iSv, Position librement définie */
     {
      P0RobotFutur.x=P.x;
      P0RobotFutur.y=P.y;
      P0RobotFutur.ThetaRobotDegres=P.phi;

      P0Tool=P0RobotFutur;

      MapTargetToAxle();

      PAux.x=P0MA.x;
      PAux.y=P0MA.y;
      PAux.phi=P0MA.ThetaRobotDegres;
      MoveAGN(PAux);
      return ;
     }
//---------------------------------------------------------------------------
 void  MoveToolToXYAGN(location &P) // /* iSv, Position librement définie */
     {
      P0RobotFutur.x=P.x;
      P0RobotFutur.y=P.y;
      P0RobotFutur.ThetaRobotDegres=P.phi;

      P0Tool=P0RobotFutur;

      MapTargetToAxle();

      PAux.x=P0MA.x;
      PAux.y=P0MA.y;
      PAux.phi=P0MA.ThetaRobotDegres;
      MoveToXYAGN(PAux);
      return ;
     }
//---------------------------------------------------------------------------
void MoveToAngleAGN(tDegres phi) // /* iSv, Position librement d‚finie */
     {
        TournerSurPlaceAGN(phi-Here().phi);
     }
//---------------------------------------------------------------------------
void MoveToXYAGN(location &P) //* iSv, Position librement définie */
     {
        AllerEnXYAGN( P.x,  P.y);
     }
//---------------------------------------------------------------------------
void MoveToWPXYAGN(WayPoint &P) ///* iSv, Position librement définie */
     {
        AllerEnXYAGN( P.x,  P.y);
     }
//---------------------------------------------------------------------------
void ObserverColonneAGN(int ALNoColonne,int ALStartLigne, int ALStopLigne)
                // met à jour NRouge, XRouge, NVert, etc.
{
    AnalyserColonneAGN( ALNoColonne,ALStartLigne, ALStopLigne);
     return;
};
//---------------------------------------------------------------------------
void ObserverLigneAGN(int ALNoLigne,int ALStartColonne, int ALStopColonne)
                // met à jour NRouge, XRouge, NVert, etc.
{   AnalyserLigneAGN( ALNoLigne,ALStartColonne, ALStopColonne);
     return;
};
//---------------------------------------------------------------------------
void  OuvrirEntreeAGN()
  {
    SignalOutAGN(12, true) ;
    return ;
  }
//---------------------------------------------------------------------------
location PasserDeLocationRobotALocationTerrain(location &pLR) // /*  */
//location PasserDeLocationTerrainALocationRobot(location &pLT) // /*  */
 {  location L;
    tPoint2DPlus PR , PL;
    tMatriceTransf MT, MT0R, MTRO, MT0O;
// T 0 Objet =T O Robot *  T Robot Objet

// T Robot Objet =inv(T O Robot) *  T 0 Objet

// T 0 Objet =T O Robot *  T Robot Caméra *
//                     T Caméra Objet
//  mais d'abord, il faut passer de l'image au repère caméra

        MTRO=LocationAMatrice(pLR);

        PointAMatrice(P0Robot, MT0R);

        MultiplierM(MT0R, MTRO, MT);

        L=MatriceALocation(MT);

        return(L);
}  // PasserDeLocationRobotALocationTerrain
//---------------------------------------------------------------------------
location PasserDeLocationTerrainALocationRobot(location &pLT) // /*  */
 //

 {  location L;
    tMatriceTransf MT, MTInv, MT0R, MT0O;

// T Robot Objet =inv(T O Robot) *  T 0 Objet

        MT0O=LocationAMatrice(pLT);

        PointAMatrice(P0Robot,MT0R);

        InverserM(MT0R, MTInv);

        MultiplierM(MTInv, MT0O, MT);

        L=MatriceALocation(MT);

        return(L);
}   // PasserDeLocationTerrainALocationRobot
//---------------------------------------------------------------------------
location PasserDeLocationRobotPolaireALocationImage
                (int r, float ThDeg, int &Row, int &Column) // /*  */
 //    T E M P - non testé

 {  location L;
    tMatriceTransf MT, MTInv, MT0R, MT0O;

  //*****  CmAPixel(PCameraTemp.x,
  //**** a restituer                    PCameraTemp.y,pColonne, pLigne);

// T Robot Objet =inv(T O Robot) *  T 0 Objet

   /*     MT0O=LocationAMatrice(pLT);

        PointAMatrice(P0Robot,MT0R);

        InverserM(MT0R, MTInv);

        MultiplierM(MTInv, MT0O, MT);

        L=MatriceALocation(MT);   */

        return(L);
}   // end of PasserDeLocationRobotPolaireALocationImage
//---------------------------------------------------------------------------
void PasserDeXYCameraALocationTerrain(int pXCamera, int pYCamera,location &pL0Temp) // /*  */
 {  tPoint2DPlus P0TempI , PCameraTemp;
    tMatriceTransf MT, TCameraTemp;
// T 0 Objet =T O Robot *  T Robot Caméra *
//                     T Caméra Objet
//  mais d'abord, il faut passer de l'image au repère caméra

        PCameraTemp.x=pXCamera;
        PCameraTemp.y=pYCamera;
        PCameraTemp.ThetaRobotDegres=0;

        PointAMatrice(PCameraTemp, TCameraTemp);

        PointAMatrice(PRobotCamera, TRobotCamera);

        PointAMatrice(P0Robot, T0Robot);

        MultiplierM(T0Robot, TRobotCamera, MT);
        MultiplierM(MT, TCameraTemp, MT);

        MatriceAPoint(MT, P0TempI);

        pL0Temp=PointToLocation(P0TempI);

        return;
}
//---------------------------------------------------------------------------
void PasserDeLImageAuTerrain(int pColonne, int pLigne,tPoint2DPlus &pP0Temp) // /*  */
 {
// T 0 Objet =T O Robot *  T Robot Caméra *
//                     T Caméra Objet
//  mais d'abord, il faut passer de l'image au repère caméra
        tMatriceTransf MT;

        PixelACm(pColonne, pLigne, PCameraTemp.x,
                                        PCameraTemp.y);
        PCameraTemp.ThetaRobotDegres=0;
        PointAMatrice(PCameraTemp, TCameraTemp);

        PointAMatrice(PRobotCamera, TRobotCamera);

        PointAMatrice(P0Robot, T0Robot);

        MultiplierM(T0Robot, TRobotCamera, MT);
        MultiplierM(MT, TCameraTemp, MT);

        MatriceAPoint(MT, pP0Temp);

        return;
}
//---------------------------------------------------------------------------
//---------------------------------------------------------------------------
tPoint2DPlus  LocationToPoint(location &pL)
  { tPoint2DPlus P;
    P.x=pL.x ;
    P.y=pL.y ;
    P.ThetaRobotDegres=pL.phi ;
    return(P) ;
  }
//---------------------------------------------------------------------------
//---------------------------------------------------------------------------
location  PointToLocation(tPoint2DPlus &pP)
//tPoint2DPlus  LocationToPoint(location &pL)
  { location L;
    L.x=pP.x ;
    L.y=pP.y ;
    L.phi=pP.ThetaRobotDegres ;
    return(L) ;
  }
//---------------------------------------------------------------------------
void PrendreUneImageAGN()

{        CallIP(1150);
     return;
};
//---------------------------------------------------------------------------
void ObjectCheckT()
{  PrendreUneImageAGN();
   

}
//---------------------------------------------------------------------------
void  RentrerBrasAGN()
  {
    SignalOutAGN(10, false) ;
    return ;
  }
//---------------------------------------------------------------------------
void  RentrerDoigtAGN()
  {
    SignalOutAGN(11, false) ;
    return ;
  }
 //---------------------------------------------------------------------------
 void  ResetGalilAGN() // /*     */
     {
      ResetGalil();
      CallIP(1200); // attente éventuelle (à tester) et initialisation
      return ;
     }
//---------------------------------------------------------------------------
void ReturnFromSub()
 {
  {
    if (Work[ActiveTask].IndicePile>0)
      {
       Work[ActiveTask].IndicePile--;
       GoState(Work[ActiveTask].Pile[Work[ActiveTask].IndicePile+1]+1);
      }
     else
     {
     MessageLu=" uPiaget - ReturnFromSub - Pile trop vide, niveau= "+
              IntToStr( Work[NTInterpreteurPiaget].IndicePile);
      }
//       writeln('                    Tƒche active: ', ActiveTask);
  }
 }
 //---------------------------------------------------------------------------
void ReturnFromIP()
{
int i;

     if (Work[NTInterpreteurPiaget].IndicePile>0)
      {
       Work[NTInterpreteurPiaget].IndicePile--;
       i=(Work[NTInterpreteurPiaget].Pile[
           Work[NTInterpreteurPiaget].IndicePile+1]+1);
       Work[NTInterpreteurPiaget].TaskStatus=Faite;
      }
     else
     {
     MessageLu=" uPiaget - CallIP - Pile trop vide, niveau= "+
              IntToStr( Work[NTInterpreteurPiaget].IndicePile);
      }
    Work[NTStrategie].StateNo=i;
    Work[NTStrategie].TaskStatus=EnAction;
    Work[NTInterpreteurPiaget].StateNo=1;
    Work[NTInterpreteurPiaget].TaskStatus=Faite;

      return ;
     }
//---------------------------------------------------------------------------
void SayString(AnsiString t)
{
   if(!Mute)
   {
   Form1->ApdSapiEngine1->Speak(t.c_str());
   FrmT2S->String2File(t.c_str());
   }
} // end of SayString
//---------------------------------------------------------------------------
void SayStringAndWait(AnsiString t)
{
   if(!Mute)
   {
   Form1->ApdSapiEngine1->Speak(t.c_str());
   FrmT2S->String2File(t.c_str());
   CallIP(2600);
   }
} // end of SayStringAndWait
//---------------------------------------------------------------------------
 void SearchEnveloppeAGN( int pLeftSearchMargin,int pFrontSearchMargin,int pRightSearchMargin,         //cm
        float pSearchAngleMin,float pSearchAngleMax,
           bool &pObjectFound, int &pObstDistMin,
           float &pObstAngleMin, int &pObstWidthCm,
           int &pObstMeasuredMarginLeftCm,
            int &pObstMeasuredMarginRightCm ,
            int &pObstMeasuredMarginFrontCm   )
{
//  Searches, using Enveloppe, SearchAngleMin and SearchAngleMax, Result:
//     -  free   (no obstacle)
//    or
//     -  obstacle
//           ObstDistMin,
//           ObstAngleMin,
//           ObstWidth (at +10cm),
//           ObstMeasuredMarginLeft,
//           ObstMeasuredMarginRight.

/*
float EnvelopeAngleDegreeTmp, SinTmp, CosTmp;
float SearchAngleMin, SearchAngleMax,
           ObstAngleMin;
int      ObstDistMin,
         ObstWidth, // (at +10cm),
         ObstMeasuredMarginLeft,
         ObstMeasuredMarginRight;
*/
int iSearchIndexMin, iSearchIndexMax, iObstIndexMin,
        iTmp, iObstWidthIndex, iObstMeasuredMarginLeftIndex,
        iObstMeasuredMarginRightIndex;
float aTmp, SinTmp, CosTmp, ObsAngleMin;

     iSearchIndexMin=pSearchAngleMin/i2aLaser+iLaserCenter;
     iSearchIndexMax=pSearchAngleMax/i2aLaser+iLaserCenter;
     pObjectFound=false;
     pObstDistMin=400; //cm
     for (int i=iSearchIndexMin;i<iSearchIndexMax+1;i++)
          // obstacle within envelope?
          { if (laserdistance[i]/10<LaserSearchEnveloppeCM[i])
            {pObjectFound=true;
            // min smaller?
             if (pObstDistMin>LaserSearchEnveloppeCM[i])
              {pObstDistMin=LaserSearchEnveloppeCM[i];
               iObstIndexMin=i;
              } // end if min smaller
             } // end if smaller  dist
            } // end for
      if (pObjectFound)
        {   // estimation of width
        iObstWidthIndex=1;
        iTmp=iObstIndexMin;
        // width and margin on left
        while (((laserdistance[iTmp+1]/10-pObstDistMin)<10)  // cm
                 && (iTmp<=iSearchIndexMax))
         {iTmp++;
          iObstWidthIndex++;
         }
//      ObstMeasuredMarginLeftIndex=iTmp-SearchIndexMin; // angular margin
        iObstMeasuredMarginLeftIndex=iTmp; // index for end of left margin
        aTmp=(iTmp-iLaserCenter) * i2aLaser;
        SinTmp=sin(aTmp/180*M_PI);
        pObstMeasuredMarginLeftCm=pLeftSearchMargin-pObstDistMin*SinTmp;

        // width and margin on right
        iTmp=iObstIndexMin;
        while (((laserdistance[iTmp-1]/10-pObstDistMin)<10)  // cm
                 && (iTmp>=iSearchIndexMin))
         {iTmp--;
          iObstWidthIndex--;
         }
//      ObstMeasuredMarginRightIndex=SearchIndexMax-iTmp; // angular margin
        iObstMeasuredMarginRightIndex=iTmp; // index for end of right margin
        aTmp=(iTmp-iLaserCenter) * i2aLaser;
        SinTmp=sin(aTmp/180*M_PI);
        pObstMeasuredMarginRightCm=pRightSearchMargin+pObstDistMin*SinTmp;

        pObstAngleMin=(iObstIndexMin-iLaserCenter) * i2aLaser;
        CosTmp=cos(pObstAngleMin/180*M_PI);
        pObstMeasuredMarginFrontCm=pObstDistMin*CosTmp;

        pObstWidthCm=pRightSearchMargin-pObstMeasuredMarginRightCm
             +pLeftSearchMargin-pObstMeasuredMarginLeftCm;
        }   // end ObjectFound


        GoNext();
  } // end of SearchEnveloppe
//---------------------------------------------------------------------------
 void SetAGN(location &P, location &Exp) // cf. V+:  Set P=expression;
  {
    P=Exp;
    GoNext();
    return ;
  }
//---------------------------------------------------------------------------
 void SetEyeModeBatteryMode() //
  {
 ModeEyes=BatteryMode;
  }
//---------------------------------------------------------------------------
 void SetEyeModeBothEyesBlinking() //
  {
 ModeEyes=BothEyesBlinking;
 LeftEyeOffTime=0.2;
 LeftEyeOnTime=0.2;
  }
//---------------------------------------------------------------------------
 void SetEyeModeEyesInverse() //
  {
 ModeEyes=EyesInverse;
 LeftEyeOffTime=0.5;
 LeftEyeOnTime=0.5;
  }
//---------------------------------------------------------------------------
 void SetEyeModeLeftBlinking() //
  {
 ModeEyes=LeftEyeBlinking;
 LeftEyeOffTime=0.2;
 LeftEyeOnTime=0.2;
  }
//---------------------------------------------------------------------------
 void SetEyeModeNormal() //
  {
 ModeEyes=NormalMode;
 LeftEyeOffTime=0.5;
 LeftEyeOnTime=0.5;
  }
//---------------------------------------------------------------------------
 void SetEyeModeRightBlinking() //
  {
 ModeEyes=RightEyeBlinking;
 RightEyeOffTime=0.2;
 RightEyeOnTime=0.2;
  }
//---------------------------------------------------------------------------
 void SetEyeModeUserMode() //
  {
 ModeEyes=UserMode;
  }
  /*   enum {NormalMode, EyesInverse,EyesAsynchrous,UserMode, RightEyeBlinking,
   LeftEyeBlinking, BothEyesBlinking, BatteryMode, EmotionMode}  tModeEyes;
tModeEyes ModeEyes;
float LeftEyeOnTime=0.5, LeftEyeOffTime=0.5, EyeDutyCycleMin=0.2,EyeDutyCycleMax=2 , // 0.2 .. 2 s
      RightEyeOnTime=0.5,  RightEyeOffTime=0.5;  */

//---------------------------------------------------------------------------
 void SetEyeModeWithDutyCycle(float ton, float toff) //
  {
 ModeEyes=NormalMode;
 LeftEyeOffTime=toff;
 LeftEyeOnTime=ton;
  }

//---------------------------------------------------------------------------
/* void SetHereAGN()    // Remplacé par Here()
  {
    Here.x=P0Robot.x;
    Here.y=P0Robot.y;
    Here.phi=P0Robot.ThetaRobotDegres;
    GoNext();
     return ;
  }  */
//---------------------------------------------------------------------------
 void SetPositionRobotAGN(int const x, int y, int ThetaRobotDegres)
              // (re)définit la position nominale courante du robot
   {
        P0Robot.x=x;
        P0Robot.y=y;
        P0Robot.ThetaRobotDegres=ThetaRobotDegres;
        GoNext();
        return ;
  }
//---------------------------------------------------------------------------
 void SetToolAGN(float x, float y, float phi)
  {
     Tool.x=x;
     Tool.y=y;
     Tool.phi=phi;
     GoNext();
  }
//---------------------------------------------------------------------------
  void SetTransfAGN(float const x, float y, float phi)
   {
     Transf.x=x;
     Transf.y=y;
     Transf.phi=phi;
     GoNext();
     return ;
   }
//---------------------------------------------------------------------------
bool SignalActifEtVrai(int NS)
  {
   return ( SignauxIn[NS].actif && SignauxIn[NS].EtatVF);
  }
//---------------------------------------------------------------------------
bool SignalIn(int NS)
  {
   return SignauxIn[NS].EtatVF;
  }
//---------------------------------------------------------------------------
void SignalOut(int NS, bool etat)
  {
   SignauxOut[NS].EtatVF =etat;
   DemandeRefreshSortie = true ;
   return ;
  }
//---------------------------------------------------------------------------
//---------------------------------------------------------------------------
void SignalOutAGN(int NS, bool etat)
  {
   SignauxOut[NS].EtatVF =etat;
   DemandeRefreshSortie = true ;
   GoNext();
   return ;
  }
//---------------------------------------------------------------------------
//---------------------------------------------------------------------------
void  SortirDoigtAGN()
  {
    SignalOutAGN(11, true) ;
    return ;
  }
void TournerSurPlaceAGN(tDegres Angle)          /* iS+iIP */
     {
       P0RobotFutur.ThetaRobotDegres=P0Robot.ThetaRobotDegres+Angle ;
       LancerMouvement(Rot, P0RobotFutur);
       CallIP(1350);
     }
//---------------------------------------------------------------------------
 location Trans(float const x, float y, float phi)
   { location temp;
     temp.x=x;
     temp.y=y;
     temp.phi=phi;
     return temp;
   }
//---------------------------------------------------------------------------
 void TurnEyesOff() //
  {
 ModeEyes=UserMode;
 SignalOut(NSOLEDFonctionnement, false);
 SignalOut(2, false);
  }
//---------------------------------------------------------------------------
 void TurnEyesOn() //
  {
 ModeEyes=UserMode;
 SignalOut(NSOLEDFonctionnement, true);
 SignalOut(2, true);
  }
//---------------------------------------------------------------------------
void  TurnStatusDiodeGreen()
  {
     SignalOutAGN(5,false); // diode red off!
     SignalOutAGN(7,true); // diode green on!
   return ;
  }
//---------------------------------------------------------------------------
void  TurnStatusDiodeGreenAGN()
  {
   TurnStatusDiodeGreen();
   GoNext();
   return ;
  }
//---------------------------------------------------------------------------
void  TurnStatusDiodeGreenAndRed()
  {
     SignalOutAGN(5,true); // diode red on!
     SignalOutAGN(7,true); // diode green on!
   return ;
  }
//---------------------------------------------------------------------------
void  TurnStatusDiodeGreenAndRedAGN()
  {
     TurnStatusDiodeGreenAndRed();
    GoNext();
   return ;
  }
//---------------------------------------------------------------------------
void  TurnStatusDiodeRed()
  {
     SignalOutAGN(5,true); // diode red on!
     SignalOutAGN(7,false); // diode green off!
   return ;
  }
//---------------------------------------------------------------------------
void  TurnStatusDiodeRedAGN()
  {
        TurnStatusDiodeRed() ;
   GoNext();
   return ;
  }
//---------------------------------------------------------------------------
void  TurnStatusDiodeOff()
  {
     SignalOutAGN(5,false); // diode red off!
     SignalOutAGN(7,false); // diode green off!
   return ;
  }
//---------------------------------------------------------------------------
void  TurnStatusDiodeOffAGN()
  {
        TurnStatusDiodeOff();
   GoNext();
   return ;
  }
//---------------------------------------------------------------------------
void  TypeAnsiStringAGN(AnsiString A)
  {
//  Work[ActiveTask].StateNo++;

   MessageUser=A;
   Form1->MUser->Lines->Text= A;
   GoNext();
   return ;
  }
//---------------------------------------------------------------------------
void  TypeIntegerAGN(int I)
  {
//  Work[ActiveTask].StateNo++;

   MessageUser=AnsiString(IntToStr(I));
   Form1->MUser->Lines->Text= MessageUser;
   GoNext();
   return ;
  }
//---------------------------------------------------------------------------
void  TypeRealAGN(float R)
  {
//  Work[ActiveTask].StateNo++;

   MessageUser=AnsiString(FloatToStr(R));
   Form1->MUser->Lines->Text= MessageUser;
   GoNext();
   return ;
  }
//---------------------------------------------------------------------------
//void  TypeStringAGN(AnsiString T)
void  TypeStringAGN(char* T)
  {
//  Work[ActiveTask].StateNo++;

   MessageUser=AnsiString(T);
//   MessageUser=T;
   Form1->MUser->Lines->Text= T;
   GoNext();
   return ;
  }
//---------------------------------------------------------------------------
  void VirerAGN(tCm RayonTrajectoire, tDegres AngleTrajectoire) // /* cm et degres */
     {
       uPPTemp.RayonTrajectoire=RayonTrajectoire;
       uPPTemp.AngleTrajectoire=AngleTrajectoire;
       P0RobotFutur=uPPTemp; ///* pour affichage de la consigne */
       LancerMouvement(RotExc, uPPTemp);
       CallIP(1350);
     }
//---------------------------------------------------------------------------
void ViserLocationAGN(location L1)
{  int DAngle;
   DAngle=DirectionButDegres(L1.x,L1.y)-Here().phi;
   Form1->Edit2->Text = DAngle;
   // Déballer angle???
  TournerSurPlaceAGN(DAngle);
}   // fin ViserLocationAGN
//------------------VK & VS Function------------------------------------------

void BackLocationAGN(location L1)
{  int Myangle;
   //int Anglepass;
   //int negAnglepass;
    //    Anglepass=  DirectionButDegres(L1.x,L1.y);
     //   negAnglepass= 0-Anglepass;
     //   Myangle=Here().phi+negAnglepass;
  // int checkhere;
  // checkhere=Here().phi;
   //if(Here().phi>0)
  Myangle= DirectionButDegres(L1.x,L1.y)-Here().phi;//0-Here().phi-DirectionButDegres(L1.x,L1.y);
  if(Myangle>=360)
  Myangle-=360;
  else if(Myangle<=-360)
  Myangle+=360;

  Form1->Edit2->Text = Myangle;
   //else
  //-----------Myangle=180-Here().phi-2*DirectionButDegres(L1.x,L1.y);
  //-------------Form1->Edit2->Text = Myangle;
   // Déballer angle???
  TournerSurPlaceAGN(Myangle);
}   // fin BackLocationAGN

//---------------------------------------------------------------------------
void WaitAGN(int NSignalIn)
  {
    if (SignauxIn[NSignalIn].EtatVF)
    GoNext();
    return;
  }
//---------------------------------------------------------------------------
void WaitWhileSpeaking()
  {
    CallIP(2600);
    return;
  }
//---------------------------------------------------------------------------
void WaitWhileSpeakingAGN()
  {
    CallIP(2600);
    GoNext();
    return;
  }
//---------------------------------------------------------------------------
   // with timeout
void WaitWithTimeoutAGN(int NSignalIn, float pDureeMax)  // retour dans TimeOut
  {
    uPNSI=NSignalIn;
    uPDureeMax=pDureeMax;
    CallIP(2400);
    GoNext();
    return;
  }
//---------------------------------------------------------------------------
void CalibrationDistanceAGN() // Permet au robot de se calibrer d'après une
                              // réfèrence connue. S. Villoz 006.10.17
{
    static int DistanceAttendue = 200;  // centimètres

    DistCalibration1=GetLaserMindist(&AngleCalibration1,-5,-5); // -5°
    DistCalibration2=GetLaserMindist(&AngleCalibration2,0,0); // 0°
    DistCalibration3=GetLaserMindist(&AngleCalibration3,6,6); // 5°

    Sleep(100);

    if(P0Robot.ThetaRobotDegres==0)
    {
     if(DistCalibration2 <= 300)
     {
     DistanceCorrection = (int)DistanceAttendue - DistCalibration2;
     XRobotCorrige = P0Robot.x + DistanceCorrection;
     DistanceAttendue = DistCalibration2;
     SetPositionRobotAGN(XRobotCorrige,P0Robot.y,P0Robot.ThetaRobotDegres);
     }
    }
    if(P0Robot.ThetaRobotDegres==90)
    {
     if(DistCalibration2 <= 300)
     {
      DistanceCorrection = (int)DistanceAttendue - DistCalibration2;
      YRobotCorrige = P0Robot.y + DistanceCorrection;
      DistanceAttendue = DistCalibration2;
      SetPositionRobotAGN(P0Robot.x,YRobotCorrige,P0Robot.ThetaRobotDegres);
     }
    }
    if(P0Robot.ThetaRobotDegres==180)
    {
     if(DistCalibration2 <= 300)
     {
     DistanceCorrection = (int)DistanceAttendue - DistCalibration2;
     XRobotCorrige = P0Robot.x - DistanceCorrection;
     DistanceAttendue = DistCalibration2;
     SetPositionRobotAGN(XRobotCorrige,P0Robot.y,P0Robot.ThetaRobotDegres);
     }
    }
    if(P0Robot.ThetaRobotDegres==270)
    {
     if(DistCalibration2 <= 300)
     {
      DistanceCorrection = (int)DistanceAttendue - DistCalibration2;
      YRobotCorrige = P0Robot.y - DistanceCorrection;
      DistanceAttendue = DistCalibration2;
      SetPositionRobotAGN(P0Robot.x,YRobotCorrige,P0Robot.ThetaRobotDegres);
     }
    }
}

//---------------------------------------------------------------------------
void CalculateMap(/*byte MapG[MapGridWidthCm][MapGridHeightCm],*/ int EditFurnNumber,int TotalFurnNumber,int FurnShape,byte FurnType,int FurnLeft,int FurnTop,int FurnWidth,int FurnHeight,int FurnTilt)
{

const MapDimensionX = MapGridWidthCm; // Horizontal length of map in CMs                    //
const MapDimensionY = MapGridHeightCm; // Vertical length of map CMs                         //
                                                                                     //
/*
Code's Objective:       Function to Calculate Bit Pattern of Furniture on Map

Author:                 Pushkar Chandra Awasthi (IIT Kanpur)

Date Finished:          12th July, 2006
*/



///////////////////////////////////////////////////////////////////////////////////////
// Declaring BitMap Size and Creating the Bitmap Array                               //
// This Array could be passed by the Calling Function                                //
// and as we discussed earlier we could just call this function, only to calculate   //
// the Bit pattern of one Furniture each time an object is drawn                     //
///////////////////////////////////////////////////////////////////////////////////////
                     //
float PI = 3.1415926536;
                                                                                     //
/*byte MapGrid [MapDimensionX][MapDimensionY];
for (int i = 0; i < 1000; i++) {
      for (int j = 0; j < 1000; j++){
            MapGrid [i][j] = 0 ;
      }
}



int FurnShape = 1;         // 1 => Rectangle, 2 => Circle, 3 => Ellipse

int FurnType = 1;          //  0 => BlankSpace, 1 => Calibration Objects,
                           //  2 => Slightly Mobile objects, 3 => Highly Mobile objects,

int FurnLeft = 20;          // Left Position Coordinate of Furnitutre
                           //(Displacement in X - direction from coordinate (0,0) of Map)

int FurnTop = 30;          // Top Position Coordinate of Furnitutre
                           //(Displacement in Y - direction from coordinate (0,0) of Map)

int FurnWidth = 60;        //Furniture Width (The dimentions of the furniture in the
                           //X-direction (Without implimentation of the Tilt))

int FurnHeight = 40;       //Furniture Height (The dimentions of the furniture in the
                           //Y-direction (Without implimentation of the Tilt))

int FurnTilt = 90;          // Tilt of the Furnitutre : Defined as +ve angle (Degrees),
                           //Anticlockwise from X Axis
*/                                                                                                                                                                                       //

float Xo, Yo, a, b, calc, C, S, xp2, yp2, xp1, yp1, R, Y;
int xi, yi, x2, temp2;


      switch (FurnShape){
         case 1: // Furniture is a Rectangle

         Xo = (FurnLeft + (FurnWidth / 2));
         Yo = (FurnTop + (FurnHeight / 2));
         a = FurnWidth/2;
         b = FurnHeight/2;
         C = cos (FurnTilt*PI/180);
         S = sin (FurnTilt*PI/180);

         if ((FurnTilt == 90 )|| (FurnTilt == 270)){
         Xo = (FurnLeft + (FurnWidth / 2));
         Yo = (FurnTop + (FurnHeight / 2));
         temp2 = FurnHeight; FurnHeight = FurnWidth; FurnWidth = temp2;
         FurnLeft = Xo - FurnWidth/2;
         FurnTop = Yo - FurnHeight/2;
            for (int x = FurnLeft; x < (FurnLeft + FurnWidth); x++) {
               for (int y = FurnTop; y  < (FurnTop + FurnHeight); y++){
                  if (x >=0 && x <MapGridWidthCm && y >= 0 && y <MapGridHeightCm){
                     MapGrid [x][y] =  FurnType;
                  }
               }
            }


         }
            else if ((FurnTilt == 0) || (FurnTilt == 180) || (FurnTilt == 360)){
               for (int x = FurnLeft; x < (FurnLeft + FurnWidth); x++) {
                  for (int y = FurnTop; y  < (FurnTop + FurnHeight); y++){
                     if (x >=0 && x <MapGridWidthCm && y >= 0 && y <MapGridHeightCm){
                        MapGrid [x][y] =  FurnType;
                     }
                  }
               }
            }
               else {
                  for (float x =  0; x < MapGridWidthCm; x++){
                     for (float y = 0; y < MapGridHeightCm; y++){
                        xp1 = x - Xo;
                        yp1 = Yo - y;
                        xp2 = xp1*C + yp1*S;
                        yp2 = yp1*C - xp1*S;


                        if ((xp2 >= -a)&&(xp2 < a)&&(yp2 > -b)&&(yp2 <= b)){
                            xi = x; yi = y;
                            if (xi >=0 && xi <MapGridWidthCm && yi >= 0 && yi <MapGridHeightCm){
                               MapGrid [xi][yi] =  FurnType;
                            }
                        }
                     }
                  }
               }

         break;




         case 2:  // Furniture is a Circle
            Xo = (FurnLeft + (FurnWidth / 2));
            x2 = Xo - 1;
            Yo = (FurnTop + (FurnHeight / 2));

            if (FurnWidth < FurnHeight)
               R = FurnWidth / 2;
                  else
                     R = FurnHeight / 2;

            for (int x1 = Xo; x1 < (Xo + R); x1++) {

               Y = ceil(sqrt((R*R) - ((x1 - Xo)*(x1 - Xo)))+ Yo);

               for (int y1 = Yo; y1 < Y; y1++){
                  if (x1 >=0 && x1 <MapGridWidthCm && y1 >= 0 && y1 <MapGridHeightCm){
                     MapGrid [x1][y1] =  FurnType;
                  }
                  if (x2 >=0 && x2 <MapGridWidthCm && y1 >= 0 && y1 <MapGridHeightCm){
                     MapGrid [x2][y1] =  FurnType;
                  }
               }

                for (int y2 = Yo-1; y2 > (Yo-(Y-Yo)-1); y2--){
                   if (x1 >=0 && x1 <MapGridWidthCm && y2 >= 0 && y2 <MapGridHeightCm){
                      MapGrid [x1][y2] =  FurnType;
                   }
                   if (x2 >=0 && x2 <MapGridWidthCm && y2 >= 0 && y2 <MapGridHeightCm){
                      MapGrid [x2][y2] =  FurnType;
                   }
                }

                x2--;
            }
            break;

         case 3: // Furniture is a Ellipse

         Xo = (FurnLeft + (FurnWidth / 2));
         Yo = (FurnTop + (FurnHeight / 2));
         b = FurnHeight/2;
         a = FurnWidth/2;
         C = cos (FurnTilt*PI/180);
         S = sin (FurnTilt*PI/180);

         for (float x =  0; x < MapGridWidthCm; x ++){
            for (float y = 0; y < MapGridHeightCm; y++){
               xp1 = x - Xo;
               yp1 = Yo - y;
               xp2 = xp1*C + yp1*S;
               yp2 = yp1*C - xp1*S;
               calc = (((xp2)*(xp2))/(a*a)) + (((yp2)*(yp2))/(b*b)) -  1;
               if (calc < 0){
                  xi = x; yi = y;
                  if (xi>=0 && xi<MapGridWidthCm && yi >= 0 && yi <MapGridHeightCm){
                     MapGrid [xi][yi] =  FurnType;
                  }

               }
            }
         }
         break;




         default:
         break;
      } //End of Switch

} // End of CalculateMap
#pragma package(smart_init)
/*

unit uPiaget;  /*  copyright hesso.eivd.iai.jdz, 3.05.99 *
interface
uses uPanneau, uMouv7, uMTask4,/* uMulMx7C * uESGen, uCalTrns, graph;

/*  Liste des POSITIONS prédéfinies

      NPDemarrage, NPBouletDroiteDerriere, NPBouletDroiteDevant,
      NPBouletCentreDroit, NPBouletCentre,
      NPBouletCentreGauche, NPBouletGaucheDevant, NPBouletGaucheDerriere,
      NPDevantPontGauche, NPDerrierePontGauche,
      NPDevantPontDroit , NPDerrierePontDroit ,
      NPTourGGGauche, NPTourGGauche, NPTourGauche, NPTourCentrale,
      NPTourDroite, NPTourDDroite, NPTourDDDroite

                              :tIndicePosition;

*

implementation   /********************************
 void AccelererFreinerAGN(distanceAcc, distanceDec:tCm); /* iS, dsAcc, dsDec *
 var vtemp, atemp:single;          /* attention! modifie les facteurs acc‚l et d‚c‚l. *
 {
       uPPTemp.ds=distanceAcc+distanceDec;
       vtemp=VitesseMaxGlobale*FacteurVitesseMax;
       /* ads=vdv */
       /* as=v^2/2 */
       /* a=v*v/2/s *

       if distanceAcc<=0 then distanceAcc=1;
       atemp=Vtemp*vtemp/2/distanceAcc;
       FacteurAccelerationMax=atemp/AccelerationMaxGlobale;
       AccelerationMaxCourante=AccelerationMaxGlobale*FacteurAccelerationMax;

       if distanceDec<=0 then distanceDec=1;
       atemp=Vtemp*vtemp/2/distanceDec;
       FacteurDecelerationMax=atemp/AccelerationMaxGlobale; /* Decel=accel *
       DecelerationMaxCourante=AccelerationMaxGlobale*FacteurDecelerationMax;

 void LancerActiverFusees(NSo:tIndiceSignauxOut);
   {
          CommuterSortie(NSo, true);
          with SignauxOut[NSo] do
            Temporisateur=DelaiMax;
          with Work[NTActionFusees] do
             if TaskStatus=Faite then TaskStatus=Demandee;
/*          with Work[NTStrategie] do
             StateNo=StateNo+1; /*  GoNext *
   }
 void ActiverFuseeGaucheAGN;
     {
       LancerActiverFusees(xNSoActiverFuseeGauche);
       GoNext;
     }
 void ActiverFuseeDroiteAGN;
     {
       LancerActiverFusees(xNSoActiverFuseeDroite);
       GoNext;
     }
 void  AllerAuBordBlancNoirAGN;  /* iup (instr. unit‚ Piag.) v  *
     {
       CallIP(1010);
     }
 void  AllerAuBordNoirBlancAGN /* en particulier travers‚e  *;
     {
       CallIP(1110);
     }
 void  AllerEnAGN(P: tPoint2DPlus); /* iSv, Position librement d‚finie *
     {
      P0RobotFutur=P; /* pour affichage de la consigne *
      LancerMouvement(XY, P);
      CallIP(1350);
     }
  void  AllerEnPositionAGN(NP: tindicePosition); /* Position pr‚d‚finie *
     {
      AllerEnAGN(Position[NP].p);  /* y c. CallIP *
     }
 void ApprocherPaletAGN(NP: tindicePosition; marge:single); /* iSv, Position de l'Palet NP
                        /*ex AllerPercerBallonAGN, AllerPrendreBouletAGN *
  const
 /* Le point d'approche est … l'avant,
     cad 20cm de l'essieu moteur sur xrobot */
 /* position relative (frontale) de l'Palet *

   PRobotPointpourApprocheNominale: tPoint2DPlus=(x:29;y:0;
        ThetaRobotDegres:0;
       Ds:0; RayonTrajectoire: 0;
       AngleTrajectoire: 0);
   Controle=false;
  var
   PRobotPointpourApproche: tPoint2DPlus;
   P0Palet: tPoint2DPlus;
   T0Palet, TRP: tMatriceTransf;
    {

 /* Ici, la consigne doit se comprendre au centre de l'Palet et non */
 /* … l'endroit standard, au milieu de l'essieu moteur.            */
 /* Pour comprendre, faire un graphe. Travail en 3 pas.            *
      if controle then AfficherPoint(P0Robot);

 /* r‚ception de P0Palet, la position d'un Palet par rapport au terrain *
      P0Palet=Position[NP].P;

 /* l'orientation est dans l'axe Robot-Palet *
       Diff2DPlus(P0Robot, P0Palet, DPosition);
       if (DPosition.x<>0) or (DPosition.y<>0)
         then /* mvmnt non nul > calcul de l'orientation du robot *
          {
           P0Palet.ThetaRobotDegres=
              RadiansADegres(Atan24(DPosition.y,DPosition.x));
           P0Palet.ThetaRobotDegres=
			         DeballerDegres(P0Palet.ThetaRobotDegres);
          end
         else
           /* mouvement nul; maintien de l'orientation du robot *
           P0Palet.ThetaRobotDegres=P0Robot.ThetaRobotDegres;
      if controle then AfficherPoint(P0Palet);

 /* conversion de P0Palet en matrice  *
      PointAMatrice(P0Palet,T0Palet);
      if controle then  AfficherMTransf(T0Palet);
 /* Mise … jour de PRobotPointdApproche *
      PRobotPointpourApproche=PRobotPointpourApprocheNominale;
      PRobotPointpourApproche.x=PRobotPointpourApprocheNominale.x+marge;
 /* conversion de PRobotPointdApproche en matrice  *
      PointAMatrice(PRobotPointpourApproche,TRP);
      if controle then  AfficherMTransf(TRP);

 /* 0.--------T0Palet----->.Palet      */
 /*   \-T0R--->.R----TRP-->/                   */

 /* D'o— la consigne voulue: T0C=T0R : */

/*  T0Consigne=T0Palet:INV(TRP): */

 /* inversion de TRP... *
      InverserM(TRP, TTemp);
      if controle then  AfficherMTransf(TTemp);
 /* ...et produit       *
      MultiplierM(T0Palet,TTemp,T0C);
      if controle then  AfficherMTransf(T0C);

      MatriceAPoint(T0C,P0RobotFutur);
      if controle then  AfficherPoint(P0RobotFutur);
  /* pas de rotation inutile, maintien de l'orientation cam‚ra *
      P0RobotFutur.ThetaRobotDegres =P0Palet.ThetaRobotDegres;
      if controle then  AfficherPoint(P0RobotFutur);
 /*     P0RobotFutur.ThetaRobotDegres=0; /* n‚glig‚e en mode XYetCam *
      uPPTemp=P0RobotFutur;
      if controle then readln;

      CallIP(1000);
     }
 void ApprocherEtoileAGN(marge:single);
 Const DifferenceDiametre=0;  /* entre et ‚toile *
  {
   ApprocherPaletAGN(NPEtoile, marge+DifferenceDiametre);
  }
 void xAllumerPharesAGN;
  {
   CommuterSortie(xNSoAllumerPhares, true);
   GoNext;
  }     */
/*
 void xEteindrePharesAGN;
  {
   CommuterSortie(xNSoAllumerPhares, false);
   GoNext;
  }
 void  ApproAGN(P: location; d: real); /* iSv, Position librement d‚finie *
     {
      P0RobotFutur.x=P.x-d*cos(P.phi/180*3.1416);
      P0RobotFutur.y=P.y-d*sin(P.phi/180*3.1416);
      P0RobotFutur.thetaRobotDegres=round(P.phi);
      LancerMouvement(XY, P0RobotFutur);
      CallIP(1360);
     }
 void AttendreAGN(Duree:single);   /* s *
   {
       SleepAGN(5, duree);
   }
 void AttendreFinActionBouletsAGN;
  {           /* y c. avance de StateNo *
     if Work[NTActionFusees].TaskStatus=Faite then
          GoNext;
  }
 void AttendreFinMouvementAGN;
  {           /* y c. avance de StateNo *
     if Work[NTMouvementSpat].TaskStatus=Faite then
          GoNext;
  }

  void  AvancerRobotSurBordAGN(EtouOuL, CondFXGauche, CondFXDroite: boolean;
        DistanceMax: tCm; var DistanceParcourue:single; var Echec: boolean);
  {
    uPDistanceMax=DistanceMax; uPDistanceParcourue=0;
    uPEtOuOuL=EtOuOuL; uPCondFXGauche=CondFXGauche;
    uPCondFXDroite=CondFXDroite;
    CallIP(1500);
  }

 void  CalerSurLignesAGN; /* suit une ligne blanche et s'arrˆte sur une */
                               /* ligne blanche transverse *
     {
       CallIP(1110);
     }

 void CallIP(StateNoSub:Integer);   /* appelle l'interpr‚teur Piaget *
  {
    Work[NTStrategie].TaskStatus=Suspendue;
    With Work[NTInterpreteurPiaget] do
     {
      if IndicePile<TaillePile then
       {
        IndicePile=IndicePile+1;
        Pile[IndicePile]=Work[NTStrategie].StateNo;
        StateNo=  StateNoSub;
        TaskStatus=EnAction;
      end
     else
      {
       writeln(' uPiaget - CallIP - Pile trop pleine, niveau= ',IndicePile);
       readln;
      }
     } /* with *
  }
 void CentrerDoigtAGN;
     {
       CallIP(1410);
     }
 void ChangerPhaseAGN(NouvellePhase:tindicePhase);
 var j:integer;
  {
    for j=1 to NPhases do
      Phase[j].enService=(j=NouvellePhase);
    {AfficherStrategieSurDiodes;}
    GoNext;
  }
 void ChoisirLePontVisuellementAGN;
     {
       CallIP(1550);
     }
 Function  CroisementAtteint: boolean;    /* iS et IP *
  {
    CroisementAtteint=uPCroisementAtteint;
  }
 Function  DemandeDeCalageCamera: boolean;    /* iS et IP *
  {
    DemandeDeCalageCamera=SignalActifEtVrai(NSI6CaleCamera);
  }  */
  /*
 void  DescendreSabotAGN; /* Le robot est suppos‚ centr‚ et */
                            /* orient‚ vers gauche ou droite *
    {
      CallIP(1600);
     }

   void FixerVitesseMaxEnPourcent(int Valeur);
  {
   FacteurVitesseMax=Valeur/100;
   VitesseMaxCourante=FacteurVitesseMax*VitesseMaxGlobale;
  }

 void FixerAccelerationMaxEnPourcent(Valeur:integer);
  {
   FacteurAccelerationMax=Valeur/100;
   AccelerationMaxCourante=FacteurAccelerationMax*AccelerationMaxGlobale;
  }
 void FixerDecelerationMaxEnPourcent(Valeur:integer);
  {
   FacteurDecelerationMax=Valeur/100;
   DecelerationMaxCourante=FacteurDecelerationMax*AccelerationMaxGlobale;
  }
 void FrapperADroiteAGN;
     {
       ModeDeplacementDoigt=ADroite;
       Work[NTGestionDoigt].TaskStatus=Demandee;
       CallIP(1403);
     }
 void FrapperAGaucheAGN;
     {
       ModeDeplacementDoigt=AGauche;
       Work[NTGestionDoigt].TaskStatus=Demandee;
       CallIP(1403);
     }
 Function  EchoCapteurUSBasGauche: boolean;    /* iS et IP *
  {
    EchoCapteurUSBasGauche=SignalActifEtVrai(NSUSBasGauche);
  }
 Function  EchoCapteurUSHautGauche: boolean;    /* iS et IP *
  {
    EchoCapteurUSHautGauche=SignalActifEtVrai(NSUSHautGauche);
  }
 Function  EchoCapteurUSCentre: boolean;    /* iS et IP *
  {
    EchoCapteurUSCentre=SignalActifEtVrai(NSUSCentre);
  }
 Function  EchoCapteurUSBasDroite: boolean;    /* iS et IP *
  {
    EchoCapteurUSBasDroite=SignalActifEtVrai(NSUSBasDroite);
  }
 Function  EchoCapteurUSHautDroite: boolean;    /* iS et IP *
  {
    EchoCapteurUSHautDroite=SignalActifEtVrai(NSUSHautDroite);
  }

void FlasherPMIAGN(NoSortie, NFois: integer; TOn,TOff:single); /*  *
  {
   uPNoSortie=NoSortie;   /* strictement: NSo:tIndiceSignauxOut *
   uPNFois=NFois;
   uPTOn=TOn;
   uPTOff=TOff;
   CallIP(1300);
  }

void LancerLacherPMI(NSo:tIndiceSignauxOut);
   {
          CommuterSortie(NSo, true);
          with SignauxOut[NSo] do
            Temporisateur=DelaiMax;
          with Work[NTLacherPMI] do
             if TaskStatus=Faite then TaskStatus=Demandee;
   }
void LancerMonterPlateForme;
   {
          CommuterSortie(NSoMonterPlateForme, true);
          with SignauxOut[NSoMonterPlateForme] do
            Temporisateur=DelaiMax;
          with Work[NTMonterPlateForme] do
              TaskStatus=Demandee;
   }
void MonterPlateFormeAGN;  /*  *
  {
   LancerMonterPlateForme;
   GoNext;
  }
void LacherPMIDroiteAGN;  /*  *
  {
   FlasherPMIAGN(NSoLacherPMIDroite, 4 /* fois*,
        uPDemiImpulsion /* s On *,
        uPDemiImpulsion /* s *);
/*   LancerLacherPMI(NSoLacherPMIDroite);
   GoNext;  *
  }
void LacherPMIGaucheAGN;  /*  *
{
   FlasherPMIAGN(NSoLacherPMIGauche, 4 /* fois*,
        uPDemiImpulsion /* s On *,
        uPDemiImpulsion /* s *);
/*   LancerLacherPMI(NSoLacherPMIGauche);
   GoNext;  *
}
void DeclencherPMIEtoileAGN;  /*  *
{
   FlasherPMIAGN(NSoDeclencherPMIEtoile, 4 /* fois*,
        uPDemiImpulsion /* s On *,
        uPDemiImpulsion /* s *);
/*   LancerLacherPMI(NSoDeclencherPMIDroite);
   GoNext;  *
}
void DeclencherVentouseGaucheAGN;  /*  *
{
   FlasherPMIAGN(NSoLacherVentouseGauche, 1 /* fois*,
        0.4 /* s On *,
        0 /* s *);
}
void DeclencherVentouseDroiteAGN;  /*  *
{
   FlasherPMIAGN(NSoLacherVentouseDroite, 1 /* fois*,
        0.4 /* s On *,
        0 /* s *);
}

void LancerMouvementCompactAGN(MM: tModeDeMouvement; PF:tPoint2DPlus);
  {            /* y c. avance de StateNo *
          P0RobotFutur=PF; /* pour affichage de la consigne *
          uMouv7.LancerMouvement(MM, PF);
          GoNext;
  }
 void LocaliserBaliseVisuellementAGN;
     {
       CallIP(1580);
     }
 void  MoveAGN(P: location); /* iSv, Position librement d‚finie *
     {
      P0RobotFutur.x=P.x;
      P0RobotFutur.y=P.y;
      P0RobotFutur.thetaRobotDegres=round(P.phi);
      LancerMouvement(XY, P0RobotFutur);
      CallIP(1360);
     }
 void PrendrePaletAGN;
  {
   with Palet[1] do
     ForeColor=Forecolor-8;
   GoNext;
  }   */
 void PromptIntegerAGN(AnsiString MyText, int i)
      {
       extern bool PromptOn;
       PromptOn=true;
       AffichageType=MyText;
       CallIP(1370);
      }

 void ReculerADroiteAGN(tCm RayonTrajectoire, tDegres AngleTrajectoire)  ///* cm et degres */
     {
       VirerAGN(RayonTrajectoire, AngleTrajectoire); // /* cm et degres */
     }           // /* y c. gosub */
 void ReculerAGaucheAGN(tCm RayonTrajectoire, tDegres AngleTrajectoire) // /* cm et degres */
     {
       VirerAGN(-RayonTrajectoire, -AngleTrajectoire); // /* cm et degres */
     }           // /* y c. gosub */
 void ReculerAGN(tCm distance)
     {
       uPPTemp.ds=-distance;
       P0RobotFutur=uPPTemp; ///* pour affichage de la consigne */
       LancerMouvement(MDMds, uPPTemp);
       CallIP(1350);
     }
 /*
/* void  RejeterBouletAGN;
  {

      PriseOuRejet=RejetBoulet;
      CallIP(1005);

     }                *
void ReturnFromIP;
var i: integer;
 {
  with Work[NTInterpreteurPiaget] do {
    if IndicePile>0 then
      {
       IndicePile=IndicePile-1;
       i=(Pile[IndicePile+1]+1);
       TaskStatus=Faite;
      end
     else
      {
       writeln(' uPiaget - ReturnFromIP - Pile vide, , niveau= ',IndicePile);
       readln;
      }
    Work[NTStrategie].StateNo=i;
    Work[NTStrategie].TaskStatus=EnAction;
    Work[NTInterpreteurPiaget].StateNo=1;
    Work[NTInterpreteurPiaget].TaskStatus=Faite;
  }
 }
 */
 /*
 Function  SignalIn(NoIn: tIndiceSignalIn): boolean;    /* iS et IP *
  {
    SignalIn=SignalActifEtVrai(NoIn);
  }
 void SignalOutAGN(NoOut: tIndiceSignauxOut; etat: boolean);    /* iS et IP *
  {
    CommuterSortie(NoOut, etat);
    GoNext;
  }
 void SortirDoigtADroiteAGN;
     {
       ModeDeplacementDoigt=ADroite;
       Work[NTGestionDoigt].TaskStatus=Demandee;
       CallIP(1400);
     }
 void SortirDoigtAGaucheAGN;
     {
       ModeDeplacementDoigt=AGauche;
       Work[NTGestionDoigt].TaskStatus=Demandee;
       CallIP(1400);
     }
 void  TirerSurTourAGN(NoTour: tindicePosition);
  Const YTour=260; /* cm ;  … v‚rifier *
  var Angle0TourDegres: integer;
      XTour: single;
      PF: tPoint2DPlus;
  {
    PF=P0Robot;  /* "remplissage neutre pour affichage de la consigne *
    XTour=Position[NoTour].p.x; /* cm; … v‚rifier  *
    Angle0TourDegres=round(180*ATan24(YTour-P0Robot.y,XTour-P0Robot.x)/pi);
 /*   Writeln(' ***** ',Angle0TourDegres);     *
    PF.ThetaRobotDegres=Angle0TourDegres+90; /* angle canon *
  /*  P0RobotFutur=PF; /* pour affichage de la consigne *
    uMouv7.LancerMouvement(Rot, PF);
    CallIP(1200);
  }
 void  TournerCameraSurButeeAGN(AngleMax: tDegres;
                var AngleTourne:single; var Echec: boolean);
  {
    uPAngleMax=AngleMax; uPAngleTourne=0;
    CallIP(1450);
  }
 void  SuivreLigneADroiteAGN(DistanceMax: tCm) /* la ligne est … droite de la roue avant  *;
     {
       uPDistanceMax=DistanceMax; uPDistanceParcourue=0;
       uPFibreGauche=NSFDroite;
       uPFibreDroite=NSFXDroite;
       CallIP(2110); /*    *
     }
 void  SuivreLigneAGaucheAGN(DistanceMax: tCm) /* la ligne est … gauche de la roue avant  *;
     {
/*       uPDistanceMax=DistanceMax; uPDistanceParcourue=0;
       uPFibreGauche=NSFXGauche;
       uPFibreDroite=NSFGauche;
       CallIP(2110); /*    *
     }
 void  SuivreLigneAuCentreAGN(DistanceMax: tCm; FibreStop:tindiceSignalIn)
         /* la ligne est de part et d'autre de la roue avant  *;
     {
       uPDistanceMax=DistanceMax; uPDistanceParcourue=0;
       uPFibreGauche=NSFGauche;
       uPFibreDroite=NSFDroite;
       uPFibreStop= FibreStop;
       CallIP(2110); /*    *
     }
 void SuivreLigneAuCentre2AGN
      (DistanceMin,DistanceMax: tCm;
		 FibreActive, FibreStop:tindiceSignalIn)
                      /* la ligne est de part et d'autre de la roue avant  *;
     {
       uPDistanceMax=DistanceMax; uPDistanceParcourue=0;
       uPFibreActive=FibreActive;
   /*    uPFibreDroite=NSFDroite; *
       uPFibreStop= FibreStop;
       CallIP(2210); /*    *
     }
 void SuivreLigneVisuellementAGN(AngleLigne, K: single;
             LargeurLigneMax,  DistanceMax: tCm /*;
                  var CroisementAtteint:boolean*);
     {
       uPLargeurLigneMax=LargeurLigneMax;
 /*    uPDistanceMin, uPDistanceMax: tCm;
     uPCroisementAtteint: boolean;      *
       uPAngleLigne=AngleLigne;
       uPDistanceMax=DistanceMax;
       uPK=K;
       CallIP(2310); /*    *
     }  */
     /*
 void TypeIntegerAGN(i: integer);
      {
       Str(i, AffichageType);
       GoNext;
      }
 void TypeLocationAGN(l: location);
 var s: string;
      {
       Str(l.x:5:1, s);
       AffichageType=s;
       Str(l.y:5:1, s);
       AffichageType=AffichageType+s;
       Str(l.phi:5:1, s);
       AffichageType=AffichageType+s;
       GoNext;
      }
 void TypeRealAGN(r: real);
      {
       Str(r, AffichageType);
       GoNext;
      }
 void TypeStringAGN(s: string);
      {
       AffichageType=s;
       GoNext;
      }   */
     /*
 void ViserPositionAGN(P: tPoint2DPlus);
   /* ex.  AllerEnAGN(P: tPoint2DPlus); /* iSv, Position librement d‚finie *
     {
      P0RobotFutur=P; /* pour affichage de la consigne *
      LancerMouvement(RXY, P);
      CallIP(1350);
     }
 Function  VoieLibre: boolean;    /* iS et IP *
  {
    VoieLibre=not (SignalActifEtVrai(NSUSHautGauche)
    or  SignalActifEtVrai(NSUSCentre) or  SignalActifEtVrai(NSUSHautDroite));
  }

end.
*/


