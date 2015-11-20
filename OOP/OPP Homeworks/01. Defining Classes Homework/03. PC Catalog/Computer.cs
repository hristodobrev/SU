using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace _03.PC_Catalog
{
    class Computer
    {
        private string name;
        private decimal price;
        private List<Component> components = new List<Component>();


        public Computer(string name, params Component[] components)
        {
            this.Name = name;
            foreach (var component in components)
            {
                this.components.Add(component);
                this.price += component.Price;
            }
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

        public decimal Price
        {
            get
            {
                return this.price;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Name: " + this.Name + "\n");
            foreach (Component component in this.components)
            {
                sb.Append(component.ToString() + "\n");
            }
            sb.Append(String.Format("Total price: {0}", this.Price.ToString("C", CultureInfo.CreateSpecificCulture("bg-BG"))));

            return sb.ToString();
        }
    }
}
