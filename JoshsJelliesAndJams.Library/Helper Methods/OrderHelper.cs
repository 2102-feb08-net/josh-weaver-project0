using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoshsJelliesAndJams.Library.Helper_Methods
{
    public class OrderHelper
    {
        public int SumProducts(OrderModel appOrder)
        {
            List<ProductModel> list = appOrder.Product;
            int total = 0;
            foreach(var i in list)
            {
                total = list.Sum(quantity => quantity.Quantity);
            }
            return total;
        }
    }
}
