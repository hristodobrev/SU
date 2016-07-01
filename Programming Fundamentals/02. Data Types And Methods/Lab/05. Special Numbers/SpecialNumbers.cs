namespace _05.Special_Numbers
{
    using System;

    class SpecialNumbers
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine("{0} -> {1}", i, IsSpecial(i));
            }
        }

        private static bool IsSpecial(int number)
        {
            int sum = 0;
            while (number > 0)
            {
                sum += number%10;
                number /= 10;
            }

            if (sum == 5 || sum == 7 || sum == 11)
            {
                return true;
            }

            return false;
        }
    }
}
