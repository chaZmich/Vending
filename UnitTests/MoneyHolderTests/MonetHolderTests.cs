using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VendingMachine.Vending;
using Moq;
using VendingDevice = VendingMachine.Vending.VendingMachine;
using VendingMachine.Products;
using VendingMachine.Finance;
using VendingMachine.Dependency;

namespace UnitTests.MoneyHolderTests
{
    [TestClass]
    public class MonetHolderTests : TestBase
    {
        [TestMethod]
        public void SettingBufferedSetsBuffered()
        {
            var holder = InitMoneyHolderBinding();
            holder.SetBuffedAmount(new Money() { Euros = 1, Cents = 5 });
            Assert.IsTrue(holder.GetBufferedAmount().Cents == 5);
            Assert.IsTrue(holder.GetBufferedAmount().Euros == 1);
        }

        [TestMethod]
        public void SettingAccountedSetsAccounted()
        {
            var holder = InitMoneyHolderBinding();
            holder.SetAccountedAmount(new Money() { Euros = 1, Cents = 5 });
            Assert.IsTrue(holder.GetAccountedAmount().Cents == 5);
            Assert.IsTrue(holder.GetAccountedAmount().Euros == 1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void RemovingMoveBufferedThatHaveCausesError()
        {
            var holder = InitMoneyHolderBinding();
            holder.SubstractBufferedAmount(new Money() { Euros = 5 });
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void RemovingMoveAccountedThatHaveCausesError()
        {
            var holder = InitMoneyHolderBinding();
            holder.SubstractAccounterAmount(new Money() { Euros = 5 });
        }


        
    }
}
