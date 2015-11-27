using System;

namespace _06.BitArray
{
    class ArrayManipulating
    {
        static void Main()
        {
            BitArray num = new BitArray(99999);
            num[99999] = 1;
            Console.WriteLine(num);
            Console.WriteLine(num[6]);
        }
    }
}
