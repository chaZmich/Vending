﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VendingMachine.Vending;
using Moq;
using VendingDevice = VendingMachine.Vending.VendingMachine;

namespace UnitTests
{
    [TestClass]
    public class ProductTests
    {       
        [TestMethod]
        public void AddProductIncreasingTotal()
        {
            var mock = new Mock<VendingDevice>("test",1);
            var products =  mock.Object.Products.Length;
            mock.Object.AddProduct(new Product());
            Assert.IsTrue(mock.Object.Products.Length == products + 1);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void AddProductOverMaximumCapacity()
        {
            var mock = new Mock<VendingDevice>("test",0);
            mock.Object.AddProduct(new Product());
        }

        [TestMethod]
        public void RemoveProductDecreasingTotal()
        {
            var mock = new Mock<VendingDevice>("test", 1);
            mock.Object.Products = new Product[] {new Product()};
            mock.Object.RemoveProduct(1);
            Assert.IsTrue(mock.Object.Products.Length == 0);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void RemoveProductFromEmptyProductsCausesException()
        {
            var mock = new Mock<VendingDevice>("test", 1);
            mock.Object.RemoveProduct(1);
        }

        [TestMethod]
        public void ProductOrderedDecreaseTotal()
        {
            var mock = new Mock<VendingDevice>("test", 1);
            mock.Object.Products = new Product[] { new Product() };
            mock.Object.Buy(1);
            Assert.IsTrue(mock.Object.Products.Length == 0);
        }


        [TestMethod]
        public void ProductOrderedSavesCoins()
        {
            var mock = new Mock<VendingDevice>("test", 1);
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
            var mock = new Mock<VendingDevice>("test", 1);
            mock.Object.Products = new Product[] { new Product() };
            mock.Object.Buy(-999);
        }
    }
}
