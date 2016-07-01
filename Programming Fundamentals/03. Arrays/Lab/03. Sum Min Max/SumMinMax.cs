namespace _03.Sum_Min_Max
{
    using System;
    using System.Linq;

    class SumMinMax
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int[] numbers = new int[n];
            for (int i = 0; i < n; i++)
            {
                numbers[i] = int.Parse(Console.ReadLine());
            }

            Console.WriteLine("Sum = " + numbers.Sum());
            Console.WriteLine("Min = " + numbers.Min());
            Console.WriteLine("Max = " + numbers.Max());
            Console.WriteLine("First = " + numbers.First());
            Console.WriteLine("Last = " + numbers.Last());
            Console.WriteLine("Average = " + numbers.Average());
        }
    }
}