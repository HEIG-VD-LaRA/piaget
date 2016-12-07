using System;

namespace Piaget_Core {
    class TaskHandle {
        private string name;
        private Action state_procedure;

        public TaskHandle(string name) {
            this.name = name;
        }
        
        public string Name {
            get {
                return this.name;
            }
        }

        public void SetNextState(Action next_state_procedure) {
            this.state_procedure = next_state_procedure;
        }
        
        protected void Exec() {
            this.state_procedure();
        }
    }
}
