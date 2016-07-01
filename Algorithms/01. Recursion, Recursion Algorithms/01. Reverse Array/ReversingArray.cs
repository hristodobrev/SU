namespace _01.Reverse_Array
{
    using System;
    using System.Linq;

    class ReversingArray
    {
        static void Main(string[] args)
        {
            var array = Console.ReadLine()
                .Split(new []{' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var reversed = new int[array.Length];
            ReverseArray(reversed, array, 0);

            Console.WriteLine(string.Join(" ", reversed));
        }

        static void ReverseArray(int[] reversed, int[] array, int index)
        {
            if (index == array.Length)
            {
                return;
            }

            for (int i = 0; i < array.Length; i++)
            {
                reversed[i] = array[array.Length - (i + 1)];
                ReverseArray(reversed, array, index + 1);
            }
        }
    }
}
