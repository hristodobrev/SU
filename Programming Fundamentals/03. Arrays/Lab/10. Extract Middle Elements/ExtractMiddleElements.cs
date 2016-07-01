namespace _10.Extract_Middle_Elements
{
    using System;
    using System.Linq;

    class ExtractMiddleElements
    {
        static void Main()
        {
            var numbers = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(decimal.Parse)
                .ToArray();

            if (numbers.Length == 1)
            {
                Console.WriteLine("{ " + numbers[0] + " }");
            }
            else if (numbers.Length % 2 == 0)
            {
                Console.WriteLine("{ " + numbers[(numbers.Length / 2) - 1] + ", " + numbers[numbers.Length / 2] + " }");
            }
            else
            {
                Console.WriteLine("{ " + numbers[(numbers.Length / 2) - 1] + ", " + numbers[numbers.Length / 2] + ", " + numbers[(numbers.Length / 2) + 1] + " }");
            }
        }
    }
}
