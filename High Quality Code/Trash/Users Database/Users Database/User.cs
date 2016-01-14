using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Users_Database
{
    public class User
    {
        public User(string name, string password)
        {
            Name = name;
            Password = password;
        }

        public string Name { get; private set; }

        public string Password { get; private set; }
    }
}
