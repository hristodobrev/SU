using System;
using System.Linq;

namespace _01.Bunker_Buster
{
    class BunkerBuster
    {
        static void Main()
        {
            int[] dimensions = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rows = dimensions[0];
            int cols = dimensions[1];

            int[,] field = new int[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                int[] values = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray();
                for (int j = 0; j < cols; j++)
                {
                    field[i, j] = values[j];
                }
            }

            string command = Console.ReadLine();
            while (command != "cease fire!")
            {
                var commandArgs = command.Split();
                int row = int.Parse(commandArgs[0]);
                int col = int.Parse(commandArgs[1]);
                int damage = char.Parse(commandArgs[2]);

                DoTheDamage(field, damage, row, col);

                command = Console.ReadLine();
            }

            int destroyedCells = CountDestroyedCells(field);
            int totalCells = rows * cols;
            double percentage = destroyedCells / (double)totalCells * 100;

            Console.WriteLine("Destroyed bunkers: {0}", destroyedCells);
            Console.WriteLine("Damage done: {0:F1} %", percentage);
        }

        private static int CountDestroyedCells(int[,] field)
        {
            int counter = 0;
            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    if (field[i, j] <= 0)
                    {
                        counter++;
                    }
                }
            }

            return counter;
        }

        private static void DoTheDamage(int[,] matrix, int damage, int row, int col)
        {
            int halfDamage = (int)Math.Ceiling(damage / 2.0);
            int startRow = Math.Max(0, row - 1);
            int endRow = Math.Min(matrix.GetLength(0) - 1, row + 1);
            int startCol = Math.Max(0, col - 1);
            int endCol = Math.Min(matrix.GetLength(1) - 1, col + 1);

            for (int i = startRow; i <= endRow; i++)
            {
                for (int j = startCol; j <= endCol; j++)
                {
                    if (i == row && j == col)
                    {
                        matrix[i, j] -= damage;
                    }
                    else
                    {
                        matrix[i, j] -= halfDamage;
                    }
                }
            }
        }
    }
}
