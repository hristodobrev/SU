using System;

namespace _03.PC_Catalog
{
    class PCCatalog
    {
        static void Main()
        {
            Component hdd1 = new Component("HDD", "Seagate 2 TB", 230);
            Component ram1 = new Component("RAM","Crossair 8 GB", 140);
            Component gpu1 = new Component("GPU","GTX TitanZ", 1980);
            Component cpu1 = new Component("CPU", "Intel Core i7-6700", 655);
            Component cddrive1 = new Component("DVD", 45);

            Component hdd2 = new Component("HDD", "Toshiba 500 GB", 70);
            Component ram2 = new Component("RAM", "Value 4 GB", 74);
            Component gpu2 = new Component("GPU", "Sapphire HD8750", 430);
            Component cpu2 = new Component("CPU", "AMD Buldozer A9950", 400);

            Computer computer1 = new Computer("Mnogo moshten", hdd1, ram1, gpu1, cpu1, cddrive1);
            Computer computer2 = new Computer("Sreden klas", hdd2, ram2, gpu2, cpu2);

            Console.WriteLine(computer1);
            Console.WriteLine();
            Console.WriteLine(computer2);
        }
    }
}
