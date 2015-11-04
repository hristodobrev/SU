using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _04.PopulationCounter
{
    class PopulationCounter
    {
        static void Main()
        {
            string line = Console.ReadLine();

            var countryData = new Dictionary<string, Dictionary<string, ulong>>();

            while (line != "report")
            {
                string[] lineArgs = line.Split('|');
                string city = lineArgs[0];
                string country = lineArgs[1];
                ulong population = ulong.Parse(lineArgs[2]);

                if (!countryData.ContainsKey(country))
                {
                    countryData[country] = new Dictionary<string, ulong>();
                    countryData[country].Add("total population", 0L);
                }

                countryData[country].Add(city, population);
                countryData[country]["total population"] += population;

                line = Console.ReadLine();
            }

            foreach (var pair in countryData
                .OrderByDescending(c => c.Value["total population"]))
            {
                Console.WriteLine("{0} (total population: {1})",
                    pair.Key, pair.Value["total population"]);
                foreach (var innerPair in pair.Value.OrderByDescending(c => c.Value))
                {
                    if (innerPair.Key == "total population")
                    {
                        continue;
                    }
                    Console.WriteLine("=>{0}: {1}", innerPair.Key, innerPair.Value);
                }
            }
        }
    }
}
