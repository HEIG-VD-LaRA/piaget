using System;
using System.Diagnostics;

namespace Piaget_Core {

    public class Time {
        static public readonly double sec = Stopwatch.Frequency;
        static public readonly double ms = sec / 1000.0;
        static public readonly double us = ms / 1000.0;
        static public readonly double ns = us / 1000.0;

        enum Units { sec, ms, us, ns };
        static public string Format(double time) {
            Units units = Units.sec;
            if (time == 0.0) {
                return "0 sec";
            }
            while (time < 1.0) {
                time *= 1000.0;
                units++;
            }
            return (Math.Truncate(time * 100.0) / 100.0).ToString() + " " + units.ToString();
        }
    }
}
