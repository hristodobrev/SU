using System;
using System.Text;
class CountSubstringOccurances
{
    static void Main()
    {
        // Input
        string text = Console.ReadLine();
        string searchKey = Console.ReadLine();

        // Output
        Console.WriteLine(CountKeys(text, searchKey));
    }

    // Logic
    static int CountKeys(string text, string searchKey)
    {
        int counter = 0;
        StringBuilder currentKey = new StringBuilder();

        for (int i = 0; i < text.Length - searchKey.Length; i++)
        {
            for (int j = 0; j < searchKey.Length; j++)
            {
                currentKey.Append(text[j + i]);
            }

            if (string.Compare(currentKey.ToString(), searchKey, true) == 0)
            {
                counter++;
            }
            currentKey.Clear();
        }

        return counter;
    }

}
