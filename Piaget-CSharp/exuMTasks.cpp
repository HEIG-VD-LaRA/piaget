//----uMTask-------et uTasks------------------------------------------------------

#include <vcl.h>
#include <string>
#pragma hdrstop
#include "UMain.h"
#include "UPanneauAux.h"
#include "uPiagetAux.h"
//#include <stdio.h>
//#include <vcl.h>
//#include <math.h>
#include <dos.h>

#include "uMTasks.h"
using namespace std;

struct  time t;  //   #include   <dos.h>
int CentiemesRel;

 void SleepAGN(float Duree)
 {
       if ( Work[ActiveTask].SleepingState)
       {
          Work[ActiveTask].TickCounter--;
         if (Work[ActiveTask].TickCounter<=0)
//                               (* wake-up? *)
          {
           if (!Work[ActiveTask].TempsLong)
            {       // Temps Court: gérer les Ticks
            Work[ActiveTask].StateNo++;
            Work[ActiveTask].SleepingState=false;
            }
            else
            {      // Temps long: gérer les centièmes
            gettime(&t);
            CentiemesRel=t.ti_hund-
                Work[ActiveTask].VieuxCentiemes;
            if (CentiemesRel<0)
              CentiemesRel+=100;
            Work[ActiveTask].VieuxCentiemes=t.ti_hund;
            Work[ActiveTask].Centiemes-=CentiemesRel;
            if (Work[ActiveTask].Centiemes<0)
             {  // fin
            Work[ActiveTask].StateNo++;
            Work[ActiveTask].SleepingState=false;
             }
             else
             {  // nouveau centieme approximatif
                Work[ActiveTask].TickCounter=
                   Work[ActiveTask].TicksParCentieme;
             }
            }
          }
//                              (* not sleeping *)
         }
         else
         {
          Work[ActiveTask].SleepingState=true;
          extern long TicksParSeconde;
          if (Duree>0.09)    // s
          {Work[ActiveTask].TempsLong=true;
           Work[ActiveTask].TicksParCentieme
                =TicksParSeconde/100;
           Work[ActiveTask].Centiemes=Duree*100;
           gettime(&t);
 //  printf("The current time is: %2d:%02d:%02d.%02d\n",
 //         t.ti_hour, t.ti_min, t.ti_sec, t.ti_hund);
           Work[ActiveTask].TempsInitial=t.ti_hund;
           Work[ActiveTask].VieuxCentiemes=t.ti_hund;
           Work[ActiveTask].TickCounter=
                   Work[ActiveTask].TicksParCentieme;
                    }
          else
          { Work[ActiveTask].TempsLong=false;
            Work[ActiveTask].TickCounter=Duree*TicksParSeconde;
          }
         }
     };

//Procedure WaitForTaskDoneAGN(TaskNo, TaskToWaitFor: integer);
//         (* AGN: And Goto Next state  *)
// begin
//
//   if Work[TaskToWaitFor].TaskStatus=Faite then
//         Work[TaskNo].StateNo:=Work[TaskNo].StateNo+1;
// end;
//begin
//  For j:= 1 to NTasks do
//  with Work[j] do
//   begin
//     StateNo:=1;
//     SleepingState:=False;
//     TaskStatus:=Faite;
//  end;
//end.

#pragma package(smart_init)

