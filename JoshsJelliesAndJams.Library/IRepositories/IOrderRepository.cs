using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace JoshsJelliesAndJams.Library.IRepositories
{
    public interface IOrderRepository
    {
        OrderModel PullHistory();

        OrderModel AddOrder();

        List<ProductModel> SeeDetails(int orderID);
    }
}
