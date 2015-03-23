using System;
using System.Text;

namespace LianZhao.Text
{
    public static class StringBuilderExtensions
    {
        public static bool TryAppend(this StringBuilder sb, string str)
        {
            if (sb == null)
            {
                throw new ArgumentNullException("sb");
            }

            if (string.IsNullOrEmpty(str))
            {
                return true;
            }

            if (sb.Length + str.Length <= sb.MaxCapacity)
            {
                sb.Append(str);
                return true;
            }
            else
            {
                sb.Append(str.Substring(0, sb.MaxCapacity - sb.Length));
                return false;
            }
        }

        public static void RemoveFirst(this StringBuilder sb, int length = 1)
        {
            if (sb == null)
            {
                throw new ArgumentNullException("sb");
            }

            if (sb.Length < length)
            {
                throw new ArgumentOutOfRangeException("length");
            }

            sb.Remove(0, length);
        }

        public static void RemoveLast(this StringBuilder sb, int length = 1)
        {
            if (sb == null)
            {
                throw new ArgumentNullException("sb");
            }

            if (sb.Length < length)
            {
                throw new ArgumentOutOfRangeException("length");
            }

            sb.Remove(sb.Length - length, length);
        }
    }
}