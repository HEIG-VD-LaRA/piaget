using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Piaget_CSharp
{
    public  class uMTasks
    {

public const int  NTasksC=21;
public static int  NTasks=21; //NTasksC;     // pas de passage externe pour cstes?

/// int const TaillePileC=5;
const int  TaillePileC=5;
// int  TaillePile=TaillePileC;
public static int  TaillePile=TaillePileC;
public enum tPhase
{
    Demandee, EnAction, Suspendue, Faite, Pret, EnMatch, GameOver
};
        /*
public enum tPhase
{
    Pret, EnMatch, GameOver
};*/

/// typedef int tIndicePile; // 0..TaillePile;
int tIndicePile; // 0..TaillePile;

public struct tForData   // Boucle For en multitƒche *)
{
    public int J, Start, Stop, Step;
    public float SleepingTime;
    public bool InLoop;
    public int CurrentAddress;
};
public struct tTask
{
    public String Name;
   public int StateNo;
   public tForData ForData; //(* Boucle For en multitƒche *)
    public tPhase TaskStatus;
    public bool SleepingState;//(*  sleeping ou non;       *)
    public long TickCounter;  //(* stockage de durée convertie de sec. en ticks *)
    public bool TempsLong;
    public bool V4MouvementGalilFait;
    public long Centiemes, VieuxCentiemes, // obsolete
           TempsInitial, TempsFinal,// en sys ticks
           SysTicksTW;// new Sys Ticks to Wait for
 ///  tIndicePile IndicePile;
    public int IndicePile;
    //            int[] intArray;
    //            intArray = new int[100];

    public int[] Pile;// TaillePileC

 ///***        Pile = new int[TaillePileC];
  //****** à reprendre depuis ici!
   
} // end struct tTask

public static long SysTicks, SysTicksRel, SysTicksOld;

// tTask Work[100];          //tTask Work[NTasksC+1];     julien
public static tTask[] Work = new tTask[NTasksC + 1];          //tTask Work[NTasksC+1];     julien

public static int ActiveTask; // 0..NTasks;   */

public static void SleepAGN(float Duree)
{   long DureeL;
    double DureeEnTicksD;
    bool TimeOut;
    // sleeping?
    if (Work[ActiveTask].SleepingState)
        // already sleeping
     {
  //      uMTasks.SysTicks = System.DateTime.Now.Ticks; // once only in Main loop
        // fini?
         if (Work[ActiveTask].TempsFinal >= Work[ActiveTask].TempsInitial)    // ***  JDZ 013.07.04
             TimeOut = (uMTasks.SysTicks > Work[ActiveTask].TempsFinal); 
         else
             TimeOut = ((uMTasks.SysTicks > Work[ActiveTask].TempsFinal)
                 &&
               (uMTasks.SysTicks < Work[ActiveTask].TempsInitial)); 
      if (TimeOut)
        //                               (* wake-up? *)
        {
            Work[ActiveTask].StateNo++;
            Work[ActiveTask].SleepingState = false;
        } // end if fini

        // go on sleeping - nothing to do
       }  // temp end true SleepingState
           
       else  //not sleeping -  enters Sleeping time
                 {
                  Work[ActiveTask].SleepingState=true;
          //        extern long TicksParSeconde;
       //           {Work[ActiveTask].TempsLong=true; // in all cases now
      //             Work[ActiveTask].TicksParCentieme
       //                 =TicksParSeconde/100;
     //              Work[ActiveTask].Centiemes=Duree*100;
                  DureeEnTicksD = (Duree * 10000000);// 1 Tick par 100ns
                  DureeL = Convert.ToInt64(DureeEnTicksD); // en dizaines de microsecondes 

                   Work[ActiveTask].SysTicksTW=DureeL;  
        //           gettime(&t); inutle
         //  printf("The current time is: %2d:%02d:%02d.%02d\n",
         //         t.ti_hour, t.ti_min, t.ti_sec, t.ti_hund);
                   uMTasks.SysTicks = System.DateTime.Now.Ticks;
 
               //    Work[ActiveTask].TempsInitial=t.ti_hund; 
                   Work[ActiveTask].TempsInitial = uMTasks.SysTicks;
                   Work[ActiveTask].TempsFinal = uMTasks.SysTicks + DureeL;
               //    if (((Work[ActiveTask].TempsFinal + 100000000)- Work[ActiveTask].TempsInitial) < 0) // protection again wraparound with 1 second margin
                //       Work[ActiveTask].TempsFinal = DureeL;   ***  JDZ 013.07.04
                     //                Work[ActiveTask].VieuxCentiemes=t.ti_hund;
               //      Work[ActiveTask].VieuxSysTicks =uMTasks.SysTicks  ; // inutile

  //                 Work[ActiveTask].TickCounter=
  //                         Work[ActiveTask].TicksParCentieme;
                           
                 }  // end if SleepingState
 
}  // end SleepAGN



internal static void SleepAGN(double p)
{
    //throw new NotImplementedException();
    uMTasks.SleepAGN((float)p);
}
    } // end class
}  // end NameSpace
