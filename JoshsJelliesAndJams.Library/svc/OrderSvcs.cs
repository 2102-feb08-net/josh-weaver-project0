using System;
using System.Collections.Generic;
using System.Linq;

namespace JoshsJelliesAndJams.Library.svc
{
    public class OrderSvcs
    {
        public Order NewOrder(OrderModel appOrder, Order dbOrder)
        {

        }

        public OrderDetails NewOrderDetails(OrderModel appOrder, OrderDetails dbOrderDetails)
        {


            return orderDetailList;
        }

        public List<Inventory> UpdateInventoryAfterOrder(OrderModel appOrder, List<Inventory> dbInventory)
        {


            return inventoryAdjustments;
        }

        public List<OrderModel> OrderHistory(CustomerModel appCustomer, Order dbOrder)
        {

            return appOrder;
        }

        public List<ProductModel> OrderDetailHistory(int orderID, OrderDetail dbOrderDetail)
        {

            return results;
        }
    }
}
