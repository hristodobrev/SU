namespace _02.Rotate_And_Sum
{
    using System;
    using System.Linq;

    class RotateAndSum
    {
        static void Main()
        {
            var numbers = Console.ReadLine().
                Split().Select(int.Parse).ToArray();

            var n = int.Parse(Console.ReadLine());

            var result = new int[numbers.Length];

            var temp = numbers;

            for (int i = 1; i <= n; i++)
            {
                temp = RotateRight(temp);
                for (int j = 0; j < result.Length; j++)
                {
                    result[j] += temp[j];
                }
            }

            Console.WriteLine(string.Join(" ", result));
        }

        static int[] RotateRight(int[] arr)
        {
            return arr.Skip(arr.Length - 1).Concat(arr.Take(arr.Length - 1)).ToArray();
        }
    }
}