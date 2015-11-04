using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

class PlusRemove
{
    static void Main()
    {
        List<StringBuilder> lines = new List<StringBuilder>();
        //List<string> lines = new List<string>();
        List<int> plusRow = new List<int>();
        List<int> plusCol = new List<int>();

        string currentLine = Console.ReadLine();
        while (currentLine != "END")
        {
            lines.Add(new StringBuilder(currentLine));
            currentLine = Console.ReadLine();
        }

        int row = 1;
        int col = 1;
        for (int i = row; i < lines.Count - 1; i++)
        {
            for (int j = col; j < lines[i].Length - 1; j++)
            {
                string currentChar = lines[i][j].ToString().ToLower();
                if (j < Math.Min(lines[i].Length, Math.Min(lines[i - 1].Length, lines[i + 1].Length)))
                {
                    bool check =
                        lines[i - 1][j].ToString().ToLower() == currentChar
                        && lines[i + 1][j].ToString().ToLower() == currentChar
                        && lines[i][j + 1].ToString().ToLower() == currentChar
                        && lines[i][j - 1].ToString().ToLower() == currentChar;

                    if (check)
                    {
                        plusCol.Add(j);
                        plusRow.Add(i);
                    }
                }
            }
        }
        for (int i = 0; i < plusCol.Count; i++)
        {
            int currentRow = plusRow[i];
            int currentCol = plusCol[i];
            lines[currentRow - 1][currentCol] = ' ';
            lines[currentRow + 1][currentCol] = ' ';
            lines[currentRow][currentCol] = ' ';
            lines[currentRow][currentCol + 1] = ' ';
            lines[currentRow][currentCol - 1] = ' ';

        }
        foreach (var line in lines)
        {
            string printLine = line.ToString().Replace(" ", "");
            Console.WriteLine(printLine);
        }
    }
}