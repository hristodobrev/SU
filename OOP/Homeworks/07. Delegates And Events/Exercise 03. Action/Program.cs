namespace Exercise_03.Action
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main()
        {
            List<int> collection = new List<int>() { 1, 2, 3, 4, 6, 11, 3 };

            collection.ForEach(Console.WriteLine);
        }
    }
}
