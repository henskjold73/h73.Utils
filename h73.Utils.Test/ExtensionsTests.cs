using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace h73.Utils.Test
{
    [TestClass]
    public class ExtensionsTests
    {
        [TestMethod]
        public void IsNull_Object_Null_True()
        {
            object obj = null;

            Assert.AreEqual(true, obj.IsNull());
        }

        [TestMethod]
        public void IsNull_Object_Anon_False()
        {
            object obj = new { };

            Assert.AreEqual(false, obj.IsNull());
        }

        [TestMethod]
        public void IsNull_string_Null_True()
        {
            string obj = "";

            Assert.AreEqual(true, obj.IsNull());
        }

        [TestMethod]
        public void IsNull_string_1_False()
        {
            string obj = "1";

            Assert.AreEqual(false, obj.IsNull());
        }

        [TestMethod]
        public void In_Int_String_Enum()
        {
            Assert.AreEqual(true, 1.In(1, 2, 3));
            Assert.AreEqual(true, "test1".In("test1", "test2", "test3"));
            Assert.AreEqual(false, 4.In(1, 2, 3));
            Assert.AreEqual(false, "test4".In("test1", "test2", "test3"));
            Assert.AreEqual(true, MyEnum.A.In(MyEnum.A, MyEnum.B, MyEnum.C));
            Assert.AreEqual(false, MyEnum.D.In(MyEnum.A, MyEnum.B, MyEnum.C));
        }

        [TestMethod]
        public void Between_int()
        {
            Assert.IsTrue(2.Between(1, 3));
            Assert.IsFalse(4.Between(1, 3));
        }

        [TestMethod]
        public void Between_DateTime()
        {
            Assert.IsTrue(DateTime.Now.Between(DateTime.Now.AddHours(-1), DateTime.Now.AddHours(1)));
            Assert.IsFalse(DateTime.Now.AddHours(-2).Between(DateTime.Now.AddHours(-1), DateTime.Now.AddHours(1)));
        }
    }
}
