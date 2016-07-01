namespace _11.Convert_Speed_Units
{
    using System;

    class ConvertSpeedUnits
    {
        static void Main()
        {
            float distance = float.Parse(Console.ReadLine());
            float hours = float.Parse(Console.ReadLine());
            float minutes = float.Parse(Console.ReadLine());
            float seconds = float.Parse(Console.ReadLine());

            float metersPerSecond = distance / (hours * 3600 + minutes * 60 + seconds);
            float kilometersPerHour = (distance/1000)/(hours + minutes/60 + seconds / 3600);
            float milesPerHour = (distance/1609)/(hours + minutes/60 + seconds / 3600);

            Console.WriteLine(metersPerSecond);
            Console.WriteLine(kilometersPerHour);
            Console.WriteLine(milesPerHour);
        }
    }
}
