using System;
using System.Threading;
using System.Windows.Forms;

namespace Piaget_Core {
    public static class ExtensionsToCSharp {

        // Overloading of built-in Invoke(Delegate method) in order to allow lambda expressions as input
        //
        // When updating the UI from another thread than the UI thread, a System.InvalidOperationException will occur
        // because that case isn't thread safe and could theorically lead to strange results.
        // In an application using PiagetJB, the task manager is launched in a separate thread, then when a task wants 
        // to update the UI, this needs to be done via Invoke or BeginInvoke.
        // 
        // For an example of use, see examples in Piaget\Core\Tests. Notice that the synthax could be slighty simplified
        // when only a single instruction updates the UI.
        public static void Invoke(this Control control, Action action) {
            control.Invoke((Delegate)action);
        }

        // Idem but for BeginInvoke(Delegate method). When using Invoke, it blocks the task (and other tasks too as we are 
        // doing cooperative task management) until the UI update has completed.
        // BeginInvoke avoid this blocking, but you should be aware that in a case like :
        //    this.BeginInvoke(() => this.tbMessages.Text = n.ToString());
        //    n++;
        // it won't work as expected as the UI updating action will be call after the change in the value of n, as BeginInvoke
        // only schedule the UI updating for later.
        public static void BeginInvoke(this Control control, Action action) {
            control.BeginInvoke((Delegate)action);
        }
        
    }

    public static class Misc {
        public static void SleepWhile(Func<bool> condition) {
            while (condition()) {
                Thread.Sleep(1);
            }
        }
    }
}