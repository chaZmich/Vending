using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.Vending
{
    public struct Money
    {
        public int Euros { get; set; }
        public int Cents { get; set; }

        /// <summary>
        /// Overload + operator to properly calculate cent overflow
        /// </summary>
        /// <param name="addition1">First amount</param>
        /// <param name="addition2">Second amount</param>
        /// <returns>Calculated result</returns>
        public static Money operator + (Money addition1, Money addition2)
        {
            var result = new Money();
            result.Euros = addition1.Euros + addition2.Euros;
            result.Cents = addition1.Cents + addition2.Cents;
            if (result.Cents >= 100)
            {
                result.Euros += 1;
                result.Cents = 100 - result.Cents;
            }
            return result;
        }

        /// <summary>
        /// Overload - operator to properly calculate cent overflow
        /// </summary>
        /// <param name="substraction1">First element</param>
        /// <param name="substraction2">Second element</param>
        /// <returns>Calculated result</returns>
        public static Money operator -(Money substraction1, Money substraction2)
        {
            var result = new Money();
            result.Euros = substraction1.Euros - substraction2.Euros;
            result.Cents = substraction1.Cents - substraction2.Cents;
            if (result.Cents < 0)
            {
                result.Euros -= 1;
                result.Cents = 100 + result.Cents;
            }
            if (result.Euros < 0)
            {
                throw new ArgumentOutOfRangeException("Not enough money on balance");
            }
            return result;
        }
    }
}
