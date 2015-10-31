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
    public class VendingMachine : ISupportedVendingMachine
    {
        public VendingMachine(string manufacturer, int productCapacity)
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

        public int ProductCapacity
        {
            get { throw new NotImplementedException(); }
        }

        public void AddProduct(Product newProduct)
        {
            //dirty adding. Need to add method to add, decrease and update products. Thread safety !!
            //var initialProducts = products.GetLength(1);
            //Array.Resize(ref products, initialProducts + 1);
            //mock.Object.Products = products;
            throw new NotImplementedException();
        }

        public void RemoveProduct(int productId)
        {
            throw new NotImplementedException();
        }

        public Money OrderBuffer
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
    }
}
