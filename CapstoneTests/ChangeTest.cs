using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone.Classes;

namespace CapstoneTests
{
    [TestClass]
    public class ChangeTest
    {

        [TestMethod]
        public void TestWith200Cents()
        {
            Change newChange = new Change(200);
            Assert.AreEqual(8, newChange.Quarters);
        }

        [TestMethod]
        public void TestWith240Cents()
        {
            Change newChange = new Change(240);
            Assert.AreEqual(1, newChange.Dimes);
        }

        [TestMethod]
        public void TestWith205Cents()
        {
            Change newChange = new Change(205);
            Assert.AreEqual(1, newChange.Nickels);
        }


        public void Will35CentsReturn1QAnd1Dime()
        {
            Change thirtyFive = new Change(35);

            Assert.AreEqual(1, thirtyFive.Quarters);
            Assert.AreEqual(1, thirtyFive.Dimes);
        }

        [TestMethod]
        public void Will1Dollar65CentsCentReturn1QAnd1Dime()
        {
            Change one65 = new Change(165);

            Assert.AreEqual(6, one65.Quarters);
            Assert.AreEqual(1, one65.Dimes);
            Assert.AreEqual(1, one65.Nickels);

        }
    }
}
    
