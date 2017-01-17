using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Piaget_CSharp
{
    class Task02
    {   /*
         * Faire un pas  - move a little bit 
         */
        public void Task02c()
        {
            const int TaskNumber = 2;
            uMTasks.ActiveTask = TaskNumber;
            //------------------------------------------------------------------------------------------
            
 
            int i;
            bool SG,SD;
            switch (uMTasks.Work[TaskNumber].StateNo)
            {
                case
                1:
                    if (uMTasks.Work[TaskNumber].TaskStatus == uMTasks.tPhase.Demandee)
	                {
                        uMTasks.Work[TaskNumber].TaskStatus = uMTasks.tPhase.EnAction;
                        if (uPanel.Choix[uPanel.NCStepSound].Etat) System.Media.SystemSounds.Beep.Play();
                        uMTasks.Work[TaskNumber].StateNo=10;
                    }
                   break;  
                case
                10:
                   uMTasks.Work[TaskNumber].StateNo = 20;
                   break;  
                case
                20: 
                    SG=uMouv.SensGauche;
                    SD = uMouv.SensDroit;
                    if (uPanel.InverseSensLineaire)
                    {    SG=!SG;
                        SD=!SD;
                    }

                    uTasks.V2Duree=uPanel.DeltaTPas / 2;
                    uMTasks.Work[TaskNumber].StateNo = 30;
        
                   break;  
                case
                30: 
                    uMTasks.SleepAGN(uTasks.V2Duree);
                    break;  
                case
                31:
                    uMTasks.Work[TaskNumber].StateNo = 40;
                    break;  
                case
                40:
                    uMTasks.SleepAGN(uTasks.V2Duree);
                    break;  
                case
                41:
                    uMTasks.Work[TaskNumber].StateNo = 60;
                    break;  
                case
                60:
                    uMTasks.Work[TaskNumber].TaskStatus = uMTasks.tPhase.Faite;
                    uMTasks.Work[TaskNumber].StateNo = 1;
                    break;
                default:
                    {
                        uPanel.MessageErreur = "Task" + TaskNumber.ToString() + " - Line missing: " + uMTasks.Work[TaskNumber].StateNo.ToString();// uPanel.MessageErreur.Length;
                    } break;
            }//end switch
            //------------------------------------------------------------------------------------------
            /* code origine
            void Task02()   // (* Faire un pas *)
{
 extern bool InteractionSouhaitee;
 int const TaskNumber=2;
 int i;
 bool SG,SD;
 ActiveTask=TaskNumber;
 switch ( Work[TaskNumber].StateNo ){
  case
    1:
         if (Work[TaskNumber].TaskStatus==Demandee)
	        {
        	 Work[TaskNumber].TaskStatus=EnAction;
               if ( Choix[NCStepSound].Etat ) Beep();
                 Work[TaskNumber].StateNo=10;
                }
                   break;  case
    10:
           Work[TaskNumber].StateNo=20;
                   break;  case
    20: {
//    PasGauche,SensGauche,
  //              PasDroit,SensDroit
           SG=SensGauche;
           SD=SensDroit;
           if (InverseSensLineaire)
           {SG=!SG;
            SD=!SD;}

           V2Duree=DeltaTPas / 2;
           Work[TaskNumber].StateNo=30;
        }
                   break;  case

    30:  SleepAGN(V2Duree);
                  break;  case

    31:
 //****        if Choix[NCStepSound].etat then NoSound;
         Work[TaskNumber].StateNo=40;
    //     Work[TaskNumber].StateNo=41;
                  break;  case
    40:  SleepAGN(V2Duree);
                  break;  case

   41:
 //****       if (!( VarEtat[NVEArret].etat))
                Work[TaskNumber].StateNo=60;
                  break;  case

    60:
        Work[TaskNumber].TaskStatus=Faite;
        Work[TaskNumber].StateNo=1;

       break;
  default :
     {
     MessageErreur="Task"+IntToStr(TaskNumber)+" - Line missing: "+IntToStr(Work[TaskNumber].StateNo);
     };
  }
 }   // Task02
            */
        } // end void Task02c


    } // end class Task02
}
