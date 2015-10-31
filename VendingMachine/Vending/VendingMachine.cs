﻿using System;
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
        private Money _orderBuffer = new Money();

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
            throw new NotImplementedException();
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
                return _orderBuffer;
            }
            set
            {
                _orderBuffer = value;
            }
        }
    }
}
