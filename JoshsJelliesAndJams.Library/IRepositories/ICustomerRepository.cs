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


        CustomerModel AddCustomer(CustomerModel model);

        void UpdateDefaultStore(CustomerModel appCustomer, string appStore);

    }
}
