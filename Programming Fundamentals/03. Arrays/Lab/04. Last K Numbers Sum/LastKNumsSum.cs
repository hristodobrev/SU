namespace _04.Last_K_Numbers_Sum
{
    using System;

    class LastKNumsSum
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());

            decimal[] numbers = new decimal[n];
            numbers[0] = 1;

            for (int i = 1; i < n; i++)
            {
                numbers[i] = GetSum(numbers, i - k, i - 1);
            }

            Console.WriteLine(string.Join(" ", numbers));
        }

        private static decimal GetSum(decimal[] numbers, int start, int end)
        {
            decimal sum = 0;
            start = Math.Max(0, start);
            for (int j = start; j <= end; j++)
            {
                sum += numbers[j];
            }

            return sum;
        }
    }
}
