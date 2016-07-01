namespace _26.Factorial
{
    using System;
    using System.Numerics;

    class Factorial
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine(CalculateFactorial(n));
        }

        private static BigInteger CalculateFactorial(int n)
        {
            if (n < 1)
            {
                return 1;
            }

            return n * CalculateFactorial(n - 1);
        }
    }
}
