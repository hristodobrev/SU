namespace _25.Master_Numbers
{
    using System;

    class MasterNumbers
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 1; i < n; i++)
            {
                if (IsMasterNumber(i))
                {
                    Console.WriteLine(i);
                }
            }
        }

        private static bool IsMasterNumber(int number)
        {
            var isMasterNumber = IsPalindrome(number) && IsDivisibleBySeven(number) && HasOneEvenDigit(number);

            return isMasterNumber;
        }

        private static bool IsPalindrome(int number)
        {
            string numString = number.ToString();
            bool isPalindrome = true;
            for (int i = 0; i < numString.Length / 2; i++)
            {
                if (!numString[i].Equals(numString[numString.Length - 1 - i]))
                {
                    isPalindrome = false;
                    break;
                }
            }

            return isPalindrome;
        }

        private static bool IsDivisibleBySeven(int number)
        {
            int sum = 0;
            while (number > 0)
            {
                sum += number%10;
                number /= 10;
            }

            return sum%7 == 0;
        }

        private static bool HasOneEvenDigit(int number)
        {
            bool hasOneEveDigit = false;

            while (number > 0)
            {
                if ((number%10)%2 == 0)
                {
                    hasOneEveDigit = true;
                    break;
                }
                number /= 10;
            }

            return hasOneEveDigit;
        }
    }
}
