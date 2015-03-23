using System;
using System.Collections.Generic;
using System.Linq;

namespace LianZhao.Linq
{
    public static partial class Enumerable
    {
        public static Tuple<T, T> MinAndMax<T>(this IEnumerable<T> source, IComparer<T> comparer = null)
        {
            if (!source.Any())
            {
                throw new ArgumentException("Sequence contains no elements", "source");
            }

            if (comparer == null)
            {
                comparer = Comparer<T>.Default;
            }

            var min = source.First();
            var max = min;
            foreach (var element in source)
            {
                var r = comparer.Compare(element, min);
                if (r < 0)
                {
                    min = element;
                }
                else
                {
                    max = element;
                }
            }

            return Tuple.Create(min, max);
        }
    }
}