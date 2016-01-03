namespace Empires.Resources
{
    using System;
    using Empires.Enums;

    public class Resource
    {
        private ResourceType resourceType;
        private int quantity;

        public Resource(ResourceType resourceType)
        {
            this.ResourceType = resourceType;
            this.quantity = 0;
        }

        public int Quantity
        {
            get
            {
                return this.quantity;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("quantity",
                        "Quantity cannot be negative");
                }
                this.quantity = value;
            }
        }

        public ResourceType ResourceType
        {
            get
            {
                return this.resourceType;
            }
            private set
            {
                this.resourceType = value;
            }
        }
    }
}
