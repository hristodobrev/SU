using System;
using System.Collections.Generic;

class GenericArraySort
{
    static void Main()
    {
        // Input
        List<int> numbers = new List<int>(){ 4, 6, 24, 63, 65, 34, 10 };
        List<double> doubles = new List<double>{ 4.63, 6.32, 5.634, 4.6647, 6.436 };
        List<DateTime> dates = new List<DateTime>(){ new DateTime(2010, 3, 5), new DateTime(2002, 5, 7), new DateTime(2010, 6, 8) };
        // Logic
        SortArray(numbers);
        SortArray(doubles);
        SortArray(dates);

        Console.WriteLine(string.Join(", ", numbers));
        Console.WriteLine(string.Join(", ", doubles));
        Console.WriteLine(string.Join(", ", dates));
    }

    // Logic
    static void SortArray<T>(List<T> list) where T : IComparable
    {
        for (int i = 0; i < list.Count - 1; i++)
        {
            int minValue = i;
            for (int j = i + 1; j < list.Count; j++)
            {
                if (list[minValue].CompareTo(list[j]) > 0)
                {
                    minValue = j;
                }
            }
            T temp = list[i];
            list[i] = list[minValue];
            list[minValue] = temp;
        }
    }

}
