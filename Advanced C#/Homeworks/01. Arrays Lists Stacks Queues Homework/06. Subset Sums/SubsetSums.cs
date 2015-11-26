using System;
using System.Collections.Generic;
using System.Linq;
class SortedSubsetSums
{
    static void Main()
    {
        // Input
        int sum = int.Parse(Console.ReadLine());
        List<int> numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

        // Logic
        bool isPrinted = false;
        for (int i = 0; i < Math.Pow(2, numbers.Count); i++)
        {
            List<int> currentSubset = new List<int>();
            for (int j = 0; j < numbers.Count; j++)
            {
                if ((i & (1 << (numbers.Count - j - 1))) != 0)
                {
                    currentSubset.Add(numbers[j]);
                }
            }
            if (currentSubset.Sum() == sum && currentSubset.Count != 0)
            {
                // Output
                Console.WriteLine(string.Join(" + ", currentSubset) + " = {0}", sum);
                isPrinted = true;
            }
        }
        if (!isPrinted)
        {
            // Output
            Console.WriteLine("No matching subsets.");
        }
    }
}