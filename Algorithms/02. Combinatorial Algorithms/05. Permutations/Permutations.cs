namespace _05.Permutations
{
    using System;
    using System.Linq;

    class Permutations
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int[] array = Enumerable.Range(1, n).ToArray();

            GeneratePermutations(array);
        }

        private static void GeneratePermutations(int[] arr, int index = 0)
        {
            if (index >= arr.Length - 1)
            {
                PrintArray(arr);
            }
            else
            {
                for (int i = index; i < arr.Length; i++)
                {
                    Swap(ref arr[i], ref arr[index]);
                    GeneratePermutations(arr, index + 1);  
                    Swap(ref arr[i], ref arr[index]);
                }
            }
        }

        private static void Swap(ref int a, ref int b)
        {
            if (a == b)
            {
                return;
            }

            a ^= b;
            b ^= a;
            a ^= b;
        }

        private static void PrintArray(int[] arr)
        {
            Console.WriteLine("({0})", string.Join(", ", arr));
        }
    }
}
