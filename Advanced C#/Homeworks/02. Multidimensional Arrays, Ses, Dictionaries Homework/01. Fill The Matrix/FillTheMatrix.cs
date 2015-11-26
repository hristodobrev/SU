using System;
class FillTheMatrix
{
    static void Main()
    {
        // Input
        int rows = int.Parse(Console.ReadLine());
        int cols = int.Parse(Console.ReadLine());
        int[,] firstMatrix = new int[rows, cols];
        int[,] secondMatrix = new int[rows, cols];

        // Logic
        for (int i = 0; i < cols; i++)
        {
            for (int j = 0; j < rows; j++)
            {
                firstMatrix[j, i] += (i * rows) + j + 1;
            }
        }

        // Output
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Console.Write("{0,-2} ", firstMatrix[i, j]);
            }
            Console.WriteLine();
        }

        // Logic
        for (int i = 0; i < cols; i++)
        {
            for (int j = 0; j < rows; j++)
            {
                if (i % 2 == 0)
                {
                    secondMatrix[j, i] += (i * rows) + j + 1;
                }
                else
                {
                    secondMatrix[j, i] += (i * rows) + (rows - j);
                }
            }
        }

        // Output
        Console.WriteLine();
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Console.Write("{0,-2} ", secondMatrix[i, j]);
            }
            Console.WriteLine();
        }
    }
}