using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoshsJelliesAndJams.Library.svc
{
    public class StoreSvcs
    {
        public List<ProductModel> Inventory(List<Inventory> dbInventory)
        {
            List<ProductModel> appInventory = new List<ProductModel>();


            foreach (var item in dbInventory)
            {
                ProductModel listItem = new ProductModel
                {
                    Name = item.Product.Name,
                    Quantity = item.Product.Quantity
                };
                appInventory.Add(listItem);
            }
            return appInventory;
        }

        public List<OrderDetail> History(List<OrderDetail> dbOrder)
        {
            List<OrderModel> appOrder = new List<OrderModel>();

            foreach (var item in dbOrder)
            {
                OrderModel lineItem = new OrderModel
                {
                    OrderNumber = item.OrderId,
                    OrderPlaced = (DateTime)item.DatePlaced,
                    Total = item.OrderTotal
                };
                appOrder.Add(lineItem);
            }
        }
    }
}
