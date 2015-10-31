using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VendingMachine.Vending;
using Moq;
using VendingDevice = VendingMachine.Vending.VendingMachine;

namespace UnitTests
{
    [TestClass]
    public class CoinTests
    {
        [TestMethod]
        public void CoinsInsertAddedToAmount()
        {

        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void CoinsInsertNotSupported()
        {

        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void CoinsGetBackFromEmpty()
        {

        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void CoinsGetBackMoreThanHave()
        {

        }

        [TestMethod]
        public void CoinsGetRemainder()
        {

        }
    }
}
