using System;
using System.Text;
class StringLength
{
    static void Main()
    {
        // Input
        string text = Console.ReadLine();

        // Output
        Console.WriteLine(FillOrCut(text));
    }

    static string FillOrCut(string text)
    {
        StringBuilder newText = new StringBuilder();

        if (text.Length < 20)
        {
            newText.Append(text);
            newText.Append('*', 20 - text.Length);
            return newText.ToString();
        }

        for (int i = 0; i < 20; i++)
        {
            newText.Append(text[i]);
        }

        return newText.ToString();
    }

}
