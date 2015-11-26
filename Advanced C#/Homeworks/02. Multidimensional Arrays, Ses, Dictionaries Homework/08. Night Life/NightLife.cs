using System;
using System.Collections.Generic;
using System.Linq;
class NightLife
{
    static void Main()
    {
        Dictionary<string, SortedDictionary<string, SortedSet<string>>> nightLife = new Dictionary<string, SortedDictionary<string, SortedSet<string>>>();
        string currentLine = Console.ReadLine();
        while (currentLine.ToLower() != "end")
        {
            string[] splited = currentLine.Split(';');
            if (!nightLife.ContainsKey(splited[0]))
            {
                nightLife[splited[0]] = new SortedDictionary<string, SortedSet<string>>();
            }
            if (!nightLife[splited[0]].ContainsKey(splited[1]))
            {
                nightLife[splited[0]][splited[1]] = new SortedSet<string>();
            }
            nightLife[splited[0]][splited[1]].Add(splited[2]);
            currentLine = Console.ReadLine();
        }
        foreach (var city in nightLife)
        {
            Console.WriteLine(city.Key);
            foreach (var place in city.Value)
            {
                Console.WriteLine("->{0}: {1}", place.Key, string.Join(", ", place.Value));
            }
        }
    }
}