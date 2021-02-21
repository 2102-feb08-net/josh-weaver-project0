using System;
using System.Collections.Generic;

#nullable disable

namespace JoshsJelliesAndJams.DAL
{
    public partial class Order
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int OrderId { get; set; }
        public int? CustomerId { get; set; }
        public int? StoreId { get; set; }
        public int NumberOfProducts { get; set; }
        public decimal OrderTotal { get; set; }
        public DateTime? DatePlaced { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Store Store { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
