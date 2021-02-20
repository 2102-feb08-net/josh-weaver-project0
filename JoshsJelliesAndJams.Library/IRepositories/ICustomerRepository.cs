using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoshsJelliesAndJams.Library.IRepositories
{
    public interface ICustomerRepository
    {
        CustomerModel LookupCustomer(string firstName, string lastName);

        void AddCustomer(CustomerModel model);

        void AddDefaultStore(string store);

        void UpdateCustomer(CustomerModel customer);

    }
}
