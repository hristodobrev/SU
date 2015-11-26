using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
class Palindromes
{
    static void Main()
    {
        // Input
        string[] words = Console.ReadLine().Split(' ', '.', '!', '?', ',');
        
        // Output
        Console.WriteLine(string.Join(", ", Palindromesss(words)));
    }

    static SortedSet<string> Palindromesss(string[] words)
    {
        SortedSet<string> palindromes = new SortedSet<string>();

        for (int i = 0; i < words.Length; i++)
        {
            bool isPalindrome = true;
            for (int j = 0; j < words[i].Length / 2; j++)
            {
                if (words[i][j] != words[i][(words[i].Length - 1) - j])
                {
                    isPalindrome = false;
                    break;
                }
            }
            if (isPalindrome)
            {
                palindromes.Add(words[i]);
            }
        }
        palindromes.Remove(string.Empty);
        return palindromes;
    }

}