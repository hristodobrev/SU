namespace _10.Pairs_By_Difference
{
    using System;
    using System.Linq;

    class PairsByDifference
    {
        static void Main()
        {
            int[] numbers = Console.ReadLine().Split()
                .Select(int.Parse).ToArray();

            int difference = int.Parse(Console.ReadLine());

            int pairs = 0;

            for (int i = 0; i < numbers.Length - 1; i++)
            {
                for (int j = i + 1; j < numbers.Length; j++)
                {
                    if (Math.Abs(numbers[i] - numbers[j]) == difference)
                    {
                        pairs++;
                    }
                }
            }

            Console.WriteLine(pairs);
        }
    }
}
