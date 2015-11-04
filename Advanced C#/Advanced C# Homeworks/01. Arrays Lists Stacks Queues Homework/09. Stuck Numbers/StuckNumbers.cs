using System;
using System.Collections.Generic;
using System.Linq;
class StuckNumbers
{
    static void Main()
    {
        // Input
        int n = int.Parse(Console.ReadLine());
        int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

        // Logic
        bool check = false;
        for (int a = 0; a < n; a++)
        {
            for (int b = 0; b < n; b++)
            {
                for (int c = 0; c < n; c++)
                {
                    for (int d = 0; d < n; d++)
                    {
                        if (a != b && a != c && a != d &&
                            b != c && b != d && c != d)
                        {
                            string first = numbers[a].ToString() + numbers[b];
                            string second = numbers[c].ToString() + numbers[d];
                            if (first == second)
                            {
                                // Output
                                Console.WriteLine("{0}|{1}=={2}|{3}", numbers[a], numbers[b], numbers[c], numbers[d]);
                                check = true;
                            }
                        }
                    }
                }
            }
        }
        if (!check)
        {
            // Output
            Console.WriteLine("No");
        }
    }
}