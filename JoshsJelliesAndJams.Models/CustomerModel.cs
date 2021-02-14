using System;
using System.Collections.Generic;
using System.Text;

namespace JoshsJelliesAndJams
{
    public class CustomerModel
    {
        private static int _customerIdSeed = 1;
        public int CustomerID { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public string StreetAddress { get; }
        public string City { get; }
        public string State { get; }
        public int Zipcode { get; }
    }
}
