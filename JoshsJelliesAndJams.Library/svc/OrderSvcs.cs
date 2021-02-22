﻿using System.Collections.Generic;
using System.Linq;

namespace JoshsJelliesAndJams.Library.svc
{
    public class OrderSvcs
    {
        public Order NewOrder(OrderModel appOrder, Order dbOrder)
        {
            DateTime dateTime = DateTime.Now;

            Order newOrder = new Order
            {
                CustomerId = appOrder.CustomerNumber,
                StoreId = appOrder.StoreID,
                NumberOfProducts = appOrder.Product.Sum(x => x.Quantity),
                OrderTotal = appOrder.Product.Sum(x => x.TotalLine),
                DatePlaced = dateTime
            };

            return dbOrder;
        }

        public OrderDetails NewOrderDetails(OrderModel appOrder, OrderDetails dbOrderDetails)
        {
            List<OrderDetail> orderDetailList = new List<OrderDetail>();

            foreach (var product in appOrder.Product)
            {
                OrderDetail newDetail = new OrderDetail
                {
                    OrderId = dbOrderDetails.Order.OrderId,
                    ProductId = product.ProductId,
                    Quantity = product.Quantity,
                    TotalCost = product.Quantity * product.CostPerItem
                };
                orderDetailList.Add(newDetail);
            }

            return orderDetailList;
        }

        public List<Inventory> UpdateInventoryAfterOrder(OrderModel appOrder, List<Inventory> dbInventory)
        {
            List<Inventory> inventoryAdjustments = new List<Inventory>();


            for (int prod = 0; prod < appOrder.Product.Count; prod++)
            {
                for (int inv = 0; inv < dbInventory.Count; inv++)
                {
                    if (appOrder.Product[prod].ProductId == dbInventory[inv].ProductId)
                    {
                        Inventory newInventory = new Inventory
                        {
                            StoreId = appOrder.StoreID,
                            ProductId = appOrder.Product[prod].ProductId,
                            Quantity = appOrder.Product[prod].Quantity - dbInventory[inv].Quantity
                        };
                        inventoryAdjustments.Add(newInventory);
                    }
                }
            }

            return inventoryAdjustments;
        }
    }
}
