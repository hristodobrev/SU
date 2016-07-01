namespace _10.Filled_Square
{
    using System;

    class FilledSquare
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            PrintHeader(n);
            for (int i = 0; i < n - 2; i++)
            {
                PrintMiddle(n, i % 2 == 1 ? "\\/" : "/\\");
            }
            PrintHeader(n);
        }

        private static void PrintMiddle(int n, string symbol)
        {
            Console.Write("-");
            for (int i = 0; i < n - 1; i++)
            {
                Console.Write(symbol);
            }
            Console.WriteLine("-");
        }

        private static void PrintHeader(int n)
        {
            Console.WriteLine(new string('-', n * 2));
        }
    }
}
