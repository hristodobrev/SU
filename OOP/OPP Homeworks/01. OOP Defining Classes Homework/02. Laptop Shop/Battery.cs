using System;

namespace _02.Laptop_Shop
{
    class Battery
    {
        private string model;
        private double batteryLife;

        public Battery(string model)
            : this(model, 0)
        {

        }

        public Battery(string model, double batteryLife)
        {
            this.model = model;
            this.batteryLife = batteryLife;
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

        public double BatteryLife
        {
            get
            {
                return this.batteryLife;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Battery Life cannot be negative number.");
                }
                this.batteryLife = value;
            }
        }

    }
}
