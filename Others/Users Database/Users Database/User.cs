namespace Users_Database
{
    using System;

    public class User
    {
        private string username;
        private string password;

        public User(string username, string password)
        {
            this.Username = username;
            this.Password = password;
        }

        public string Username
        {
            get
            {
                return this.username; 
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Username cannot be null or empty.");
                }

                this.username = value;
            }
        }

        public string Password
        {
            get
            {
                return this.password;
            }

            private set
            {
                if (value.Length < 6)
                {
                    throw new ArgumentOutOfRangeException("Password must contain at least 6 characters.");
                }

                this.password = value;
            }
        }
    }
}
