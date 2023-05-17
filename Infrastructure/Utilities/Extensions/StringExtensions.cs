using System;
using System.Collections.Generic;

namespace Dashboard.Common.Extensions
{
    public static class StringExtensions
    {
        internal static bool OrdinalContains(this string s, string value, bool ignoreCase = false)
            => s != null &&
               s.Contains(value, ignoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal);

        internal static bool OrdinalStartsWith(this string s, string value, bool ignoreCase = false)
            => s != null && s.StartsWith(value,
                ignoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal);

        internal static bool OrdinalEndsWith(this string s, string value, bool ignoreCase = false)
            => s != null && s.EndsWith(value,
                ignoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal);

        public static bool IsNullOrEmpty(this string str) => string.IsNullOrEmpty(str);

        public static IEnumerable<TSource> DistinctBy<TSource, TKey>
            (this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            var seenKeys = new HashSet<TKey>();
            foreach (var element in source)
            {
                if (seenKeys.Add(keySelector(element)))
                {
                    yield return element;
                }
            }
        }
    }
}
