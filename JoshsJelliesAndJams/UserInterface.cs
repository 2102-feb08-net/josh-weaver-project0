using JoshsJelliesAndJams.Library.IRepositories;
using JoshsJelliesAndJams.Library.Models;
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

            if (response.Equals("Management"))
            {
                ManagementMenu();
            }
            else if (int.Parse(response) == 2)
            {
                OrderHistory();
            }
            else if (int.Parse(response) == 1)
            {
                NewOrder();
            }
            else
            {
                Console.WriteLine("Please select a proper input.");
                Console.WriteLine();
                Welcome();
            }
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
                    _customer = NewCustomer();
                    customerResponse = false;
                }
                else if (int.Parse(response) == 2)
                {
                    _customer = ReturningCustomer();
                    customerResponse = false;
                }
                else
                {
                    Console.WriteLine("Please select a proper input");
                }
            } while (customerResponse);

          

            Console.WriteLine();
            bool addOrder = true;

            List<ProductModel> productList = _storeRepository.CheckInventory(_customer.DefaultStore);

            for (int i = 0; i < productList.Count; i++)
                Console.WriteLine($"{productList[i].ProductId} - {productList[i].Name}\t {productList[i].CostPerItem:C2}\t\t");

            
            List<ProductModel> orderList = new List<ProductModel>();
            
            string productID;
            string quantity;
            int loopCounter = 0;
            do
            {
                ProductModel lineItem = new ProductModel();

                Console.WriteLine("Please select a product by number:");
                productID = Console.ReadLine();
                lineItem.ProductId = int.Parse(productID);
                lineItem.CostPerItem = productList[int.Parse(productID)-1].CostPerItem;

                Console.WriteLine("Please add a quantity:");
                quantity = Console.ReadLine();
                lineItem.Quantity = int.Parse(quantity);

                orderList.Add(lineItem);

                Console.WriteLine("Would you like to add anything else to your order? Y/N");
                if (Console.ReadLine().Equals("N"))
                    addOrder = false;
                loopCounter++;
            } while (addOrder);

            _order = new OrderModel
            {
                Product = orderList,
                CustomerNumber = _customer.CustomerID,
                StoreID = _customer.DefaultStore
            };

            decimal total = 0;
            foreach (var line in _order.Product)
                total += (line.Quantity * line.CostPerItem);
            _order.Total = total;

            _orderRepository.AddOrder(_order);

            Console.WriteLine($"Thank you for your order. Press enter to continue.");
            Console.ReadLine();

            Welcome();

        }

        private CustomerModel ReturningCustomer()
        {
            Console.WriteLine("What is your first name?");
            string firstName = Console.ReadLine();
            Console.WriteLine("What is your last name?");
            string lastName = Console.ReadLine();

            _customer = new CustomerModel();
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
            return _customer;
        }

        private CustomerModel NewCustomer()
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

            customer.DefaultStore = DefaultStore();

            _customer = customer;
            _customer = _customerRepository.AddCustomer(customer);

            return _customer;
        }



        private int DefaultStore()
        {
            List<StoreModel> storeList = _storeRepository.ListStores();

            foreach (var store in storeList)
            {
                Console.WriteLine($"{store.StoreID} - {store.StoreName} - {store.StoreCity}, {store.StoreState}");
            }
            Console.WriteLine("Please select a store to order from:");
            string userInput = Console.ReadLine();

            return int.Parse(userInput);

        }

        private void OrderHistory()
        {
            _customer = ReturningCustomer();
            Console.WriteLine("Order History:");

            List<OrderModel> orderHistory = _orderRepository.PullHistory(_customer);
            
            foreach(var line in orderHistory)
            {
                Console.WriteLine($"Order Number: {line.OrderNumber}: #:{Decimal.ToInt64(line.NumberOfProducts)} - $:{line.Total:C2} - {line.OrderPlaced}");
                Console.WriteLine();
            }
            Console.WriteLine("Which order would you like to see? (Input numeric value)");
            int response = int.Parse(Console.ReadLine());

            List<ProductModel> orderDetail = _orderRepository.SeeDetails(response);

            foreach(var line in orderDetail)
            {
                Console.WriteLine($"{line.Name} - {Decimal.ToInt64(line.Quantity)} - {line.CostPerItem:C2} - {line.TotalLine}");
                Console.WriteLine();
            }
            Console.ReadLine();
            Welcome();
        }

        private void ManagementMenu()
        {
            Console.WriteLine("Welcome Management! What would you like to see?");
            Console.WriteLine("1 - Store Order History\t2 - Store Inventory");

            if (int.Parse(Console.ReadLine()) == 1)
            {
                StoreHistory();
            }
            else if (int.Parse(Console.ReadLine()) == 2)
            {
                StoreInventory();
            }
            else
                Console.WriteLine("Please enter a valid input:");
        }
        private void StoreHistory()
        {
            List<StoreModel> storeList = _storeRepository.ListStores();

            foreach (var store in storeList)
            {
                Console.WriteLine($"{store.StoreID} - {store.StoreName} - {store.StoreCity}, {store.StoreState}");
            }
            Console.WriteLine("Please select a store to view order history from:");
            string userInput = Console.ReadLine();

            List<OrderModel> orderHistory = _storeRepository.StoreHistory(int.Parse(userInput));

            foreach (var line in orderHistory)
            {
                Console.WriteLine($"Order Number: {line.OrderNumber}: #:{line.NumberOfProducts:G} - $:{line.Total:C2} - {line.OrderPlaced}");
                Console.WriteLine();
            }
            Console.WriteLine("Which order would you like to see? (Input numeric value)");
            int response = int.Parse(Console.ReadLine());

            List<ProductModel> orderDetail = _orderRepository.SeeDetails(response);

            foreach (var line in orderDetail)
            {
                Console.WriteLine($"{line.Name} - {line.Quantity:G} - {line.CostPerItem:C2} - {line.TotalLine}");
                Console.WriteLine();
            }
            Console.ReadLine();
        }

        private void StoreInventory()
        {
            List<StoreModel> storeList = _storeRepository.ListStores();

            foreach (var store in storeList)
            {
                Console.WriteLine($"{store.StoreID} - {store.StoreName} - {store.StoreCity}, {store.StoreState}");
            }
            Console.WriteLine("Please select a store to view current inventory:");
            int userInput = int.Parse(Console.ReadLine());

            List<ProductModel> displayInventory = _storeRepository.CheckInventory(userInput);
            
            foreach (var line in displayInventory)
            {
                Console.WriteLine($"{line.Name} - {line.Quantity:G}");
                Console.WriteLine();
            }
            Console.ReadLine();


        }
    }
}
