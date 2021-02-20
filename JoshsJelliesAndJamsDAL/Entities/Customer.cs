using System;
using System.Collections.Generic;

#nullable disable

namespace JoshsJelliesAndJams.DAL
{
    public partial class Customer
    {
        public Customer()
        {
            Orders = new HashSet<Order>();
        }

        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string StreetAddress1 { get; set; }
        public string StreetAddress2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zipcode { get; set; }
        public DateTime CustomerCreated { get; set; }
        public int? DefaultStoreId { get; set; }

        public virtual Store DefaultStore { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
