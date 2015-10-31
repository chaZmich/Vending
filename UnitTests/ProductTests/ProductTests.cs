using System;
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
            var mock = new Mock<VendingDevice>("test");
            var products =  mock.Object.Products;
            //dirty adding. Need to add method to add, decrease and update products. Thread safety !!
            var initialProducts = products.GetLength(1);
            Array.Resize(ref products,initialProducts+1);
            mock.Object.Products = products;
            Assert.IsTrue(mock.Object.Products.GetLength(1) == initialProducts + 1);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void AddProductOverMaximumCapacity()
        {

        }

        [TestMethod]
        public void RemoveProductDecreasingTotal()
        {

        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void RemoveProductFromEmptyProductsCausesException()
        {

        }

        [TestMethod]
        public void ProductOrderedDecreaseTotal()
        {

        }


        [TestMethod]
        public void ProductOrderedSavesCoins()
        {

        }


        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void ProductOrderedNotExistingProduct()
        {

        }
    }
}
