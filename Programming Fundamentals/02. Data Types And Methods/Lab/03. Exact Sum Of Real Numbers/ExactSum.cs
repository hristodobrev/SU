namespace _03.Exact_Sum_Of_Real_Numbers
{
    using System;

    class ExactSum
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            decimal sum = 0;
            for (int i = 0; i < n; i++)
            {
                sum += decimal.Parse(Console.ReadLine());
            }
            Console.WriteLine(sum);
        }
    }
}
