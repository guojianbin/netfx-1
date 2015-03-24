using System.Collections.Generic;

namespace LianZhao.Linq
{
    public static partial class Enumerable
    {
        public static int IndexOf<T>(this IEnumerable<T> source, T item, IEqualityComparer<T> comparer = null)
        {
            if (comparer == null)
            {
                var list = source as IList<T>;
                if (list != null)
                {
                    return list.IndexOf(item);
                }
                comparer = EqualityComparer<T>.Default;
            }

            using (var itor = source.GetEnumerator())
            {
                var i = 0;
                while (itor.MoveNext())
                {
                    if (comparer.Equals(itor.Current, item))
                    {
                        return i;
                    }

                    i++;
                }
            }

            return -1;
        }
    }
}