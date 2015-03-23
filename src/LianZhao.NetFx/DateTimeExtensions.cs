using System;

namespace LianZhao
{
    public static class DateTimeExtensions
    {
        public static DateTime? ToLocalTime(this DateTime? dateTime)
        {
            if (dateTime == null)
            {
                return null;
            }

            return dateTime.Value.ToLocalTime();
        }

        public static DateTime? ToUniversalTime(this DateTime? dateTime)
        {
            if (dateTime == null)
            {
                return null;
            }

            return dateTime.Value.ToUniversalTime();
        }

        public static DateTime FromUnixTimeStamp(double unixTimeStamp)
        {
            return new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddSeconds(unixTimeStamp);
        }
    }
}