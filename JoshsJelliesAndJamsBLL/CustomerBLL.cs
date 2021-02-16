using JoshsJelliesAndJamsDAL;
using System;

namespace JoshsJelliesAndJams.BLL
{
    public class CustomerBLL
    {
        private static CustomerDAL data;

        public CustomerBLL(string connectionstring)
        {
            data = new CustomerDAL(connectionstring);
        }

        public static CustomerModel NewCustomer(string firstName, string lastName, string streetAddress, string city, string state, int zipcode)
        {
            CustomerModel temp = new CustomerModel();
            temp.CustomerID = CustomerModel._customerIdSeed;
            CustomerModel._customerIdSeed++;
            temp.FirstName = firstName;
            temp.LastName = lastName;
            temp.StreetAddress = streetAddress;
            temp.City = city;
            temp.State = state;
            temp.Zipcode = zipcode;

            return temp;
        }

        public static string AddCustomer(CustomerModel add)
        {
            //return data.AddCustomer(add);
            return "Customer Added";
        }

    }
}
