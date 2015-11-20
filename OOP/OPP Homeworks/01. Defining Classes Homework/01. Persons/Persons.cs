using System;

namespace _01.Persons
{
    class Persons
    {
        static void Main()
        {
            Person pesho = new Person("Pesho", 100, "pesho@gmail.com");
            Console.WriteLine(pesho);

            Person gosho = new Person("Gosho", 20);
            Console.WriteLine(gosho);
        }
    }
}
