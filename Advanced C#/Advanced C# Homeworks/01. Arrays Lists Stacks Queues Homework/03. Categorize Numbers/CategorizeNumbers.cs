using System;
using System.Linq;
using System.Collections.Generic;
class CategorizeNumbers
{
    static void Main()
    {
        // Input
        float[] array = Console.ReadLine().Split(' ').Select(float.Parse).ToArray();

        // Logic
        List<int> roundNumbers = new List<int>();
        List<float> floatPointNumbers = new List<float>();

        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] % (int)array[i] == 0)
            {
                roundNumbers.Add((int)array[i]);
            }
            else
            {
                floatPointNumbers.Add(array[i]);
            }
        }

        // Output
        Console.WriteLine("[{0}] - > min: {1}, max: {2}, sum: {3}, avg: {4:f2}",string.Join(", ", floatPointNumbers), floatPointNumbers.Min(), floatPointNumbers.Max(), floatPointNumbers.Sum(), floatPointNumbers.Average());
        Console.WriteLine("[{0}] - > min: {1}, max: {2}, sum: {3}, avg: {4:f2}",string.Join(", ", roundNumbers), roundNumbers.Min(), roundNumbers.Max(), roundNumbers.Sum(), roundNumbers.Average());
    }
}