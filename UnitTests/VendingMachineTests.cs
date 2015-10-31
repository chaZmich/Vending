using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VendingMachine.Vending;
using Moq;
using VendingDevice = VendingMachine.Vending.VendingMachine;

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
        public void test1()
        {
            var mock = new Mock<VendingDevice>();
            Assert.IsFalse(mock.Object.Manufacturer == String.Empty);
        }
    }
}
