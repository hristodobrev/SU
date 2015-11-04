using System;
using System.Text.RegularExpressions;
class ValidUsernames
{
    static void Main()
    {
        // Input
        string text = Console.ReadLine();

        // Logic
        string[] splitedNames = text.Split(new char[] {' ', '/', '\\', '(', ')'}, StringSplitOptions.RemoveEmptyEntries);
        string names = " " + string.Join(" ", splitedNames) + " ";
        string pattern = @"(?<=[\b ])[A-Za-z]\w{2,24}(?=[\b ])";
        Regex regex = new Regex(pattern);
        MatchCollection matches = regex.Matches(names);

        string firstName = null;
        string secondName = null;
        int maxSum = int.MinValue;

        for (int i = 0; i < matches.Count - 1; i++)
        {
            if (matches[i].Length + matches[i + 1].Length > maxSum)
            {
                maxSum = matches[i].Length + matches[i + 1].Length;
                firstName = matches[i].ToString();
                secondName = matches[i + 1].ToString();
            }
        }

        // Output
        Console.WriteLine(firstName);
        Console.WriteLine(secondName);
    }
}