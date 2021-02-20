using System;
using System.Collections.Generic;
using System.Text;

namespace JoshsJelliesAndJams.Library
{
    public class CustomerModel
    {
        public int CustomerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string StreetAddress1 { get; set; }
        public string StreetAddress2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Zipcode { get; set; }
        public string DefaultStore { get; set; }
    }
}
