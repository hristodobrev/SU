using System;
using System.Text.RegularExpressions;
class ExtractingEmails
{
    static void Main()
    {
        // Input
        string text = Console.ReadLine();

        // Logic
        string pattern = @"(?<=\b)(?<![-_\.])[A-Za-z0-9]+[-_.]?[A-Za-z0-9]+(?![-_\.])@(?<![-_\.])[A-Za-z]+[-\.]?[A-Za-z]+\.[A-Za-z][-\.?A-Za-z]+(?![-_\.])?(?=\b)";
        Regex regex = new Regex(pattern);
        MatchCollection matches = regex.Matches(text);


        // Output
        foreach (Match match in matches)
        {
            Console.WriteLine(match);
        }
    }
}