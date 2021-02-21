using System;
using System.Collections.Generic;

#nullable disable

namespace JoshsJelliesAndJams.DAL
{
    public partial class ProductModel
    {
        public ProductModel()
        {
            Inventories = new HashSet<Inventory>();
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int ProductId { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        public virtual ICollection<Inventory> Inventories { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
