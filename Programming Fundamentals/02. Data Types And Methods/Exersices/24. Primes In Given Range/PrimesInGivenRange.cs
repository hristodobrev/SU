namespace _24.Primes_In_Given_Range
{
    using System;
    using System.Collections.Generic;

    class PrimesInGivenRange
    {
        static void Main()
        {
            int startNum = int.Parse(Console.ReadLine());
            int endNum = int.Parse(Console.ReadLine());

            var primes = FindPrimesInRange(startNum, endNum);
            Console.WriteLine(primes.Count == 0 ? "(empty list)" : string.Join(", ", primes));
        }

        private static List<int> FindPrimesInRange(int startNum, int endNum)
        {
            List<int> primes = new List<int>();

            for (int i = startNum; i <= endNum; i++)
            {
                if (IsPrime(i))
                {
                    primes.Add(i);
                }
            }

            return primes;
        }

        private static bool IsPrime(long number)
        {
            if (number == 0 || number == 1)
            {
                return false;
            }

            number = Math.Abs(number);

            for (long delimiter = 2; delimiter <= Math.Sqrt(number); delimiter++)
            {
                if (number % delimiter == 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
