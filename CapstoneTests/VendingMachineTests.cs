using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone.Classes;
using System.Collections.Generic;

namespace CapstoneTests
{
    [TestClass]
    public class VendingMachineTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            VendingMachine x = new VendingMachine();
            x.FeedMoney(500);
            x.Purchase("A1");
            //Dictionary<string, List<VendingMachineItem>> inventory = new InventoryFileDAL("vendingmachine.csv").GetInventory(); 

       // VendingMachineItem y = inventory["A1"][0];

            Assert.AreEqual(4, x.GetQuantityRemaining("A1"));
            x.Purchase("A1");
            Assert.AreEqual(3, x.GetQuantityRemaining("A1"));

        }


    }
}
