using System;
using System.Collections.Generic;

namespace LianZhao.Collections.Generic
{
    public class FuncComparer<T> : Comparer<T>
    {
        public Func<T, T, int> Comparer { get; private set; }

        public FuncComparer(Func<T, T, int> comparer)
        {
            Comparer = comparer;
        }

        public override int Compare(T x, T y)
        {
            return Comparer.Invoke(x, y);
        }
    }
}