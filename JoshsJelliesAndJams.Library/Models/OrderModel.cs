using System;
using System.Collections.Generic;
using System.Text;

namespace JoshsJelliesAndJams.Library
{
    public class OrderModel
    {
        private static int _orderNumberSeed = 1;
        public int OrderNumber { get; }
        public List<ProductModel> Product { get; set; }
        public int CustomerNumber { get; }
    }
}
