using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace JoshsJelliesAndJams.Library.IRepositories
{
    public interface IOrderRepository
    {
        OrderModel PullHistory(CustomerModel appCustomer);

        string AddOrder(OrderModel appOrder);

        void AddOrderDetails(OrderModel appOrder);

        int AddOrderSummary(OrderModel appOrder);

        List<ProductModel> SeeDetails(int orderID);
    }
}
