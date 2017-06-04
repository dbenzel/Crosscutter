using System;
using System.Linq;

namespace Crosscutter.Extensions
{
    public static class StringExtensions
    {
        public static bool IsNullOrEmpty(this string source) => string.IsNullOrEmpty(source);
        public static bool IsNullOrWhitespace(this string source) => string.IsNullOrWhiteSpace(source);
        public static bool IsPopulated(this string source) => !string.IsNullOrWhiteSpace(source);

        public static bool IsIn(this string source, params string[] items)
        {
            return items.Any(x => x.Equals(source, StringComparison.InvariantCultureIgnoreCase));
        }

        public static bool Matches(this string source, params string[] items)
        {
            return items.Any(x => x.Equals(source));
        }

        public static string GetSafeSubstring(this string source, int index, int? length = null)
        {
            if (source.IsNullOrEmpty() || index < 0 || index + 1 > source.Length)
                return string.Empty;

            if (length == null || index + length.Value + 1 > source.Length)
                return source.Substring(index);

            return source.Substring(index, length.Value);
        }
    }
}
