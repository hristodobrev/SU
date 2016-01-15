using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Performance_of_Operations
{
    using System.Diagnostics;

    class CalculateTimes
    {
        static void Main(string[] args)
        {
            TimeSpan averageAddTimeOperation = GetAddOperationAverageTime();

            Console.WriteLine(averageAddTimeOperation);
        }

        private static TimeSpan GetAddOperationAverageTime()
        {
            Stopwatch timer = new Stopwatch();

            List<TimeSpan> times = new List<TimeSpan>();

            for (int i = 0; i < 500; i++)
            {
                timer.Restart();
                timer.Start();
                var a = 0;
                for (int j = 0; j < 5000; j++)
                {
                    a = a + 500;
                }
                timer.Stop();
                times.Add(timer.Elapsed);
            }

            double averageTicks = times.Average(timespan => timespan.Ticks);
            TimeSpan average = new TimeSpan(Convert.ToInt64(averageTicks));

            return average;
        }
    }
}