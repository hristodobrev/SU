﻿namespace _14.Integer_To_Hex_And_Binary
{
    using System;

    class IntegerToHexAndBinary
    {
        static void Main()
        {
            int number = int.Parse(Console.ReadLine());

            string hex = Convert.ToString(number, 16).ToUpper();
            string binary = Convert.ToString(number, 2);

            Console.WriteLine(hex);
            Console.WriteLine(binary);
        }
    }
}
