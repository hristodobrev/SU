namespace Find_Paths_In_Labyrinth
{
    using System;

    class Program
    {
        static char[,] maze = 
            {
                {' ', ' ', ' ', '*', ' ', ' ', ' ', ' ', ' ', ' '},
                {'*', '*', ' ', '*', ' ', '*', '*', '*', '*', ' '},
                {' ', ' ', ' ', ' ', ' ', ' ', '*', ' ', ' ', ' '},
                {' ', '*', '*', '*', '*', ' ', '*', ' ', '*', '*'},
                {' ', ' ', ' ', ' ', ' ', ' ', '*', ' ', ' ', ' '},
                {' ', '*', '*', '*', '*', '*', '*', '*', '*', ' '},
                {' ', ' ', ' ', '*', '*', '*', '*', ' ', ' ', ' '},
                {' ', '*', ' ', '*', ' ', ' ', ' ', ' ', '*', ' '},
                {' ', '*', ' ', '*', ' ', '*', '*', ' ', '*', ' '},
                {' ', '*', ' ', ' ', ' ', ' ', '*', ' ', '*', 'e'},
            };

        static void Main(string[] args)
        {
            FindPaths(0, 0);

        }

        static void FindPaths(int row, int col)
        {
            if (!IsInRange(row, col))
            {
                return;
            }

            if (maze[row, col].Equals('e'))
            {
                PrintResult();
            }
            
            if (!maze[row, col].Equals(' '))
            {
                return;
            }

            maze[row, col] = '.';

            FindPaths(row - 1, col);
            FindPaths(row, col + 1);
            FindPaths(row + 1, col);
            FindPaths(row, col - 1);

            maze[row, col] = ' ';
        }

        static bool IsInRange(int row, int col)
        {
            var range = row < maze.GetLength(0) && row >= 0 &&
                        col < maze.GetLength(1) && col >= 0;

            return range;
        }

        static void PrintResult()
        {
            for (int row = 0; row < maze.GetLength(0); row++)
            {
                for (int col = 0; col < maze.GetLength(1); col++)
                {
                    if (maze[row, col].Equals(' '))
                    {
                        Console.Write(" ");
                    }
                    else if (maze[row, col].Equals('.'))
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(".");
                    }
                    else if (maze[row, col].Equals('*'))
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.Write(" ");
                    }
                    else if (maze[row, col].Equals('e'))
                    {
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.Write(" ");
                    }
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                Console.WriteLine("|");
            }
            Console.WriteLine(new string('-', maze.GetLength(1)) + "+");
        }
    }
}
