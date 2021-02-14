using System;
using System.Collections.Generic;
using System.Text;

namespace JoshsJelliesAndJams
{
    public class AddCustomer
    {
        private static int _customerIdSeed = 1;
        public int CustomerID { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public string StreetAddress { get; }
        public string City { get; }
        public string State { get; }
        public int Zipcode { get; }

        public AddCustomer(string firstName, string lastName, string streetAddress, string city, string state, int zipcode)
        {
            CustomerID = _customerIdSeed;
            _customerIdSeed++;
            FirstName = firstName;
            LastName = lastName;
            StreetAddress = streetAddress;
            City = city;
            State = state;
            Zipcode = zipcode;
        }
    }
}
