using Crosscutter.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Should;
using System;

namespace Crosscutter.Test.Extensions
{
    [TestClass]
    public class GenericExtensionsShould
    {
        [TestMethod]
        public void evaluate_is_in_generic_params_array()
        {
            ((DateTime?)null).IsIn(DateTime.Today).ShouldBeFalse();
            1.IsIn(1, 2, 3).ShouldBeTrue();
            100m.IsIn(200m, 300m, 400m).ShouldBeFalse();
        }
    }
}