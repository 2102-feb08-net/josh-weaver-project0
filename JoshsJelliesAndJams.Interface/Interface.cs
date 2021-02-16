using System;

namespace JoshsJelliesAndJams.Interface
{
    public class Interface
    {
        static void Welcome()
        {
            Console.WriteLine("Hello and Welcome to Josh's Jellies and Jams!");
            Console.WriteLine("Are you a new customer or returning customer? Please select a number:");
            Console.WriteLine($"1- New Customer\t2- Returning Customer");
            string response = Console.ReadLine();
            if(int.Parse(response) == 1)
            {
                AddCustomer();
            }
            else if (int.Parse(response) == 2)
            {
                Selection();
            }
            else
            {
                throw new ArgumentOutOfRangeException("Please select a proper input");
            }
        }

        private static void AddCustomer()
        {
            throw new NotImplementedException();
        }

        static void Selection()
        {
            Console.WriteLine("What would you like to do today? Please select a number:");
            Console.WriteLine("1- Create a new order\t2-Set default store\t3- Review Order History");
            string response = Console.ReadLine();

            if (int.Parse(response) == 1)
            {
                AddOrder();
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

        static void NewCustomer()
        {
            Console.WriteLine("Thank you for choosing to be a new customer!");
            Console.WriteLine("Please enter your first name:");
            string firstName = Console.ReadLine();
            Console.WriteLine("Please enter your last name:");
            string lastName = Console.ReadLine();
            Console.WriteLine("Please enter your street address:");
            string streetAddress = Console.ReadLine();
            Console.WriteLine("Please enter your state abbriviation:");
            string state = Console.ReadLine();
            Console.WriteLine("Please enter your zip code:");
            string zipcode = Console.ReadLine();

            //add constructor and pass through the inputted information
        }
    }
}
