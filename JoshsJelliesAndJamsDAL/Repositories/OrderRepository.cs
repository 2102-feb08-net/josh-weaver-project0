using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using JoshsJelliesAndJams.Library;
using JoshsJelliesAndJams.Library.IRepositories;
using JoshsJelliesAndJams.Library.svc;
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

        public void AddOrder(OrderModel appOrder)
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
                        OrderTotal = appOrder.Total,
                        DatePlaced = dateTime
                    };

                    context.Add(newOrder);
                    context.SaveChanges();

                    Order dbOrderV2 = context.Orders.OrderBy(x => x.OrderId).Last();
                    OrderDetail dbOrderDetails = context.OrderDetails.OrderBy(x => x.Id).Last();

                    List<OrderDetail> orderDetailList = new List<OrderDetail>();

                    foreach (var product in appOrder.Product)
                    {
                        OrderDetail newDetail = new OrderDetail
                        {
                            OrderId = dbOrderV2.OrderId,
                            ProductId = product.ProductId,
                            Quantity = product.Quantity,
                            TotalCost = product.CostPerItem * product.Quantity
                        };
                        orderDetailList.Add(newDetail);
                    }

                    foreach (var lineItem in orderDetailList)
                    {
                        context.Add(lineItem);
                        context.SaveChanges();
                    }

                    for (int prod = 0; prod < appOrder.Product.Count; prod++)
                    {
                        Inventory dbInventory = context.Inventories
                            .Include(x => x.Product)
                            .Where(x => appOrder.StoreID == x.StoreId)
                            .Where(x =>  x.Product.ProductId == appOrder.Product[prod].ProductId )
                            .First();

                        dbInventory.ProductId = appOrder.Product[prod].ProductId;
                        dbInventory.Quantity -= appOrder.Product[prod].Quantity;

                        context.Update(dbInventory);
                        context.SaveChanges();
                    }
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

                    foreach (var item in dbOrder)
                    {
                        OrderModel lineItem = new OrderModel
                        {
                            OrderNumber = item.OrderId,
                            OrderPlaced = (DateTime)item.DatePlaced,
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
                            CostPerItem = item.Product.Price,
                            Quantity = item.Quantity,
                            TotalLine = item.TotalCost
                        };
                        results.Add(itemResult);
                    }

                    return results;
                }
            }
        }
    }
}
