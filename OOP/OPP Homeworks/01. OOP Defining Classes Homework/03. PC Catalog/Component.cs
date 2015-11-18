using System;

namespace _03.PC_Catalog
{
    class Component
    {
        private string name;
        private decimal price;
        private string details;

        public Component(string name, string details, decimal price)
        {

        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Name cannot be empty.");
                }
                this.name = value;
            }
        }
    }
}
