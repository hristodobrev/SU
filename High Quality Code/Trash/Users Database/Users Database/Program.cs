using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Users_Database
{
    class Program
    {
        static void Main(string[] args)
        {
            var database = new Database();
            var user = new User("Gosho", "123456");
            database.AddUser(user);

            Console.WriteLine(database.TryLogin("Pepo", "1234"));
            Console.WriteLine(database.TryLogin("Gosho", "123456"));
        }
    }
}
