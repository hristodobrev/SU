namespace Gen01Vectors
{
    using System;
    using System.Linq;

    class GenVectors
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var vector = new int[n];

            Gen01Vector(vector, n - 1);
        }

        static void Gen01Vector(int[] vector, int index)
        {
            if (index < 0)
            {
                PrintVector(vector);
                return;
            }

            for (int i = 0; i <= 1; i++)
            {
                vector[index] = i;
                Gen01Vector(vector, index - 1);
            }
        }

        private static void PrintVector(int[] vector)
        {
            Console.WriteLine(string.Join(" ", vector.Reverse()));
        }
    }
}
