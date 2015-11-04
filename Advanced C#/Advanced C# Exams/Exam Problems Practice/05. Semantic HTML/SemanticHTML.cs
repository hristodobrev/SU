using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class SemanticHTML
{
    static void Main()
    {
        string currentLine = Console.ReadLine();
        List<string> output = new List<string>();

        while (currentLine != "END")
        {
            string pattern = @"\<(div).+(\s*(id|class)\s*=\s*""(.+?)"")";
            Regex divAndIdPattern = new Regex(pattern);
            Match match = divAndIdPattern.Match(currentLine);
            Regex whiteSpaces = new Regex(@"(?<=.)\s+(?=.)");
            if (match.Groups.Count == 5)
            {
                string group1 = match.Groups[1].ToString();
                string group2 = match.Groups[2].ToString();
                string group4 = match.Groups[4].ToString();

                string currentOutput = currentLine.Replace(group1, group4).Replace(group2, "");
                output.Add(whiteSpaces.Replace(currentOutput, " "));
            }
            else
            {
                string secondPattern = @"<\/(div)>(\s*<!--\s*(.+?)\s*-->)";
                Regex secondRegex = new Regex(secondPattern);
                Match secondMatch = secondRegex.Match(currentLine);
                if (secondMatch.Groups.Count == 4)
                {
                    string group1 = secondMatch.Groups[1].ToString();
                    string group2 = secondMatch.Groups[2].ToString();
                    string group3 = secondMatch.Groups[3].ToString();

                    string currentOutput = currentLine.Replace(group1, group3).Replace(group2, "");
                    output.Add(currentOutput = whiteSpaces.Replace(currentOutput, " "));

                }
                else
                {
                    output.Add(currentLine);
                }
            }
            currentLine = Console.ReadLine();
        }

        foreach (var line in output)
        {
            Console.WriteLine(line);
        }
    }
}