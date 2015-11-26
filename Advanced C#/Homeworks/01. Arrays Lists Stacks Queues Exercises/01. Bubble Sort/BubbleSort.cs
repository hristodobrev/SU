using System;
using System.Linq;

class BubbleSort
{
    static void Main()
    {
        int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        int temp;
        bool loop;
        do
        {
            loop = false;
            for (int i = 0; i < numbers.Length - 1; i++)
            {
                if (numbers[i] > numbers[i + 1])
                {
                    temp = numbers[i];
                    numbers[i] = numbers[i + 1];
                    numbers[i + 1] = temp;
                    loop = true;
                }
            }
        } while (loop);

        Console.WriteLine("[" + string.Join(", ", numbers) + "]");
    }
}