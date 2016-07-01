namespace _01.Generate_Variations_With_Repetitions
{
    using System;

    class VariationsWithRepetitions
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());

            int[] arr = new int[k];

            GenerateVariations(arr, n);
        }

        private static void GenerateVariations(int[] arr, int n, int index = 0)
        {
            if (index >= arr.Length)
            {
                PrintArray(arr);
                return;
            }

            for (int i = 1; i <= n; i++)
            {
                arr[index] = i;
                GenerateVariations(arr, n, index + 1);
            }
        }

        private static void PrintArray(int[] arr)
        {
            Console.WriteLine("({0})", string.Join(", ", arr));
        }
    }
}