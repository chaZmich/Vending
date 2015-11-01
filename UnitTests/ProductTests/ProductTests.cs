using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VendingMachine.Vending;
using Moq;
using VendingDevice = VendingMachine.Vending.VendingMachine;
using VendingMachine.Products;
using System.Collections.Generic;
using VendingMachine.Dependency;
using Microsoft.Practices.Unity;
using VendingMachine.Finance;

namespace UnitTests
{
    [TestClass]
    public class ProductTests : TestBase
    {       
        [TestMethod]
        public void AddProductIncreasingTotal()
        {
            var library = InitProductLibraryBinding(5);
            var mock = new Mock<VendingDevice>("test", library, InitMoneyHolderMock());
            var products =  mock.Object.Products.Length;
            library.AddProduct(new Product());
            Assert.IsTrue(mock.Object.Products.Length == products + 1);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void AddProductOverMaximumCapacity()
        {
            var library = InitProductLibraryBinding(0);
            var mock = new Mock<VendingDevice>("test", library, InitMoneyHolderMock());
            library.AddProduct(new Product());
        }

        [TestMethod]
        public void RemoveProductDecreasingTotal()
        {
            var library = InitProductLibraryMock(1);
            var mock = new Mock<VendingDevice>("test", library, InitMoneyHolderMock());
            mock.Object.Products = new Product[] {new Product() {Available = 2}};
            library.RemoveProduct(1);
            Assert.IsTrue(mock.Object.Products.Length == 0);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void RemoveProductFromEmptyProductsCausesException()
        {
            var library = InitProductLibraryBinding(0);
            var mock = new Mock<VendingDevice>("test", library, InitMoneyHolderMock());
            library.RemoveProduct(1);
        }

        [TestMethod]
        public void ProductOrderedDecreaseTotal()
        {
            var mock = new Mock<VendingDevice>("test", InitProductLibraryBinding(2), InitMoneyHolderMock());
            mock.Object.Products = new Product[] { new Product() {Available = 2} };
            mock.Object.Buy(1);
            Assert.IsTrue(mock.Object.Products[0].Available == 1);
        }


        [TestMethod]
        public void ProductOrderedSavesCoins()
        {
            var mock = new Mock<VendingDevice>("test", InitProductLibraryBinding(1), InitMoneyHolderBinding());
            mock.Object.Products = new Product[] { new Product() {Available = 5, Price = new Money() {Euros = 1, Cents = 10}}};
            mock.Object.InsertCoin(new Money() { Cents = 10, Euros = 1 });
            mock.Object.Buy(1);
            Assert.IsTrue(mock.Object.Amount.Euros == 1);
            Assert.IsTrue(mock.Object.Amount.Cents == 10);
        }


        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void ProductOrderedNotExistingProduct()
        {
            var mock = new Mock<VendingDevice>("test", InitProductLibraryMock(1), InitMoneyHolderMock());
            mock.Object.Products = new Product[] { new Product() };
            mock.Object.Buy(-999);
        }
    }
}
