using System;

namespace _02.Distance_Calculator
{
    class DistanceCalculatorMain
    {
        static void Main()
        {
            Console.WriteLine(DistanceCalculator.CalculateDistance(3, 5, 1, 3, 7, 1));
            Console.WriteLine(DistanceCalculator.CalculateDistance(4.63, 42.63, 23.5, 23.76, -23.543, -29.3));
        }
    }
}
