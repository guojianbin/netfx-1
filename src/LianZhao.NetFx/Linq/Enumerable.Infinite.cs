using System;
using System.Collections.Generic;

namespace LianZhao.Linq
{
    public static partial class Enumerable
    {
        public static IEnumerable<T> Infinite<T>(Func<int, T> generator)
        {
            if (generator == null)
            {
                throw new ArgumentNullException("generator");
            }

            return InfiniteIterator(generator);
        }

        private static IEnumerable<T> InfiniteIterator<T>(Func<int, T> generator)
        {
            var count = 0;
            while (true)
            {
                yield return generator(count++);
            }
        }
    }
}