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
    public class CustomerRepository : ICustomerRepository
    {

        private static DbContextOptions<JoshsJelliesAndJamsContext> optionsBuilder;



        public void DBConnection(StreamWriter logStream)
        {
            string connectionString = File.ReadAllText("C:/Revature/JJJDb.txt");

            optionsBuilder = new DbContextOptionsBuilder<JoshsJelliesAndJamsContext>()
                .UseSqlServer(connectionString)
                .LogTo(logStream.WriteLine, minimumLevel: LogLevel.Information)
                .Options;

        }

        public void AddCustomer(CustomerModel appCustomer)
        {
            using (var logStream = new StreamWriter("jjjdb-log.txt", append: true) { AutoFlush = true })
            {
                DBConnection(logStream);
                using (var context = new JoshsJelliesAndJamsContext(optionsBuilder))
                {
                    IQueryable<Customer> dbCustomer = context.Customers
                        .OrderBy(x => x.CustomerId);

                    DateTime dateTime = DateTime.Now;

                    var newCustomer = new Customer
                    {
                        FirstName = appCustomer.FirstName,
                        LastName = appCustomer.LastName,
                        StreetAddress1 = appCustomer.StreetAddress1,
                        StreetAddress2 = appCustomer.StreetAddress2,
                        City = appCustomer.City,
                        State = appCustomer.State,
                        Zipcode = appCustomer.Zipcode,
                        CustomerCreated = dateTime,
                        DefaultStore = null
                    };
                    context.Add(newCustomer);
                    context.SaveChanges();
                }
            }
        }

        public void UpdateDefaultStore(CustomerModel appCustomer, string appStore)
        {
            using (var logStream = new StreamWriter("jjjdb-log.txt", append: true) { AutoFlush = true })
            {
                DBConnection(logStream);
                using (var context = new JoshsJelliesAndJamsContext(optionsBuilder))
                {
                    Customer dbCustomer = context.Customers
                        .Select(c => c)
                        .Where(c => (c.FirstName == appCustomer.FirstName) && (c.LastName == appCustomer.LastName))
                        .First();

                    dbCustomer.DefaultStoreId = int.Parse(appCustomer.DefaultStore);

                    context.SaveChanges();
                }
            }
        }

        public CustomerModel LookupCustomer(string fname, string lname)
        {
            using (var logStream = new StreamWriter("jjjdb-log.txt", append: true) { AutoFlush = true })
            {
                DBConnection(logStream);
                using (var context = new JoshsJelliesAndJamsContext(optionsBuilder))
                {

                    Customer dbCustomer = context.Customers
                        .Include(c => c.DefaultStore)
                        .Where(c => (c.FirstName == @fname) && (c.LastName == lname))
                        .First();

                    CustomerModel appCustomer = new CustomerModel
                    {
                        FirstName = dbCustomer.FirstName,
                        LastName = dbCustomer.LastName,
                        StreetAddress1 = dbCustomer.StreetAddress1,
                        StreetAddress2 = dbCustomer.StreetAddress2,
                        City = dbCustomer.City,
                        State = dbCustomer.State,
                        Zipcode = dbCustomer.Zipcode,
                        DefaultStore = dbCustomer.DefaultStore.Name
                    };

                    return appCustomer;

                }
            }

        }

        public void UpdateCustomer(CustomerModel customer)
        {
            throw new NotImplementedException();
        }
    }
}
