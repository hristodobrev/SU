namespace _02.Nested_Loops_To_Recursion
{
    using System;

    class NestedLoopsToRecursion
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            IterateLoops(n);
        }

        static void IterateLoops(int n, int index = 0, int[]arr = null)
        {
            if (arr == null)
            {
                arr = new int[n];
            }

            if (index == n)
            {
                Console.WriteLine(string.Join(" ", arr));
                return;
            }

            for (int i = 1; i <= n; i++)
            {
                arr[index] = i;
                IterateLoops(n, index + 1, arr);
            }
        }
    }
}
