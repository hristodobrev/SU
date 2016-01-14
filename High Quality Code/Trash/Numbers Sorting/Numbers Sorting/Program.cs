using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Numbers_Sorting.Interfaces;
using Numbers_Sorting.Sorters;

namespace Numbers_Sorting
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();

            var nums = new int[10000];
            GenerateRandomNumbers(nums);

            ISorter sorter = new SelectSorter();

            Stopwatch timer = new Stopwatch();

            timer.Start();
            sorter.Sort(nums);
            timer.Stop();
            Console.WriteLine("Selection Sort Time: " + timer.Elapsed);

            GenerateRandomNumbers(nums);

            sorter = new BubbleSorter();

            timer.Restart();
            timer.Start();
            sorter.Sort(nums);
            timer.Stop();
            Console.WriteLine("Bubble Sort Time: " + timer.Elapsed);
        }

        private static void GenerateRandomNumbers(int[] nums)
        {
            Random rand = new Random();
            int length = nums.Length;
            for (int index = 0; index < length; index++)
            {
                nums[index] = rand.Next(length);
            }
        }
    }
}
