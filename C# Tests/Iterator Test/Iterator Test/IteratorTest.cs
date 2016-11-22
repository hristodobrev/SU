namespace Iterator_Test
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    class IteratorTest
    {
        static void Main()
        {
            int[] a = new int[]{1, 2, 3, 4, 5};
            //foreach (var b in GetEnumerator(a))
            //{
            //    Console.WriteLine(b);
            //}
        }

        static public IEnumerator GetEnumerator(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                yield return arr[i];
            }
        }
    }
}
