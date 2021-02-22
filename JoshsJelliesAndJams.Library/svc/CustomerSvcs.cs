using System;

namespace JoshsJelliesAndJams.Library.svc
{
    public class CustomerSvcs
    {
        public static Customer AddNewCustomer(CustomerModel appCustomer)
        {
            DateTime dateTime = DateTime.Now;

            var newCustomer = new Customer
            {
                FirstName = appCustomer.FirstName,
                LastName = appCustomer.LastName,
                StreetAddress1 = appCustomer.StreetAddress1,
                StreetAddress2 = appCustomer.StreetAddress2,
                City = appCustomer.City,
                State = appCustomer.State,
                Zipcode = appCustomer.Zipcode,
                CustomerCreated = dateTime,
                DefaultStore = null
            };

            return newCustomer;
        }

        public static CustomerModel CustomerLookup(Customer dbCustomer)
        {
            CustomerModel appCustomer = new CustomerModel
            {
                FirstName = dbCustomer.FirstName,
                LastName = dbCustomer.LastName,
                StreetAddress1 = dbCustomer.StreetAddress1,
                StreetAddress2 = dbCustomer.StreetAddress2,
                City = dbCustomer.City,
                State = dbCustomer.State,
                Zipcode = dbCustomer.Zipcode,
                DefaultStore = dbCustomer.DefaultStore.Name
            };
            return appCustomer;
        }

        public static CustomerModel UpdateStore(CustomerModel appCustomer, Customer dbCustomer)
        {
            dbCustomer.DefaultStoreId = int.Parse(appCustomer.DefaultStore);

            return dbCustomer;
        }
    }
}
