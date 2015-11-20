using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace _03.PC_Catalog
{
    class PCCatalog
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Component hdd1 = new Component("HDD", "Seagate 2 TB", 230);
            Component ram1 = new Component("RAM","Crossair 8 GB", 140);
            Component gpu1 = new Component("GPU","GTX TitanZ", 1980);
            Component cpu1 = new Component("CPU", "Intel Core i7-6700", 655);
            Component cddrive1 = new Component("DVD", 45);

            Component hdd2 = new Component("HDD", "Toshiba 500 GB", 70);
            Component ram2 = new Component("RAM", "Value 4 GB", 74);
            Component gpu2 = new Component("GPU", "Sapphire HD8750", 430);
            Component cpu2 = new Component("CPU", "AMD Buldozer A9950", 400);

            List<Computer> computers = new List<Computer>
                {
                    new Computer("Nai-moshtniq", hdd1, ram1, gpu1, cpu1, cddrive1),
                    new Computer("Sreden klas", hdd2, ram2, gpu2, cpu2),
                    new Computer("Melez", hdd2, ram2, gpu1, cpu2),
                    new Computer("Mnogo moshten", hdd2, ram1, gpu1, cpu1),
                    new Computer("Leko moshten", hdd2, ram2, gpu1, cpu1)
                };

            var sortedComputers = computers.OrderBy(x => x.Price);

            foreach (var computer in sortedComputers)
            {
                Console.WriteLine(computer);
                Console.WriteLine();
            }
        }
    }
}
