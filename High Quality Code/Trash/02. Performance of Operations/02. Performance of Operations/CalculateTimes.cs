using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace _02.Performance_of_Operations
{
    using System.Diagnostics;

    class CalculateTimes
    {
        static void Main(string[] args)
        {
            TimeSpan addOperationAverageTime = GetAddOperationAverageTime();
            Console.WriteLine("Add Operation Average Time:" + addOperationAverageTime);

            TimeSpan subtractOperationAverageTime = GetSubtractOperationAverageTime();
            Console.WriteLine("Subtract Operation Average Time:" + subtractOperationAverageTime);
        }

        private static TimeSpan GetSubtractOperationAverageTime()
        {
            Stopwatch timer = new Stopwatch();

            List<TimeSpan> times = new List<TimeSpan>();

            for (int i = 0; i < 5000; i++)
            {
                timer.Restart();
                timer.Start();
                int a = 0;
                a = a - 500;
                timer.Stop();
                times.Add(timer.Elapsed);
            }

            double averageTicks = times.Average(timespan => timespan.Ticks);
            TimeSpan average = new TimeSpan(Convert.ToInt64(averageTicks));

            return average;
        }

        private static TimeSpan GetAddOperationAverageTime()
        {
            Stopwatch timer = new Stopwatch();

            List<TimeSpan> times = new List<TimeSpan>();

            for (int i = 0; i < 5000; i++)
            {
                timer.Restart();
                timer.Start();
                int a = 0;
                a = a + 500000;
                timer.Stop();
                times.Add(timer.Elapsed);
            }

            double averageTicks = times.Average(timespan => timespan.Ticks);
            TimeSpan average = new TimeSpan(Convert.ToInt64(averageTicks));

            return average;
        }
    }
}
