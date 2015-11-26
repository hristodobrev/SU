using System;
using System.Text;
using System.Collections.Generic;
class StringMatrixRotation
{
    static void Main()
    {
        // Input
        List<string> list = new List<string>();
        StringBuilder rotation = new StringBuilder(Console.ReadLine());
        string text = Console.ReadLine();
        while (text.ToUpper() != "END")
        {
            list.Add(text);
            text = Console.ReadLine();
        }

        // Logic
        rotation.Remove(0, 7);
        for (int i = 0; i < rotation.Length; i++)
        {
            if (rotation[i] == ')')
            {
                rotation.Remove(i, 1);
            }
        }
        int degrees = int.Parse(rotation.ToString());
        degrees %= 360;
        if (degrees == -90)
        {
            degrees = 270;
        }
        else if (degrees == -180)
        {
            degrees = 180;
        }
        else if (degrees == -270)
        {
            degrees = 90;
        }
        char[,] matrix = new char[list.Count, GetLongestLenght(list)];
        for (int y = 0; y < list.Count; y++)
        {
            for (int x = 0; x < list[y].Length; x++)
            {
                matrix[y, x] = list[y][x];
            }
        }

        if (degrees == 90)
        {
            matrix = Rotate90(matrix);
        }
        else if(degrees == 180)
        {
            matrix = Rotate180(matrix);
        }
        else if (degrees == 270)
        {
            matrix = Rotate270(matrix);
        }

        // Output
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write(matrix[i, j]);
            }
            Console.WriteLine();
        }
    }

    static int GetLongestLenght(List<string> list)
    {
        int maxLenght = int.MinValue;
        for (int i = 0; i < list.Count; i++)
        {
            if (maxLenght < list[i].Length)
            {
                maxLenght = list[i].Length;
            }
        }
        return maxLenght;
    }

    static char[,] Rotate90(char[,] matrix)
    {
        char[,] rotatedMatrix = new char[matrix.GetLength(1), matrix.GetLength(0)];
        for (int i = 0; i < rotatedMatrix.GetLength(0); i++)
        {
            for (int j = 0; j < rotatedMatrix.GetLength(1); j++)
            {
                rotatedMatrix[i, j] = matrix[matrix.GetLength(0) - 1 - j, i];
            }
        }
        return rotatedMatrix;
    }

    static char[,] Rotate180(char[,] matrix)
    {
        char[,] rotatedMatrix = new char[matrix.GetLength(0), matrix.GetLength(1)];
        for (int i = 0; i < rotatedMatrix.GetLength(0); i++)
        {
            for (int j = 0; j < rotatedMatrix.GetLength(1); j++)
            {
                rotatedMatrix[i, j] = matrix[matrix.GetLength(0) - 1 - i, matrix.GetLength(1) - 1 - j];
            }
        }
        return rotatedMatrix;
    }

    static char[,] Rotate270(char[,] matrix)
    {
        char[,] rotatedMatrix = new char[matrix.GetLength(1), matrix.GetLength(0)];
        for (int i = 0; i < rotatedMatrix.GetLength(0); i++)
        {
            for (int j = 0; j < rotatedMatrix.GetLength(1); j++)
            {
                rotatedMatrix[i, j] = matrix[j, matrix.GetLength(1) - 1 - i];
            }
        }
        return rotatedMatrix;
    }

}