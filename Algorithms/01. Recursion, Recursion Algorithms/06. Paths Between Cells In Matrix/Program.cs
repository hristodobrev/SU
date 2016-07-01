namespace _06.Paths_Between_Cells_In_Matrix
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        private static List<string> paths;
        private static int pathsFound = 0;

        static void Main()
        {
            paths = new List<string>();
            

            char[,] matrix =
            {
                {'s',' ',' ',' '},
                {' ','*','*',' '},
                {' ','*','*',' '},
                {' ','*','e',' '},
                {' ',' ',' ',' '}
            };

            FindPaths(matrix);

            Console.WriteLine(string.Join("\\n", paths));
            Console.WriteLine("Total paths found: {0}", pathsFound);
        }

        static void FindPaths(char[,] matrix, int row = 0, int col = 0, List<char> currentPath = null, char direction = 'L')
        {
            if (currentPath == null)
            {
                currentPath = new List<char>();
            }

            currentPath.Add(direction);

            if (row < 0 || row >= matrix.GetLength(0) || col < 0 || col >= matrix.GetLength(1))
            {
                return;
            }

            if (matrix[row, col] == 'e')
            {
                paths.Add(currentPath.ToString());
                pathsFound++;
                return;
            }

            if (matrix[row, col] != ' ')
            {
                return;
            }

            matrix[row, col] = 'v';

            FindPaths(matrix, row, col - 1, currentPath, 'L');
            FindPaths(matrix, row - 1, col, currentPath, 'U');
            FindPaths(matrix, row, col + 1, currentPath, 'R');
            FindPaths(matrix, row + 1, col, currentPath, 'D');

            matrix[row, col] = ' ';

            currentPath.RemoveAt(currentPath.Count - 1);
        }
    }
}
