using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone.Classes;

namespace CapstoneTests
{
    [TestClass]
    public class ChangeTest
    {
        [TestMethod]
        public void TestWith200Cent()
        {
            Change newChange = new Change(200);
            Assert.AreEqual(8, newChange.Quarters);
        }

        [TestMethod]
        public void TestWith240Cent()
        {
            Change newChange = new Change(240);
            Assert.AreEqual(1, newChange.Dimes);
        }
    }
}
