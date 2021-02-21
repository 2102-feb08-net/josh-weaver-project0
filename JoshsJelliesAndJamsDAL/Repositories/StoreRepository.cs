using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JoshsJelliesAndJams.Library;
using JoshsJelliesAndJams.Library.IRepositories;

namespace JoshsJelliesAndJams.DAL.Repositories
{
    public class StoreRepository : IStoreRepository
    {
        public void AddInventory(List<ProductModel> productList)
        {
            throw new NotImplementedException();
        }

        public OrderModel CheckInventory(int storeID)
        {
            throw new NotImplementedException();
        }

        public OrderModel CheckInventory(string storeName)
        {
            throw new NotImplementedException();
        }

        public void RemoveInventory(List<ProductModel> productList)
        {
            throw new NotImplementedException();
        }

        public OrderModel StoreHistory(int storeID)
        {
            throw new NotImplementedException();
        }

        public OrderModel StoreHistory(string storeName)
        {
            throw new NotImplementedException();
        }
    }
}
