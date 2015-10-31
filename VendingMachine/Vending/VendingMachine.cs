using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.Vending
{
    /// <summary>
    /// Vending machine basic implementation
    /// </summary>
    public class VendingMachine : IVendingMachine
    {
        public VendingMachine(string manufacturer)
        {

        }

        /// <summary>
        /// Do not allow creating vending machines without manufacturer set
        /// So hiding default constructor
        /// </summary>
        private VendingMachine()
        {

        }

        public string Manufacturer
        {
            get { throw new NotImplementedException(); }
        }

        public Money Amount
        {
            get { throw new NotImplementedException(); }
        }

        public Product[] Products
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public Money InsertCoin(Money amount)
        {
            throw new NotImplementedException();
        }

        public Money ReturnMoney()
        {
            throw new NotImplementedException();
        }

        public Product Buy(int productNumber)
        {
            throw new NotImplementedException();
        }
    }
}
