using System;
using System.Collections.Generic;
using System.Linq;
class LongestIncreasingSequence
{
    static void Main()
    {
        // Input
        int[] array = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

        // Logic
        List<int> currentSequence = new List<int>();
        List<int> longestSequence = new List<int>();

        for (int i = 0; i < array.Length - 1; i++)
        {
            currentSequence.Add(array[i]);
            if (i == array.Length - 2)
            {
                currentSequence.Add(array[array.Length - 1]);
                Console.WriteLine(string.Join(" ", currentSequence));
                if (currentSequence.Count > longestSequence.Count)
                {
                    longestSequence.Clear();
                    longestSequence.AddRange(currentSequence);
                }
            }
            if (array[i] > array[i + 1])
            {
                Console.WriteLine(string.Join(" ", currentSequence));
                if (currentSequence.Count > longestSequence.Count)
                {
                    longestSequence.Clear();
                    longestSequence.AddRange(currentSequence);
                }
                currentSequence.Clear();
            }
            else
            {
                continue;
            }
        }
        // Ouput
        Console.WriteLine("Longest Sequence: {0}", string.Join(" ", longestSequence));
    }
}