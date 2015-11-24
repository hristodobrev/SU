using System;
using System.Collections.Generic;

namespace _03.Paths
{
    public class Path3D
    {
        private List<Point3D> points;

        public Path3D(params Point3D[] points)
        {
            this.Points = new List<Point3D>();
            foreach (var point in points)
            {
                this.AddPoint(point);
            }
        }

        public List<Point3D> Points { get; set; }

        public void AddPoint(Point3D point)
        {
            this.Points.Add(point);
        }
    }
}
