using System;
using System.Linq;
class SortArrayOfNumbers
{
    static void Main()
    {
        // Input
        int[] array = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

        // Logic
        Array.Sort(array);

        // Output
        Console.WriteLine(string.Join(" ", array));
    }
}