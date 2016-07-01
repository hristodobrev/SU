namespace _04.Variable_In_Hexadecimal
{
    using System;

    class VariableInHexadecimalFormat
    {
        static void Main()
        {
            string hexadecimal = Console.ReadLine();

            Console.WriteLine(Convert.ToInt32(hexadecimal, 16));
        }
    }
}
