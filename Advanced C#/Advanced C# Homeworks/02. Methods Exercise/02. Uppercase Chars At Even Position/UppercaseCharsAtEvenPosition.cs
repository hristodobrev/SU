using System;
class UppercaseCharsAtEvenPosition
{
    static void Main()
    {
        // Input
        string text = Console.ReadLine();

        // Output
        Console.WriteLine(GetUppercasedChars(text));
    }

    // Logic
    static string GetUppercasedChars(string text)
    {
        char[] textArray = text.ToCharArray();
        for (int i = 0; i < textArray.Length; i++)
        {
            if (i % 2 == 0)
            {
                textArray[i] = char.ToUpper(textArray[i]);
            }
        }
        return new string(textArray);
    }

}