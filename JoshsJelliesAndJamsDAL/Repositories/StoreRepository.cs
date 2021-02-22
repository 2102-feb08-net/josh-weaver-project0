using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using JoshsJelliesAndJams.Library;
using JoshsJelliesAndJams.Library.IRepositories;
using JoshsJelliesAndJams.Library.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace JoshsJelliesAndJams.DAL.Repositories
{
    public class StoreRepository : IStoreRepository
    {
        private static DbContextOptions<JoshsJelliesAndJamsContext> optionsBuilder;

        void DBConnection(StreamWriter logStream)
        {
            string connectionString = File.ReadAllText("C:/Revature/JJJDb.txt");

            optionsBuilder = new DbContextOptionsBuilder<JoshsJelliesAndJamsContext>()
                .UseSqlServer(connectionString)
                .LogTo(logStream.WriteLine, minimumLevel: LogLevel.Information)
                .Options;

        }
        public void AddInventory(List<Library.ProductModel> productList)
        {
            using (var logStream = new StreamWriter("jjjdb-log.txt", append: true) { AutoFlush = true })
            {
                DBConnection(logStream);
                using (var context = new JoshsJelliesAndJamsContext(optionsBuilder))
                {
                    
                }
            }
        }

        public List<InventoryModel> CheckInventory(int storeID)
        {
            using (var logStream = new StreamWriter("jjjdb-log.txt", append: true) { AutoFlush = true })
            {
                DBConnection(logStream);
                using (var context = new JoshsJelliesAndJamsContext(optionsBuilder))
                {
                    var dbInventory = context.Inventories
                        .Include(x => x.Product)
                        .Where(x => x.StoreId.Equals(storeID))
                        .ToList();

                    List<InventoryModel> appInventory = new List<InventoryModel>();


                    foreach (var item in dbInventory)
                    {
                        InventoryModel listItem = new InventoryModel
                        {
                            Products = item.Product.Name,
                            Price = item.Product.Price
                        };
                        appInventory.Add(listItem);
                    }

                    return appInventory;

                }
            }
        }

        public List<InventoryModel> CheckInventory(string storeName)
        {
            using (var logStream = new StreamWriter("jjjdb-log.txt", append: true) { AutoFlush = true })
            {
                DBConnection(logStream);
                using (var context = new JoshsJelliesAndJamsContext(optionsBuilder))
                {
                    var dbInventory = context.Inventories
                       .Include(x => x.Product)
                       .Where(x => x.StoreId.Equals(storeName))
                       .ToList();

                    List<InventoryModel> appInventory = new List<InventoryModel>();


                    foreach (var item in dbInventory)
                    {
                        InventoryModel listItem = new InventoryModel
                        {
                            Products = item.Product.Name,
                            Price = item.Product.Price
                        };
                        appInventory.Add(listItem);
                    }

                    return appInventory;
                }
            }
        }

        public void RemoveInventory(List<Library.ProductModel> productList)
        {
            using (var logStream = new StreamWriter("jjjdb-log.txt", append: true) { AutoFlush = true })
            {
                DBConnection(logStream);
                using (var context = new JoshsJelliesAndJamsContext(optionsBuilder))
                {

                }
            }
        }

        public List<OrderModel> StoreHistory(int storeId)
        {
            using (var logStream = new StreamWriter("jjjdb-log.txt", append: true) { AutoFlush = true })
            {
                DBConnection(logStream);
                using (var context = new JoshsJelliesAndJamsContext(optionsBuilder))
                {
                    List<Order> dbOrder = context.Orders
                        .Where(x => x.StoreId.Equals(storeId))
                        .ToList();

                    List<OrderModel> appOrder = new List<OrderModel>();

                    foreach(var item in dbOrder)
                    {
                        OrderModel lineItem = new OrderModel
                        {
                            OrderNumber = item.OrderId,
                            OrderPlaced = (DateTime)item.DatePlaced,
                            Total = item.OrderTotal
                        };
                        appOrder.Add(lineItem);
                    }

                    return appOrder;
                }
            }
        }

        public List<OrderModel> StoreHistory(string storeName)
        {
            using (var logStream = new StreamWriter("jjjdb-log.txt", append: true) { AutoFlush = true })
            {
                DBConnection(logStream);
                using (var context = new JoshsJelliesAndJamsContext(optionsBuilder))
                {
                    List<Order> dbOrder = context.Orders
                     .Where(x => x.StoreId.Equals(storeName))
                     .ToList();

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

                    return appOrder;
                }
            }
        }
    }
}
