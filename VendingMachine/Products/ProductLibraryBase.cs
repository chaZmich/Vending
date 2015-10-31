using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.Products
{
    public abstract class ProductLibraryBase : IProductLibrary
    {
        private List<Product> _products = new List<Product>();

        /// <summary>
        /// Product library base class
        /// </summary>
        public ProductLibraryBase()
        {

        }

        /// <summary>
        /// Product library base class
        /// </summary>
        /// <param name="products"></param>
        public ProductLibraryBase(List<Product> products)
        {
            _products = products;
        }

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
            var product = _products[id - 1];
            var listedProducts = new List<Product>(_products);
            listedProducts.RemoveAt(id - 1);
        }

        /// <summary>
        /// Default implementation for adding product. 
        /// Adds new product to the products collection
        /// </summary>
        /// <param name="product">Product to be added</param>
        public virtual void AddProduct(Product product)
        {
            _products.Add(product);
        }


        /// <summary>
        /// Set products collection
        /// </summary>
        /// <param name="products">Products collection to override existing</param>
        public void SetProducts(List<Product> products)
        {
            _products = products;
        }
    }
}
