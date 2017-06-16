using Crosscutter.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Should;
using System.Linq;

namespace Crosscutter.Test.Extensions
{
    [TestClass]
    public class RegexExtensionsShould
    {
        private const string AlphaLowercase = @"[a-z]";
        private const string LetterAFollowedByLetter = @"A\w\b";

        [TestMethod]
        public void match_regex_patterns()
        {
            ((string)null).MatchesRegex(AlphaLowercase).ShouldBeFalse();
            "".MatchesRegex(AlphaLowercase).ShouldBeFalse();
            "a".MatchesRegex(AlphaLowercase).ShouldBeTrue();
            "A".MatchesRegex(AlphaLowercase).ShouldBeTrue();
            "a".MatchesRegex(AlphaLowercase, false).ShouldBeTrue();
            "A".MatchesRegex(AlphaLowercase, false).ShouldBeFalse();
        }

        [TestMethod]
        public void replace_regex_matches()
        {
            ((string)null).ReplaceRegex(AlphaLowercase, string.Empty).ShouldEqual(string.Empty);
            " ".ReplaceRegex(@"\s", "").ShouldEqual(string.Empty);
            "a".ReplaceRegex(AlphaLowercase, "").ShouldEqual(string.Empty);
            "A".ReplaceRegex(AlphaLowercase, "").ShouldEqual(string.Empty);
            "a".ReplaceRegex(AlphaLowercase, "", false).ShouldEqual(string.Empty);
            "A".ReplaceRegex(AlphaLowercase, "", false).ShouldEqual("A");
        }

        [TestMethod]
        public void remove_regex_matches()
        {
            ((string)null).RemoveRegex(AlphaLowercase).ShouldEqual(string.Empty);
            " ".RemoveRegex(@"\s").ShouldEqual(string.Empty);
            "a".RemoveRegex(AlphaLowercase).ShouldEqual(string.Empty);
            "A".RemoveRegex(AlphaLowercase).ShouldEqual(string.Empty);
            "a".RemoveRegex(AlphaLowercase, false).ShouldEqual(string.Empty);
            "A".RemoveRegex(AlphaLowercase, false).ShouldEqual("A");
        }

        [TestMethod]
        public void get_first_match()
        {
            ((string)null).GetFirstMatch(LetterAFollowedByLetter).ShouldEqual(string.Empty);
            "AA AB AC".GetFirstMatch(LetterAFollowedByLetter).ShouldEqual("AA");
            "00".GetFirstMatch(LetterAFollowedByLetter).ShouldEqual(string.Empty);
        }

        [TestMethod]
        public void get_all_matches()
        {
            ((string)null).GetAllMatches(LetterAFollowedByLetter).ShouldBeEmpty();

            var results = "AA AB AC".GetAllMatches(LetterAFollowedByLetter).ToList();

            results.Count.ShouldEqual(3);
            results[0].Value.ShouldEqual("AA");
            results[1].Value.ShouldEqual("AB");
            results[2].Value.ShouldEqual("AC");
        }
    }
}
