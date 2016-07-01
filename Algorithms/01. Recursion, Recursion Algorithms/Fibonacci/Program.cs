namespace Fibonacci
{
    using System;
    using System.Diagnostics;
    using System.Runtime.InteropServices;

    class Program
    {
        private const int MAX_FIBONACCI_MEMBERS = 1000;
        static decimal[] chache = new decimal[MAX_FIBONACCI_MEMBERS];

        static void Main(string[] args)
        {
            Stopwatch timer = new Stopwatch();

            timer.Start();
            for (int i = 0; i < 100000; i++)
            {
                SlowFibonacci(10);
            }
            timer.Stop();
            Console.WriteLine("Slow Fibonacci time: {0}", timer.Elapsed);

            timer.Reset();
            timer.Start();
            for (int i = 0; i < 100000; i++)
            {
                FastFibonacci(10);
            }
            timer.Stop();
            Console.WriteLine("Fast Fibonacci time: {0}", timer.Elapsed);
        }

        static decimal FastFibonacci(int num)
        {
            if (num == 0 || num == 1)
            {
                return 1;
            }

            if (chache[num] == 0)
            {
                chache[num] = FastFibonacci(num - 1) + FastFibonacci(num - 2);
            }

            return chache[num];
        }

        static decimal SlowFibonacci(int num)
        {
            if (num == 0 || num == 1)
            {
                return 1;
            }

            return SlowFibonacci(num - 1) + SlowFibonacci(num - 2);
        }
    }
}
