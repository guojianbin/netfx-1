using System;
using System.Collections.Generic;
using System.Linq;

namespace LianZhao.Linq
{
    public static partial class Enumerable
    {
        public static IEnumerable<T> Union<T>(this IEnumerable<IEnumerable<T>> items)
        {
            return items.Aggregate(System.Linq.Enumerable.Empty<T>(), (current, item) => current.Union(item));
        }

        public static IEnumerable<double> Range(double start, int count, double step)
        {
            for (var i = 0; i < count; i++)
            {
                yield return (i * step) + start;
            }
        }

        public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
        {
            foreach (var item in source)
            {
                action(item);
            }
        }

        public static void ForEach<T>(this IEnumerable<T> source, Action<T, int> action)
        {
            var i = 0;
            foreach (var item in source)
            {
                action(item, i++);
            }
        }

        public static IEnumerable<double> Sum(this IEnumerable<IEnumerable<double>> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }

            if (!source.Any() || source.Any(item => item == null))
            {
                throw new ArgumentException("source");
            }

            var itors = source.Select(list => list.GetEnumerator()).ToArray();
            while (itors.All(itor => itor.MoveNext()))
            {
                yield return itors.Sum(itor => itor.Current);
            }

            foreach (var itor in itors)
            {
                itor.Dispose();
            }
        }

        public static IEnumerable<double> Average(this IEnumerable<IEnumerable<double>> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }

            if (!source.Any() || source.Any(item => item == null))
            {
                throw new ArgumentException("source");
            }

            var itors = source.Select(list => list.GetEnumerator()).ToArray();
            var count = itors.Count();
            while (itors.All(itor => itor.MoveNext()))
            {
                yield return itors.Sum(itor => itor.Current) / count;
            }

            foreach (var itor in itors)
            {
                itor.Dispose();
            }
        }

        public static bool IsEmpty<T>(this IEnumerable<T> source)
        {
            return !source.Any();
        }

        public static IEnumerable<T> PaddedTake<T>(this IEnumerable<T> source, int count, T defaultValue = default(T))
        {
            return source.Concat(System.Linq.Enumerable.Repeat(defaultValue, count)).Take(count);
        }
    }
}