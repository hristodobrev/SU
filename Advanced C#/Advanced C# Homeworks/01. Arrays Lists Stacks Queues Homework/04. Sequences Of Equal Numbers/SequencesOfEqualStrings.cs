using System;
using System.Linq;
using System.Collections.Generic;
class SequencesOfEqualStrings
{
    static void Main()
    {
        // Input
        List<string> list = Console.ReadLine().Split(' ').ToList();

        // Logic
        for (int i = 0; i < list.Count; i++)
        {
            string counts = list[i];
            for (int x = i + 1; x < list.Count; x++)
            {
                if (list[i] == list[x])
                {
                    counts += " " + list[i];
                    list.RemoveAt(x);
                }
            }
            // Output
            Console.WriteLine(string.Join(" ", counts));
        }
    }
}