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
    public class VendingMachineTests : TestBase
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
            var mock = new Mock<VendingDevice>("test", InitProductLibraryMock(0), InitMoneyHolderMock());
            Assert.IsFalse(mock.Object.Manufacturer == String.Empty);
        }
    }
}
