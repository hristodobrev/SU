namespace _08.Sum_Arrays
{
    using System;
    using System.Linq;

    class SumArrays
    {
        static void Main()
        {
            var firstSequence = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(decimal.Parse)
                .ToArray();
            var secondSequence = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(decimal.Parse)
                .ToArray();

            var max = Math.Max(firstSequence.Length, secondSequence.Length);

            var sums = new decimal[max];

            for (int i = 0; i < max; i++)
            {
                sums[i] = firstSequence[i % firstSequence.Length] + secondSequence[i % secondSequence.Length];
            }

            Console.WriteLine(string.Join(" ", sums));
        }
    }
}
