using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.Finance
{
    /// <summary>
    /// General inteface for money holder for vending 
    /// </summary>
    public interface IMoneyHolder
    {
        /// <summary>
        /// Get accounted - already saved amount of money
        /// </summary>
        /// <returns></returns>
        Money GetAccountedAmount();

        /// <summary>
        /// Get buffered money amount. Buffered but not saved to account
        /// </summary>
        /// <returns></returns>
        Money GetBufferedAmount();

        /// <summary>
        /// Sets accounted amount of money
        /// </summary>
        void SetAccountedAmount(Money amount);

        /// <summary>
        /// Sets buffered amount of money
        /// </summary>
        void SetBuffedAmount(Money amount);

        /// <summary>
        /// Add amount of money to the account
        /// </summary>
        /// <param name="money">Money to add</param>
        void AddAccountedAmount(Money money);

        /// <summary>
        /// Substract amount from account
        /// </summary>
        /// <param name="money">Amount to substract</param>
        void SubstractAccounterAmount(Money money);

        /// <summary>
        /// Add amount to buffered account
        /// </summary>
        /// <param name="money">Amount to add</param>
        void AddBufferedAmount(Money money);

        /// <summary>
        /// Substract amount from buffered account
        /// </summary>
        /// <param name="money">Amount to substract</param>
        void SubstractBufferedAmount(Money money);
    }
}
