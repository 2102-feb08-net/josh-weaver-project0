using System;
using System.Collections.Generic;
using System.Text;

namespace JoshsJelliesAndJams.Library
{
    public class OrderModel
    {
        public int OrderNumber { get; set; }
        public List<ProductModel> Product { get; set; }
        public DateTime OrderPlaced { get; set; }
        public decimal Total { get; set; }
        public int NumberOfProducts { get; set; }
        public int CustomerNumber { get; set; }
        public int StoreID { get; set; }
    }
}
