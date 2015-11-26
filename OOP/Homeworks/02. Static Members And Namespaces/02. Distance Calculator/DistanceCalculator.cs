using System;

namespace _02.Distance_Calculator
{
    static class DistanceCalculator
    {
        public static double CalculateDistance(double x1, double y1, double z1,
            double x2, double y2, double z2)
        {
            return Math.Sqrt((x2 - x1) * (x2 - x1) +
                (y2 - y1) * (y2 - y1) +
                (z2 - z1) * (z2 - z1));
        }
    }
}
