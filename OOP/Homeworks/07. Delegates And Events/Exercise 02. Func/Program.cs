namespace Exercise_02.Func
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        static void Main()
        {
            List<int> list = new List<int>() { 1, 2, 3, 4, 6, 11, 3 };
            Console.WriteLine(string.Join(", ", list.TakeWhile(x => x < 10)));
        }
    }
}
