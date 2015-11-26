using System;
using System.IO;
using System.Xml.Serialization;

namespace _03.Paths
{
    using System.IO;
    using System.Xml.Serialization;
    using System.Collections.Generic;

    public static class Storage
    {
        public static Path3D LoadPath(string source)
        {
            using (StreamReader reader = new StreamReader(source))
            {
                List<Point3D> points = new List<Point3D>();
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] splited = line.Split(new char[]{'[', ',', ']'}, StringSplitOptions.RemoveEmptyEntries);
                    points.Add(new Point3D(double.Parse(splited[0]), double.Parse(splited[1]), double.Parse(splited[2])));
                }

                return new Path3D(points.ToArray());
            }
        }

        public static void SavePath(string destination, Path3D path)
        {
            using (StreamWriter writer = new StreamWriter(destination))
            {
                foreach (var point in path.Points)
                {
                    writer.WriteLine(String.Format("[{0}, {1}, {2}]", point.X, point.Y, point.Z));
                }
            }
        }
    }
}
