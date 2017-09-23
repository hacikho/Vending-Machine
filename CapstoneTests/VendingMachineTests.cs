using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone.Classes;
using System.Collections.Generic;

namespace CapstoneTests
{
    [TestClass]
    public class VendingMachineTests
    {
        VendingMachine vmObject;
        [TestInitialize]
        public void Initialize()
        {
            vmObject = new VendingMachine();

        }
        [TestMethod]
        public void TestPurchaseMethod()
        {
            vmObject.FeedMoney(500);
            vmObject.Purchase("A1");
            Assert.AreEqual(4, vmObject.GetQuantityRemaining("A1"));
            vmObject.Purchase("A1");
            Assert.AreEqual(3, vmObject.GetQuantityRemaining("A1"));

        }

        [TestMethod]
        public void TestFeedMoneyMethod()
        {
            vmObject.FeedMoney(500);
            Assert.AreEqual("500", vmObject.CurrentBalance);
        }

        [TestMethod]
        public void TestReturnChangeMethod()
        {
            vmObject.FeedMoney(600);
            vmObject.Purchase("D1");
            Assert.AreEqual(0, vmObject.ReturnChange());
            
        }
    }
}
