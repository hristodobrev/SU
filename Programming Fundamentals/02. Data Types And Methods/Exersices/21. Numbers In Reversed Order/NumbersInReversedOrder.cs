namespace _21.Numbers_In_Reversed_Order
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class NumbersInReversedOrder
    {
        static void Main()
        {
            decimal number = decimal.Parse(Console.ReadLine());

            Console.WriteLine(ReverseNumber(number));
        }

        private static decimal ReverseNumber(decimal number)
        {
            string numberString = number.ToString();
            List<char> reversedString = new List<char>();
            for (int i = numberString.Length - 1; i >= 0; i--)
            {
                reversedString.Add(numberString[i]);
            }
            decimal reversedNumber = decimal.Parse(String.Join("", reversedString));

            return reversedNumber;
        }
    }
}
