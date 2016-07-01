namespace _09.Animal_Type
{
    using System;

    class AnimalType
    {
        static void Main()
        {
            string animal = Console.ReadLine();

            string output = null;
            switch (animal)
            {
                case "dog":
                    output = "mammal";
                    break;
                case "snake":
                case "tortoise":
                case "crocodile":
                    output = "reptile";
                    break;
                default:
                    output = "unknown";
                    break;
            }

            Console.WriteLine(output);
        }
    }
}
