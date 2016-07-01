namespace _01.Remove_Negatives_And_Reverse
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());

            string[][] words = new string[rows][];

            for (int row = 0; row < rows; row++)
            {
                words[row] = Console.ReadLine().Split();
            }

            for (int col = 0; col < cols; col++)
            {
                for (int row = rows - 1; row >= 0; row--)
                {
                    Console.Write(words[row][col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
