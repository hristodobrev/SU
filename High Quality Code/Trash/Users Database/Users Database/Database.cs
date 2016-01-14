using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Users_Database
{
    public class Database
    {
        private List<User> users;

        public Database()
        {
            this.users = new List<User>();
        }

        public void AddUser(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("User cannot be null.");
            }

            this.users.Add(user);
        }

        public bool TryLogin(string username, string password)
        {
            bool successfulLogin = this.users.Any(user => user.Name.Equals(username) && user.Password.Equals(password));

            return successfulLogin;
        }
    }
}
