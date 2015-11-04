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
        List<List<int>> subsets = new List<List<int>>();
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
                subsets.Add(currentSubset);
                isPrinted = true;
            }
        }

        // Sorting lists by lenght and first element size
        for (int i = 0; i < subsets.Count - 1; i++)
        {
            int minIndex = i;
            for (int j = i + 1; j < subsets.Count; j++)
            {
                if (subsets[minIndex].Count > subsets[j].Count)
                {
                    minIndex = j;
                }
                else if (subsets[minIndex].Count == subsets[j].Count)
                {
                    if (subsets[minIndex].First() > subsets[j].First())
                    {
                        minIndex = j;
                    }
                }
            }
            List<int> temp = new List<int>();
            temp.AddRange(subsets[i].ToList());
            subsets[i].Clear();
            subsets[i].AddRange(subsets[minIndex]);
            subsets[minIndex].Clear();
            subsets[minIndex].AddRange(temp);
        }

        if (!isPrinted)
        {
            // Output
            Console.WriteLine("No matching subsets.");
        }
        else
        {
            for (int i = 0; i < subsets.Count; i++)
            {
                Console.WriteLine(string.Join(" + ", subsets[i]) + " = {0}", sum);
            }
        }
    }
}