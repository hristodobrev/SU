namespace _03.Fold_And_Sum
{
    using System;
    using System.Linq;

    class FoldAndSum
    {
        static void Main()
        {
            int[] numbers = Console.ReadLine()
                .Split().Select(int.Parse).ToArray();

            int length = numbers.Length/4;

            int[] firstHalf = numbers.Take(length).Reverse().Concat(numbers.Skip(numbers.Length - length).Reverse()).ToArray();

            int[] secondHalf = numbers.Skip(length).Take(length * 2).ToArray();

            int[] result = new int[length*2];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = firstHalf[i] + secondHalf[i];
            }

            Console.WriteLine(string.Join(" ", result));
        }
    }
}
