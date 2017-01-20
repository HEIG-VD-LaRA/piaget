
namespace Piaget_Core.System {

    public class SystemConfig {
        // The time increment for the function used to make a sleep (Thread.Sleep)
        // is one milisecond.
        static public readonly long SleepTimeIncrement = (long)(1.0 * Time.ms);
    }

    public class Config {
        static public readonly long SyncUISleep = (long)(200.0 * Time.ms);
    }
}
