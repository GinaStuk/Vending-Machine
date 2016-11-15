using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone.Classes;
namespace CapstoneTests
{
    [TestClass]
    public class VMItemTest
    {
        [TestMethod]
        public void VMItemTest_givenStringAndInt_ReturnItem()
        {
            VMItem test = new VMItem("chips" , 125);
            Assert.AreEqual(test.Name, "chips");
            Assert.AreEqual(test.Price, 125);
        }
    }
}
