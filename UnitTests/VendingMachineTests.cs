using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VendingMachine.Vending;
using Moq;
using VendingDevice = VendingMachine.Vending.VendingMachine;
using VendingMachine.Products;
using VendingMachine.Finance;

namespace UnitTests
{
    [TestClass]
    public class VendingMachineTests
    {
        [TestMethod]
        public void BasicTest()
        {
            var mock = new Mock<IVendingMachine>();

            mock.Setup(framework => framework.ReturnMoney())
                .Returns(new Money());
            
            Assert.AreEqual(mock.Object.ReturnMoney(), new Money());
        }

        [TestMethod]
        public void NewMachineNotEmptyManufacturer()
        {
            var mockMoney = new Mock<IMoneyHolder>();
            var mockProducts = new Mock<IProductLibrary>(0);
            var mock = new Mock<VendingDevice>("test", mockProducts.Object, mockMoney.Object);
            Assert.IsFalse(mock.Object.Manufacturer == String.Empty);
        }
    }
}
