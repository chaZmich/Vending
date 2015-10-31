﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.Helpers;
using VendingMachine.Products;
using VendingMachine.Finance;

namespace VendingMachine.Vending
{
    /// <summary>
    /// Vending machine basic implementation
    /// </summary>
    public class VendingMachine : ISupportedVendingMachine
    {
        private string  _manufacturer = String.Empty;
        private int     _productCapacity = 0;
        
        private IProductLibrary _library;
        private IMoneyHolder _moneyHolder;

        /// <summary>
        /// One lock object for entire machine. To ensure single access to machine properties
        /// </summary>
        private Object _lockObject = new Object();

        /// <summary>
        /// Vending machine constructor.
        /// </summary>
        /// <param name="manufacturer">Manufacturer name for the machine</param>
        /// <param name="productCapacity">Maximum product capacity for the machine</param>
        public VendingMachine(string manufacturer, int productCapacity, IProductLibrary library,
                    IMoneyHolder moneyHolder)
        {
            _manufacturer = manufacturer;
            _productCapacity = productCapacity;
            _library = library;
            _moneyHolder = moneyHolder;
        }

        /// <summary>
        /// Do not allow creating vending machines without manufacturer and capacity set
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
            get { return _moneyHolder.GetAccountedAmount(); }
        }

        /// <summary>
        /// List of products available for ordering
        /// </summary>
        public Product[] Products
        {
            get
            {
                return _library.GetProducts();
            }
            set
            {
                _library.SetProducts(new List<Product>(value));
            }
        }

        /// <summary>
        /// Inserting coints to the machine. Saving them in order buffer
        /// </summary>
        /// <param name="amount">Amount of coins inserted</param>
        /// <returns></returns>
        public Money InsertCoin(Money amount)
        {
            if (!MoneyHelper.ValidateInsertedCoin(amount))
            {
                throw new ArgumentException("Coin not supported");
            }
            var _backedBuffer = _moneyHolder.GetBufferedAmount();
            try
            {
                _moneyHolder.AddBufferedAmount(amount);
                return _moneyHolder.GetBufferedAmount();
            }
            catch (Exception ex)
            {
                // in case of calculation failed revert buffer to previous state
                // and throw exception
                _moneyHolder.SetBuffedAmount(_backedBuffer);
                throw ex;
            }
        }

        /// <summary>
        /// Return all inserted coins
        /// </summary>
        /// <returns>Amount of coins inserted before</returns>
        public Money ReturnMoney()
        {
            return _moneyHolder.GetBufferedAmount();
        }

        /// <summary>
        /// Buy product and move buffered coins to saved amount
        /// </summary>
        /// <param name="productNumber">Ordered product id</param>
        /// <returns>Ordered product</returns>
        public Product Buy(int productNumber)
        {
            if (Products.Length >= productNumber)
            {
                var backedProducts = Products;
                var product = Products[productNumber - 1];
                try
                {
                    RemoveProduct(productNumber);
                }
                catch (Exception ex)
                {
                    Products = backedProducts;
                    throw ex;
                }

                var backedAmount = _moneyHolder.GetAccountedAmount();
                var backedOrder = _moneyHolder.GetBufferedAmount();
                try
                {
                    // processing money
                    _moneyHolder.AddAccountedAmount(product.Price);
                    _moneyHolder.SubstractBufferedAmount(product.Price);
                    return product;
                }
                catch (Exception ex)
                {
                    //in case of any problems with money calculation
                    //revert all transactions and revert product status
                    Products = backedProducts;
                    _moneyHolder.SetAccountedAmount(backedAmount);
                    _moneyHolder.SetBuffedAmount(backedOrder);
                    throw ex;
                }
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
            if (Products.Length < _productCapacity)
            {
                var backedProducts = Products;
                try
                {
                    /// since product list can be be updated in ANY TIME (according to task)
                    /// need to ensure it is only changed by one code in a time
                    /// This will help avoid ordering a product being changed or deleted
                    lock (_lockObject)
                    {
                        _library.AddProduct(newProduct);
                    }
                }
                catch (Exception ex)
                {
                    // revert any changes to products before sending ex further
                    Products = backedProducts;
                    throw ex;
                }
            }
            else
            {
                throw new IndexOutOfRangeException("Product capacity limited");
            }
        }

        public void RemoveProduct(int productId)
        {
            if (Products.Length > 0)
            {
                var backedProducts = Products;
                try
                {
                    /// since product list can be be updated in ANY TIME (according to task)
                    /// need to ensure it is only changed by one code in a time
                    /// This will help avoid ordering a product being changed or deleted
                    lock (_lockObject) 
                    {
                        _library.RemoveProduct(productId);
                    }
                }
                catch (Exception ex)
                {
                    // revert any changes to products before sending ex further
                    Products = backedProducts;
                    throw ex;
                }
            }
            else
            {
                throw new IndexOutOfRangeException("Product does not exists");
            }
            
        }
    }
}
