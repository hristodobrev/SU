namespace Exercise_01
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        static void Main(string[] args)
        {
            List<int> collection = new List<int>() {
                1, 2, 3, 4, 6, 11, 3
            };

            Console.WriteLine(collection.FirstOrDefault(x => x > 7));
            Console.WriteLine(collection.FirstOrDefault(x => x < 0));
        }
    }
}
