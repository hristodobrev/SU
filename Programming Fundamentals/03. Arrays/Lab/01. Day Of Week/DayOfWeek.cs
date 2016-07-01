namespace _01.Day_Of_Week
{
    using System;

    class DayOfWeek
    {
        static void Main()
        {
            var day = int.Parse(Console.ReadLine());
            string[] daysOfWeek = {"Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday"};


            if (day > 7 || day < 1)
            {
                Console.WriteLine("Invalid Day!");
            }
            else
            {
                Console.WriteLine(daysOfWeek[day - 1]);
            }
        }
    }
}
