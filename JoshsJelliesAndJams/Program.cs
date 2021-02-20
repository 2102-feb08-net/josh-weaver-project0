using JoshsJelliesAndJams.Library;
using JoshsJelliesAndJams.DAL.Repositories;

namespace JoshsJelliesAndJams
{
    public class Program
    {
        public static void Main(string[] args)
        {            
            UserInterface run = new UserInterface(new CustomerRepository());
            run.Run();
        }
    }
}
