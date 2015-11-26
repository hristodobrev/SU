using System;
using System.Collections.Generic;
using System.Linq;

class BunkerBuster
{
    static void Main()
    {
        // Input
        int[] fieldSize = Console.ReadLine().Split(new char[0], StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
        List<int[]> cellsStrength = new List<int[]>();
        for (int i = 0; i < fieldSize[0]; i++)
        {
            cellsStrength.Add(Console.ReadLine().Split(new char[0], StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());
        }
        List<string> commands = new List<string>();
        string currentLine = Console.ReadLine();
        while (currentLine != "cease fire!")
        {
            commands.Add(currentLine);
            currentLine = Console.ReadLine();
        }
        for (int i = 0; i < commands.Count; i++)
        {
            string[] currentCommands = commands[i].Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
            int currentRow = int.Parse(currentCommands[0]);
            int currentCol = int.Parse(currentCommands[1]);
            int strength = currentCommands[2][0];
            int halfStrength;
            if (strength % 2 > 0)
            {
                halfStrength = (strength / 2) + 1;
            }
            else
            {
                halfStrength = strength / 2;
            }

            cellsStrength[currentRow][currentCol] -= strength;
            if (currentCol > 0 && currentRow > 0)
            {
                cellsStrength[currentRow - 1][currentCol - 1] -= halfStrength;
                cellsStrength[currentRow - 1][currentCol] -= halfStrength;
                cellsStrength[currentRow][currentCol - 1] -= halfStrength;
            }
            else if (true)
            {
                
            }
        }

        for (int i = 0; i < cellsStrength.Count; i++)
        {
            Console.WriteLine(string.Join(" ", cellsStrength[i]));
        }

    }
}