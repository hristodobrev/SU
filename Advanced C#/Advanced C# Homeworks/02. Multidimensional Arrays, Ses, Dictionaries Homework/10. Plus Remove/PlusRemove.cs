using System;
using System.Collections.Generic;
using System.Text;
class PlusRemove
{
    static void Main()
    {
        List<StringBuilder> lines = new List<StringBuilder>();
        string currentLine = Console.ReadLine();
        while (currentLine.ToLower() != "end")
        {
            lines.Add(new StringBuilder(currentLine));
            currentLine = Console.ReadLine();
        }
        for (int i = 1; i < lines.Count; i++)
        {
            for (int j = 1; j < lines[i].Length - 2; j++)
            {
                char currentChar = lines[i][j];
                bool isEquals =
                    lines[i - 1][j] == currentChar &&
                    lines[i + 1][j] == currentChar &&
                    lines[i][j - 1] == currentChar &&
                    lines[i][j + 1] == currentChar;

                if (isEquals)
                {
                    Console.WriteLine(currentChar);
                    lines[i - 1].Remove(j, 1);
                    lines[i + 1].Remove(j, 1);
                    lines[i].Remove(j - 1, 1);
                    lines[i].Remove(j + 1, 1);
                }
            }
        }
        for (int i = 0; i < lines.Count; i++)
        {
            Console.WriteLine(lines[i]);
        }
    }
}