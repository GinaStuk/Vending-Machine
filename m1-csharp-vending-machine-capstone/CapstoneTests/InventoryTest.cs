using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone.Classes;

namespace CapstoneTests
{
    [TestClass]
    public class InventoryTest
    {
        [TestMethod]
        public void Inventory_GivenItemAndQuantity_ReturnCorrectValues()
        {
            VMItem test1 = new VMItem("ice cream", 300);
            Inventory test2 = new Inventory(test1, 3);
            Assert.AreEqual(test1.Name, "ice cream");
            Assert.AreEqual(test1.Price, 300);
            Assert.AreEqual(test2.Quantity, 3);

        }
    }
}
