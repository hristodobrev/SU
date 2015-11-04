using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string text = "This is very long text, and I'm too lazy to write it on my own, so it will end here...";
        string searchTerm = "OWN";
        string[] source = text.Split(new char[] { ' ', '.', ',', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);

        var wordsFound =
            from word in source
            where word.ToLower() == searchTerm.ToLower()
            select word;

        Console.WriteLine(wordsFound.Count());

    }
}