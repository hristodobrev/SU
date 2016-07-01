namespace _08.Most_Frequent_Number
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class MostFrequentNumber
    {
        static void Main()
        {
            int[] numbers = Console.ReadLine().Split()
                .Select(int.Parse).ToArray();

            Dictionary<int, int> counts = new Dictionary<int, int>();

            for (int i = 0; i < numbers.Length; i++)
            {
                if (!counts.ContainsKey(numbers[i]))
                {
                    counts[numbers[i]] = 1;
                }
                else
                {
                    counts[numbers[i]]++;
                }
            }

            int value = counts.Max(e => e.Value);
            Console.WriteLine(counts.FirstOrDefault(x => x.Value == value).Key);
        }
    }
}
