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
    public class ProductTests
    {       
        [TestMethod]
        public void AddProductIncreasingTotal()
        {
            var mockMoney = new Mock<IMoneyHolder>();
            var library = DependencyFactory.Resolve<ProductLibrary>(new ParameterOverride("productCapacity", 5));
            var mock = new Mock<VendingDevice>("test", library, mockMoney.Object);
            var products =  mock.Object.Products.Length;
            library.AddProduct(new Product());
            Assert.IsTrue(mock.Object.Products.Length == products + 1);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void AddProductOverMaximumCapacity()
        {
            var library = DependencyFactory.Resolve<ProductLibrary>(new ParameterOverride("productCapacity", 0));
            var mockMoney = new Mock<IMoneyHolder>();
            var mock = new Mock<VendingDevice>("test", library, mockMoney.Object);
            library.AddProduct(new Product());
        }

        [TestMethod]
        public void RemoveProductDecreasingTotal()
        {
            var mockMoney = new Mock<IMoneyHolder>();
            var products = DependencyFactory.Resolve<ProductLibrary>(new ParameterOverride("productCapacity", 1));
            var mock = new Mock<VendingDevice>("test", products, mockMoney.Object);
            mock.Object.Products = new Product[] {new Product()};
            products.RemoveProduct(1);
            Assert.IsTrue(mock.Object.Products.Length == 0);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void RemoveProductFromEmptyProductsCausesException()
        {
            var products = DependencyFactory.Resolve<ProductLibrary>(new ParameterOverride("productCapacity", 0));
            var mockMoney = new Mock<IMoneyHolder>();
            var mock = new Mock<VendingDevice>("test", products, mockMoney.Object);
            products.RemoveProduct(1);
        }

        [TestMethod]
        public void ProductOrderedDecreaseTotal()
        {
            var mockMoney = new Mock<IMoneyHolder>();
            var products = DependencyFactory.Resolve<ProductLibrary>(new ParameterOverride("productCapacity", 2));
            var mock = new Mock<VendingDevice>("test", products, mockMoney.Object);
            mock.Object.Products = new Product[] { new Product() };
            mock.Object.Buy(1);
            Assert.IsTrue(mock.Object.Products.Length == 0);
        }


        [TestMethod]
        public void ProductOrderedSavesCoins()
        {
            var products = DependencyFactory.Resolve<ProductLibrary>(new ParameterOverride("productCapacity", 1));
            var mock = new Mock<VendingDevice>("test", products,
                DependencyFactory.Resolve<MoneyHolder>());
            mock.Object.Products = new Product[] { new Product() {Price = new Money() {Euros = 1, Cents = 10}}};
            mock.Object.InsertCoin(new Money() { Cents = 10, Euros = 1 });
            mock.Object.Buy(1);
            Assert.IsTrue(mock.Object.Amount.Euros == 1);
            Assert.IsTrue(mock.Object.Amount.Cents == 10);
        }


        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void ProductOrderedNotExistingProduct()
        {
            var mockMoney = new Mock<IMoneyHolder>();
            var products = DependencyFactory.Resolve<ProductLibrary>(new ParameterOverride("productCapacity", 1));
            var mock = new Mock<VendingDevice>("test", products, mockMoney.Object);
            mock.Object.Products = new Product[] { new Product() };
            mock.Object.Buy(-999);
        }
    }
}
