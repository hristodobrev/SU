using System;
using System.Collections.Generic;
class MatrixShuffling
{
    static void Main()
    {
        // Input
        int rows = int.Parse(Console.ReadLine());
        int cols = int.Parse(Console.ReadLine());
        string[,] matrix = new string[rows, cols];
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                matrix[i, j] = Console.ReadLine();
            }
        }

        // Logic
        List<string> commands = new List<string>();
        string message = "";
        while (message.ToLower() != "end")
        {
            message = Console.ReadLine();
            if (message.ToLower() != "end")
            {
                commands.Add(message);
            }
        }
        for (int i = 0; i < commands.Count; i++)
        {
            string[] currentCommand = commands[i].Split();
            if (currentCommand[0] != "swap")
            {
                Console.WriteLine("Invalid input!");
            }
            else
            {
                int[] coordinates = new int[4];
                for (int j = 0; j < 4; j++)
                {
                    coordinates[j] = int.Parse(currentCommand[j + 1]);
                }
                if (coordinates[0] > rows - 1 && coordinates[1] > cols - 1 && coordinates[2] > rows - 1 && coordinates[3] > cols - 1)
                {
                    Console.WriteLine("Invalid input!");
                }
                else
                {
                    string temp = matrix[coordinates[0], coordinates[1]];
                    matrix[coordinates[0], coordinates[1]] = matrix[coordinates[2], coordinates[3]];
                    matrix[coordinates[2], coordinates[3]] = temp;
                    for (int k = 0; k < rows; k++)
                    {
                        for (int l = 0; l < cols; l++)
                        {
                            Console.Write("{0} ", matrix[k, l]);
                        }
                        Console.WriteLine();
                    }
                }
            }
        }
    }
}