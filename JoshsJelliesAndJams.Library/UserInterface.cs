using JoshsJelliesAndJams.Library.IRepositories;
using System;


namespace JoshsJelliesAndJams.Library
{
    public class UserInterface
    {
        ICustomerRepository _customerRepository;

        public UserInterface(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public void Run()
        {
            Welcome();
        }

        private void Welcome()
        {
            Console.WriteLine("Hello and Welcome to Josh's Jellies and Jams!");
            Console.WriteLine("Are you a new customer or returning customer? Please select a number:");
            Console.WriteLine($"1- New Customer\t2- Returning Customer");
            string response = Console.ReadLine();
            if (int.Parse(response) == 1)
            {
                NewCustomer();
            }
            else if (int.Parse(response) == 2)
            {
                ReturningCustomer();
            }
            else
            {
                throw new ArgumentOutOfRangeException("Please select a proper input");
            }
        }

        private void ReturningCustomer()
        {
            Console.WriteLine("What is your first name?");
            string firstName = Console.ReadLine().ToUpper();
            Console.WriteLine("What is your last name?");
            string lastName = Console.ReadLine().ToUpper();
            CustomerModel temp = new CustomerModel();

            temp = _customerRepository.LookupCustomer(firstName, lastName);
        }

        private void Selection()
        {
            Console.WriteLine("What would you like to do today? Please select a number:");
            Console.WriteLine("1- Create a new order\t2-Set default store\t3- Review Order History");
            string response = Console.ReadLine();

            if (int.Parse(response) == 1)
            {
                NewOrder();
            }
            else if (int.Parse(response) == 2)
            {
                DefaultStore();
            }
            else if (int.Parse(response) == 3)
            {
                OrderHistory();
            }
            else
            {
                throw new ArgumentOutOfRangeException("Please select a proper input.");
            }
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

            _customerRepository.AddCustomer(customer);

            Selection();
        }

        private void NewOrder()
        {
            OrderModel order = new OrderModel();
            string productId;
            string quantity;
            bool addOrder = true;
            //import inventory list from BLL

            Console.WriteLine("Please enter your first name:");
            string firstName = Console.ReadLine();

            Console.WriteLine("Please enter your last name:");
            string lastName = Console.ReadLine();

            _customerRepository.LookupCustomer(firstName, lastName);

            do
            {
                //add a list of inventory (probably with a loop), data validation, etc)

                Console.WriteLine("Please select a product:");
                productId = Console.ReadLine();

                Console.WriteLine("Please add a quantity:");
                quantity = Console.ReadLine();

                //add list to order model

                Console.WriteLine("Would you like to add anything else to your order? Y/N");
                if (Console.ReadLine().Contains("N"))
                    addOrder = false;
            } while (addOrder);

            //Console.WriteLine($"Thank you for your order. Your order number is {Order.number}. Press enter to continue.");
            Console.ReadLine();

            Selection();

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
