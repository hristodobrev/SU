using System;
using System.Text;
class ReverseString
{
    static void Main()
    {
        // Input
        string text = Console.ReadLine();

        // Output
        Console.WriteLine(ReverseText(text));
    }

    // Logic
    static string ReverseText(string text)
    {
        StringBuilder reversedText = new StringBuilder();

        for (int i = text.Length - 1; i >= 0; i--)
        {
            reversedText.Append(text[i]);
        }

        return reversedText.ToString();
    }

}