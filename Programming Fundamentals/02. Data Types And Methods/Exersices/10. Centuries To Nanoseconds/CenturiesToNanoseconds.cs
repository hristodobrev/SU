﻿namespace _10.Centuries_To_Nanoseconds
{
    using System;

    class CenturiesToNanoseconds
    {
        static void Main()
        {
            int centuries = int.Parse(Console.ReadLine());
            int years = centuries*100;
            long days = (int)(years * 365.2422);
            ulong hours = (ulong)(days*24);
            ulong minutes = hours*60;
            decimal seconds = minutes * 60;
            decimal milliseconds = seconds * 1000;
            decimal microseconds = milliseconds * 1000;
            decimal nanoseconds = microseconds*1000;

            Console.WriteLine("{0} centuries = {1} years = {2} days = {3} hours = {4} minutes = {5} seconds = {6} milliseconds = {7} microseconds = {8} nanoseconds",
                centuries,
                years,
                days,
                hours,
                minutes,
                seconds,
                milliseconds,
                microseconds,
                nanoseconds);
        }
    }
}
