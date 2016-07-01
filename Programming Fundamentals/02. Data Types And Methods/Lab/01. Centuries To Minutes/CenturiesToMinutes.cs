namespace _01.Centuries_To_Minutes
{
    using System;

    class CenturiesToMinutes
    {
        static void Main()
        {
            int centuries = int.Parse(Console.ReadLine());
            int years = centuries*100;
            ulong days = (ulong) Math.Floor(years*365.2422);
            ulong hours = days*24;
            ulong minutes = hours*60;

            Console.WriteLine("{0} centuries = {1} years = {2} days = {3} hours = {4} minutes",
                centuries, years, days, hours, minutes);
        }
    }
}
