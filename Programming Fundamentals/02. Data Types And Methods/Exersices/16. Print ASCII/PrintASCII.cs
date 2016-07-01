namespace _16.Print_ASCII
{
    using System;
    using System.Collections.Generic;

    class PrintASCII
    {
        static void Main()
        {
            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());

            List<char> characters = new List<char>();

            for (int i = start; i <= end; i++)
            {
                characters.Add((char)i);
            }

            Console.WriteLine(string.Join(" ", characters));
        }
    }
}
