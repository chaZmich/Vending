using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.Vending;

namespace VendingMachine.Helpers
{
    public static class MoneyHelper
    {
        static List<int> SupportedCentCoins = new List<int>() { 5, 10, 20, 50 };
        static List<int> SupportedEuroCoins = new List<int>() { 1, 2 };
        
        /// <summary>
        /// Simple validation for coin values. 
        /// </summary>
        /// <param name="money">Added amount of money</param>
        /// <returns>True coin is supported</returns>
        public static Boolean ValidateInsertedCoin(Money money)
        {
            if (money.Euros > 0)
            {
                return SupportedEuroCoins.Contains(money.Euros);
            }
            else if (money.Cents > 0)
            {
                return SupportedCentCoins.Contains(money.Cents);
            }
            else
            {
                throw new Exception("Invalid money amout");
            }
        }
    }
}
