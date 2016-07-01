namespace _09.Condense_Array_To_Number
{
    using System;
    using System.Linq;

    class CondenseArrayToNumbers
    {
        static void Main()
        {
            var numbers = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(decimal.Parse)
                .ToArray();

            for (int j = 0; j < numbers.Length - 1; j++)
            {
                for (int i = 0; i < numbers.Length - 1; i++)
                {
                    numbers[i] = numbers[i] + numbers[i + 1];
                }
            }

            Console.WriteLine(numbers[0]);
        }
    }
}
