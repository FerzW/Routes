using System;

namespace Routes
{
    static class TimeConverter
    {
        public const int maxTime = 24*60 - 1;

        public static int TimeToInt(DateTime timeDT)
        {
            return timeDT.Hour * 60 + timeDT.Minute;
        }

        public static DateTime IntToTime(int timeInt)
        {
            return new DateTime(1971, 1, 1, timeInt / 60, timeInt % 60, 0);
        }

        public static bool timeIsCorrect(int timeInt)
        {
            return timeInt <= maxTime;
        }

    }
}
