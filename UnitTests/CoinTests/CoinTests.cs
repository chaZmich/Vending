using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VendingMachine.Vending;
using Moq;
using VendingDevice = VendingMachine.Vending.VendingMachine;
using VendingMachine.Products;
using VendingMachine.Finance;
using VendingMachine.Dependency;

namespace UnitTests
{
    [TestClass]
    public class CoinTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CoinsInsertNotSupported()
        {
            var mockProducts = new Mock<IProductLibrary>(0);
            var mockMoney = new Mock<IMoneyHolder>();
            var mock = new Mock<VendingDevice>("test",mockProducts.Object, mockMoney.Object);
            mock.Object.InsertCoin(new Money() { Euros = 7 });
        }

        [TestMethod]
        public void CoinsGetBackFromEmpty()
        {
            var mockProducts = new Mock<IProductLibrary>(0);
            var mockMoney = new Mock<IMoneyHolder>();
            var mock = new Mock<VendingDevice>("test",  mockProducts.Object, mockMoney.Object);
            var result = mock.Object.ReturnMoney();
            Assert.IsTrue(result.Euros == 0);
            Assert.IsTrue(result.Cents == 0);
        }

        [TestMethod]
        public void CoinsGetBackMoreThanHave()
        {
            var mockProducts = new Mock<IProductLibrary>(0);
            var mock = new Mock<VendingDevice>("test", mockProducts.Object, DependencyFactory.Resolve<MoneyHolder>());
            mock.Object.InsertCoin(new Money() { Cents = 5 });// TODO check test. probably need another way           
            var result = mock.Object.ReturnMoney();
            Assert.IsTrue(result.Euros == 0);
            Assert.IsTrue(result.Cents == 5);
        }

        [TestMethod]
        public void CoinsGetRemainder()
        {
            var mockProducts = new Mock<IProductLibrary>(0);
            var mockMoney = new Mock<IMoneyHolder>();
            var mock = new Mock<VendingDevice>("test", mockProducts.Object, mockMoney.Object);
            mock.Object.ReturnMoney();
        }
    }
}
