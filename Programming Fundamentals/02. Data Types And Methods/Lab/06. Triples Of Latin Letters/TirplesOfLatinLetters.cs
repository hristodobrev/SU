namespace _06.Triples_Of_Latin_Letters
{
    using System;

    class TirplesOfLatinLetters
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                char first = (char) ('a' + i); 
                for (int j = 0; j < n; j++)
                {
                    char second = (char)('a' + j); 
                    for (int k = 0; k < n; k++)
                    {
                        char third = (char)('a' + k); 
                        Console.WriteLine("{0}{1}{2}", first, second, third);
                    }
                }
            }
        }
    }
}
