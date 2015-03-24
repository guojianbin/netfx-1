using System;
using System.Collections.Generic;
using System.Linq;

namespace LianZhao.Linq
{
    public static partial class Enumerable
    {
        public static Tuple<T, int> MinAndIndex<T>(this IEnumerable<T> source, IComparer<T> comparer = null)
        {
            if (comparer == null)
            {
                comparer = Comparer<T>.Default;
            }
            return
                source.Select((value, index) => Tuple.Create(value, index))
                    .Aggregate((a, b) => (comparer.Compare(a.Item1, b.Item1)) < 0 ? a : b);
        }
    }
}