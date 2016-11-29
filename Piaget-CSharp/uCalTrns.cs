using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Piaget_CSharp
{
    class uCalTrns
    {
//public static void MultiplierM(tMatriceTransf &m1, tMatriceTransf &m2, tMatriceTransf &pM)
public static void MultiplierM(uPanel.tMatriceTransf m1, uPanel.tMatriceTransf m2,
                        ref uPanel.tMatriceTransf pM)
  {    uPanel.tMatriceTransf M;
  //(* changement du vecteur position *)

//(* (  ux ux    vx uy ) (ux vx  vx vy )  (ux px  vx py  px - )     *)
     M.u.x=m1.u.x*m2.u.x+m1.v.x*m2.u.y;
     M.v.x=m1.u.x*m2.v.x+m1.v.x*m2.v.y;
     M.p.x=m1.u.x*m2.p.x+m1.v.x*m2.p.y+m1.p.x;
//(* (  uy ux    vy uy ) (uy vx  vy vy )  (uy px  vy py  py -  )     *)
     M.u.y=m1.u.y*m2.u.x+m1.v.y*m2.u.y;
     M.v.y=m1.u.y*m2.v.x+m1.v.y*m2.v.y;
     M.p.y=m1.u.y*m2.p.x+m1.v.y*m2.p.y+m1.p.y;
     pM=M;
  }

//void InverserM(tMatriceTransf &m, tMatriceTransf &Minv)
public static void InverserM(uPanel.tMatriceTransf m, ref uPanel.tMatriceTransf Minv)
  {
//  (* changement du vecteur position *)
     Minv.p.x=-(m.p.x*m.u.x+m.p.y*m.u.y);
     Minv.p.y=-(m.p.x*m.v.x+m.p.y*m.v.y);
 // (* transposée *)
     Minv.u.x=m.u.x;    Minv.v.x=m.u.y;
     Minv.u.y=m.v.x;    Minv.v.y=m.v.y;
   }
public static void PointAMatrice(uPanel.tPoint2DPlus pt,ref uPanel.tMatriceTransf m)
  { float  ThetaTemp, CTemp,STemp;
  ThetaTemp = uMouv.DegresARadians(uPiaget.Round(pt.ThetaRobotDegres));
   CTemp=Convert.ToSingle(Math.Cos(ThetaTemp));
   STemp=Convert.ToSingle(Math.Sin(ThetaTemp));
 // (* changement du vecteur position *)
     m.p.x=pt.x;
     m.p.y=pt.y;
 // (* sous-matrice de rotation *)
     m.u.x= CTemp;    m.v.x=-STemp;
     m.u.y= STemp;    m.v.y= CTemp;
   }
public static void MatriceAPoint( uPanel.tMatriceTransf m,ref uPanel.tPoint2DPlus pt)
  {
//   (* changement du vecteur position *)
     pt.x=m.p.x;
     pt.y=m.p.y;
//  (* angle *)
     pt.ThetaRobotDegres=
              uMouv.RadiansADegres(uMouv.Atan24(m.u.y,m.u.x));
     pt.ThetaRobotDegres=
                uMouv.DeballerDegres(uPiaget.Round(pt.ThetaRobotDegres));
  } // end MatriceAPoint

/*

 void AfficherPoint( pt:tPoint2DPlus );
 {
  with pt do
   {
    writeln('      X        Y       ThR  ');
    writeln(x:9:1, Y:8:1, ThetaRobotDegres:8 );
   }
 }
 void AfficherMTransf( m:tMatriceTransf );
 {
    writeln('     U       V       P   ');
  with m do
   {
    writeln(u.x:8:3, v.x:8:3, p.x:8:1 );
    writeln(u.y:8:3, v.y:8:3, p.y:8:1 );
   }
 }
*/
    }
}
