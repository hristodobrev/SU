using System;
using System.Collections.Generic;
using System.Linq;
class CountSymbols
{
    static void Main()
    {
        string text = Console.ReadLine();
        SortedSet<char> characters = new SortedSet<char>();
        for (int i = 0; i < text.Length; i++)
        {
            characters.Add(text[i]);
        }
        int[] counter = new int[characters.Count()];
        for (int i = 0; i < characters.Count; i++)
        {
            for (int j = 0; j < text.Length; j++)
            {
                if (text[j] == characters.ElementAt(i))
                {
                    counter[i]++;
                }
            }
        }
        for (int i = 0; i < characters.Count(); i++)
        {
            Console.WriteLine("{0}: {1} time/s", characters.ElementAt(i), counter[i]);
        }
    }
}