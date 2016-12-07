using System;

namespace Piaget_Core {
    class Task : TaskHandle {
        public Task(string name) : base(name) {
        }
        public new void Exec() {
            base.Exec();
        }
    }
}
