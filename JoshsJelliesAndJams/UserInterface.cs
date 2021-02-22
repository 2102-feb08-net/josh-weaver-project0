using JoshsJelliesAndJams.Library.IRepositories;
using System;
using System.Collections.Generic;

namespace JoshsJelliesAndJams.Library
{
    public class UserInterface
    {
        ICustomerRepository _customerRepository;
        IOrderRepository _orderRepository;
        IStoreRepository _storeRepository;

        static CustomerModel _customer;
        static OrderModel _order;
        static ProductModel _product;

        public UserInterface(ICustomerRepository customerRepository, IOrderRepository orderRepository, IStoreRepository storeRepository)
        {
            _customerRepository = customerRepository;
            _orderRepository = orderRepository;
            _storeRepository = storeRepository;
        }

        public void Run()
        {
            Welcome();
        }

        private void Welcome()
        {
            Console.WriteLine("Hello and Welcome to Josh's Jellies and Jams!");
            Console.WriteLine("What would you like to do today? Please select a number:");
            Console.WriteLine("1 - Create a new order\t 2 - Review Order History");
            string response = Console.ReadLine();

            if (int.Parse(response) == 1)
            {
                NewOrder();
            }
            else if (int.Parse(response) == 2)
            {
                OrderHistory();
            }
            else if (response.Equals("Management"))
            {
                //ManagementMenu();
            }
            else
            {
                Console.WriteLine("Please select a proper input.");
                Console.WriteLine();
                Welcome();
            }
        }

        private void ReturningCustomer()
        {
            Console.WriteLine("What is your first name?");
            string firstName = Console.ReadLine().ToUpper();
            Console.WriteLine("What is your last name?");
            string lastName = Console.ReadLine().ToUpper();

            _customer = _customerRepository.LookupCustomer(firstName, lastName);

            Console.WriteLine($"{_customer.FirstName} {_customer.LastName}\n{_customer.StreetAddress1}\n{_customer.StreetAddress2}\n{_customer.City}, {_customer.State}, {_customer.Zipcode}");
            Console.WriteLine();
            Console.WriteLine("Is the above information correct? Y/N");
            string response = Console.ReadLine();
            if (response.Equals("N"))
            {
                Console.WriteLine("Would you like to quit? Y/N");
                string secondResponse = Console.ReadLine();
                if (secondResponse.Equals("Y"))
                {
                    Welcome();
                }
                else
                {
                    ReturningCustomer();
                }
            }
        }

        private void Selection()
        {

        }

        private void NewCustomer()
        {
            CustomerModel customer = new CustomerModel();

            Console.WriteLine("Thank you for choosing to be a new customer!");
            Console.WriteLine("Please enter your first name:");
            string firstName = Console.ReadLine();
            customer.FirstName = firstName;

            Console.WriteLine("Please enter your last name:");
            string lastName = Console.ReadLine();
            customer.LastName = lastName;

            Console.WriteLine("Please enter your street address:");
            string streetAddress = Console.ReadLine();
            customer.StreetAddress1 = streetAddress;

            Console.WriteLine("Please enter your additional address information (Apt, Suite, etc):");
            string streetAddress2 = Console.ReadLine();
            customer.StreetAddress2 = streetAddress2;

            Console.WriteLine("Please enter your city");
            string city = Console.ReadLine();
            customer.City = city;

            Console.WriteLine("Please enter your state abbriviation:");
            string state = Console.ReadLine();
            customer.State = state;

            Console.WriteLine("Please enter your zip code:");
            string zipcode = Console.ReadLine();
            customer.Zipcode = zipcode;

            _customer = customer;
            _customerRepository.AddCustomer(customer);
        }

        private void NewOrder()
        {
            Console.WriteLine("Are you a new customer or returning customer? Please select a number:");
            Console.WriteLine($"1- New Customer\t2- Returning Customer");
            string response = Console.ReadLine();

            bool customerResponse = true;

            do
            {
                if (int.Parse(response) == 1)
                {
                    NewCustomer();
                    customerResponse = false;
                }
                else if (int.Parse(response) == 2)
                {
                    ReturningCustomer();
                    customerResponse = false;
                }
                else
                {
                    Console.WriteLine("Please select a proper input");
                }
            } while (customerResponse);

            Console.WriteLine();
            bool addOrder = true;

            

            do
            {
                //add a list of inventory (probably with a loop), data validation, etc)

                Console.WriteLine("Please select a product:");
                //productId = Console.ReadLine();

                Console.WriteLine("Please add a quantity:");
                //quantity = Console.ReadLine();

                //add list to order model

                Console.WriteLine("Would you like to add anything else to your order? Y/N");
                if (Console.ReadLine().Equals("N"))
                    addOrder = false;
            } while (addOrder);

            //Console.WriteLine($"Thank you for your order. Your order number is {Order.number}. Press enter to continue.");
            Console.ReadLine();

            Welcome();

        }

        private void DefaultStore()
        {

        }

        private void OrderHistory()
        {
            Console.WriteLine("What type of order history would you like to see?");
            Console.WriteLine("1 - Customer History\t2 - Store History\t3 - Store Inventory");
            string input = Console.ReadLine();

            if (int.Parse(input) == 1)
            {
                CustomerHistory();
            }
            else if (int.Parse(input) == 2)
            {
                StoreHistory();
            }
            else if (int.Parse(input) == 3)
            {
                StoreInventory();
            }
            else
            {
                Console.WriteLine("Please input a valid selection.");
                OrderHistory();
            }
        }

        private void CustomerHistory()
        {
            //logic here for receiving the customer name to pull order history for the customer
        }

        private void StoreHistory()
        {
            //logic here to select a store name and pull all order history for that store
        }

        private void StoreInventory()
        {
            //logic here to select a store and display the store inventory 
            //create a store inventory method
        }
    }
}
