using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JoshsJelliesAndJams.Library;
using JoshsJelliesAndJams.Library.IRepositories;

namespace JoshsJelliesAndJams.DAL.Repositories
{
    class CustomerRepository : ICustomerRepository
    {
        public CustomerModel AddCustomer(CustomerModel customer)
        {
            throw new NotImplementedException();
        }

        public CustomerModel AddDefaultStore(string store)
        {
            throw new NotImplementedException();
        }

        public CustomerModel LookupCustomer(string fname, string lname)
        {
            throw new NotImplementedException();
        }

        public CustomerModel UpdateCustomer(CustomerModel customer)
        {
            throw new NotImplementedException();
        }
    }
}
