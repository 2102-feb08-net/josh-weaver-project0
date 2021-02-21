using System;
using System.Collections.Generic;

#nullable disable

namespace JoshsJelliesAndJams.DAL
{
    public partial class Inventory
    {
        public int Id { get; set; }
        public int? StoreId { get; set; }
        public int? ProductId { get; set; }
        public int Quantity { get; set; }

        public virtual ProductModel Product { get; set; }
        public virtual Store Store { get; set; }
    }
}
