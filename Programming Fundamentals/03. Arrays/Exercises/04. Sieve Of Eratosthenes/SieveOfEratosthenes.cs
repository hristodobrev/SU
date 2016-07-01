namespace _04.Sieve_Of_Eratosthenes
{
    using System;
    using System.Collections.Generic;

    class SieveOfEratosthenes
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            bool[] primes = new bool[n + 1];
            primes[0] = false;
            primes[1] = false;
            for (int i = 2; i <= n; i++)
            {
                primes[i] = true;
            }

            int p = 2;

            List<int> primesList = new List<int>();
            while (p <= n)
            {
                if (primes[p])
                {
                    primesList.Add(p);
                    for (int i = 2; i <= n / p; i++)
                    {
                        primes[p*i] = false;
                    }
                }
                p++;
            }

            Console.WriteLine(string.Join(" ", primesList));
        }
    }
}
