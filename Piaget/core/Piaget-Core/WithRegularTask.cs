using Piaget_Core.System;

namespace Piaget_Core {
    abstract class WithRegularTask : WithTask {
    }

    //interface IRegularTask {
    //    string Name { get; }
    //    void SetNextState(Action next_state_procedure);
    //    void ExtraSleep(ulong extra_time);
    //    void AddParallelTask(string name, RegularTask task, ulong period);
    //    void AddSerialTask(string name, RegularTask task, ulong period);
    //    void AddLoopTask(string name, LoopTask task, ulong period);
    //    void Terminate();
    //}
}
