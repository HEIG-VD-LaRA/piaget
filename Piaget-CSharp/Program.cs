

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;



namespace Piaget_CSharp
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            /*
             *Augmenter la priorité du processus courant SL 2013 
             */
            System.Diagnostics.Process myProcess = System.Diagnostics.Process.GetCurrentProcess();
            myProcess.PriorityClass = System.Diagnostics.ProcessPriorityClass.RealTime;
            /********************/




            Application.Run(new FPiaget());


        }
    }
}
