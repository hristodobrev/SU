namespace _02.Variations_Without_Repetition
{
    using System;

    class VariationsWithoutRepetition
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());
            int[] arr = new int[k];
            bool[] used = new bool[n + 1];

            GenerateVariations(arr, used, n);
        }

        private static void GenerateVariations(int[] arr, bool[] used, int sizeOfSet, int index = 0)
        {
            if (index >= arr.Length)
            {
                PrintArray(arr);
            }
            else
            {
                for (int i = 1; i <= sizeOfSet; i++)
                {
                    if (!used[i])
                    {
                        arr[index] = i;
                        used[i] = true;
                        GenerateVariations(arr, used, sizeOfSet, index + 1);
                        used[i] = false;
                    }
                }
            }
        }

        private static void PrintArray(int[] arr)
        {
            Console.WriteLine("({0})", string.Join(", ", arr));
        }
    }
}
