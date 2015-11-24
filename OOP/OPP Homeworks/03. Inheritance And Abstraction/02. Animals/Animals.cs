using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Animals
{
    class Animals
    {
        static void Main()
        {
            List<Animal> animals = new List<Animal>
            {
                new Dog("Kiara", 7, "Female"),
                new Tomcat("Mochko", 2),
                new Cat("Pisa", 5, "Female"),
                new Dog("Raya", 2, "Female"),
                new Frog("Marto", 2, "Male"),
                new Tomcat("Dzen", 4),
                new Frog("Froggie", 1, "Male"),
                new Kitten("Macuki", 2),
                new Frog("Djina", 1, "Female"),
                new Cat("Djena", 3, "Female"),
                new Dog("Djo", 8, "Male"),
                new Frog("Froggera", 1, "Female"),
                new Cat("Tom", 3, "Male"),
                new Dog("Misho", 7, "Male"),
                new Cat("Djintaro", 1, "Male"),
                new Kitten("Michuo", 3),
                new Frog("Frogger", 3, "Male"),
                new Dog("Rex", 4, "Male"),
                new Kitten("Nasaka", 3),
                new Dog("Sharo", 5, "Male"),
                new Tomcat("Denis", 3),
                new Kitten("Kia", 1),
            };

            var dogsCount = animals.FindAll(x => x is Dog).Count;
            var frogsCount = animals.FindAll(x => x is Frog).Count;
            var catsCount = animals.FindAll(x => x is Cat).Count;
            var kittensCount = animals.FindAll(x => x is Kitten).Count;
            var tomcatsCount = animals.FindAll(x => x is Tomcat).Count;

            Console.WriteLine("Dogs: {0}", dogsCount);
            Console.WriteLine("Frogs: {0}", frogsCount);
            Console.WriteLine("Cats: {0}", catsCount);
            Console.WriteLine("Kittens: {0}", kittensCount);
            Console.WriteLine("Tomcats: {0}", tomcatsCount);
        }
    }
}
