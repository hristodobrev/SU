using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;
class ExtractHyperlinks
{
    static void Main()
    {
        // Input
        List<string> text = new List<string>();
        string currentLine = Console.ReadLine();
        while (currentLine.ToLower() != "end")
        {
            text.Add(currentLine + " ");
            currentLine = Console.ReadLine();
        }

        // Logic
        string pattern = @"(?<=href=([""'])).*?(?=\1)";
        Regex regex = new Regex(pattern);
        MatchCollection matches = regex.Matches(string.Join(" ", text));

        // Output
        foreach (Match match in matches)
        {
            Console.WriteLine(match);
        }
    }
}