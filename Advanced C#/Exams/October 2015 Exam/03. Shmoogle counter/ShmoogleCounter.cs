using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class ShmoogleCounter
{
    static void Main()
    {
        string currentLine = Console.ReadLine();
        List<string> ints = new List<string>();
        List<string> doubles = new List<string>();

        while (currentLine != "//END_OF_CODE")
        {
            string pattern = @"double ([A-Za-z]{1,25})(?=[\s,;()])|int ([A-Za-z]{1,25})(?=[\s,;()])";
            Regex regex = new Regex(pattern);
            MatchCollection matches = regex.Matches(currentLine);

            foreach (Match match in matches)
            {
                if (match.Groups[1].ToString() != "")
                {
                    doubles.Add(match.Groups[1].ToString());
                }
                if (match.Groups[2].ToString() != "")
                {
                    ints.Add(match.Groups[2].ToString());
                }
            }

            currentLine = Console.ReadLine();
        }

        ints.Sort();
        doubles.Sort();
        if (doubles.Count > 0)
        {
            Console.WriteLine("Doubles: {0}", string.Join(", ", doubles));
        }
        else
        {
            Console.WriteLine("Doubles: None");
        }
        if (ints.Count > 0)
        {
            Console.WriteLine("Ints: {0}", string.Join(", ", ints));
        }
        else
        {
            Console.WriteLine("Ints: None");
        }
    }
}