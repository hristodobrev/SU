namespace _23.Prime_Checker
{
    using System;

    class PrimeChecker
    {
        static void Main()
        {
            long number = long.Parse(Console.ReadLine());

            Console.WriteLine(IsPrime(number));
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
                if (number%delimiter == 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
