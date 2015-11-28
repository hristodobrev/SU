using System;

namespace _01.Shapes.Shapes
{
    using Interfaces;

    class Circle : IShape 
    {
        private double radius;

        public Circle(double radius)
        {
            this.Radius = radius;
        }

        public double Radius
        {
            get
            {
                return this.radius;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Radius cannot be zero or negative number.");
                }
                this.radius = value;
            }
        }

        public double CalculateArea()
        {
            return this.Radius * Math.PI * Math.PI;
        }

        public double CalculatePerimeter()
        {
            return this.Radius * Math.PI * 2;
        }
    }
}
