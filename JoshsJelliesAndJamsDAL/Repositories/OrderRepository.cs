using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JoshsJelliesAndJams.Library;
using JoshsJelliesAndJams.Library.IRepositories;

namespace JoshsJelliesAndJams.DAL.Repositories
{
    class OrderRepository : IOrderRepository
    {
        public OrderModel AddOrder()
        {
            throw new NotImplementedException();
        }

        public OrderModel PullHistory()
        {
            throw new NotImplementedException();
        }

        public List<ProductModel> SeeDetails(int orderID)
        {
            throw new NotImplementedException();
        }
    }
}
