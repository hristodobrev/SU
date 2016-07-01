namespace _05.Triple_Sum
{
    using System;
    using System.Linq;

    class TripleSum
    {
        static void Main()
        {
            var sequence = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(decimal.Parse)
                .ToArray();

            bool found = false;

            for (int i = 0; i < sequence.Length - 1; i++)
            {
                for (int j = i + 1; j < sequence.Length; j++)
                {
                    if (sequence.Contains(sequence[i] + sequence[j]))
                    {
                        found = true;
                        Console.WriteLine("{0} + {1} == {2}", sequence[i], sequence[j], sequence[i] + sequence[j]);
                    }
                }
            }

            if (!found)
            {
                Console.WriteLine("No");
            }
        }
    }
}
