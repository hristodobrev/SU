namespace Galactic_GPS
{
    using System;

    class GalacticGPS
    {
        static void Main()
        {
            try
            {
                Location home = new Location(18.037986, 29.870097, Planet.Earth);

                Console.WriteLine(home);

                Location jupiter = new Location(62.436253, 26.356235, Planet.Jupiter);

                Console.WriteLine(jupiter);

                Location outOfRange = new Location(152.512552, -200.421553, Planet.Saturn);

                Console.WriteLine(outOfRange);
            }
            catch(ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
