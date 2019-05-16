using Crosscutter.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Should;

namespace Crosscutter.Test.Extensions
{
    [TestClass]
    public class StringExtensionsShould
    {
        [TestMethod]
        public void evaluate_is_null_or_empty()
        {
            ((string)null).IsNullOrEmpty().ShouldBeTrue();
            "".IsNullOrEmpty().ShouldBeTrue();
            " ".IsNullOrEmpty().ShouldBeFalse();
            "a".IsNullOrEmpty().ShouldBeFalse();
        }

        [TestMethod]
        public void evaluate_is_null_or_whitespace()
        {
            ((string)null).IsNullOrWhitespace().ShouldBeTrue();
            "".IsNullOrWhitespace().ShouldBeTrue();
            " ".IsNullOrWhitespace().ShouldBeTrue();
            "a".IsNullOrEmpty().ShouldBeFalse();
        }

        [TestMethod]
        public void evaluate_is_populated()
        {
            ((string)null).IsPopulated().ShouldBeFalse();
            "".IsPopulated().ShouldBeFalse();
            " ".IsPopulated().ShouldBeFalse();
            "a".IsPopulated().ShouldBeTrue();
        }

        [TestMethod]
        public void get_safe_substring()
        {
            ((string)null).GetSafeSubstring(0, 3).ShouldEqual(string.Empty);
            "abc".GetSafeSubstring(-1, 3).ShouldEqual(string.Empty);
            "abc".GetSafeSubstring(0, 3).ShouldEqual("abc");
            "abc".GetSafeSubstring(0, 4).ShouldEqual("abc");
            "abc".GetSafeSubstring(1, 3).ShouldEqual("bc");
            "abc".GetSafeSubstring(3, 3).ShouldEqual(string.Empty);
            "abc".GetSafeSubstring(1).ShouldEqual("bc");
            "abc".GetSafeSubstring(0, 2).ShouldEqual("ab");
        }

        [TestMethod]
        public void evaluate_is_in_param_array_of_strings()
        {
            ((string)null).IsIn("a", "b", "c").ShouldBeFalse();
            "a".IsIn("a", "b", "c").ShouldBeTrue();
            "A".IsIn("a", "b", "c").ShouldBeTrue();
        }

        [TestMethod]
        public void evaluate_matches_param_array_of_strings()
        {
            ((string)null).Matches("a", "b", "c").ShouldBeFalse();
            "a".Matches("a", "b", "c").ShouldBeTrue();
            "A".Matches("a", "b", "c").ShouldBeFalse();
        }

        [TestMethod]
        public void collapse_spaces()
        {
            ((string)null).CollapseSpaces().ShouldEqual(string.Empty);
            "Just  Read  The  Instructions".CollapseSpaces().ShouldEqual("Just Read The Instructions");
        }
    }
}
