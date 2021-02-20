using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JoshsJelliesAndJams.Library;
using JoshsJelliesAndJams.Library.IRepositories;
using JoshsJelliesAndJams.Library.Models;

namespace JoshsJelliesAndJams.DAL.Repositories
{
    class CustomerRepository : ICustomerRepository
    {
        public void AddCustomer(CustomerModel customer)
        {
            //add customer to db
        }

        public void AddDefaultStore(string store)
        {
            throw new NotImplementedException();
        }

        public CustomerModel LookupCustomer(string fname, string lname)
        {
            throw new NotImplementedException();
        }

        public void UpdateCustomer(CustomerModel customer)
        {
            throw new NotImplementedException();
        }
    }
}
