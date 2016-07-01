namespace _09.Largest_Increasing_Subsequence
{
    using System;
    using System.Linq;

    class LargestIncreasingSubsequence
    {
        static void Main()
        {
            var range = int.Parse(Console.ReadLine());
            int[][] distances = new int[range][];
            for (int i = 0; i < range; i++)
            {
                distances[i] = Console.ReadLine().Split().Select(int.Parse).ToArray();
            }

            var route = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var totalDistance = 0;
            for (int i = 0; i < route.Length; i++)
            {
                var firstTown = 0;
                if (i == 0)
                {
                    firstTown = 0;
                }
                else
                {
                    firstTown = route[i - 1];
                }
                var secondTown = route[i];
                totalDistance += distances[firstTown][secondTown];
            }

            Console.WriteLine(totalDistance);
        }
    }
}
