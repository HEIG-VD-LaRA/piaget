using System;
using Piaget_Core.System;

namespace Piaget_Core {

    class SystemConfig {
        private const long SleepTimeIncrementReal = 1 * (long)Clock.ms;
        static public readonly long SleepTimeIncrement = Clock.ToPiagetTime(SleepTimeIncrementReal);
    }

    class DefaultConfig : SystemConfig {
    }

    class Config : DefaultConfig {
    }
}
