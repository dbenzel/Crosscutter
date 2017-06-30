using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Crosscutter.Extensions
{
    public static class RegexExtensions
    {
        public static bool MatchesRegex(this string source, string pattern, bool ignoreCase = true)
        {
            if (source == null) return false;

            return Regex.IsMatch(source, pattern, GetOptions(ignoreCase));
        }

        public static string ReplaceRegex(this string source, string pattern, string replacement, bool ignoreCase = true)
        {
            if (source == null) return string.Empty;

            return Regex.Replace(source, pattern, replacement, GetOptions(ignoreCase));
        }

        public static string RemoveRegex(this string source, string pattern, bool ignoreCase = true)
        {
            return source.ReplaceRegex(pattern, "", ignoreCase);
        }

        public static string GetFirstMatch(this string source, string pattern, bool ignoreCase = true)
        {
            if (source == null) return string.Empty;

            return Regex.Match(source, pattern, GetOptions(ignoreCase)).Value;
        }

        public static IEnumerable<Match> GetAllMatches(this string source, string pattern, bool ignoreCase = true)
        {
            if (source == null) return new List<Match>();

            return Regex.Matches(source, pattern, GetOptions(ignoreCase)).Cast<Match>();
        }

        public static IEnumerable<string> SplitOnRegex(this string source, string pattern, bool ignoreCase = true)
        {
            if (source == null) return new List<string>();
            
            return Regex.Split(source, pattern, GetOptions(ignoreCase));
        }

        private static RegexOptions GetOptions(bool ignoreCase) => ignoreCase ? RegexOptions.IgnoreCase : RegexOptions.None;
    }
}
