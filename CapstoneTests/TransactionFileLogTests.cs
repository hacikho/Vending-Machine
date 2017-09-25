using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone.Classes;

namespace CapstoneTests
{
    [TestClass]
    public class TransactionFileLogTests
    {
        TransactionFileLog newObject;
        VendingMachine vm;
        [TestInitialize]
        public void Initialize()
        {
            vm = new VendingMachine();
            newObject = new TransactionFileLog("Log.txt");
        }

        [TestMethod]
        public void TestMethod1()
        {
            vm.FeedMoney(2);
            newObject.RecordDeposit(2,2);
            Assert.AreEqual()
        }
    }
}
