using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class QueryMess
{
    static void Main()
    {
        List<string> output = new List<string>();
        string currentLine = Console.ReadLine();

        while (currentLine != "END")
        {
            var pairs = new Dictionary<string, List<string>>();
            string pairPattern = @"(?=&|.)(\w+?)=(.+?)(?=&|\n)";
            Regex pairRegex = new Regex(pairPattern);
            MatchCollection matches = pairRegex.Matches(currentLine);

            foreach (Match match in matches)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(match.Groups[1]);
                Console.ForegroundColor = ConsoleColor.White;
            }

            currentLine = Console.ReadLine();
        }
        //foreach (var line in output)
        //{
        //    Console.WriteLine(line);
        //}
    }
}