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
        public static List<int> SupportedCentCoins = new List<int>() { 5, 10, 20, 50 };
        public static List<int> SupportedEuroCoins = new List<int>() { 1, 2 };
        

        /// <summary>
        /// Simple helper to properly calculate money overflow for cents
        /// </summary>
        /// <param name="initialAmount">Initial amount on money</param>
        /// <param name="addedAmount">Money amount being to be added</param>
        /// <returns>Calculated money result without cents overflow</returns>
        public static Money CalculateChange(Money initialAmount, Money addedAmount)
        {
            var result = new Money();
            result.Euros = initialAmount.Euros + addedAmount.Euros;
            result.Cents = initialAmount.Cents + addedAmount.Cents;
            if (result.Cents > 100)
            {
                result.Euros += 1;
                result.Cents = 100 - result.Cents;
            }
            return result;
        }


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
