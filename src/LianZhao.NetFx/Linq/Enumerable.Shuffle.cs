using System;
using System.Collections.Generic;
using System.Linq;

namespace LianZhao.Linq
{
    public static partial class Enumerable
    {
        public static IEnumerable<TSource> Shuffle<TSource>(this IEnumerable<TSource> source, Random random = null)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }

            random = random ?? RandomLazy.Value;
            return ShuffleIterator(source, random);
        }

        private static IEnumerable<T> ShuffleIterator<T>(IEnumerable<T> source, Random random)
        {
            var buffer = source.ToList();
            for (var i = 0; i < buffer.Count; i++)
            {
                var j = random.Next(i, buffer.Count);
                yield return buffer[j];

                buffer[j] = buffer[i];
            }
        }
    }
}