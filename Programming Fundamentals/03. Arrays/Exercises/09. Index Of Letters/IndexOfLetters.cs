namespace _09.Index_Of_Letters
{
    using System;

    class IndexOfLetters
    {
        static void Main()
        {
            string input = Console.ReadLine();

            for (int i = 0; i < input.Length; i++)
            {
                Console.WriteLine("{0} -> {1}", input[i], input[i] - 97);
            }
        }
    }
}
