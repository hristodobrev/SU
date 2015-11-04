using System;
using System.Linq;
class LargerThanNeighbours
{
    static void Main()
    {
        // Input
        int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

        // Logic, Output
        for (int i = 0; i < numbers.Length; i++)
        {
            Console.WriteLine(IsLargerThanNeighbours(numbers, i));
        }
    }

    static bool IsLargerThanNeighbours(int[] numbers, int index)
    {
        if (index == 0)
        {
            if (numbers[0] > numbers[1])
            {
                return true;
            }
            return false;
        }
        else if (index == numbers.Length - 1)
        {
            if (numbers[index] > numbers[index - 1])
            {
                return true;
            }
            return false;
        }
        else
        {
            if (numbers[index] > numbers[index + 1] && numbers[index] > numbers[index - 1])
            {
                return true;
            }
            return false;
        }
    }

}