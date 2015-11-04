using System;
using System.Text.RegularExpressions;
class SeriesOfLetters
{
    static void Main()
    {
        // Input
        string text = Console.ReadLine();

        // Logic
        string pattern = @"([a-zA-Z])(?=\1)";

        Regex regex = new Regex(pattern);

        string result = regex.Replace(text, "");

        // Output
        Console.WriteLine(result);
    }
}