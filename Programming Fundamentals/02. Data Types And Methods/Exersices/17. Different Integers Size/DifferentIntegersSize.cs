namespace _17.Different_Integers_Size
{
    using System;
    using System.Collections.Generic;

    class DifferentIntegersSize
    {
        static void Main()
        {
            var number = Console.ReadLine();
            var capableTypes = new List<string>();

            try
            {
                long.Parse(number);
                capableTypes.Add("long");
            }
            catch (OverflowException)
            {
            }
            try
            {
                uint.Parse(number);
                capableTypes.Add("uint");
            }
            catch (OverflowException)
            {
            }
            try
            {
                int.Parse(number);
                capableTypes.Add("int");
            }
            catch (OverflowException)
            {
            }
            try
            {
                ushort.Parse(number);
                capableTypes.Add("ushort");
            }
            catch (OverflowException)
            {
            }
            try
            {
                short.Parse(number);
                capableTypes.Add("short");
            }
            catch (OverflowException)
            {
            }
            try
            {
                byte.Parse(number);
                capableTypes.Add("byte");
            }
            catch (OverflowException)
            {
            }
            try
            {
                sbyte.Parse(number);
                capableTypes.Add("sbyte");
            }
            catch (OverflowException)
            {
            }

            if (capableTypes.Count != 0)
            {
                Console.WriteLine("{0} can fit in:", number);
                capableTypes.Reverse();
                foreach (var type in capableTypes)
                {
                    Console.WriteLine("* {0}", type);
                }
            }
            else
            {
                Console.WriteLine("{0} can't fit in any type", number);
            }
        }
    }
}
