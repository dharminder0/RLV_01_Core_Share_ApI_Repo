using System;

namespace Core.Common.Extensions {
    public static class DateTimeExtensions {
        public static double GetAmsterdamUTCTimeOffset(this DateTime date) {
            var wEurope = TimeZoneInfo.FindSystemTimeZoneById("W. Europe Standard Time");
            var utcTime = date.ToUniversalTime();
            var offSet = wEurope.GetUtcOffset(utcTime);
            return offSet.TotalHours;
        }

        public static DateTime ToAmsterdamTime(this DateTime date) {
            var wEurope = TimeZoneInfo.FindSystemTimeZoneById("W. Europe Standard Time");
            var utcTime = date.ToUniversalTime();
            var offSet = wEurope.GetUtcOffset(utcTime);
            return date.AddHours(offSet.TotalHours);
        }

        public static DateTime FromUtcToAmsterdamTime(this DateTime date) {
            var wEurope = TimeZoneInfo.FindSystemTimeZoneById("W. Europe Standard Time");
            var utcTime = TimeZoneInfo.ConvertTimeFromUtc(date, wEurope);
            return utcTime;
        }
    }
}
