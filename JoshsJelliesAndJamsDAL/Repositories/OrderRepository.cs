﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using JoshsJelliesAndJams.Library;
using JoshsJelliesAndJams.Library.IRepositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace JoshsJelliesAndJams.DAL.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private static DbContextOptions<JoshsJelliesAndJamsContext> optionsBuilder;

        private void DBConnection(StreamWriter logStream)
        {
            string connectionString = File.ReadAllText("C:/Revature/JJJDb.txt");

            optionsBuilder = new DbContextOptionsBuilder<JoshsJelliesAndJamsContext>()
                .UseSqlServer(connectionString)
                .LogTo(logStream.WriteLine, minimumLevel: LogLevel.Information)
                .Options;

        }

        public string AddOrder(OrderModel appOrder)
        {
            using (var logStream = new StreamWriter("jjjdb-log.txt", append: true) { AutoFlush = true })
            {
                DBConnection(logStream);
                using (var context = new JoshsJelliesAndJamsContext(optionsBuilder))
                {
                    Order dbOrder = context.Orders.OrderBy(x => x.OrderId).Last();
                    
                    DateTime dateTime = DateTime.Now;
                    
                    Order newOrder = new Order
                    {
                        CustomerId = appOrder.CustomerNumber,
                        StoreId = appOrder.StoreID,
                        NumberOfProducts = appOrder.Product.Sum(x => x.Quantity),
                        OrderTotal = appOrder.Product.Sum(x => x.TotalLine),
                        DatePlaced = dateTime
                    };

                    context.Add(newOrder);
                    context.SaveChanges();


                    OrderDetail dbOrderDetails = context.OrderDetails
                        .Include(x => x.Order)
                        .OrderBy(x => x.Order.OrderId).Last();

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
                    context.Add(orderDetailList);
                    context.SaveChanges();



                    List<Inventory> dbInventory = context.Inventories
                        .Include(x => x.Product)
                        .Where(x => appOrder.StoreID.Equals(x.StoreId))
                        .ToList();

                    List<Inventory> inventoryAdjustments = new List<Inventory>();
                    

                    for(int prod = 0; prod < appOrder.Product.Count; prod++)
                    {
                        for(int inv = 0; inv < dbInventory.Count; inv++)
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

                    context.Add(inventoryAdjustments);
                    context.SaveChanges();

                    return ($"Thank you! Your order number is {dbOrder.OrderId}.");

                }
            }
        }

        public List<OrderModel> PullHistory(CustomerModel appCustomer)
        {
            using (var logStream = new StreamWriter("jjjdb-log.txt", append: true) { AutoFlush = true })
            {
                DBConnection(logStream);
                using (var context = new JoshsJelliesAndJamsContext(optionsBuilder))
                {
                    List<Order> dbOrder = context.Orders
                        .Where(x => x.CustomerId.Equals(appCustomer.CustomerID))
                        .ToList();

                    List<OrderModel> appOrder = new List<OrderModel>();

                    foreach(var item in dbOrder)
                    {
                        OrderModel lineItem = new OrderModel
                        {
                            OrderPlaced = (DateTime) item.DatePlaced,
                            NumberOfProducts = item.NumberOfProducts,
                            Total = item.OrderTotal
                        };
                        appOrder.Add(lineItem);
                    }

                    return appOrder;
                }
            }
        }

        public List<ProductModel> SeeDetails(int orderID)
        {
            using (var logStream = new StreamWriter("jjjdb-log.txt", append: true) { AutoFlush = true })
            {
                DBConnection(logStream);
                using (var context = new JoshsJelliesAndJamsContext(optionsBuilder))
                {
                    List<OrderDetail> dbOrderDetails = context.OrderDetails
                        .Include(x => x.Product)
                        .Where(x => x.OrderId.Equals(orderID))
                        .ToList();

                    List<ProductModel> results = new List<ProductModel>();


                    foreach (var item in dbOrderDetails)
                    {
                        ProductModel itemResult = new ProductModel
                        {
                            Name = item.Product.Name,
                            CostPerItem = item.Product.Price
                        };
                        results.Add(itemResult);
                    }

                    return results;
                }
            }
        }

        public void AddOrderDetails(OrderModel appOrder)
        {
            using (var logStream = new StreamWriter("jjjdb-log.txt", append: true) { AutoFlush = true })
            {
                DBConnection(logStream);
                using (var context = new JoshsJelliesAndJamsContext(optionsBuilder))
                {

                }
            }
        }

        public int AddOrderSummary(OrderModel appOrder)
        {
            throw new NotImplementedException();
        }
    }
}
