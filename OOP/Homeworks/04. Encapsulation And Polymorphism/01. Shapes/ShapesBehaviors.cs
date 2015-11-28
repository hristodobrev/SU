using System;

namespace _01.Shapes
{
    using Interfaces;
    using Shapes;

    class ShapesBehaviors
    {
        static void Main()
        {
            IShape[] shapes = 
            {
                new Rectangle(3.4, 1.5),
                new Rhombus(1.2, 4.1),
                new Rectangle(1.4, 3.5),
                new Circle(5.2),
                new Rectangle(10.4, 9.5),
                new Circle(3.5),
                new Rhombus(23.5, 10.5)
            };

            foreach (IShape shape in shapes)
            {
                Console.WriteLine("{0}: Area - {1:F2}, Perimeter - {2:F2}", shape.GetType().Name, shape.CalculateArea(), shape.CalculatePerimeter());
            }
        }
    }
}
