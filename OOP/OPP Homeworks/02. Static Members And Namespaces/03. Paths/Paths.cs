using System;

namespace _03.Paths
{
    class Paths
    {
        static void Main()
        {
            Point3D p1 = new Point3D(4.6, 6.4, 36);
            Point3D p2 = new Point3D(6.2, 5.32, 64.2);
            Point3D p3 = new Point3D(19.6, 36.4, 23.5);

            Path3D path = new Path3D(p1, p2, p3);

            Storage.SavePath("MyPath.path", path);

            Path3D loaded = Storage.LoadPath("MyPath.path");

            foreach (var point in loaded.Points)
            {
                Console.WriteLine(point);
            }
        }
    }
}
