using System.Linq;

namespace LianZhao.Linq
{
    public static class Lookup
    {
        #region Empty

        public static ILookup<TKey, TValue> Empty<TKey, TValue>()
        {
            return EmptyHolder<TKey, TValue>.Instance;
        }

        private static class EmptyHolder<TKey, TValue>
        {
            public static readonly ILookup<TKey, TValue> Instance =
                System.Linq.Enumerable.Empty<int>().ToLookup(x => default(TKey), x => default(TValue));
        }
        #endregion
    }
}