using System;
using System.Collections.Generic;
using System.Text;

namespace JoshsJelliesAndJams.Library
{
    public class ProductModel
    {
        private int _quantity;
        public int ProductId { get; set; }
        public string Name { get; set; }
        public int Quantity { get => _quantity; set => _quantity = Quantity; }
        public decimal CostPerItem { get; set; }
        public decimal TotalLine { get; set; }
    }
}
