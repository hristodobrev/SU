using System;
using System.Globalization;
using System.Text;
class UnicodeCharacters
{
    static void Main()
    {
        // Input
        string text = Console.ReadLine();

        // Output
        Console.WriteLine(string.Join("", PrintUnicodeCharacters(text)));
    }

    // Logic
    static string[] PrintUnicodeCharacters(string text)
    {
        string[] characterLiterals = new string[text.Length];

        for (int i = 0; i < text.Length; i++)
        {
            int number = text[i];
            characterLiterals[i] = "\\" + number.ToString("x4");
        }

        return characterLiterals;
    }
}