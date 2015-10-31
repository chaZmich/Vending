using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.Products
{
    public abstract class ProductLibraryBase : IProductLibrary
    {
        #region private fields
        private List<Product> _products = new List<Product>();

        private int _productCapacity = 0;

        /// <summary>
        /// One lock object for entire machine. To ensure single access to machine properties
        /// </summary>
        private Object _lockObject = new Object();
        #endregion


        #region CTOR
        /// <summary>
        /// Default ctor
        /// </summary>
        public ProductLibraryBase()
        {

        }
        /// <summary>
        /// Product library base class
        /// </summary>
        public ProductLibraryBase(int productCapacity)
        {
            _productCapacity = productCapacity;
        }

        /// <summary>
        /// Product library base class
        /// </summary>
        /// <param name="products"></param>
        public ProductLibraryBase(int productCapacity,List<Product> products)
        {
            _products = products;
            _productCapacity = productCapacity;
        } 
        #endregion


        public int ProductCapacity
        {
            get { throw new NotImplementedException(); }
        }

        #region public properties
        /// <summary>
        /// Default implementation for getting all products
        /// </summary>
        /// <returns>All products from the library</returns>
        public virtual Product[] GetProducts()
        {
            return _products.ToArray();
        }

        /// <summary>
        /// Default implementation for removing project
        /// Remove item from the collection (by id)
        /// </summary>
        /// <param name="id">Position of the deleted project</param>
        public virtual void RemoveProduct(int id)
        {

            if (_products.Count > 0)
            {
                var backedProducts = _products;
                try
                {
                    /// since product list can be be updated in ANY TIME (according to task)
                    /// need to ensure it is only changed by one code in a time
                    /// This will help avoid ordering a product being changed or deleted
                    lock (_lockObject)
                    {
                        _products.RemoveAt(id - 1);
                    }
                }
                catch (Exception ex)
                {
                    // revert any changes to products before sending ex further
                    _products = backedProducts;
                    throw ex;
                }
            }
            else
            {
                throw new IndexOutOfRangeException("Product does not exists");
            }
        }

        /// <summary>
        /// Default implementation for adding product. 
        /// Adds new product to the products collection
        /// </summary>
        /// <param name="product">Product to be added</param>
        public virtual void AddProduct(Product product)
        {
            if (_products.Count < _productCapacity)
            {
                var backedProducts = _products;
                try
                {
                    /// since product list can be be updated in ANY TIME (according to task)
                    /// need to ensure it is only changed by one code in a time
                    /// This will help avoid ordering a product being changed or deleted
                    lock (_lockObject)
                    {
                        _products.Add(product);
                    }
                }
                catch (Exception ex)
                {
                    // revert any changes to products before sending ex further
                    _products = backedProducts;
                    throw ex;
                }
            }
            else
            {
                throw new IndexOutOfRangeException("Product capacity limited");
            }

        }

        /// <summary>
        /// Set products collection
        /// </summary>
        /// <param name="products">Products collection to override existing</param>
        public void SetProducts(List<Product> products)
        {
            if (products.Count <= _productCapacity)
            {
                _products = products;
            }
            else
            {
                throw new ArgumentOutOfRangeException("Product collection is bigger then maximum capacity");
            }
        }        

        /// <summary>
        /// Fills product amount
        /// </summary>
        /// <param name="id">id of the product to be filled</param>
        public void FillProduct(int id)
        {
            var backedProducts = _products;
            try
            {
                /// since product list can be be updated in ANY TIME (according to task)
                /// need to ensure it is only changed by one code in a time
                /// This will help avoid ordering a product being changed or deleted
                lock (_lockObject)
                {
                    var product = _products[id-1];
                    product.Available += 1;
                    _products[id - 1] = product;
                }
            }
            catch (Exception ex)
            {
                // revert any changes to products before sending ex further
                _products = backedProducts;
                throw ex;
            }
        }


        /// <summary>
        /// Default implementation for unfilling project
        /// Decreasing product amount
        /// </summary>
        /// <param name="id">Position of the unfilled project</param>
        public virtual void UnfillProduct(int id)
        {

            if (_products.Count > 0 && _products[id-1].Available >= 0)
            {
                var backedProducts = _products;
                try
                {
                    /// since product list can be be updated in ANY TIME (according to task)
                    /// need to ensure it is only changed by one code in a time
                    /// This will help avoid ordering a product being changed or deleted
                    lock (_lockObject)
                    {
                        var product = _products[id - 1];
                        product.Available -= 1;
                        _products[id - 1] = product;
                    }
                }
                catch (Exception ex)
                {
                    // revert any changes to products before sending ex further
                    _products = backedProducts;
                    throw ex;
                }
            }
            else
            {
                throw new IndexOutOfRangeException("Product does not exists");
            }
        }
        #endregion


       
    }
}
