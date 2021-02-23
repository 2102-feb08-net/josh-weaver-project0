using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace JoshsJelliesAndJams.Library.IRepositories
{
    public interface IOrderRepository
    {
        List<OrderModel> PullHistory(CustomerModel appCustomer);

        void AddOrder(OrderModel appOrder);

        List<ProductModel> SeeDetails(int orderID);
    }
}
