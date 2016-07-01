namespace _07.Exchange_Variable_Values
{
    using System;

    class ExchangeValues
    {
        static void Main()
        {
            var a = Console.ReadLine();
            var b = Console.ReadLine();

            PrintVariables(a, b, "Before");

            var temp = a;
            a = b;
            b = temp;

            PrintVariables(a, b, "After");
        }

        private static void PrintVariables(object a, object b, string condition)
        {
            Console.WriteLine(condition + ":\na = {0}\nb = {1}", a, b);
        }
    }
}
