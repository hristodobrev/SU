using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;

class Program
{
    struct Positions
    {
        public int row;
        public int col;
        public Positions(int row, int col)
        {
            this.row = row;
            this.col = col;
        }
    }

    static void Main()
    {
        string[] dimensions = Console.ReadLine().Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
        int rows = int.Parse(dimensions[0]);
        int cols = int.Parse(dimensions[1]);

        List<Positions> bunniesPositions = new List<Positions>();

        bool win = true;
        bool escaped = false;

        StringBuilder[] lair = new StringBuilder[rows];

        int playerCol = 0;
        int playerRow = 0;

        for (int i = 0; i < rows; i++)
        {
            lair[i] = new StringBuilder(Console.ReadLine());
            int curPos = Array.IndexOf(lair[i].ToString().ToArray(), 'P');
            if (curPos != -1)
            {
                playerCol = curPos;
                playerRow = i;
                lair[playerRow][playerCol] = '.';
            }
            for (int j = 0; j < cols; j++)
            {
                if (lair[i][j] == 'B')
                {
                    bunniesPositions.Add(new Positions(i, j));
                }
            }
        }

        string commands = Console.ReadLine();

        int expands = 1;

        for (int i = 0; i < commands.Length; i++)
        {

            if (!escaped)
            {
                if (lair[playerRow][playerCol] == 'B')
                {
                    win = false;
                    break;
                }
            }

            if (commands[i] == 'L')
            {
                if (playerCol > 0)
                {
                    playerCol--;
                }
                else
                {
                    escaped = true;
                }
            }
            else if (commands[i] == 'R')
            {
                if (playerCol < cols - 1)
                {
                    playerCol++;
                }
                else
                {
                    escaped = true;
                }
            }
            else if (commands[i] == 'U')
            {
                if (playerRow > 0)
                {
                    playerRow--;
                }
                else
                {
                    escaped = true;
                }
            }
            else if (commands[i] == 'D')
            {
                if (playerRow < rows - 1)
                {
                    playerRow++;
                }
                else
                {
                    escaped = true;
                }
            }

            for (int j = 0; j < bunniesPositions.Count; j++)
            {
                int curRow = bunniesPositions[j].row;
                int curCol = bunniesPositions[j].col;
                ExpandBunnies(lair, curRow, curCol, rows, cols, expands);
            }

            if (!escaped)
            {
                expands++;
            }
        }


        for (int j = 0; j < lair.Length; j++)
        {
            Console.WriteLine(lair[j].ToString());
        }
        if (win)
        {
            Console.WriteLine("won: {0} {1}", playerRow, playerCol);
        }
        else
        {
            Console.WriteLine("dead: {0} {1}", playerRow, playerCol);
        }
    }

    static void ExpandBunnies(StringBuilder[] lair, int row, int col, int rows, int cols, int expand)
    {
        int startRow = row - expand;
        int startCol = col + 1 - expand;
        int endRow = row + expand;
        int endCol = col + expand;
        int offset = expand - 1;
        for (int i = startRow - 1; i <= endRow + 1; i++)
        {
            if (i < startRow + ((endRow - startRow) / 2))
            {
                offset--;
                for (int j = startCol + offset; j < endCol - offset; j++)
                {
                    if (i < 0 || i > rows - 1 || j < 0 || j > cols - 1)
                    {
                        break;
                    }
                    lair[i][j] = 'B';
                }
            }
            else
            {
                offset++;
                for (int j = startCol + offset; j < endCol - offset; j++)
                {
                    if (i < 0 || i > rows - 1 || j < 0 || j > cols - 1)
                    {
                        break;
                    }
                    lair[i][j] = 'B';
                }
            }
        }
    }
}