namespace _12.Rectangle_Properties
{
    using System;

    class RectangleProperties
    {
        static void Main()
        {
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());

            double perimeter = width * 2 + height * 2;
            double area = width * height;
            double diagonal = Math.Sqrt(width * width + height * height);

            Console.WriteLine("{0}\n{1}\n{2}", perimeter, area, diagonal);
        }
    }
}
