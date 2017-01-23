using Piaget_Core.Base;
using System;
using System.Windows.Forms;

namespace Piaget_Core {

    public interface ISyncWithTasks {
        void Invoke(Action action);
    }

    public class SyncUIWithTasks : WithTasking, ISyncWithTasks {
        private Action action_from_UI;

        public SyncUIWithTasks() {
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
            this.action_from_UI = action;
            Misc.SleepWhile(() => this.action_from_UI != null);
        }
    }
}
