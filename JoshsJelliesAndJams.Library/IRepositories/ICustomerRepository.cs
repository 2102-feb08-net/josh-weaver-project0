using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoshsJelliesAndJams.Library.IRepositories
{
    public interface ICustomerRepository
    {
        CustomerModel LookupCustomer(string fname, string lname);

        CustomerModel AddCustomer(CustomerModel customer);

        CustomerModel AddDefaultStore(string store);

        CustomerModel UpdateCustomer(CustomerModel customer);

    }
}
