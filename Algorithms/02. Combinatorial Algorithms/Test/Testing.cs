namespace Test
{
    using System;

    class Testing
    {
        static int n = 4;
        static int k = 3;
        static int[] arr = new int[k];
        static bool[] used = new bool[n];
        static int[] free = new int[] { 1,2,3,4 };

        static void Main()
        {
            VarNoRep(0);
        }

        static void VarNoRep(int index)
        {
            if (index >= k)
            {
                Console.WriteLine(string.Join(" ", arr));
            }
            else
            {
                for (int i = index; i < n; i++)
                {
                    arr[index] = free[i];
                    Swap(ref free[i], ref free[index]);
                    VarNoRep(index + 1);
                    Swap(ref free[i], ref free[index]);
                }
            }
        }

        private static void Swap(ref int a, ref int b)
        {
            var temp = a;
            a = b;
            b = temp;
        }

        static void GenerateVariationsNoRep(int index)
        {
            if (index >= k)
            {
                Console.WriteLine(string.Join(" ", arr));
            }
            else
            {
                for (int i = 0; i < n; i++)
                {
                    if (!used[i])
                    {
                        used[i] = true;
                        arr[index] = i;
                        GenerateVariationsNoRep(index + 1);
                        used[i] = false;
                    }
                }
            }
        }

        static void GenerateVariations(int index)
        {
            if (index >= k)
            {
                Console.WriteLine(string.Join(" ", arr));
            }
            else
            {
                for (int i = 0; i < n; i++)
                {
                    arr[index] = i;
                    GenerateVariations(index + 1);
                }
            }
        }
    }
}
