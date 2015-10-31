using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.Finance
{
    public class MoneyHolderBase : IMoneyHolder
    {
        #region private fields
        /// <summary>
        /// Saved and accounted money
        /// </summary>
        private Money _account;
        /// <summary>
        /// Buffered and not saved amount
        /// </summary>
        private Money _bufferedAccount; 
        #endregion


        #region public properties
        /// <summary>
        /// Gets accounted money
        /// </summary>
        /// <returns>Accounted Money</returns>
        public Money GetAccountedAmount()
        {
            return _account;
        }

        /// <summary>
        /// Get buffered amount of money
        /// </summary>
        /// <returns>Buffered amount of money</returns>
        public Money GetBufferedAmount()
        {
            return _bufferedAccount;
        }

        /// <summary>
        /// Sets accounted money
        /// </summary>
        /// <param name="amount">Amount to set</param>
        public void SetAccountedAmount(Money amount)
        {
            _account = amount;
        }

        /// <summary>
        /// Sets buffered amount of money
        /// </summary>
        /// <param name="amount">Amount to set</param>
        public void SetBuffedAmount(Money amount)
        {
            _bufferedAccount = amount;
        }

        /// <summary>
        /// Add amount of money to the account
        /// </summary>
        /// <param name="money">Money to add</param>
        public void AddAccountedAmount(Money money)
        {
            _account += money;
        }

        /// <summary>
        /// Substract amount from account
        /// </summary>
        /// <param name="money">Amount to substract</param>
        public void SubstractAccounterAmount(Money money)
        {
            _account -= money;
        }

        /// <summary>
        /// Add amount to buffered account
        /// </summary>
        /// <param name="money">Amount to add</param>
        public void AddBufferedAmount(Money money)
        {
            _bufferedAccount += money;
        }

        /// <summary>
        /// Substract amount from buffered account
        /// </summary>
        /// <param name="money">Amount to substract</param>
        public void SubstractBufferedAmount(Money money)
        {
            _bufferedAccount -= money;
        } 
        #endregion
    }
}
