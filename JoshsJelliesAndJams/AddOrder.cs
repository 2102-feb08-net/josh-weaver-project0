using System;
using System.Collections.Generic;
using System.Text;

namespace JoshsJelliesAndJams
{
    public class AddOrder
    {
        private static int _orderNumberSeed = 1;
        public int OrderNumber { get; }
        public List<object> Items { get; set; }
        public int CustomerNumber { get; }

        public AddOrder(List<object> items, int customerNumber)
        {
            OrderNumber = _orderNumberSeed;
            _orderNumberSeed++;
            Items = items;
            CustomerNumber = customerNumber;
        }
    }
}
