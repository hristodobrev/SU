namespace NotWorkingDaysOfWeek
{
    using System;
    using System.Globalization;

    class HolidaysBetweenTwoDates
    {
        static void Main()
        {
            var startDate = DateTime.ParseExact(Console.ReadLine(),
            "d.M.yyyy", CultureInfo.InvariantCulture);
            var endDate = DateTime.ParseExact(Console.ReadLine(),
                "d.M.yyyy", CultureInfo.InvariantCulture);
            var holidaysCount = 0;
            var difference = endDate - startDate;
            for (var i = 0; i <= difference.Days; i++)
            {
                var day = startDate.AddDays(i).DayOfWeek;
                if (day.Equals(DayOfWeek.Saturday) ||
                    day.Equals(DayOfWeek.Sunday))
                {
                    holidaysCount++;
                }
            }

            Console.WriteLine(holidaysCount);
        }
    }
}
