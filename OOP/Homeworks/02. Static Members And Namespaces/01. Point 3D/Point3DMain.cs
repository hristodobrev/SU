using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01.Point_3D
{
    class Point3DMain
    {
        static void Main()
        {
            Point3D p1 = new Point3D(5, 2 ,7);
            Point3D p2 = new Point3D(3, -2, 6);

            Console.WriteLine(p1);
            Console.WriteLine(p2);
            Console.WriteLine(Point3D.InitialCoordinate);
        }
    }
}
