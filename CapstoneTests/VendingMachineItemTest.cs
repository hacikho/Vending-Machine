using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone.Classes;

namespace CapstoneTests
{
    [TestClass]
    public class VendingMachineItemTest
    {
        [TestMethod]
        public void TetsCandyItem()
        {
            CandyItem skittles = new CandyItem("Skittles", 1.00M);
            Assert.AreEqual("Munch Munch, Yum!", skittles.Consume());
        }

        [TestMethod]
        public void TestBeverageItem()
        {
            BeverageItem pepsi = new BeverageItem("Diet pepsi", 2.00M);
            Assert.AreEqual("Glug Glug, Yum!", pepsi.Consume());

        }

        [TestMethod]
        public void TestChipItem()
        {
            ChipItem chip = new ChipItem("Lays", 2.00M);
            Assert.AreEqual("Crunch Crunch, Yum!", chip.Consume());
        }

        [TestMethod]
        public void TestGumItem()
        {
            GumItem gum = new GumItem("FreeDent", 4.00M);
            Assert.AreEqual("Chew Chew, Yum!", gum.Consume());
        }
    }

}
