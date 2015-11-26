using System;

namespace _02.Laptop_Shop
{
    class LaptopShop
    {
        static void Main()
        {
            Laptop laptop = new Laptop("HP 250 G2", 600);
            Laptop laptop2 = new Laptop("Lenovo Yoga 2 Pro",
                "Lenovo", 2259);
            Laptop laptop3 = new Laptop("Lenovo Yoga 2 Pro",
                "Lenovo", "Intel Core i5-4210U (2-core, 1.70 - 2.70 GHz, 3MB cache)", 2259);
            Laptop laptop4 = new Laptop("Lenovo Yoga 2 Pro", 
                "Lenovo", "Intel Core i5-4210U (2-core, 1.70 - 2.70 GHz, 3MB cache)", 8, 2259);
            Laptop laptop5 = new Laptop("Lenovo Yoga 2 Pro",
                "Lenovo", "Intel Core i5-4210U (2-core, 1.70 - 2.70 GHz, 3MB cache)", 8,
                "Intel HD Graphics 4400", 2259);
            Laptop laptop6 = new Laptop("Lenovo Yoga 2 Pro",
                "Lenovo", "Intel Core i5-4210U (2-core, 1.70 - 2.70 GHz, 3MB cache)", 8,
                "Intel HD Graphics 4400",
                "128GB SSD", 2259);
            Laptop laptop7 = new Laptop("Lenovo Yoga 2 Pro",
                "Lenovo", "Intel Core i5-4210U (2-core, 1.70 - 2.70 GHz, 3MB cache)", 8,
                "Intel HD Graphics 4400",
                "128GB SSD", "13.3\" (33.78 cm) – 3200 x 1800 (QHD+), IPS sensor display", 2259);
            Laptop laptop8 = new Laptop("Lenovo Yoga 2 Pro",
                "Lenovo", "Intel Core i5-4210U (2-core, 1.70 - 2.70 GHz, 3MB cache)", 8,
                "Intel HD Graphics 4400",
                "128GB SSD", "13.3\" (33.78 cm) – 3200 x 1800 (QHD+), IPS sensor display",
                "Li-Ion, 4-cells, 2550 mAh", 2259);
            Laptop laptop9 = new Laptop("Lenovo Yoga 2 Pro",
                "Lenovo", "Intel Core i5-4210U (2-core, 1.70 - 2.70 GHz, 3MB cache)", 8,
                "Intel HD Graphics 4400",
                "128GB SSD", "13.3\" (33.78 cm) – 3200 x 1800 (QHD+), IPS sensor display",
                "Li-Ion, 4-cells, 2550 mAh", 4.5, 2259);

            Console.WriteLine(laptop);
            Console.WriteLine();
            Console.WriteLine(laptop2);
            Console.WriteLine();
            Console.WriteLine(laptop3);
            Console.WriteLine();
            Console.WriteLine(laptop4);
            Console.WriteLine();
            Console.WriteLine(laptop5);
            Console.WriteLine();
            Console.WriteLine(laptop6);
            Console.WriteLine();
            Console.WriteLine(laptop7);
            Console.WriteLine();
            Console.WriteLine(laptop8);
            Console.WriteLine();
            Console.WriteLine(laptop9);
        }
    }
}
