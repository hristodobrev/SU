namespace Generating_Combinations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class GeneratingCombinations
    {
        static void Main(string[] args)
        {
            Console.Write("Enter numbers: ");
            var numbers = Console.ReadLine().Split().Select(e => int.Parse(e)).ToList();
            Console.Write("Enter count: ");
            var count = int.Parse(Console.ReadLine());
            var nums = new int[count];

            GenerateCombinations(nums, numbers, 0);
        }

        static void GenerateCombinations(int[] foundCombination, List<int> numbers, int index)
        {
            if (index >= foundCombination.Length)
            {
                Console.WriteLine(string.Join(" ", foundCombination));
                return;
            }

            for (int ind = 0; ind < numbers.Count; ind++)
            {
                foundCombination[index] = numbers[ind];
                GenerateCombinations(foundCombination, numbers, index + 1);
            }
        }
    }
}

