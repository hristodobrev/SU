using System;
using System.Linq;
class SelectionSort
{
    static void Main()
    {
        // Input
        int[] array = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

        // Logic
        for (int i = 0; i < array.Length - 1; i++)
        {
            int minIndex = i;
            for (int j = i + 1; j < array.Length; j++)
            {
                if (array[minIndex] > array[j])
                {
                    minIndex = j;
                }
            }
            int temp = array[i];
            array[i] = array[minIndex];
            array[minIndex] = temp;
        }

        // Output
        Console.WriteLine(string.Join(" ", array));
    }
}