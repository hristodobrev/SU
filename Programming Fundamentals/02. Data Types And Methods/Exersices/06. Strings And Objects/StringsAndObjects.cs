namespace _06.Strings_And_Objects
{
    using System;

    class StringsAndObjects
    {
        static void Main()
        {
            string first = Console.ReadLine();
            string second = Console.ReadLine();

            object whole = first + " " + second;

            Console.WriteLine(whole);
        }
    }
}
