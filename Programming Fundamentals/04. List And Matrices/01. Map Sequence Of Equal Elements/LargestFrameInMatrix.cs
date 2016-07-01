namespace _01.Map_Sequence_Of_Equal_Elements
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class LargestFrameInMatrix
    {
        private static decimal maxSum = decimal.MinValue;
        private static int bestRow = 0;
        private static int bestCol = 0;

        static void Main()
        {
            var input = Console.ReadLine().Split().ToArray();
            int rows = int.Parse(input[0]);
            int cols = int.Parse(input[1]);

            int[][] matrix = new int[rows][];

            for (int row = 0; row < rows; row++)
            {
                matrix[row] = Console.ReadLine().Split().Select(int.Parse).ToArray();
            }

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    CheckCell(matrix, row, col, rows, cols);
                }
            }
        }

        private static void CheckCell(int[][] matrix, int row, int col, int rows, int cols)
        {
            var number = matrix[row][col];

            var maxLength = 0;
            for (int currentCol = col; currentCol < cols; currentCol++)
            {
                if (matrix[row][currentCol] == number)
                {
                    if (row + 1 < rows)
                    {
                        if (matrix[row + 1][currentCol] == number && matrix[row + 1][col] == number)
                        {
                            for (int currentRow = row; currentRow < rows; currentRow++)
                            {
                                var found = true;
                                for (int innerCol = col; innerCol <= currentCol; innerCol++)
                                {
                                    if (matrix[currentRow][innerCol] != number)
                                    {
                                        found = false;
                                        break;
                                    }
                                }

                                if (found)
                                {
                                    var frameRows = currentRow - row + 1;
                                    var frameCols = currentCol - col + 1;
                                    if (maxLength <= frameRows*frameCols)
                                    {
                                        maxLength = frameRows*frameCols;
                                        Console.WriteLine("Found: {0} {1}", frameRows, frameCols);
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        if (maxLength < currentCol - col + 1)
                        {
                            maxLength = currentCol - col + 1;
                            Console.WriteLine("Found: {0} {1}", 1, currentCol - col + 1);
                        }
                    }
                }
            }
        }

        private static void PrintMatrix(int[][] matrix, int rows, int cols)
        {
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write(matrix[row][col] + (col == cols - 1 ? "" : " "));
                }
                Console.WriteLine();
            }
        }
    }
}
