using System;
using System.Collections.Generic;
namespace _02.Laptop_Shop
{
    class Laptop
    {
        private string model;
        private string manufacturer;
        private string processor;
        private int ram;
        private string graphicsCard;
        private string hdd;
        private string screen;
        private Battery battery;
        private double price;

        public Laptop(string model, double price)
            : this(model, null, null, 0, null, null, null, null, 0, price)
        {
            
        }

        public Laptop(string model, string manufacturer, double price)
            : this(model, manufacturer, null, 0, null, null, null, null, 0, price)
        {

        }

        public Laptop(string model, string manufacturer, string processor, double price)
            : this(model, manufacturer, processor, 0, null, null, null, null, 0, price)
        {

        }

        public Laptop(string model, string manufacturer, string processor, int ram, double price)
            : this(model, manufacturer, processor, ram, null, null, null, null, 0, price)
        {

        }

        public Laptop(string model, string manufacturer, string processor, int ram, string graphicsCard, double price)
            : this(model, manufacturer, processor, ram, graphicsCard, null, null, null, 0, price)
        {

        }

        public Laptop(string model, string manufacturer, string processor, int ram, string graphicsCard,
            string hdd, double price)
            : this(model, manufacturer, processor, ram, graphicsCard, hdd, null, null, 0, price)
        {

        }

        public Laptop(string model, string manufacturer, string processor, int ram, string graphicsCard,
            string hdd, string screen, double price)
            : this(model, manufacturer, processor, ram, graphicsCard, hdd, screen, null, 0, price)
        {

        }

        public Laptop(string model, string manufacturer, string processor, int ram, string graphicsCard,
            string hdd, string screen, string battery, double price)
            : this(model, manufacturer, processor, ram, graphicsCard, hdd, screen, battery, 0, price)
        {

        }

        public Laptop(string model, string manufacturer, string processor, int ram, string graphicsCard,
            string hdd, string screen, string battery, double batteryLife, double price)
        {
            if (!String.IsNullOrEmpty(model))
            {
                this.model = model;
            }
            else
            {
                throw new ArgumentNullException("Model cannot be empty.");
            }

            if (price >= 0)
            {
                this.price = price;
            }
            else
            {
                throw new ArgumentOutOfRangeException("Price cannot be negative number.");
            }

            this.manufacturer = manufacturer;
            this.processor = processor;
            this.ram = ram;
            this.graphicsCard = graphicsCard;
            this.hdd = hdd;
            this.screen = screen;
            this.battery = new Battery(battery, batteryLife);
            this.price = price;
        }

        public string Model
        {
            get
            {
                return this.model;
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Model cannot be empty.");
                }
                this.model = value;
            }
        }

        public string Manufacturer
        {
            get
            {
                return this.manufacturer;
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Manufacturer cannot be empty.");
                }
                this.manufacturer = value;
            }
        }

        public string Processor
        {
            get
            {
                return this.processor;
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Processor cannot be empty.");
                }
                this.processor = value;
            }
        }

        public int Ram
        {
            get
            {
                return this.ram;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Ram cannot be negative number.");
                }
                this.ram = value;
            }
        }

        public string GraphicsCard
        {
            get
            {
                return this.graphicsCard;
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Graphics Card cannot be empty.");
                }
                this.graphicsCard = value;
            }
        }

        public string Hdd
        {
            get
            {
                return this.hdd;
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("HDD cannot be empty.");
                }
                this.hdd = value;
            }
        }

        public string Screen
        {
            get
            {
                return this.screen;
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Screen cannot be empty.");
                }
                this.screen = value;
            }
        }

        public Battery Battery
        {
            get
            {
                return this.battery;
            }
            set
            {
                this.battery = value;
            }
        }

        public double Price
        {
            get
            {
                return this.price;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Price cannot be negative number.");
                }
                this.price = value;
            }
        }

        public override string ToString()
        {
            List<string> output = new List<string>();
            output.Add("Model: " + this.Model);
            if (!String.IsNullOrEmpty(this.manufacturer))
            {
                output.Add("Manufacturer: " + this.manufacturer);
            }
            if (!String.IsNullOrEmpty(this.Processor))
            {
                output.Add("Processor: " + this.Processor);
            }
            if (this.Ram != 0)
            {
                output.Add("RAM: " + this.Ram + " GB");
            }
            if (!String.IsNullOrEmpty(this.GraphicsCard))
            {
                output.Add("Graphics Card: " + this.GraphicsCard);
            }
            if (!String.IsNullOrEmpty(this.Hdd))
            {
                output.Add("HDD: " + this.Hdd);
            }
            if (!String.IsNullOrEmpty(this.Screen))
            {
                output.Add("Screen: " + this.Screen);
            }
            if (!String.IsNullOrEmpty(this.Battery.Model))
            {
                output.Add("Battery: " + this.Battery.Model);
            }
            if (this.Battery.BatteryLife != 0)
            {
                output.Add("Battery Life: " + this.Battery.BatteryLife + " hours");
            }
            output.Add(String.Format("Price: {0:0.00} lv.", this.Price));
            return String.Join("\n", output);
        }

    }
}
