using System;
using System.Linq;
using System.Collections.Generic;
class LegoBlocks
{
    static void Main()
    {
        // Input
        int n = int.Parse(Console.ReadLine());

        // Logic
        List<int> leftBlockLinesLenght = new List<int>();
        List<int> rightBlockLinesLenght = new List<int>();
        List<int> currentLine = new List<int>();
        List<int> leftBlock = new List<int>();
        List<int> rightBlock = new List<int>();

        // Input
        for (int i = 0; i < n * 2; i++)
        {
            currentLine = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            if (i < n)
            {
                leftBlockLinesLenght.Add(currentLine.Count());
                leftBlock.AddRange(currentLine);
            }
            else
            {
                rightBlockLinesLenght.Add(currentLine.Count());
                rightBlock.AddRange(currentLine);
            }
        }
        int blockLenght = leftBlockLinesLenght[0] + rightBlockLinesLenght[0];

        
        int leftBlockIndex = 0;
        int rightBlockIndex = 0;
        // Ouput
        string[] newMatrix = new string[n];
        for (int j = 0; j < n; j++)
        {
            if (leftBlockLinesLenght[j] + rightBlockLinesLenght[j] == blockLenght)
            {
                List<int> printLine = leftBlock.GetRange(leftBlockIndex, leftBlockLinesLenght[j]);
                leftBlockIndex += leftBlockLinesLenght[j];
                newMatrix[j] = "[" + string.Join(", ", printLine) + ", ";
                printLine = rightBlock.GetRange(rightBlockIndex, rightBlockLinesLenght[j]);
                printLine.Reverse();
                rightBlockIndex += rightBlockLinesLenght[j];
                newMatrix[j] += string.Join(", ", printLine) + "]";
            }
            else
            {
                Console.WriteLine("The total number of cells is: {0}", leftBlock.Count + rightBlock.Count);
                Environment.Exit(0);
            }
        }
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine(newMatrix[i]);
        }
    }
}