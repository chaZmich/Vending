using Microsoft.Practices.Unity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using VendingMachine.Dependency;
using VendingMachine.Finance;
using VendingMachine.Products;
using VendingMachine.Vending;
using VendingDevice = VendingMachine.Vending.VendingMachine;

namespace UnitTests
{
    /// <summary>
    /// Base tests class with common init methods
    /// </summary>
    public abstract class TestBase
    {
        /// <summary>
        /// Base initiation logic for money holder mock
        /// </summary>
        /// <returns>Mocked money holder</returns>
        public IMoneyHolder InitMoneyHolderMock()
        {
            return new Mock<IMoneyHolder>().Object;
        }

        /// <summary>
        /// Base initiation logic for product library
        /// </summary>
        /// <param name="capacity"></param>
        /// <returns></returns>
        public IProductLibrary InitProductLibraryMock(int capacity)
        {
            var result = new Mock<IProductLibrary>().Object;
            result.ProductCapacity = capacity;
            return result;
        }

        /// <summary>
        /// Init product library with dependency factory
        /// </summary>
        /// <param name="capacity">Maximum library capacity</param>
        /// <returns>Resolved product library object</returns>
        public IProductLibrary InitProductLibraryBinding(int capacity)
        {
            return DependencyFactory.Resolve<ProductLibrary>(new ParameterOverride("productCapacity", capacity));
        }

        /// <summary>
        /// Init noney holder with dependency factory
        /// </summary>
        /// <returns>Resolved money holder object</returns>
        public IMoneyHolder InitMoneyHolderBinding()
        {
            return DependencyFactory.Resolve<MoneyHolder>();
        }
    }
}
