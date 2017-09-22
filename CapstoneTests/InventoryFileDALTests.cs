using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone.Classes;
namespace CapstoneTests
{
    [TestClass]
    public class InventoryFileDALTests
    {
        InventoryFileDAL newObject;
        [TestInitialize]
        public void Initialize()
        {
            newObject = new InventoryFileDAL("vendingmachine.csv");

        }

        [TestMethod]
        public void TestIfFileExist()
        {
            Assert.IsNotNull(newObject);
        }

        [TestMethod]
        public void TestGetInventoryMethodToSeeTheDictionarySize()
        {
            Assert.AreEqual(16, newObject.GetInventory().Keys.Count);
        }

        [TestMethod]
        public void TestGetInventoryMethodToSeeTheDictionaryKeysObjectAmount()
        {
            Assert.AreEqual(5, newObject.GetInventory()["A1"].Count);
        }

        [TestMethod]
        public void TestGetInventoryMethodTheDictionaryKeyValueMatch()
        {
            Assert.AreEqual("Wonka Bar", newObject.GetInventory()["B3"][4].ItemName);
        }
    }
}
