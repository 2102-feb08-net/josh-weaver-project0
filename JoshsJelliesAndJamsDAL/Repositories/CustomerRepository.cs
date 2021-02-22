using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using JoshsJelliesAndJams.Library;
using JoshsJelliesAndJams.Library.svc;
using JoshsJelliesAndJams.Library.IRepositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace JoshsJelliesAndJams.DAL.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {

        private DbContextOptions<JoshsJelliesAndJamsContext> optionsBuilder;



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

                    Customer newCustomer = CustomerSvcs.AddNewCustomer(appCustomer);

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
                        .Where(c => (c.FirstName == appCustomer.FirstName) && (c.LastName == appCustomer.LastName))
                        .First();

                    dbCustomer = CustomerSvcs.UpdateStore(appCustomer, dbCustomer);

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

                    CustomerModel appCustomer = CustomerSvcs.CustomerLookup(dbCustomer);

                    return appCustomer;

                }
            }

        }
    }
}
