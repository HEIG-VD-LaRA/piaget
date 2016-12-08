using System;
using Piaget_Core.System;

namespace Piaget_Core {

    class SystemConfig {
        public const long SoftwareTimeIncrement = 1 * (long)Clock.ms;
    }

    class DefaultConfig {
        public const long Clock_MinSleep = 100 * Clock.ms;
        public const int Clock_Factor = 16;
    }
    
    class Config : UserConfig {
        public Config() {
            //if (Task_ThresholdToSleep < SystemConfig.Task_MinThresholdToSleep) {
            //    throw new Exception("Task_ThresholdToSleep should be at least equal to Task_MinThresholdToSleep defined in class SystemConfig");
            //}
            // Test des autres config !!!
        }
    }
}
