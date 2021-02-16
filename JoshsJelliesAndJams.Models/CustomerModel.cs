using System;
using System.Collections.Generic;
using System.Text;

namespace JoshsJelliesAndJams
{
    public class CustomerModel
    {
        public static int _customerIdSeed = 1;
        public int CustomerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Zipcode { get; set; }
    }
}
