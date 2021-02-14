using System;
using System.Collections.Generic;
using System.Text;

namespace JoshsJelliesAndJams
{
    public class Item
    {
        public int Quantity { get; }
        public string Name { get; }
        public int CostPerItem { get; }

        public Item(int quantity, string name, int cost)
        {
            Quantity = quantity;
            Name = name;
            CostPerItem = cost;
        }
    }
}
