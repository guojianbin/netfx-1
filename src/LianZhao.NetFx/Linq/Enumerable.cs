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

        public static int IndexOf(this IEnumerable<int> source, int value)
        {
            if (source is IList<int>)
            {
                return (source as IList<int>).IndexOf(value);
            }

            using (var itor = source.GetEnumerator())
            {
                var i = 0;
                while (itor.MoveNext())
                {
                    if (value == itor.Current)
                    {
                        return i;
                    }

                    i++;
                }
            }

            return -1;
        }

        public static int IndexOf(this IEnumerable<long> source, long value)
        {
            if (source is IList<long>)
            {
                return (source as IList<long>).IndexOf(value);
            }

            using (var itor = source.GetEnumerator())
            {
                var i = 0;
                while (itor.MoveNext())
                {
                    if (value == itor.Current)
                    {
                        return i;
                    }

                    i++;
                }
            }

            return -1;
        }

        public static int IndexOf<T>(this IEnumerable<T> source, T value, IEqualityComparer<T> comparer = null)
        {
            comparer = comparer ?? EqualityComparer<T>.Default;
            using (var itor = source.GetEnumerator())
            {
                var i = 0;
                while (itor.MoveNext())
                {
                    if (comparer.Equals(itor.Current, value))
                    {
                        return i;
                    }

                    i++;
                }
            }

            return -1;
        }

        public static bool IsEmpty<T>(this IEnumerable<T> source)
        {
            return !source.Any();
        }

        public static IEnumerable<T> PaddedTake<T>(this IEnumerable<T> source, int count, T defaultValue = default(T))
        {
            return source.Concat(System.Linq.Enumerable.Repeat(defaultValue, count)).Take(count);
        }

        public static Tuple<int, int> MaxAndIndex(this IEnumerable<int> source)
        {
            return
                source.Select((value, index) => Tuple.Create(value, index))
                    .Aggregate((a, b) => (a.Item1 > b.Item1) ? a : b);
        }

        public static Tuple<long, int> MaxAndIndex(this IEnumerable<long> source)
        {
            return
                source.Select((value, index) => Tuple.Create(value, index))
                    .Aggregate((a, b) => (a.Item1 > b.Item1) ? a : b);
        }

        public static Tuple<float, int> MaxAndIndex(this IEnumerable<float> source)
        {
            return
                source.Select((value, index) => Tuple.Create(value, index))
                    .Aggregate((a, b) => (a.Item1 > b.Item1) ? a : b);
        }

        public static Tuple<double, int> MaxAndIndex(this IEnumerable<double> source)
        {
            return
                source.Select((value, index) => Tuple.Create(value, index))
                    .Aggregate((a, b) => (a.Item1 > b.Item1) ? a : b);
        }

        public static Tuple<decimal, int> MaxAndIndex(this IEnumerable<decimal> source)
        {
            return
                source.Select((value, index) => Tuple.Create(value, index))
                    .Aggregate((a, b) => (a.Item1 > b.Item1) ? a : b);
        }

        public static Tuple<int, int> MinAndIndex(this IEnumerable<int> source)
        {
            return
                source.Select((value, index) => Tuple.Create(value, index))
                    .Aggregate((a, b) => (a.Item1 < b.Item1) ? a : b);
        }

        public static Tuple<long, int> MinAndIndex(this IEnumerable<long> source)
        {
            return
                source.Select((value, index) => Tuple.Create(value, index))
                    .Aggregate((a, b) => (a.Item1 < b.Item1) ? a : b);
        }

        public static Tuple<float, int> MinAndIndex(this IEnumerable<float> source)
        {
            return
                source.Select((value, index) => Tuple.Create(value, index))
                    .Aggregate((a, b) => (a.Item1 < b.Item1) ? a : b);
        }

        public static Tuple<double, int> MinAndIndex(this IEnumerable<double> source)
        {
            return
                source.Select((value, index) => Tuple.Create(value, index))
                    .Aggregate((a, b) => (a.Item1 < b.Item1) ? a : b);
        }

        public static Tuple<decimal, int> MinAndIndex(this IEnumerable<decimal> source)
        {
            return
                source.Select((value, index) => Tuple.Create(value, index))
                    .Aggregate((a, b) => (a.Item1 < b.Item1) ? a : b);
        }

        public static int IndexOfMax(this IEnumerable<int> source)
        {
            return source.IsEmpty() ? -1 : source.MaxAndIndex().Item2;
        }

        public static int IndexOfMax(this IEnumerable<long> source)
        {
            return source.IsEmpty() ? -1 : source.MaxAndIndex().Item2;
        }

        public static int IndexOfMax(this IEnumerable<float> source)
        {
            return source.IsEmpty() ? -1 : source.MaxAndIndex().Item2;
        }

        public static int IndexOfMax(this IEnumerable<double> source)
        {
            return source.IsEmpty() ? -1 : source.MaxAndIndex().Item2;
        }

        public static int IndexOfMax(this IEnumerable<decimal> source)
        {
            return source.IsEmpty() ? -1 : source.MaxAndIndex().Item2;
        }

        public static int IndexOfMin(this IEnumerable<int> source)
        {
            return source.IsEmpty() ? -1 : source.MinAndIndex().Item2;
        }

        public static int IndexOfMin(this IEnumerable<long> source)
        {
            return source.IsEmpty() ? -1 : source.MinAndIndex().Item2;
        }

        public static int IndexOfMin(this IEnumerable<float> source)
        {
            return source.IsEmpty() ? -1 : source.MinAndIndex().Item2;
        }

        public static int IndexOfMin(this IEnumerable<double> source)
        {
            return source.IsEmpty() ? -1 : source.MinAndIndex().Item2;
        }

        public static int IndexOfMin(this IEnumerable<decimal> source)
        {
            return source.IsEmpty() ? -1 : source.MinAndIndex().Item2;
        }
    }
}