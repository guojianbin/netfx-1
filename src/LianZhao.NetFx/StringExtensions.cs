using System;

namespace LianZhao
{
    public static class StringExtensions
    {
        public static int ToInt32(this string value)
        {
            return Convert.ToInt32(value);
        }

        public static int ToInt32(this string value, int defaultValue)
        {
            int rv;
            return int.TryParse(value, out rv) ? rv : defaultValue;
        }

        public static long ToInt64(this string value)
        {
            return Convert.ToInt64(value);
        }

        public static long ToInt64(this string value, long defaultValue)
        {
            long rv;
            return long.TryParse(value, out rv) ? rv : defaultValue;
        }

        public static bool ToBoolean(this string value)
        {
            return Convert.ToBoolean(value);
        }

        public static bool ToBoolean(this string value, bool defaultValue)
        {
            bool rv;
            return bool.TryParse(value, out rv) ? rv : defaultValue;
        }

        public static bool Contains(this string source, string value, StringComparison comparisonType)
        {
            return source.IndexOf(value, comparisonType) >= 0;
        }
    }
}