using System;
using System.Linq;
class MaximalSum
{
    static void Main()
    {
        // Input
        int[] rowsAndCols = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int rows = rowsAndCols[0];
        int cols = rowsAndCols[1];
        int[][] matrix = new int[rows][];
        for (int i = 0; i < rows; i++)
        {
            int[] currentLine = Console.ReadLine().Split().Select(int.Parse).ToArray();
            matrix[i] = currentLine;
        }

        // Logic
        int maxSum = int.MinValue;
        int colIndex = 0;
        int rowIndex = 0;
        for (int i = 0; i < rows - 2; i++)
        {
            for (int j = 0; j < cols - 2; j++)
            {
                int currentSum =
                    matrix[i][j] + matrix[i][j + 1] +
                    matrix[i][j + 2] + matrix[i + 1][j] +
                    matrix[i + 1][j + 1] + matrix[i + 1][j + 2] +
                    matrix[i + 2][j] + matrix[i + 2][j + 1] + matrix[i + 2][j + 2];
                if (currentSum > maxSum)
                {
                    maxSum = currentSum;
                    colIndex = j;
                    rowIndex = i;
                }
            }
        }

        // Output
        Console.WriteLine("Sum = {0}", maxSum);
        for (int i = rowIndex; i < rowIndex + 3; i++)
        {
            for (int j = colIndex; j < colIndex + 3; j++)
            {
                Console.Write("{0} ", matrix[i][j]);
            }
            Console.WriteLine();
        }
    }
}