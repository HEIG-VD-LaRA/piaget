﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Piaget_CSharp
{
    class Task20
    {
        public void Task20c()
        {
            const int TaskNumber = 20;
            uMTasks.ActiveTask = TaskNumber;

            switch (uMTasks.Work[TaskNumber].StateNo)
            {
                case

                    1:
                    uMTasks.SleepAGN(0.60F);     // 0.4 + TaskNumber*0.01 secondes .. ou n'importe quoi d'autre
                    break;
                case

                    2:
                    uPiaget.GoState(1000);
                    break;
                case





                    1000: uPiaget.GoState(1); break;
                default:
                    {
                        uPanel.MessageErreur = "Task" + TaskNumber.ToString() + " - Line missing: " + uMTasks.Work[TaskNumber].StateNo.ToString();// uPanel.MessageErreur.Length;
                    } break;
            } // end switch

        } // end void Task...c


    }// end of Task20
}
