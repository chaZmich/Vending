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
        private string  _manufacturer = String.Empty;
        private int     _productCapacity = 0;
        private Money   _amount = new Money();
        private Product[] _products = new Product[0];
        private Money   _orderBuffer = new Money();

        /// <summary>
        /// Vending machine constructor.
        /// </summary>
        /// <param name="manufacturer">Manufacturer name for the machine</param>
        /// <param name="productCapacity">Maximum product capacity for the machine</param>
        public VendingMachine(string manufacturer, int productCapacity)
        {
            _manufacturer = manufacturer;
            _productCapacity = productCapacity;
        }

        /// <summary>
        /// Do not allow creating vending machines without manufacturer set
        /// So hiding default constructor
        /// </summary>
        private VendingMachine()
        {

        }

        /// <summary>
        /// Vending machine manufacturer
        /// </summary>
        public string Manufacturer
        {
            get { return _manufacturer; }
        }

        /// <summary>
        /// Vending machine amount of available money
        /// </summary>
        public Money Amount
        {
            get { return _amount; }
        }

        /// <summary>
        /// List of products available for ordering
        /// </summary>
        public Product[] Products
        {
            get
            {
                return _products;
            }
            set
            {
                _products = value;
            }
        }

        /// <summary>
        /// Inserting coints to the machine. Saving them in order buffer
        /// </summary>
        /// <param name="amount">Amount of coins inserted</param>
        /// <returns></returns>
        public Money InsertCoin(Money amount)
        {
            //TODO add validation for inserted coins
            _orderBuffer.Euros += amount.Euros;
            _orderBuffer.Cents += amount.Cents;
            //TODO also check overflows with cents
            return _orderBuffer;
        }

        /// <summary>
        /// Return all inserted coins
        /// </summary>
        /// <returns>Amount of coins inserted before</returns>
        public Money ReturnMoney()
        {
            return _orderBuffer;
        }

        /// <summary>
        /// Buy product and move buffered coins to saved amount
        /// </summary>
        /// <param name="productNumber">Ordered product id</param>
        /// <returns>Ordered product</returns>
        public Product Buy(int productNumber)
        {
            if (_products.Length >= productNumber)
            {
                var product = _products[productNumber-1];
                var listedProducts = new List<Product>(_products);
                listedProducts.RemoveAt(productNumber - 1);
                _products = listedProducts.ToArray();
                // processing money
                _amount.Euros = _orderBuffer.Euros;
                _amount.Cents = _orderBuffer.Cents;
                _orderBuffer = new Money();
                //
                return product;
                //TODO remove monew and capacity
            }
            else
            {
                throw new IndexOutOfRangeException("Product does not exist");
            }
        }

        /// <summary>
        /// Maximum product capacity
        /// </summary>
        public int ProductCapacity
        {
            get { return _productCapacity; }
        }

        public void AddProduct(Product newProduct)
        {
            if (_products.Length < _productCapacity)
            {
                //dirty adding. Need to add method to add, decrease and update products. Thread safety !!
                var initialProducts = _products.Length;
                Array.Resize(ref _products, initialProducts + 1);
            }
            else
            {
                throw new IndexOutOfRangeException("Product capacity limited");
            }
        }

        public void RemoveProduct(int productId)
        {
            if (_products.Length > 0)
            {
                var product = _products[productId - 1];
                var listedProducts = new List<Product>(_products);
                listedProducts.RemoveAt(productId - 1);
                _products = listedProducts.ToArray();
            }
            else
            {
                throw new IndexOutOfRangeException("Product does not exists");
            }
            
        }

        public Money OrderBuffer
        {
            get
            {
                return _orderBuffer;
            }
        }
    }
}
