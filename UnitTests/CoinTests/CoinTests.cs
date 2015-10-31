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
        public void CoinsInsertAddedToBuffer()
        {
            var mock = new Mock<VendingDevice>("test", 1);
            mock.Object.InsertCoin(new Money() { Euros = 1 });
            Assert.IsTrue(mock.Object.OrderBuffer.Euros == 1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CoinsInsertNotSupported()
        {
            var mock = new Mock<VendingDevice>("test", 1);
            mock.Object.InsertCoin(new Money() { Euros = 7 });
        }

        [TestMethod]
        public void CoinsGetBackFromEmpty()
        {
            var mock = new Mock<VendingDevice>("test", 1);
            var result = mock.Object.ReturnMoney();
            Assert.IsTrue(result.Euros == 0);
            Assert.IsTrue(result.Cents == 0);
        }

        [TestMethod]
        public void CoinsGetBackMoreThanHave()
        {
            var mock = new Mock<VendingDevice>("test", 1);
            mock.Object.InsertCoin(new Money() { Cents = 5 });// TODO check test. probably need another way           
            var result = mock.Object.ReturnMoney();
            Assert.IsTrue(result.Euros == 0);
            Assert.IsTrue(result.Cents == 5);
        }

        [TestMethod]
        public void CoinsGetRemainder()
        {
            var mock = new Mock<VendingDevice>("test", 1);
            mock.Object.ReturnMoney();
        }
    }
}
