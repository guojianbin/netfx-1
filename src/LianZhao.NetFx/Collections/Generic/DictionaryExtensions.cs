using System;
using System.Collections.Generic;
using System.Linq;

namespace LianZhao.Collections.Generic
{
    public static class DictionaryExtensions
    {
        public static bool TryGetValue<TValue>(
            this IDictionary<string, TValue> dict,
            string key,
            out TValue value,
            StringComparison comparisonType)
        {
            var rv = false;
            value = default(TValue);
            foreach (var kvp in dict)
            {
                if (kvp.Key.Equals(key, comparisonType))
                {
                    value = kvp.Value;
                    rv = true;
                    break;
                }
            }

            return rv;
        }

        public static TValue GetValue<TValue>(
            this IDictionary<string, TValue> dict,
            string key,
            StringComparison comparisonType)
        {
            foreach (var kvp in dict)
            {
                if (kvp.Key.Equals(key, comparisonType))
                {
                    return kvp.Value;
                }
            }
            return default(TValue);
        }

        public static bool ContentEquals<TKey, TValue>(
            this IDictionary<TKey, TValue> left,
            IDictionary<TKey, TValue> right,
            IEqualityComparer<TKey> keyEqualityComparer = null,
            IEqualityComparer<TValue> valueEqualityComparer = null)
        {
            if (left == null || right == null || left.Count != right.Count)
            {
                return false;
            }

            keyEqualityComparer = keyEqualityComparer ?? EqualityComparer<TKey>.Default;
            valueEqualityComparer = valueEqualityComparer ?? EqualityComparer<TValue>.Default;

            return
                left.Keys.All(
                    leftKey =>
                    right.Keys.Contains(leftKey, keyEqualityComparer)
                    && valueEqualityComparer.Equals(left[leftKey], right[leftKey]));
        }
    }
}