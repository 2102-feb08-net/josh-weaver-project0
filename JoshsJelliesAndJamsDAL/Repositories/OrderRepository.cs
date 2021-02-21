using System;
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
                    OrderDetail dbOrderDetails = context.OrderDetails.OrderBy(x => x.OrderId).Last();
                    List<Inventory> dbInventory = context.Inventories
                        .Select(x => x)
                        .Include(x => x.Product)
                        .Where(x => appOrder.StoreID.Equals(x.StoreId))
                        .ToList();

                    DateTime dateTime = DateTime.Now;
                    
                    Order newOrder = new Order
                    {
                        CustomerId = appOrder.CustomerNumber,
                        StoreId = appOrder.StoreID,
                        NumberOfProducts = appOrder.Product.Sum(x => x.Quantity),
                        OrderTotal = appOrder.Product.Sum(x => x.TotalLine),
                        DatePlaced = dateTime
                    };

                    List<OrderDetail> orderDetailList = new List<OrderDetail>();

                    foreach (var product in appOrder.Product)
                    {
                        OrderDetail newDetail = new OrderDetail
                        {
                            OrderId = appOrder.StoreID,
                            ProductId = product.ProductId,
                            Quantity = product.Quantity,
                            TotalCost = product.Quantity * product.CostPerItem
                        };

                        orderDetailList.Add(newDetail);
                    }

                    List<Inventory> inventoryAdjustments = new List<Inventory>();

                    foreach (var product in appOrder.Product)
                    {
                        if (product.ProductId.Equals(dbInventory.Product.ProductId))
                        {
                            Inventory newInventory = new Inventory
                            {
                                StoreId = dbInventory.StoreId,
                                ProductId = product.ProductId,
                                Product = product.Quantity - dbInventory.Product.Quantity,

                            };
                        }
                    }
                    Console.WriteLine($"Thank you! Your order number is {dbOrder.OrderId}.");
                    context.Add(newOrder);
                    context.Add(orderDetailList);
                    context.Add(inventoryAdjustments);
                    context.SaveChanges();
                }
            }
        }

        public List<Order> PullHistory(CustomerModel appCustomer)
        {
            using (var logStream = new StreamWriter("jjjdb-log.txt", append: true) { AutoFlush = true })
            {
                DBConnection(logStream);
                using (var context = new JoshsJelliesAndJamsContext(optionsBuilder))
                {
                    List<Order> dbOrder = context.Orders
                        .Select(x => x)
                        .Where(x => x.CustomerId.Equals(appCustomer.CustomerID))
                        .ToList();

                    return dbOrder;
                }
            }
        }

        public List<OrderDetail> SeeDetails(int orderID)
        {
            using (var logStream = new StreamWriter("jjjdb-log.txt", append: true) { AutoFlush = true })
            {
                DBConnection(logStream);
                using (var context = new JoshsJelliesAndJamsContext(optionsBuilder))
                {
                    List<OrderDetail> dbOrderDetails = context.OrderDetails
                        .Select(x => x)
                        .Include(x => x.Product)
                        .Where(x => x.OrderId.Equals(orderID))
                        .ToList();

                    List<ProductModel> results = new List<ProductModel>;

                    foreach(var item in dbOrderDetails)
                    {
                        results.
                    }

                    return dbOrderDetails;
                }
            }
        }

        //public void AddOrderDetails(OrderModel appOrder)
        //{
        //    using (var logStream = new StreamWriter("jjjdb-log.txt", append: true) { AutoFlush = true })
        //    {
        //        DBConnection(logStream);
        //        using (var context = new JoshsJelliesAndJamsContext(optionsBuilder))
        //        {
        //            IQueryable<Order> dbOrder = context.OrderDetails
        //                .Include(p => p.Product)
        //                .Orderby(x => x.OrderId)
        //                .ToList();
        //        }
        //    }
        //}

        //public int AddOrderSummary(OrderModel appOrder)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
