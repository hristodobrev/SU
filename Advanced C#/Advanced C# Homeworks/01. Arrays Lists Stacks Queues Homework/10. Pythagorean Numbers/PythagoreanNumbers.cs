using System;
using System.Collections.Generic;
using System.Linq;
class PythagoreanNumbers
{
    static void Main()
    {
        // Input
        int n = int.Parse(Console.ReadLine());
        List<int> numbers = new List<int>();
        for (int i = 0; i < n; i++)
        {
            numbers.Add(int.Parse(Console.ReadLine()));
        }

        // Logic
        bool isPrinted = false;
        bool isPrintedZero = false;

        for (int a = 0; a < n; a++)
        {
            for (int b = 0; b < n; b++)
            {
                for (int c = 0; c < n; c++)
                {
                    if (a != b && numbers[a] < numbers[b])
                    {
                        if ((numbers[a] * numbers[a]) + (numbers[b] * numbers[b]) == numbers[c] * numbers[c])
                        {
                            Console.WriteLine("{0}*{0} + {1}*{1} = {2}*{2}", numbers[a], numbers[b], numbers[c]);
                            isPrinted = true;
                        }
                    }
                }
            }
            if (numbers[a] == 0 && !isPrintedZero)
            {
                Console.WriteLine("0*0 + 0*0 = 0*0");
                isPrintedZero = true;
            }
        }
        if (!isPrinted)
        {
            Console.WriteLine("No");
        }
    }
}