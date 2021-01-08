using System;

namespace LevelEditor{
    public struct TimeDateConverter{
        public static string UnixToUtcTime(long unixTime){
            var dateTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            dateTime = dateTime.AddSeconds(unixTime).ToUniversalTime();
            return dateTime.ToString("g");
        }

        public static long CurrentUnixTime(){
            var unixTime = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds();
            return unixTime;
        }
    }
}