using System;
using Piaget_Core.System;

namespace Piaget_Core {

    public class SystemConfig {
        static public readonly long SleepTimeIncrement = (long)(1.0 * Clock.ms);
    }

    public class DefaultConfig : SystemConfig {
    }

    public class Config : DefaultConfig {
    }
}
