namespace _03.Combinations_With_Repetitions
{
    using System;

    class CombinationsWithRepetitions
    {
        static void Main(string[] args)
        {
            Console.Write("n = ");
            var n = int.Parse(Console.ReadLine());
            Console.Write("k = ");
            var k = int.Parse(Console.ReadLine());

            GenerateCombinations(n, k);
        }

        static void GenerateCombinations(int n, int k, int[] tempArr = null, int index = 0, int startNum = 1)
        {
            if (tempArr == null)
            {
                tempArr = new int[k];
            }

            if (index == k)
            {
                Console.WriteLine(string.Join(" ", tempArr));
                return;
            }

            for (int i = startNum; i <= n; i++)
            {
                tempArr[index] = i;
                GenerateCombinations(n, k, tempArr, index + 1, startNum + 1);
            }
        }
    }
}
