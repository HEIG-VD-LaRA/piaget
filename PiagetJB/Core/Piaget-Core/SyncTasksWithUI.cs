using Piaget_Core.System;
using System;
using System.Windows.Forms;

namespace Piaget_Core {

    public interface ISyncWithTasks {
        void Invoke(Action action);
    }

    public class SyncUIWithTasks : WithTasking, ISyncWithTasks {
        private Form frm;
        private Action action_from_UI;

        public SyncUIWithTasks(Form frm) {
            this.frm = frm;
            this.action_from_UI = null;
        }

        protected override void Reset() {
            this.Task.SetState(Run);
        }

        private void Run() {
            if (this.action_from_UI != null) {
                this.action_from_UI();
                this.action_from_UI = null;
            }
        }

        public void Invoke(Action action) {
            while (this.action_from_UI != null) { }
            this.action_from_UI = action;
        }
    }
}
