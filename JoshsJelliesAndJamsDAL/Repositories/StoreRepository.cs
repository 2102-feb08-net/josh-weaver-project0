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
        public List<ProductModel> CheckInventory(int storeID)
        {
            using (var logStream = new StreamWriter("jjjdb-log.txt", append: true) { AutoFlush = true })
            {
                DBConnection(logStream);
                using (var context = new JoshsJelliesAndJamsContext(optionsBuilder))
                {
                    List<Inventory> dbInventory = context.Inventories
                        .Include(x => x.Product)
                        .Where(x => x.StoreId.Equals(storeID))
                        .ToList();

                    List<ProductModel> appInventory = new List<ProductModel>();


                    foreach (var item in dbInventory)
                    {
                        ProductModel listItem = new ProductModel
                        {
                            ProductId = item.Product.ProductId,
                            Name = item.Product.Name,
                            CostPerItem = item.Product.Price
                        };
                        appInventory.Add(listItem);
                    }
                    return appInventory;

                }
            }
        }

        public List<ProductModel> CheckInventory(string storeName)
        {
            using (var logStream = new StreamWriter("jjjdb-log.txt", append: true) { AutoFlush = true })
            {
                DBConnection(logStream);
                using (var context = new JoshsJelliesAndJamsContext(optionsBuilder))
                {
                    List<Inventory> dbInventory = context.Inventories
                       .Include(x => x.Product)
                       .Where(x => x.StoreId.Equals(storeName))
                       .ToList();

                    List<ProductModel> appInventory = new List<ProductModel>();


                    foreach (var item in dbInventory)
                    {
                        ProductModel listItem = new ProductModel
                        {
                            ProductId = item.Product.ProductId,
                            Name = item.Product.Name,
                            CostPerItem = item.Product.Price
                        };
                        appInventory.Add(listItem);
                    }

                    return appInventory;
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
        public List<StoreModel> ListStores()
        {
            using (var logStream = new StreamWriter("jjjdb-log.txt", append: true) { AutoFlush = true })
            {
                DBConnection(logStream);
                using (var context = new JoshsJelliesAndJamsContext(optionsBuilder))
                {
                    List<Store> dbStore = context.Stores
                        .ToList();

                    List<StoreModel> appStoreList = new List<StoreModel>;

                    foreach (var store in dbStore)
                    {
                        StoreModel lineItem = new StoreModel
                        {
                            StoreName = store.Name,
                            StoreCity = store.City,
                            StoreState = store.State
                        };
                    }
                    return appStoreList;
                }
            }
        }
    }
}
