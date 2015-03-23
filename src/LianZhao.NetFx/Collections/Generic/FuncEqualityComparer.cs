using System;
using System.Collections.Generic;

namespace LianZhao.Collections.Generic
{
    public class FuncEqualityComparer<T> : EqualityComparer<T>
    {
        public Func<T, T, bool> Comparer { get; private set; }

        public FuncEqualityComparer(Func<T, T, bool> comparer)
        {
            Comparer = comparer;
        }

        public override bool Equals(T x, T y)
        {
            return Comparer.Invoke(x, y);
        }

        public override int GetHashCode(T obj)
        {
            return obj == null ? 0 : obj.GetHashCode();
        }
    }
}