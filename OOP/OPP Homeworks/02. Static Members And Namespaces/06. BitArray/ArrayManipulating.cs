using System;

namespace _06.BitArray
{
    class ArrayManipulating
    {
        static void Main()
        {
            BitArray num = new BitArray(8);
            num[7] = 1;
            Console.WriteLine(num);
            Console.WriteLine(num[6]);
        }
    }
}
