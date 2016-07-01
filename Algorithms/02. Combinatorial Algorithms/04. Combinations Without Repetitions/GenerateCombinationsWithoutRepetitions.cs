namespace _03.Generate_Combinations_With_Repetitions
{
    using System;

    class GenerateCombinationsWithoutRepetitions
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());
            int[] arr = new int[k];

            GenerateCombinations(arr, n);
        }

        private static void GenerateCombinations(int[] arr, int n, int index = 0, int start = 1)
        {
            if (index >= arr.Length)
            {
                PrintArray(arr);
            }
            else
            {
                for (int i = start; i <= n; i++)
                {
                    arr[index] = i;
                    GenerateCombinations(arr, n, index + 1, i + 1);
                }
            }
        }

        private static void PrintArray(int[] arr)
        {
            Console.WriteLine("({0})", string.Join(", ", arr));
        }
    }
}
