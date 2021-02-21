using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoshsJelliesAndJams.Library.IRepositories
{
    public interface IStoreRepository
    {
        OrderModel StoreHistory(int storeID);

        OrderModel StoreHistory(string storeName);

        OrderModel CheckInventory(int storeID);

        OrderModel CheckInventory(string storeName);

        void AddInventory(List<ProductModel> productList);

        void RemoveInventory(List<ProductModel> productList);

    }
}
