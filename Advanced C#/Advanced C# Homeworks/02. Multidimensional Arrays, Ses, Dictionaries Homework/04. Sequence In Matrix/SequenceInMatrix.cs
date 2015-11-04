using System;
using System.Collections.Generic;
class SequenceInMatrix
{
    static void Main()
    {
        string[,] matrix = 
        {
            { "ha", "xx", "ho", "hehe" },
            { "fo", "ha", "xx", "hehe" },
            { "fo", "fo", "ha", "hehe" },
            { "ha", "fo", "fo", "ha" },
            { "fo", "fo", "fo", "hehe" },
            { "fo", "fo", "fo", "hehe" },
            { "xxx", "ho", "fo", "hehe" }
        };
        int currentSequenceLenght = 1;
        int longestSequenceLenght = int.MinValue;
        string longestSequenceValue = "";
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                currentSequenceLenght = HorizontalSequnce(row, col, matrix[row, col], matrix);
                if (currentSequenceLenght > longestSequenceLenght)
                {
                    longestSequenceLenght = currentSequenceLenght;
                    longestSequenceValue = matrix[row, col];
                }
                currentSequenceLenght = VerticalSequnce(row, col, matrix[row, col], matrix);
                if (currentSequenceLenght > longestSequenceLenght)
                {
                    longestSequenceLenght = currentSequenceLenght;
                    longestSequenceValue = matrix[row, col];
                }
                currentSequenceLenght = DiagonalSequnce(row, col, matrix[row, col], matrix);
                if (currentSequenceLenght > longestSequenceLenght)
                {
                    longestSequenceLenght = currentSequenceLenght;
                    longestSequenceValue = matrix[row, col];
                }
            }
        }
        for (int i = 0; i < longestSequenceLenght; i++)
        {
            if (i < longestSequenceLenght - 1)
            {
                Console.Write(longestSequenceValue + ", ");
            }
            else
            {
                Console.WriteLine(longestSequenceValue);
            }
        }
    }
    static int HorizontalSequnce(int row, int col, string value, string[,] matrix)
    {
        int sequenceLenght = 1;
        for (int i = col; i < matrix.GetLength(1) - 1; i++)
			{
                if (matrix[row, i] != matrix[row, i + 1])
                {
                    break;
                }
                sequenceLenght++;
			}
        return sequenceLenght;
    }

    static int VerticalSequnce(int row, int col, string value, string[,] matrix)
    {
        int sequenceLenght = 1;
        for (int i = row; i < matrix.GetLength(0) - 1; i++)
        {
            if (matrix[i, col] != matrix[i + 1, col])
            {
                break;
            }
            sequenceLenght++;
        }
        return sequenceLenght;
    }
    static int DiagonalSequnce(int row, int col, string value, string[,] matrix)
    {
        int sequenceLenght = 1;
        for (int i = row, j = col; i < matrix.GetLength(0) - 1 && j < matrix.GetLength(1) - 1; i++, j++)
        {
            if (matrix[row, col] != matrix[row + 1, col + 1])
            {
                break;
            }
            sequenceLenght++;
        }
        return sequenceLenght;
    }
}