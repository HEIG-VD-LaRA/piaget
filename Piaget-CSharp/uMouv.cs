using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Piaget_CSharp
{
    class uMouv
    {
public static uPanel.tPoint2DPlus P0Robot, P0Tool, P0MA, P0RobotFutur, P0RobotFutur2, P0RobotTemp;
public static uPanel.PlatformeP12Y P12Y;
public static float DxTemp, DyTemp, DThetaRobotDegresTemp, DsTemp, DAngleTemp,
 CDds, CDdTheta;
public static long CDMoyenne, CDDifference;
public static int TaillePileMouvement = 3, IndicePileMouvement;
public static uPanel.tMouvement[] PileMouvement = new uPanel.tMouvement[TaillePileMouvement]; /// 3
public static float DeltaTMax = 1; // (* secondes pour faire 1 cm *)  (* 1/VitesseMin *)
public static bool PasGauche, SensGauche, PasDroit, SensDroit;
public static bool CP = false, InPos = true, NextSegmentKnown = false; // Continuous path


//---------------------------------------------------------------------------
public static float  ConsigneDeplacementPas, ConsigneRotationRobotPas; // tPas
public static  uPanel.tPoint2DPlus DPosition;
const float  pi=3.1416F;
public static int x, DOrientation0RobotD; //  tDegres
public static int DPositionAbs;  // tCm
//---------------------------------------------------------------------------
public static float DegresARadians(int angle) // tRadians tDegres
{
    float y; // tRadians
 y=angle * pi / 180;
 return y;
}
//---------------------------------------------------------------------------
public static float sqr(float z)
{
  return z*z ;
  }
//---------------------------------------------------------------------------
float AbsFloat(float Num)
  { float temp;

    if (Num<0)  temp=-Num;
     else
      temp=Num;
    return(temp);
  }
//---------------------------------------------------------------------------
public static float Atan24(float Num, float Denom) // tRadians
// tRadians Atan24(single Num, single Denom)
  {
//  single Temp;
  float Temp, ADenom;
 //   Math.Atan2()
    ADenom= Math.Abs (Denom);
    if (ADenom<0.001)  Denom=0.001F;
    Temp=Convert.ToSingle(Math.Atan(Num/Denom));
    if (Denom<0) Temp=Temp+pi;
    return(Temp);
  }
//---------------------------------------------------------------------------
public static int DeballerDegres(int angle) // tDegres  tDegres
{
    int temp; // tDegres
 temp=angle;
 if (angle > 180) { temp= angle-360;
        DeballerDegres(temp);}
 if (angle <-180)  { temp= angle+360;
        DeballerDegres(temp);}
 return(temp) ;
}
//---------------------------------------------------------------------------

//void Diff2DPlus(tPoint2DPlus &P0, tPoint2DPlus &PF,
//        tPoint2DPlus &resultat)
public static void Diff2DPlus(uPanel.tPoint2DPlus P0, uPanel.tPoint2DPlus PF,ref uPanel.tPoint2DPlus resultat)
{
 resultat.x=PF.x-P0.x;
 resultat.y=PF.y-P0.y;
 resultat.ThetaRobotDegres=PF.ThetaRobotDegres-P0.ThetaRobotDegres;
 return ;
 }
//---------------------------------------------------------------------------
int DirectionButDegres(int x0But, int y0But) // tDegres tCm tCm
{
 float a;
 int temp; // tDegres
 uPanel.tPoint2DPlus PTemp;
        PTemp=P0Robot;
        PTemp.x=x0But;
        PTemp.y=y0But;
        Diff2DPlus(P0Robot, PTemp, ref DPosition);
        if ((DPosition.x!=0) ||	 (DPosition.y!=0))
         // (* mvmnt non nul > calcul de l'orientation du robot *)
          {
           a=Atan24(DPosition.y,DPosition.x);
           temp=RadiansADegres(a);
           temp=DeballerDegres(temp);
           }  else temp=0;
        return temp;
 }
//---------------------------------------------------------------------------
public static void CalculerMouvementDroit()
{
//  single Incr;
  float Incr;
  uPanel.Mouvement.Etat = uPanel.tEtat.AFaire;
  uPanel.Mouvement.NPas =Convert.ToInt32(Math.Abs(Math.Round(uMouv.ConsigneDeplacementPas)));
  if (uPanel.Mouvement.NPas > 0)
      Incr = ConsigneDeplacementPas / uPanel.Mouvement.NPas;
  else Incr = 0.001F;

  uPanel.Mouvement.IncrGauche = Incr * uPanel.PasParCmGauche / uPanel.PasParCmMax;
    uPanel.Mouvement.IncrDroit=Incr*uPanel.PasParCmDroite/uPanel.PasParCmMax;

    return;

 }
//---------------------------------------------------------------------------
public static void CalculerMouvementRotatif()
{  bool TMSLD;
   float FacteurTemp=1; // pour RH-Y, ajusté par ailleurs
//  single Incr;
  float Incr;
  uPanel.Mouvement.Etat = uPanel.tEtat.AFaire;
  uPanel.Mouvement.NPas = Convert.ToInt32(Math.Round(Math.Abs(ConsigneRotationRobotPas)));
  if (uPanel.Mouvement.NPas > 0)
     {
         TMSLD = uPanel.TrainMoteurSurLeDos;

         if (uPanel.ModeRHYorOPYlow)
         {
             if (uPanel.InverseSensRotation)
         TMSLD=!TMSLD;
       }
      else
         {
             if (uPanel.InverseSensRotationFront)
         TMSLD=!TMSLD;
        }
        // end of if (ModeRHYorOPYlow)

      if (TMSLD)
          Incr = ConsigneRotationRobotPas / uPanel.Mouvement.NPas;
        else // Sur le ventre
          Incr = -ConsigneRotationRobotPas / uPanel.Mouvement.NPas;

      if (!uPanel.ModeRHYorOPYlow)
          FacteurTemp = uGalil.FacteurGalilRotationFront;

      uPanel.Mouvement.IncrGauche = Convert.ToSingle(Math.Round(FacteurTemp *
        Incr * uPanel.PasParDegreRobotGauche / uPanel.PasParDegreRobotMax));
      uPanel.Mouvement.IncrDroit = Convert.ToSingle(Math.Round(FacteurTemp *
        -Incr * uPanel.PasParDegreRobotDroite / uPanel.PasParDegreRobotMax));
    }
       // end of  if (Mouvement.NPas >0)

    return;

}
//---------------------------------------------------------------------------
public static void CinematiqueDirecte(long NIncrGalilGauche, long NIncrGalilDroit)
{
 float a;
 //  (* données: X0RobotFutur, Y0RobotFutur, Thetcamfutur *)
 // X-Gauche, -Y droit
 //  (* calcul d'orientation future du robot *)
NIncrGalilDroit=-NIncrGalilDroit;
CDMoyenne = (NIncrGalilGauche + NIncrGalilDroit) / 2 / uGalil.FacteurGalil;
CDDifference = (NIncrGalilGauche - NIncrGalilDroit) / 2 / uGalil.FacteurGalil;
//CDds=float(CDMoyenne)/PasParCmMax;
CDds=Convert.ToSingle (CDMoyenne)/uPanel.PasParCmMax; // float
//CDdTheta=float(CDDifference)/PasParDegreRobotMax;
CDdTheta = Convert.ToSingle(CDDifference) / uPanel.PasParDegreRobotMax;

}    // void CinematiqueDirecte
//---------------------------------------------------------------------------
//---------------------------------------------------------------------------
public static void CalculerMouvementCourbe()
{
// single Incr, ITemp;
  float Incr, ITemp, DemiEcartRouesExtTmp ;
  bool  InverseCoteRotationXCentreeTmp;

  if (uPanel.ModeRHYorOPYlow)
  {
      InverseCoteRotationXCentreeTmp = uPanel.InverseCoteRotationXCentree;
      DemiEcartRouesExtTmp = uPanel.DemiEcartRouesExt;
       }
      else
  {
      InverseCoteRotationXCentreeTmp = uPanel.InverseCoteRotationXCentreeFront;
        DemiEcartRouesExtTmp = uPanel.DemiEcartRouesExtFront;

        }
        // end of if (ModeRHYorOPYlow)



  uPanel.Mouvement.Etat = uPanel.tEtat.AFaire;
  uPanel.Mouvement.NPas = Convert.ToInt32(Math.Abs(Math.Round(ConsigneDeplacementPas)));
  if (uPanel.Mouvement.NPas > 0)
    {
        Incr = ConsigneDeplacementPas / uPanel.Mouvement.NPas;

        uPanel.Mouvement.IncrGauche = Incr * uPanel.PasParCmGauche / uPanel.PasParCmMax;
        uPanel.Mouvement.IncrDroit = Incr * uPanel.PasParCmDroite / uPanel.PasParCmMax;

     if (uMouv.P0RobotFutur.RayonTrajectoire>0)
             // (*  tourne … droite...   *)
         uPanel.Mouvement.IncrDroit =
             uPanel.Mouvement.IncrGauche *
             (( P0RobotFutur.RayonTrajectoire-
              DemiEcartRouesExtTmp)/
              ( P0RobotFutur.RayonTrajectoire+
              DemiEcartRouesExtTmp));
        else  //(*  tourne … gauche...   *)
         uPanel.Mouvement.IncrGauche =
                uPanel.Mouvement.IncrDroit *              ///////////////
                ((-P0RobotFutur.RayonTrajectoire-
                DemiEcartRouesExtTmp)/
                (-P0RobotFutur.RayonTrajectoire+
                DemiEcartRouesExtTmp));
     if (uPanel.TrainMoteurSurLeDos)
     {
         ITemp = uPanel.Mouvement.IncrDroit;
        uPanel.Mouvement.IncrDroit = uPanel.Mouvement.IncrGauche;
        uPanel.Mouvement.IncrGauche = ITemp;
        }
        if (InverseCoteRotationXCentreeTmp)
        {
            ITemp = uPanel.Mouvement.IncrDroit;
        uPanel.Mouvement.IncrDroit = uPanel.Mouvement.IncrGauche;
        uPanel.Mouvement.IncrGauche = ITemp;
        }

    } //(* if Npas ... *)

 }
//---------------------------------------------------------------------------
public static void CinematiqueInverse()
{
 float a;
 //  (* données: X0RobotFutur, Y0RobotFutur, Thetcamfutur *)
 //  (* calcul d'orientation future du robot *)
    switch (uPanel.Mouvement.ModeDeMouvement)
//(*	  XY:;  R :;  MDMds : ;    *)
    {
       case
    uPanel.tModeDeMouvement.XY:
       Diff2DPlus(P0Robot, P0RobotFutur, ref DPosition);
       if ((DPosition.x!=0) ||	 (DPosition.y!=0))
         // (* mvmnt non nul > calcul de l'orientation du robot *)
          {
           a=Atan24(DPosition.y,DPosition.x);
           P0RobotFutur.ThetaRobotDegres=
              RadiansADegres(a);
           P0RobotFutur.ThetaRobotDegres=
                     DeballerDegres(uPiaget.Round(P0RobotFutur.ThetaRobotDegres));
           }
         else
          // (* mouvement nul; maintien de l'orientation du robot *)
         P0RobotFutur.ThetaRobotDegres=P0Robot.ThetaRobotDegres;
          // (* calcul de réorientation du robot (relatif) *)
       DOrientation0RobotD = uPiaget.Round(P0RobotFutur.ThetaRobotDegres - P0Robot.ThetaRobotDegres);
    	 DOrientation0RobotD=DeballerDegres( DOrientation0RobotD);
    	 ConsigneRotationRobotPas=uPanel.PasParDegreRobotMax*DOrientation0RobotD;
   	 //(* calcul de repositionnement du robot (relatif) *)
    	 DPositionAbs=
            Convert.ToInt32(Math.Sqrt(sqr(DPosition.x)+sqr(DPosition.y)));
         ConsigneDeplacementPas = uPanel.PasParCmMax * DPositionAbs;
                break; //  (* XY:  *)
                case
    uPanel.tModeDeMouvement.Rot:
      // (* calcul de r‚orientation du robot (relatif) *)
       DOrientation0RobotD=
           uPiaget.Round(P0RobotFutur.ThetaRobotDegres - P0Robot.ThetaRobotDegres);
    	 DOrientation0RobotD=DeballerDegres( DOrientation0RobotD);  // unwrap
         ConsigneRotationRobotPas = uPanel.PasParDegreRobotMax * DOrientation0RobotD;   // step
       ConsigneDeplacementPas=0;
        break; //    (* R:  *)
        case
    uPanel.tModeDeMouvement.MDMds:     // (* "code":  dsFutur=P0RobotFutur.x  *)
                ConsigneRotationRobotPas=0;
                ConsigneDeplacementPas = uPanel.PasParCmMax * P0RobotFutur.ds;
        break; //    (* MDMds:  *)
        case
    uPanel.tModeDeMouvement.RotExc:
       ConsigneRotationRobotPas=0;
       if (P0RobotFutur.RayonTrajectoire>0)
	   ConsigneDeplacementPas=  //(* angle trigo.; rayon n‚g si … gauche *)
           -uPanel.PasParCmMax * (P0RobotFutur.RayonTrajectoire + uPanel.DemiEcartRouesExt)
             * DegresARadians(uPiaget.Round(P0RobotFutur.AngleTrajectoire));
          else
           ConsigneDeplacementPas=  //(* angle trigo.; rayon n‚g si … gauche *)
           -uPanel.PasParCmMax * (P0RobotFutur.RayonTrajectoire - uPanel.DemiEcartRouesExt)
             * DegresARadians(uPiaget.Round(P0RobotFutur.AngleTrajectoire));
                break; //
                 case
    uPanel.tModeDeMouvement.RXY:
       Diff2DPlus(P0Robot, P0RobotFutur, ref DPosition);
      if ((DPosition.x!=0) || (DPosition.y!=0))
         // (* mvmnt non nul > calcul de l'orientation du robot *)
          {
           P0RobotFutur.ThetaRobotDegres=
              RadiansADegres(Atan24(DPosition.y,DPosition.x));
           uMouv.P0RobotFutur.ThetaRobotDegres=
                     DeballerDegres(uPiaget.Round(P0RobotFutur.ThetaRobotDegres));
          }
         else
           //(* mouvement nul; maintien de l'orientation du robot *)
          uMouv.P0RobotFutur.ThetaRobotDegres = uMouv.P0Robot.ThetaRobotDegres;

       //(* calcul de réorientation du robot (relatif) *)
         DOrientation0RobotD=
           uPiaget.Round(uMouv.P0RobotFutur.ThetaRobotDegres - P0Robot.ThetaRobotDegres);
    	 DOrientation0RobotD=DeballerDegres( DOrientation0RobotD);
         ConsigneRotationRobotPas = uPanel.PasParDegreRobotMax * DOrientation0RobotD;
       //  (* calcul de repositionnement du robot (relatif) *)
    	 ConsigneDeplacementPas=0;
         uMouv.P0RobotFutur.x = uMouv.P0Robot.x;  // (* pour affichage *)
         uMouv.P0RobotFutur.y = uMouv.P0Robot.y;

      break;  //  RXY:  *)
        case
    uPanel.tModeDeMouvement.Lat:     // (* "code":  dsFutur=P0RobotFutur.x  *)
                ConsigneRotationRobotPas=0;
                ConsigneDeplacementPas=uPanel.PasParCmMax*P0RobotFutur.ds;
        break; //    Lat:

  }   // switch

     return;

}    // void
//---------------------------------------------------------------------------
//---------------------------------------------------------------------------
//---------------------------------------------------------------------------
// void EmpilerMouvement(tMouvement &Mouvement, int &IndicePileMouvement)
public static void EmpilerMouvement()
{
  uMouv.IndicePileMouvement = uMouv.IndicePileMouvement + 1;
    
 if (IndicePileMouvement>TaillePileMouvement)
   {
      //   extern AnsiString MessageErreur;
         uPanel.MessageErreur=" UMouv-EmpilerMouvement-IndicePile trop grand: "+
            IndicePileMouvement.ToString();

   }
 uPanel.Mouvement.PFutur = uMouv.P0RobotFutur;
 uMouv.PileMouvement[uMouv.IndicePileMouvement] = uPanel.Mouvement;
 return;
}
/*
 public static void EmpilerMouvement(uPanel.tMouvement Mouvement, int IndicePileMouvement)
{
IndicePileMouvement=IndicePileMouvement+1;
    
if (IndicePileMouvement>TaillePileMouvement)
{
//   extern AnsiString MessageErreur;
 uPanel.MessageErreur=" UMouv-EmpilerMouvement-IndicePile trop grand: "+
    IndicePileMouvement.ToString();

}
Mouvement.PFutur=P0RobotFutur;
PileMouvement[IndicePileMouvement]=Mouvement;
return;
}
 */
//---------------------------------------------------------------------------
 void MapTargetToAxle (/*tPoint2DPlus P0Target,
                       tPoint2DPlus PTool,
                       tPoint2DPLus &P0Axle*/)
   //    gestion de TOOL
 {
   uPanel.tPoint2DPlus  PTool; //P0P;
 //  extern tPoint2DPlus P0MA;

   uPanel.tMatriceTransf T0P, T0MA, TTool, TToolInv, TTemp;
   T0P.u.x = 0; T0P.v.x = 0; T0P.p.x = 0; // useless assignment
   T0P.u.y = 0; T0P.v.y = 0; T0P.p.y = 0; // useless assignment
   // T0P = [[0,0,0,0],[0,0,0,0],[0,0,0,0],[0,0,0,0]]; // useless assignment
   // conversion de P0Target en matrice  *)
   uCalTrns.PointAMatrice(uMouv.P0RobotFutur, ref T0P);
// conversion de location en Point2DPlus  *)
   PTool.x=uPanel.Tool.x;
   PTool.y = uPanel.Tool.y;
   PTool.ThetaRobotDegres = Convert.ToInt32(uPanel.Tool.phi);

   PTool.ds = 0; PTool.AngleRobotTraj = 0;  // useless assignment
   PTool.RayonTrajectoire = 0; PTool.AngleTrajectoire = 0;  // useless assignment
// conversion de PTool en matrice  *)
   TTool = T0P;// useless assignment
   uCalTrns.PointAMatrice(PTool, ref TTool);
 // 0.--------T0P=Consigne---->.P                                            *)
 //   \-T0MA--->.R---TTOOL-->/      Motorized Axle = Standard robot reference*)
 //   |--------T0R--------->/                                                *)
 // D'où la consigne voulue: T0MA=T0P : inv(TOOL)  *)
   TToolInv = T0P;// useless assignment
   uCalTrns.InverserM (TTool, ref TToolInv  );
   T0MA = T0P;// useless assignment
   uCalTrns.MultiplierM(T0P, TToolInv, ref T0MA);
   uCalTrns.MatriceAPoint(T0MA, ref P0MA);

 //     if (controle)   AfficherMTransf(T0Ballon);
 // conversion de PRobotPointdeprise en matrice  *)
  //    PointAMatrice(PRobotPointpourPrise,TRP);
  //    if controle then  AfficherMTransf(TRP);


 }
//---------------------------------------------------------------------------
//void PrendreMouvementSurPile(tMouvement &Mouvement,
 //                int &IndicePileMouvement)
 public static void PrendreMouvementSurPile()
{
    uPanel.Mouvement = uMouv.PileMouvement[uMouv.IndicePileMouvement];
    uMouv.P0RobotFutur = uPanel.Mouvement.PFutur;
 uMouv.IndicePileMouvement = uMouv.IndicePileMouvement - 1;
 return;
}
 /*
  public static void PrendreMouvementSurPile(ref uPanel.tMouvement Mouvement, ref int IndicePileMouvement)
 {
  Mouvement=PileMouvement[IndicePileMouvement];
  P0RobotFutur=Mouvement.PFutur;
  IndicePileMouvement=IndicePileMouvement-1;
  return;
 }
  */
 //---------------------------------------------------------------------------
//void CalculerImpulsions(bool &PasGauche,bool &SensGauche,
 //               bool &PasDroit,bool &SensDroit)
public static void CalculerImpulsions(ref bool PasGauche,ref bool SensGauche,ref bool PasDroit,ref bool SensDroit){
 long i, temp;
 float AccMax, VTemp, dTtemp;
// single AccMax, VTemp, dTtemp;
 // With Mouvement do

 if (uPanel.Mouvement.Etat == uPanel.tEtat.AFaire)
      {           // (* initialisation *)
          uPanel.Mouvement.Etat = uPanel.tEtat.EnCours;
          uPanel.Mouvement.NoPasGauche = 0;
          uPanel.Mouvement.NoPasDroit = 0;
          uPanel.Mouvement.NoPasCourant = 0;
          uPanel.Mouvement.VitesseMaxM = uPanel.VitesseMaxCourante;
       P0RobotTemp=P0Robot;
       DxTemp=P0RobotFutur.x-P0Robot.x;
       DyTemp=P0RobotFutur.y-P0Robot.y;
       DThetaRobotDegresTemp=P0RobotFutur.ThetaRobotDegres-P0Robot.ThetaRobotDegres;
//    	 DOrientation0RobotD=DeballerDegres( DOrientation0RobotD);  // unwrap
	 DThetaRobotDegresTemp=uMouv.DeballerDegres( Convert.ToInt32(DThetaRobotDegresTemp));  // unwrap
       switch ( uPanel.Mouvement.ModeDeMouvement)
       {
         case
    uPanel.tModeDeMouvement.Rot:  //(*AccMax=Acceleration * 50%  *)

      //          Mouvement.AccelerationM=AccelerationMaxCourante/4; // 2
      //          Mouvement.DecelerationM=DecelerationMaxCourante/4; // 2
                uPanel.Mouvement.AccelerationM=
                   uPanel.AccelerationMaxCourante / uPanel.ReductionDAccelerationEnRotation; // 4
                uPanel.Mouvement.DecelerationM =
                   uPanel.DecelerationMaxCourante / uPanel.ReductionDAccelerationEnRotation; // 4
    // (*           NPasDecelM=NPasAccel*5/4;   *)

         break;
        default:
         {
             uPanel.Mouvement.AccelerationM = uPanel.AccelerationMaxCourante; //(* acceleration
                            //    si la camera est seule … bouger *)
             uPanel.Mouvement.DecelerationM = uPanel.DecelerationMaxCourante;
   //   (*    NPasDecelM=NPasAccel; *)
             break;
           } // (* case *)
         } //(* if modedemvmt... *)
  // calcul des distances d'accélération et de décélération  *)


       uPanel.Mouvement.VitesseM = 0;
       VTemp=0;
       uPanel.Mouvement.NPasAccelM = 0;
       uPanel.Mouvement.NPasDecelMx = 0;
     //  repeat
       while
       (! (
        (uPanel.Mouvement.NPasAccelM + uPanel.Mouvement.NPasDecelMx >=
                 uPanel.Mouvement.NPas) ||
        ((uPanel.Mouvement.VitesseM >= uPanel.Mouvement.VitesseMaxM) &&
                (VTemp >= uPanel.Mouvement.VitesseMaxM))
        )  )
        {
     //  (********)

            if (uPanel.Mouvement.VitesseM < VTemp)
         {
      // (* calcul de la durée du pas  en accél. *)
             if (uPanel.Mouvement.VitesseM > 0)
                 uPanel.DeltaT = 1 / uPanel.Mouvement.VitesseM;   // (* s/cm *)
            else
                 uPanel.DeltaT = DeltaTMax;
             if (uPanel.DeltaT > DeltaTMax) uPanel.DeltaT = DeltaTMax;
             uPanel.DeltaT = uPanel.DeltaT / uPanel.PasParCmMax;
     //  (* calcul de la vitesse instantanée en accél.  *)
             if (uPanel.Mouvement.VitesseM < uPanel.Mouvement.VitesseMaxM) //    (* acceleration ... *)
             {
                 uPanel.Mouvement.NPasAccelM = uPanel.Mouvement.NPasAccelM + 1; //(* *)
                 uPanel.Mouvement.VitesseM =
                uPanel.Mouvement.VitesseM + uPanel.Mouvement.AccelerationM * uPanel.DeltaT;
                 if (uPanel.Mouvement.VitesseM > uPanel.Mouvement.VitesseMaxM)
                     uPanel.Mouvement.VitesseM = uPanel.Mouvement.VitesseMaxM;
              }
         }
        else
         {
     //  (* calcul de la durée du pas en décél. *)
        float dtTemp ;
         if (VTemp>0)  dtTemp=1/VTemp;   //  (* s/cm *)
		  else dtTemp=DeltaTMax;
         if (dtTemp > DeltaTMax)  dtTemp=DeltaTMax;
         dtTemp = dtTemp / uPanel.PasParCmMax;
    //   (* calcul de la vitesse instantanée en décél.  *)
         if (VTemp < uPanel.Mouvement.VitesseMaxM) //(* décéleration ... *)
             {
                 uPanel.Mouvement.NPasDecelMx = uPanel.Mouvement.NPasDecelMx + 1; //(* *)
                 VTemp = VTemp + uPanel.Mouvement.DecelerationM * dtTemp;   //(*  le contraire aprŠs *)
                 if (VTemp > uPanel.Mouvement.VitesseMaxM) VTemp = uPanel.Mouvement.VitesseMaxM;
              }
         }

    //   (********)

   //    until (NPasAccelM+NPasDecelMx>= NPas) or
    //         ((vitesseM>=VitesseMaxM) and (vTemp>=VitesseMaxM)  );
       }  //  while
       uPanel.Mouvement.VitesseM = 0;
       } //(* if AFaire *)

 if (uPanel.Mouvement.Etat == uPanel.tEtat.EnCours)
     {
         if (uPanel.Mouvement.NoPasCourant < uPanel.Mouvement.NPas)
       {
           uPanel.Mouvement.NoPasCourant++;
           if (uPanel.Mouvement.NoPasCourant ==(uPiaget.Round(uPanel.Mouvement.NoPasCourant / 100) * 100))
           MiseAJourPositionIntermediaire(uPanel.Mouvement.NoPasCourant, uPanel.Mouvement.NPas);
               
 //  (* calcul des impulsions (incréments/sens) *)
         int Temp;
         Temp = uPiaget.Round(uPanel.Mouvement.NoPasGauche);
        uPanel.Mouvement.NoPasGauche =
             uPanel.Mouvement.NoPasGauche + uPanel.Mouvement.IncrGauche;
        PasGauche = (Temp != uPiaget.Round(uPanel.Mouvement.NoPasGauche));
        uMouv.SensGauche = uPanel.Mouvement.IncrGauche > 0;

        Temp = uPiaget.Round(uPanel.Mouvement.NoPasDroit);
        uPanel.Mouvement.NoPasDroit =
              uPanel.Mouvement.NoPasDroit + uPanel.Mouvement.IncrDroit;
        PasDroit = Temp != uPiaget.Round(uPanel.Mouvement.NoPasDroit);
        SensDroit = uPanel.Mouvement.IncrDroit > 0;

      }
 //  (* calcul de la durée du pas  *)
      if (uPanel.Mouvement.VitesseM > 0)
          uPanel.DeltaT = 1 / uPanel.Mouvement.VitesseM;    // (* s/cm *)
      else uPanel.DeltaT = DeltaTMax;
      if (uPanel.DeltaT > DeltaTMax) uPanel.DeltaT = DeltaTMax;
      uPanel.DeltaT = uPanel.DeltaT / uPanel.PasParCmMax;
  // (* calcul de la vitesse instantan‚e  *)
      if ((uPanel.Mouvement.NoPasCourant) <
                 uPanel.Mouvement.NPasAccelM)
        {
            uPanel.Mouvement.VitesseM =
           uPanel.Mouvement.VitesseM +
             uPanel.Mouvement.AccelerationM * uPanel.DeltaT;
            if (uPanel.Mouvement.VitesseM >
                uPanel.Mouvement.VitesseMaxM)
                uPanel.Mouvement.VitesseM = uPanel.Mouvement.VitesseMaxM;
        }
      if (uPanel.Mouvement.NoPasCourant >
         (uPanel.Mouvement.NPas - uPanel.Mouvement.NPasDecelMx))
           {
               uPanel.Mouvement.VitesseM =
               uPanel.Mouvement.VitesseM -
                 uPanel.Mouvement.DecelerationM * uPanel.DeltaT;
               if (uPanel.Mouvement.VitesseM < 0)
                   uPanel.Mouvement.VitesseM = 0;  // (* deceleration ... *)
           }

      if ((uPanel.Mouvement.NoPasCourant) >=
             uPanel.Mouvement.NPas) uPanel.Mouvement.Etat = uPanel.tEtat.Fait;  // (*  *)

     }// (*  if Etat=EnCours *)
   return;
}

//---------------------------------------------------------------------------
//void LancerMouvement( tModeDeMouvement MM, tPoint2DPlus &PF)
public static void LancerMouvement(uPanel.tModeDeMouvement MM, uPanel.tPoint2DPlus PF){                      //       (* envoyer lorsque prêt... *)
      P0RobotFutur=PF;
      uPanel.Mouvement.ModeDeMouvement = MM;
      uMTasks.Work[uPanel.NTMouvementSpat].TaskStatus = uMTasks.tPhase.Demandee;
      return;
}
//---------------------------------------------------------------------------
public static void MiseAJourPosition()
{
    uPanel.tPoint2DPlus PRobotRobotFutur;
  switch (uPanel.Mouvement.ModeDeMouvement)
  {
//(*	  XY:;  R :; MDMds : ; ...   *)
     case
     uPanel.tModeDeMouvement.XY:
        P0Robot=uMouv.P0RobotFutur;
        break; // (* XY:  *)
     case
     uPanel.tModeDeMouvement.Rot:
         
        P0Robot.ThetaRobotDegres=P0RobotFutur.ThetaRobotDegres;
     //   P0Robot.ThetaRobotDegres=P0RobotTemp.ThetaRobotDegres
     //        +DThetaRobotDegresTemp;     // 005.12.20 JDZ
         break; //   (* R:  *)
     case
     uPanel.tModeDeMouvement.MDMds:     //    (*  "code": ds=P0RobotFutur.x  *)
         P0Robot.x = P0RobotTemp.x + Convert.ToSingle(P0RobotFutur.ds * Math.Cos(DegresARadians(uPiaget.Round(P0Robot.ThetaRobotDegres))));
         P0Robot.y = P0RobotTemp.y + Convert.ToSingle(P0RobotFutur.ds * Math.Sin(DegresARadians(uPiaget.Round(P0Robot.ThetaRobotDegres))));
        break; // (* MDMds:  *)
     case
     uPanel.tModeDeMouvement.RotExc:
        //  (* Point Futur dans le repère "robot" *)
        PRobotRobotFutur.x = -Convert.ToSingle(P0RobotFutur.RayonTrajectoire * Math.Sin(DegresARadians(uPiaget.Round(P0RobotFutur.AngleTrajectoire))));
        PRobotRobotFutur.y = -Convert.ToSingle(P0RobotFutur.RayonTrajectoire * (1 - Math.Cos(DegresARadians(uPiaget.Round(P0RobotFutur.AngleTrajectoire)))));
              // (* Point Futur dans le repère "terrain" *)
        P0Robot.x = P0RobotTemp.x + PRobotRobotFutur.x * Convert.ToSingle(Math.Cos(DegresARadians(uPiaget.Round(P0RobotTemp.ThetaRobotDegres)))
                        - PRobotRobotFutur.y * Math.Sin(DegresARadians(uPiaget.Round(P0RobotTemp.ThetaRobotDegres))));
        P0Robot.y = P0RobotTemp.y + Convert.ToSingle(PRobotRobotFutur.x * Math.Sin(DegresARadians(uPiaget.Round(P0RobotTemp.ThetaRobotDegres)))
                        + PRobotRobotFutur.y * Math.Cos(DegresARadians(uPiaget.Round(P0RobotTemp.ThetaRobotDegres))));
               // (* Mise … jour des orientations *)
        P0Robot.ThetaRobotDegres=P0RobotTemp.ThetaRobotDegres+P0RobotFutur.AngleTrajectoire;

         break; //
     case
     uPanel.tModeDeMouvement.RXY:
        P0Robot.ThetaRobotDegres=P0RobotFutur.ThetaRobotDegres;
       break; //   (* RXY:  *)
       case
     uPanel.tModeDeMouvement.Lat:     //    (*  "code": ds=P0RobotFutur.x  *)
        P0Robot.x=P0RobotTemp.x+Convert.ToSingle(P0RobotFutur.ds *
                         Math.Cos(DegresARadians(uPiaget.Round(P0Robot.ThetaRobotDegres + 90))));
        P0Robot.y=P0RobotTemp.y+Convert.ToSingle(P0RobotFutur.ds *
                         Math.Sin(DegresARadians(uPiaget.Round(P0Robot.ThetaRobotDegres + 90))));
        break; // Lat:

    } // (* case *)
  
   return;
}
//---------------------------------------------------------------------------
public static void MiseAJourPositionIntermediaire(int IPas, int NPas)
{
    uPanel.tPoint2DPlus PRobotRobotFutur;
    float ratio;
    // ratio=float(IPas)/NPas;
    ratio = Convert.ToSingle(IPas) / NPas;
    switch (uPanel.Mouvement.ModeDeMouvement)
    {
        //(*	  XY:;  R :; MDMds : ; ...   *)
        case
        uPanel.tModeDeMouvement.XY:
            P0Robot.x = P0RobotTemp.x + ratio * DxTemp;
            P0Robot.y = P0RobotTemp.y + ratio * DyTemp;
            //Mouvement.PFutur
            //        P0Robot.ThetaRobotDegres=P0RobotTemp.ThetaRobotDegres
            //             +ratio*DThetaRobotDegresTemp;
            P0Robot.ThetaRobotDegres = P0RobotTemp.ThetaRobotDegres
                 + Convert.ToInt32(ratio * DThetaRobotDegresTemp);
            break; // (* XY:  *)
        case
        uPanel.tModeDeMouvement.Rot:
            P0Robot.ThetaRobotDegres = P0RobotTemp.ThetaRobotDegres
                 + Convert.ToInt32(ratio * DThetaRobotDegresTemp);
            break; //   (* R:  *)
        case
        uPanel.tModeDeMouvement.MDMds:     //    (*  "code": ds=P0RobotFutur.x  *)
            P0Robot.x = P0RobotTemp.x + Convert.ToSingle(ratio * P0RobotFutur.ds *
                             Math.Cos(DegresARadians(uPiaget.Round(P0Robot.ThetaRobotDegres))));
            P0Robot.y = P0RobotTemp.y + Convert.ToSingle(ratio * P0RobotFutur.ds *
                             Math.Sin(DegresARadians(uPiaget.Round(P0Robot.ThetaRobotDegres))));
            break; // (* MDMds:  *)
        case
        uPanel.tModeDeMouvement.RotExc:
            //  (* Point Futur dans le repère "robot" *)
            PRobotRobotFutur.x = -Convert.ToSingle(P0RobotFutur.RayonTrajectoire *
               Math.Sin(uMouv.DegresARadians(Convert.ToInt32(ratio * P0RobotFutur.AngleTrajectoire))));
            PRobotRobotFutur.y = -Convert.ToSingle(P0RobotFutur.RayonTrajectoire *
              (1 - Math.Cos(uMouv.DegresARadians(Convert.ToInt32(ratio * P0RobotFutur.AngleTrajectoire)))));
            // (* Point Futur dans le repère "terrain" *)
            P0Robot.x = P0RobotTemp.x + Convert.ToSingle(
              PRobotRobotFutur.x * Math.Cos(DegresARadians(uPiaget.Round(P0RobotTemp.ThetaRobotDegres)))
             - PRobotRobotFutur.y * Math.Sin(DegresARadians(uPiaget.Round(P0RobotTemp.ThetaRobotDegres))));
            P0Robot.y = P0RobotTemp.y + Convert.ToSingle(
              PRobotRobotFutur.x * Math.Sin(DegresARadians(uPiaget.Round(P0RobotTemp.ThetaRobotDegres)))
             + PRobotRobotFutur.y * Math.Cos(DegresARadians(uPiaget.Round(P0RobotTemp.ThetaRobotDegres))));
            // (* Mise … jour des orientations *)
            P0Robot.ThetaRobotDegres = P0RobotTemp.ThetaRobotDegres + Convert.ToInt32(
                                     ratio * P0RobotFutur.AngleTrajectoire);
            break; //
        case
        uPanel.tModeDeMouvement.RXY:
            P0Robot.ThetaRobotDegres = P0RobotTemp.ThetaRobotDegres
                   + Convert.ToInt32(ratio * DThetaRobotDegresTemp);
            break; //   (* RXY:  *)
        case
        uPanel.tModeDeMouvement.Lat:     //    (*  "code": ds=P0RobotFutur.x  *)
            P0Robot.x = P0RobotTemp.x + Convert.ToSingle(ratio * P0RobotFutur.ds *
                             Math.Cos(DegresARadians(uPiaget.Round(P0Robot.ThetaRobotDegres + 90))));
            P0Robot.y = P0RobotTemp.y + Convert.ToSingle(ratio * P0RobotFutur.ds *
                             Math.Sin(DegresARadians(uPiaget.Round(P0Robot.ThetaRobotDegres + 90))));
            break; // Lat:

    } // (* case *)

    return;
}
//---------------------------------------------------------------------------
void MiseAJourPositionSelonErreur(long ErreurXGalil, long ErreurYGalil)
{
  uPanel.tPoint2DPlus PRobotRobotFutur;
  float ratio;
  ratio=1; //float(IPas)/NPas;
  /*
      XGalil=XGalil+
      round(Mouvement.NPas*Mouvement.IncrGauche*FacteurGalil);
    YGalil=YGalil+
      (Mouvement.NPas*Mouvement.IncrDroit *FacteurGalil);

 */
  switch (uPanel.Mouvement.ModeDeMouvement)
  {
//(*	  XY:;  R :; MDMds : ; ...   *)
     case
     uPanel.tModeDeMouvement.XY:
        P0Robot.x=P0RobotTemp.x+ratio*DxTemp;
        P0Robot.y=P0RobotTemp.y+ratio*DyTemp;
        break; // (* XY:  *)
     case
     uPanel.tModeDeMouvement.Rot:
        P0Robot.ThetaRobotDegres=Convert.ToInt32(P0RobotTemp.ThetaRobotDegres
             +ratio*DThetaRobotDegresTemp);
         break; //   (* R:  *)
     case
     uPanel.tModeDeMouvement.MDMds:     //    (*  "code": ds=P0RobotFutur.x  *)
        P0Robot.x=P0RobotTemp.x+Convert.ToInt32(ratio*P0RobotFutur.ds *
                         Math.Cos(DegresARadians(uPiaget.Round(P0Robot.ThetaRobotDegres))));
        P0Robot.y=P0RobotTemp.y+Convert.ToInt32(ratio*P0RobotFutur.ds *
                        Math.Sin(DegresARadians(uPiaget.Round(P0Robot.ThetaRobotDegres))));
        break; // (* MDMds:  *)
     case
     uPanel.tModeDeMouvement.RotExc:
        //  (* Point Futur dans le repère "robot" *)
          PRobotRobotFutur.x= -Convert.ToSingle(P0RobotFutur.RayonTrajectoire *
             Math.Sin(DegresARadians(Convert.ToInt32(ratio * P0RobotFutur.AngleTrajectoire))));
          PRobotRobotFutur.y=  -Convert.ToSingle(P0RobotFutur.RayonTrajectoire *
            (1 - Math.Cos(DegresARadians(Convert.ToInt32(ratio * P0RobotFutur.AngleTrajectoire)))));
              // (* Point Futur dans le repère "terrain" *)
          P0Robot.x=P0RobotTemp.x+Convert.ToSingle(
            PRobotRobotFutur.x * Math.Cos(DegresARadians(uPiaget.Round(P0RobotTemp.ThetaRobotDegres)))
           - PRobotRobotFutur.y * Math.Sin(DegresARadians(uPiaget.Round(P0RobotTemp.ThetaRobotDegres))));
          P0Robot.y=P0RobotTemp.y+Convert.ToSingle(
            PRobotRobotFutur.x * Math.Sin(DegresARadians(uPiaget.Round(P0RobotTemp.ThetaRobotDegres)))
           + PRobotRobotFutur.y * Math.Cos(DegresARadians(uPiaget.Round(P0RobotTemp.ThetaRobotDegres))));
               // (* Mise … jour des orientations *)
          P0Robot.ThetaRobotDegres=Convert.ToInt32(P0RobotTemp.ThetaRobotDegres+
                                   ratio*P0RobotFutur.AngleTrajectoire);
         break; //
     case
     uPanel.tModeDeMouvement.RXY:
        P0Robot.ThetaRobotDegres=P0RobotTemp.ThetaRobotDegres
               +Convert.ToInt32(ratio*DThetaRobotDegresTemp);
       break; //   (* RXY:  *)
      case
     uPanel.tModeDeMouvement.Lat:     //    (*  "code": ds=P0RobotFutur.x  *)
        P0Robot.x=P0RobotTemp.x+Convert.ToSingle(ratio*P0RobotFutur.ds *
                         Math.Cos(DegresARadians(uPiaget.Round(P0Robot.ThetaRobotDegres + 90))));
        P0Robot.y=P0RobotTemp.y+Convert.ToSingle(ratio*P0RobotFutur.ds *
                         Math.Sin(DegresARadians(uPiaget.Round(P0Robot.ThetaRobotDegres + 90))));
        break; // Lat:
   } // (* case *)

   return;
}

//---------------------------------------------------------------------------
public static int RadiansADegres(float angle)  // tDegres  tRadians
{
  float a;
  int b;// tDegres
  a=angle;
 // y=angle * 180.0 / pi;
//  x=round(y);
  b=uPiaget.Round(a * 180.0F / pi);
  return b;
}

    } // class uMouv
}
