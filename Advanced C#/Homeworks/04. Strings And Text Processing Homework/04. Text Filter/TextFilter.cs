using System;
using System.Collections.Generic;
using System.Text;
class TextFilter
{
    static void Main()
    {
        // Input
        string[] bannedWords = Console.ReadLine().Split(' ', ',');
        string text = Console.ReadLine();

        // Output
        Console.WriteLine(CensoredText(bannedWords, text));
    }

    // Logic
    static string CensoredText(string[] bannedWords, string text)
    {
        string censoredText = text;
        for (int i = 0; i < bannedWords.Length; i++)
        {
            if (bannedWords[i] != "")
            {
                censoredText = censoredText.Replace(bannedWords[i], new string('*', bannedWords[i].Length));
            }
        }

        return censoredText;
    }

}