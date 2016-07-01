namespace _19.Max_Method
{
    using System;

    class MaxMethod
    {
        static void Main()
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());

            int firstMax = GetMax(a, b);

            Console.WriteLine(GetMax(firstMax, c));
        }

        private static int GetMax(int a, int b)
        {
            if (a > b)
            {
                return a;
            }

            return b;
        }
    }
}
