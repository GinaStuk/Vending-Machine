using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Capstone.Classes;

namespace CapstoneTests
{
    [TestClass]
    public class VendingMachineTest
    {
        [TestMethod]
        public void VMTest_SeeIfVMIsEmpty()
        {
            VendingMachine test = new VendingMachine();

            Assert.AreEqual(0, test.GetInventory().Count);

        }

        [TestMethod]
        public void VMTest_SeeIfVMIsStocked()
        {
            VendingMachine test = new VendingMachine();
            Dictionary<string, Inventory> testStock = new Dictionary<string, Inventory>();
            VMItem testItem = new VMItem("iceCream", 200);
            Inventory testInventory = new Inventory(testItem, 5);
            testStock.Add("D1", testInventory);

            test.Stock(testStock);

            Assert.AreEqual(1, test.GetInventory().Count);
        }
        [TestMethod]
        public void VMFeedMoney_ReturnCurrentBalance()
        {
            VendingMachine test = new VendingMachine();
            test.FeedMoney(500);
            Assert.AreEqual(500, test.CurrentBalance);
        }

        [TestMethod]
        public void VMFeedMoney_ReturnChange()
        {
            VendingMachine test = new VendingMachine();
            test.FeedMoney(500);
            test.ReturnChange();
            Assert.AreEqual(0, test.CurrentBalance);
        }

        [TestMethod]
        public void VMTest_PurchasingItem()
        {
            //building VM
            VendingMachine test = new VendingMachine();
            //Stocking VM
            Dictionary<string, Inventory> testStock = new Dictionary<string, Inventory>();
            VMItem testItem = new VMItem("iceCream", 200);
            Inventory testInventory = new Inventory(testItem, 5);

            //Act
            //Feeding money
            testStock.Add("D1", testInventory);
            test.Stock(testStock);
            test.FeedMoney(500);
            VMItem boughtItem = test.Purchase("D1");

            Assert.AreEqual(4, test.GetInventory()["D1"].Quantity);
            Assert.AreEqual(300, test.CurrentBalance);
            Assert.AreEqual("iceCream",boughtItem.Name);
        }
    }
}
