using System;
using Piaget_Core.System;

namespace Piaget_Core {

    class SystemConfig {
        static public readonly long SleepTimeIncrement = (long)(1.0 * Clock.ms);
    }

    class DefaultConfig : SystemConfig {
    }

    class Config : DefaultConfig {
    }
}
