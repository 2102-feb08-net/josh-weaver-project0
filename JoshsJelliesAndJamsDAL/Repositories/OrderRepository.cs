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
                    var dbInventory = context.Inventories
                        .Include(x => x.Store.Name)
                        .Where(x => appOrder.CustomerNumber.Equals(x.StoreId))
                        .ToList();

                    Order newOrder = new Order
                    {

                    };

                    return null;
                }
            }
        }

        public OrderModel PullHistory(CustomerModel appCustomer)
        {
            using (var logStream = new StreamWriter("jjjdb-log.txt", append: true) { AutoFlush = true })
            {
                DBConnection(logStream);
                using (var context = new JoshsJelliesAndJamsContext(optionsBuilder))
                {
                    return null;
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
                    return null;
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
                    IQueryable<Order> dbOrder = context.OrderDetails
                        .Include(p => p.Product)
                        .Orderby(x => x.OrderId)
                        .ToList();
                }
            }
        }

        public int AddOrderSummary(OrderModel appOrder)
        {
            throw new NotImplementedException();
        }
    }
}
