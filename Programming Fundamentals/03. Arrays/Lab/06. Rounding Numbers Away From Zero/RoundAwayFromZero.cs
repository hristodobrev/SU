namespace _06.Rounding_Numbers_Away_From_Zero
{
    using System;
    using System.Linq;

    class RoundAwayFromZero
    {
        static void Main()
        {
            var sequence = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(decimal.Parse)
                .ToArray();

            foreach (var num in sequence)
            {
                Console.WriteLine("{0} => {1}", num, Math.Round(num, MidpointRounding.AwayFromZero));
            }
        }
    }
}
