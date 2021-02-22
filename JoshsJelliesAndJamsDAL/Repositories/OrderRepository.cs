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

                    Order newOrder = NewOrder(appOrder, dbOrder);

                    context.Add(newOrder);
                    context.SaveChanges();


                    OrderDetail dbOrderDetails = context.OrderDetails
                        .Include(x => x.Order)
                        .OrderBy(x => x.Order.OrderId).Last();

                    OrderDetail orderDetailList = NewDetail(appOrder, dbOrderDetails);

                    context.Add(orderDetailList);
                    context.SaveChanges();



                    List<Inventory> dbInventory = context.Inventories
                        .Include(x => x.Product)
                        .Where(x => appOrder.StoreID.Equals(x.StoreId))
                        .ToList();

                    List<Inventory> inventoryAdjustments = UpdateInventoryAfterOrder(appOrder, dbInventory);

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
