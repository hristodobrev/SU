namespace _20.Name_оf_The_Last_Digit
{
    using System;

    class NameOfLastDigit
    {
        static void Main()
        {
            decimal number = decimal.Parse(Console.ReadLine());

            Console.WriteLine(GetNameOfLastDigit(number));
        }

        private static string GetNameOfLastDigit(decimal number)
        {
            decimal lastDigit = number % 10;

            switch (Math.Abs((int)lastDigit))
            {
                case 0:
                    return "zero";
                case 1:
                    return "one";
                case 2:
                    return "two";
                case 3:
                    return "three";
                case 4:
                    return "four";
                case 5:
                    return "five";
                case 6:
                    return "six";
                case 7:
                    return "seven";
                case 8:
                    return "eight";
                case 9:
                    return "nine";
                default:
                    return "A BIG ERROR OCCURED!";
            }
        }
    }
}
