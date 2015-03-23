using System;
using System.Collections.Generic;
using System.Linq;

namespace LianZhao.Linq
{
    public static partial class Enumerable
    {
        public static IEnumerable<TSource> RandomTake<TSource>(
            this IEnumerable<TSource> source,
            int count,
            Random random = null)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }

            if (count < 0)
            {
                throw new ArgumentOutOfRangeException("count");
            }

            if (count == 0)
            {
                return System.Linq.Enumerable.Empty<TSource>();
            }

            random = random ?? RandomLazy.Value;
            return source.Shuffle(random).Take(count);
        }
    }
}