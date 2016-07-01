namespace _01.Print_String_Letters
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            var nums = Console.ReadLine().Split().Select(decimal.Parse).ToList();
            var k = nums.Count / 4;

            var firstKElements = nums.Take(k).Reverse();
            var lastKElements = nums.Skip(k * 3).Reverse();
            var firstRow = firstKElements.Concat(lastKElements).ToList();
            var secondRow = nums.Skip(k).Take(k*2).ToList();

            for (int i = 0; i < firstRow.Count(); i++)
            {
                firstRow[i] += secondRow[i];
            }

            Console.WriteLine(string.Join(" ", firstRow));
        }
    }
}
