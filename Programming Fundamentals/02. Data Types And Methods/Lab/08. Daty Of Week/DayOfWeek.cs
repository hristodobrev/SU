namespace _08.Daty_Of_Week
{
    using System;

    class DayOfWeek
    {
        static void Main()
        {
            int day = int.Parse(Console.ReadLine());

            string output = null;
            switch (day)
            {
                case 1:
                    output = "Monday";
                    break;
                case 2:
                    output = "Tuesday";
                    break;
                case 3:
                    output = "Wednesday";
                    break;
                case 4:
                    output = "Thursday";
                    break;
                case 5:
                    output = "Friday";
                    break;
                case 6:
                    output = "Saturday";
                    break;
                case 7:
                    output = "Sunday";
                    break;
                default:
                    output = "Error";
                    break;
            }

            Console.WriteLine(output);
        }
    }
}
