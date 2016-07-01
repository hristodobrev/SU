namespace _22.Fibunacci_Numbers
{
    using System;

    class FibonacciNumbers
    {
        private static ulong[] cache = new ulong[1000];

        static void Main()
        {
            ulong n = ulong.Parse(Console.ReadLine());

            var fibonacci = Fib(n);

            Console.WriteLine(fibonacci);
        }

        private static ulong Fib(ulong n)
        {
            if (n == 0 || n == 1)
            {
                return 1;
            }
            if (n == 2)
            {
                return 2;
            }

            if (cache[n] == 0)
            {
                cache[n] = Fib(n - 1) + Fib(n - 2);
            }

            return cache[n];
        }
    }
}
