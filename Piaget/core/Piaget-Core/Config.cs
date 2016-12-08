using System;
using Piaget_Core.System;

namespace Piaget_Core {

    class SystemConfig {
        public const long SoftwareTimeIncrement = 1 * (long)Clock.ms;
    }

    class DefaultConfig {
        public const int Clock_MillisecondSleep = 1;
        public const int Clock_DeltaTicksToResume = 4;
    }
    
    class Config : DefaultConfig {
        public new const int Clock_SleepInMilliseconds = 1;
        public new const int Clock_DeltaTicksToResume = 1;
    }
}
