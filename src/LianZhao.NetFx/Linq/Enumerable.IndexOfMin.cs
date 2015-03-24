using System;
using System.Collections.Generic;
using System.Linq;

namespace LianZhao.Linq
{
    public static partial class Enumerable
    {
        public static int IndexOfMin<T>(this IEnumerable<T> source, IComparer<T> comparer = null)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            if (!source.Any())
            {
                return -1;
            }
            return source.MinAndIndex(comparer).Item2;
        }
    }
}