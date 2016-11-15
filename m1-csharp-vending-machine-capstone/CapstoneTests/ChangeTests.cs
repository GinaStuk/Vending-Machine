using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone.Classes;

namespace CapstoneTests
{
    [TestClass]
    public class ChangeTests
    {
        [TestMethod]
        public void Change_GivenNewChangeAmount_ReturnQuartersDimesNickels()
        {
            
            Change c = new Change(175);

            Assert.AreEqual(c.Quarter, 7);
            Assert.AreEqual(c.Dimes, 0);
            Assert.AreEqual(c.Nickel, 0);
        }

        [TestMethod]
        public void Change_GivenNewChangeAmount_ReturnQuartersDimesNickels2()
        {

            Change c = new Change(140);

            Assert.AreEqual(c.Quarter, 5);
            Assert.AreEqual(c.Dimes, 1);
            Assert.AreEqual(c.Nickel, 1);
        }
    }
}
