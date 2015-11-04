using System;
using System.Linq;
class FirstLargerThanNeighbours
{
    static void Main()
    {
        // Input
        int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

        // Output
        Console.WriteLine(FindIndexOfFirstLargerElement(numbers));
    }

    // Logic

    static int FindIndexOfFirstLargerElement(int[] numbers)
    {
        if (numbers[0] > numbers[1])
        {
            return 0;
        }
        for (int i = 1; i < numbers.Length - 1; i++)
        {
            if (numbers[i] > numbers[i + 1] && numbers[i] > numbers[i - 1])
            {
                return i;
            }
        }
        if (numbers[numbers.Length - 1] > numbers[numbers.Length - 2])
        {
            return numbers.Length - 1;
        }
        return -1;
    }
}