using System.Text.RegularExpressions;

namespace Crosscutter.Extensions
{
    public static class RegexExtensions
    {
        public static bool MatchesRegex(this string source, string pattern, bool ignoreCase = true)
        {
            if (source == null) return false;

            var options = ignoreCase ? RegexOptions.IgnoreCase : RegexOptions.None;
            return Regex.IsMatch(source, pattern, options);
        }

        public static string ReplaceRegex(this string source, string pattern, string replacement, bool ignoreCase = true)
        {
            if (source == null) return string.Empty;

            var options = ignoreCase ? RegexOptions.IgnoreCase : RegexOptions.None;
            return Regex.Replace(source, pattern, replacement, options);
        }

        public static string RemoveRegex(this string source, string pattern, bool ignoreCase = true)
        {
            return source.ReplaceRegex(pattern, "", ignoreCase);
        }

        public static string GetFirstMatch(this string source, string pattern, bool ignoreCase = true)
        {
            if (source == null) return string.Empty;

            var options = ignoreCase ? RegexOptions.IgnoreCase : RegexOptions.None;
            return Regex.Match(source, pattern, options).Value;
        }
    }
}
