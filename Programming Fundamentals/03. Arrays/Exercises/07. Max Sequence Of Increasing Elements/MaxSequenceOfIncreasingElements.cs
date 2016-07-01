namespace _07.Max_Sequence_Of_Increasing_Elements
{
    using System;
    using System.Linq;

    class MaxSequenceOfIncreasingElements
    {
        static void Main()
        {
            int[] numbers = Console.ReadLine().Split()
                .Select(int.Parse).ToArray();

            var maxLength = 1;
            var index = 0;

            for (int i = 0; i < numbers.Length - 1; i++)
            {
                var currentIndex = i;
                var currentLength = 1;
                for (int j = i + 1; j < numbers.Length; j++)
                {
                    if (numbers[j - 1] < numbers[j])
                    {
                        currentLength++;
                    }
                    else
                    {
                        i = j - 1;
                        break;
                    }
                }
                if (maxLength < currentLength)
                {
                    maxLength = currentLength;
                    index = currentIndex;
                }
            }

            Console.WriteLine(string.Join(" ", numbers.Skip(index).Take(maxLength)));
        }
    }
}
