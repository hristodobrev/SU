namespace _11.Equal_Sums
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class EqualSums
    {
        static void Main()
        {
            int[] numbers = Console.ReadLine().Split()
                .Select(int.Parse).ToArray();

            List<int> indexes = new List<int>();

            for (int i = 1; i <= numbers.Length; i++)
            {
                int leftSum = numbers.Take(i - 1).Sum();
                int rightSum = numbers.Skip(i).Sum();
                if (leftSum == rightSum)
                {
                    indexes.Add(i - 1);
                }
            }

            Console.WriteLine(indexes.Count < 1 ? "no" : string.Join(" ", indexes));
        }
    }
}
