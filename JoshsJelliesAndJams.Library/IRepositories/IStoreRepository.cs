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

        List<InventoryModel> CheckInventory(int storeID);

        List<InventoryModel> CheckInventory(string storeName);

        void AddInventory(List<ProductModel> productList);

        void RemoveInventory(List<ProductModel> productList);

    }
}
