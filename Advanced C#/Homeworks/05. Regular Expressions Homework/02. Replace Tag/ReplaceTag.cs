using System;
using System.Text;
using System.Text.RegularExpressions;
class ReplaceTag
{
    static void Main()
    {
        // Input
        string text = Console.ReadLine();

        // Logic
        string leftPattern = @"<a";
        string rightPattern = @"</a>";
        string quotesPattern = @"(""|'')";
        string closingTag = @"(?<=\"")>";

        Regex closingRegex = new Regex(closingTag);
        Regex leftRegex = new Regex(leftPattern);
        Regex rightRegex = new Regex(rightPattern);
        Regex quotesRegex = new Regex(quotesPattern);

        string newText = leftRegex.Replace(text, "[URL");
        newText = closingRegex.Replace(newText, "]");
        newText = rightRegex.Replace(newText, "[/URL]");
        newText = quotesRegex.Replace(newText, "");

        // Output
        Console.WriteLine(newText);
    }
}