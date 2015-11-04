using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

class Program
{
    static void Main()
    {
        string currentLine = Console.ReadLine();
        var dic = new Dictionary<string, Dictionary<string, int>>();


        while (currentLine != "End")
        {
            string pattern = @"([A-Za-z ]+) @([A-Za-z ]+) (\d+) (\d+)";
            Regex regex = new Regex(pattern);
            MatchCollection matches = regex.Matches(currentLine);

            foreach (Match match in matches)
            {
                string name = match.Groups[1].ToString();
                string avenue = match.Groups[2].ToString();
                int price = int.Parse(match.Groups[3].ToString());
                int count = int.Parse(match.Groups[4].ToString());
                if (!dic.ContainsKey(avenue))
                {
                    dic[avenue] = new Dictionary<string, int>();
                }
                if (!dic[avenue].ContainsKey(name))
                {
                    dic[avenue][name] = new int();
                }
                dic[avenue][name] += count * price;
            }
            currentLine = Console.ReadLine();
        }

        foreach (var element in dic)
        {
            Console.WriteLine(element.Key);
            foreach (var item in element.Value.OrderByDescending(x => x.Value))
            {
                Console.WriteLine("#  {0} -> {1}", item.Key, item.Value);
            }
        }
    }
}
