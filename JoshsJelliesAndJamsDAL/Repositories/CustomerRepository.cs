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

        
        private DbContextOptions<JoshsJelliesAndJamsContext> optionsBuilder;
        
        public void DBConnection()
        {
            using var logStream = new StreamWriter("jjjdb-log.txt", append: true) { AutoFlush = true };
            
            string connectionString = File.ReadAllText("C:/Revature/JJJDb.txt");

            optionsBuilder = new DbContextOptionsBuilder<JoshsJelliesAndJamsContext>()
                .UseSqlServer(connectionString)
                .LogTo(logStream.WriteLine, minimumLevel: LogLevel.Information)
                .Options;
        }
        
        public void AddCustomer(CustomerModel appCustomer)
        {
            DBConnection();
            using var context = new JoshsJelliesAndJamsContext(optionsBuilder);

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

            //    foreach (var item in dbCustomer)
            //{
            //    if(item.Contains(newCustomer.FirstName) && item.Contains(newCustomer.LastName))
            //    {
            //        throw new Exception("Customer already exists in database.");
            //    }
                context.Add(newCustomer);
                context.SaveChanges();
            //}    

        }

        public void AddDefaultStore(string store)
        {
            throw new NotImplementedException();
        }
        
        public CustomerModel LookupCustomer(string fname, string lname)
        {
            throw new NotImplementedException();
        }

        public void UpdateCustomer(CustomerModel customer)
        {
            throw new NotImplementedException();
        }
    }
}
