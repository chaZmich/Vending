using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.Products
{
    public class ProductLibrary : ProductLibraryBase
    {
        /// Product library class. Default implementations are ok for now
        /// 

        #region CTOR
        ///Hiding parameterless constructor to avoid creating libraries without capacity
        public ProductLibrary()
            : base(100)
        {

        }

        public ProductLibrary(int productCapacity)
            : base(productCapacity)
        {

        } 
        #endregion
    }
}
