namespace _01.Largest_Common_End
{
    using System;
    using System.Collections.Generic;

    class LargestCommonEnd
    {
        static void Main()
        {
            var first = Console.ReadLine()
                .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            var second = Console.ReadLine()
                .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);

            var maxIndex = Math.Min(first.Length, second.Length);
            int leftCommonWords = 0;
            int rightCommonWords = 0;
            bool leftContinue = true;
            bool rightContinue = true;

            for (int i = 0; i < maxIndex; i++)
            {
                if (first[i].Equals(second[i]) && leftContinue)
                {
                    leftCommonWords++;
                }
                else
                {
                    leftContinue = false;
                }

                if (first[first.Length - i - 1].Equals(second[second.Length - i - 1]) && rightContinue)
                {
                    rightCommonWords++;
                }
                else
                {
                    rightContinue = false;
                }

                if (!rightContinue && !leftContinue)
                {
                    break;
                }
            }

            Console.WriteLine(Math.Max(leftCommonWords, rightCommonWords));
        }
    }
}