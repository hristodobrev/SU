namespace Users_Database
{
    using System;
    using System.Collections.Generic;

    public class Database
    {
        private List<User> users;

        public Database()
        {
            this.users = new List<User>();
        }

        private IEnumerable<User> Users
        {
            get
            {
                return this.users;
            }
        }

        public void AddUser(User user)
        {
            if (user == null)
            {
                throw new InvalidOperationException("Cannot add not existing user.");
            }

            this.users.Add(user);
        }
    }
}
