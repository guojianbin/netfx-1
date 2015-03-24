using System;
using System.Collections.Generic;
using System.Linq;

namespace LianZhao.Linq
{
    public static partial class Enumerable
    {
        private static readonly Lazy<Random> RandomLazy = new Lazy<Random>();

        public static IEnumerable<int> Random(int count, bool unique = false, Random random = null)
        {
            if (count < 0)
            {
                throw new ArgumentOutOfRangeException("count");
            }

            random = random ?? RandomLazy.Value;
            return RandomIterator(count, unique, random);
        }

        public static IEnumerable<int> Random(int count, int maxValue, bool unique = false, Random random = null)
        {
            if (count < 0)
            {
                throw new ArgumentOutOfRangeException("count");
            }

            if (maxValue < 0)
            {
                throw new ArgumentOutOfRangeException("maxValue");
            }

            if (unique && count > maxValue)
            {
                throw new ArgumentOutOfRangeException("count", "Sequence does not cotains enough elements");
            }

            random = random ?? RandomLazy.Value;
            return RandomIterator(count, maxValue, unique, random);
        }

        public static IEnumerable<int> Random(
            int count,
            int minValue,
            int maxValue,
            bool unique = false,
            Random random = null)
        {
            if (count < 0)
            {
                throw new ArgumentOutOfRangeException("count");
            }

            if (maxValue < 0)
            {
                throw new ArgumentOutOfRangeException("maxValue");
            }

            if (minValue > maxValue)
            {
                throw new ArgumentOutOfRangeException("minValue");
            }

            if (unique && count > maxValue - minValue)
            {
                throw new ArgumentOutOfRangeException("count", "Sequence does not cotains enough elements");
            }

            random = random ?? RandomLazy.Value;
            return RandomIterator(count, minValue, maxValue, unique, random);
        }

        private static IEnumerable<int> RandomIterator(int count, bool unique, Random random)
        {
            var rv = Infinite(_ => random.Next());
            if (unique)
            {
                rv = rv.Distinct();
            }

            return rv.Take(count);
        }

        private static IEnumerable<int> RandomIterator(int count, int maxValue, bool unique, Random random)
        {
            var rv = Infinite(_ => random.Next(maxValue));
            if (unique)
            {
                rv = rv.Distinct();
            }

            return rv.Take(count);
        }

        private static IEnumerable<int> RandomIterator(
            int count,
            int minValue,
            int maxValue,
            bool unique,
            Random random)
        {
            var rv = Infinite(_ => random.Next(minValue, maxValue));
            if (unique)
            {
                rv = rv.Distinct();
            }

            return rv.Take(count);

        }
    }
}