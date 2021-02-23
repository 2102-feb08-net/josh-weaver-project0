using JoshsJelliesAndJams.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoshsJelliesAndJams.Library.IRepositories
{
    public interface IStoreRepository
    {
        List<OrderModel> StoreHistory(int storeID);

        List<OrderModel> StoreHistory(string storeName);

        List<ProductModel> CheckInventory(int storeID);

        List<ProductModel> CheckInventory(string storeName);

        List<StoreModel> ListStores();
    }
}
