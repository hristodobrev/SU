using System;
using System.Collections.Generic;

class JoinLists
{
    static void Main()
    {
        string[] firstArray = Console.ReadLine().Split(' ');
        string[] secondArray = Console.ReadLine().Split(' ');

        int[] firstNumbers = new int[firstArray.Length];
        int[] secondNumbers = new int[secondArray.Length];
        List<int> finalList = new List<int>();

        for (int i = 0; i < firstArray.Length; i++)
        {
            firstNumbers[i] = int.Parse(firstArray[i]);
        }

        for (int i = 0; i < secondArray.Length; i++)
        {
            secondNumbers[i] = int.Parse(secondArray[i]);
        }

        for (int i = 0; i < firstNumbers.Length; i++)
        {
            if (!finalList.Contains(firstNumbers[i]))
            {
                finalList.Add(firstNumbers[i]);
            }
        }

        for (int i = 0; i < secondNumbers.Length; i++)
        {
            if (!finalList.Contains(secondNumbers[i]))
            {
                finalList.Add(secondNumbers[i]);
            }
        }

        finalList.Sort();

        Console.WriteLine(string.Join(" ", finalList));
    }
}