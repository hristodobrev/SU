using System;
using System.Text.RegularExpressions;
class SentenceExtractor
{
    static void Main()
    {
        // Input
        string keyword = Console.ReadLine();
        string text = Console.ReadLine();

        // Logic
        string pattern = @"[\w ]+" + keyword + @"[\w ]+[\.?!]";
        Regex regex = new Regex(pattern);
        MatchCollection matches = regex.Matches(text);

        // Output
        foreach (Match match in matches)
        {
            string output = match.ToString().TrimStart(new char[0]);
            Console.WriteLine(output);
        }
    }
}