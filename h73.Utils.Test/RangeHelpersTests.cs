using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace h73.Utils.Test
{
    [TestClass]
    public class RangeHelpersTests
    {
        [TestMethod]
        public void Range_1_5()
        {
            var range = 1.To(5);
            var expected = new[] { 1, 2, 3, 4, 5 };
            foreach (var i in range.FromStart(x => x + 1))
            {
                Assert.IsTrue(i.In(expected));
            }
        }

        [TestMethod]
        public void Range_D0_D3()
        {
            var range = DateTime.Now.Date.To(DateTime.Now.Date.AddDays(3));
            var expected = new[]
            {
                DateTime.Now.Date.AddDays(0),
                DateTime.Now.Date.AddDays(1),
                DateTime.Now.Date.AddDays(2),
                DateTime.Now.Date.AddDays(3)
            };

            foreach (var i in range.FromStart(x => x.AddDays(1)))
            {
                Assert.IsTrue(i.In(expected));
            }
        }
    }
}