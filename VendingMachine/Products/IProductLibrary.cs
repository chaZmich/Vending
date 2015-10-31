﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.Products
{
    public interface IProductLibrary
    {
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
    }
}