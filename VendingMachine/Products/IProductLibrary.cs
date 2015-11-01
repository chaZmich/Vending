using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.Products
{
    public interface IProductLibrary
    {
        /// <summary>
        /// Maximum product capacity for the livrary
        /// </summary>
        int ProductCapacity { get; set; } 

        /// <summary>
        /// Gets all products from the collection
        /// </summary>
        /// <returns>Products collection</returns>
        Product[] GetProducts();

        /// <summary>
        /// Setting products collection
        /// </summary>
        /// <param name="products">Products collection to set</param>
        void SetProducts(List<Product> products);

        /// <summary>
        /// Remove a product from collection
        /// </summary>
        /// <param name="id">Position of deleted product</param>
        void RemoveProduct(int id);

        /// <summary>
        /// Add product to collection
        /// </summary>
        /// <param name="product">Product to add</param>
        void AddProduct(Product product);

        /// <summary>
        /// Fills product amount to maximum
        /// </summary>
        /// <param name="id">id of the product to be filled</param>
        void FillProduct(int id);

           /// <summary>
        /// Default implementation for removing project
        /// Remove item from the collection (by id)
        /// </summary>
        /// <param name="id">Position of the deleted project</param>
        void UnfillProduct(int id);
    }
}
