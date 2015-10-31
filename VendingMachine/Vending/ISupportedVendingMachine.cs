using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.Vending
{
    interface ISupportedVendingMachine : IVendingMachine
    {
        /// <summary>
        /// Buffered amount of money after coins inserted but product wasn't ordered
        /// </summary>
        Money OrderBuffer { get; }
        /// <summary>
        /// Maximum product capacity for the machine
        /// </summary>
        int ProductCapacity { get; }
        /// <summary>
        /// Adding new products to machine collection
        /// </summary>
        /// <param name="newProduct">New product to add</param>
        void AddProduct(Product newProduct);
        /// <summary>
        /// Remove product from collection
        /// </summary>
        /// <param name="productId"></param>
        void RemoveProduct(int productId);
    }
}
