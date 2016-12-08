using Piaget_Core.System;

namespace Piaget_Core {
    abstract class WithRegularTask : WithTask {
    }

    //interface IRegularTask {
    //    string Name { get; }
    //    void SetNextState(Action next_state_procedure);
    //    void ExtraSleep(long extra_time);
    //    void AddParallelTask(string name, RegularTask task, long period);
    //    void AddSerialTask(string name, RegularTask task, long period);
    //    void AddLoopTask(string name, LoopTask task, long period);
    //    void Terminate();
    //}
}
