using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Human_Student_And_Worker
{
    class Humans
    {
        static void Main()
        {
            List<Student> students = new List<Student>
            {
                new Student("Ivan", "Vasilev", "A10000"),
                new Student("Ivayla", "Mihaylova", "A10003"),
                new Student("Georgi", "Tsankov", "A10004"),
                new Student("Stoyan", "Georgiev", "A10001"),
                new Student("Miroslav", "Ganev", "A10007"),
                new Student("Gergana", "Vasileva", "A10009"),
                new Student("Stanimira", "Nikolova", "A10002"),
                new Student("Ivan", "Borisov", "A10006"),
                new Student("Ignat", "Malenov", "A10005"),
                new Student("Hristina", "Marinova", "A10008")
            };

            var sortedStudents = students.OrderBy(x => x.FacultyNumber);

            PrintInGreen("Students");
            foreach (var student in sortedStudents)
            {
                Console.WriteLine("{0} {1}: {2}", student.FirstName, student.LastName, student.FacultyNumber);
            }

            List<Worker> workers = new List<Worker>
            {
                new Worker("Marin", "Ivanov", 350, 8),
                new Worker("Ivana", "Georgieva", 145, 4),
                new Worker("Tihomir", "Spasov", 600, 7),
                new Worker("Vasil", "Levashki", 250, 6),
                new Worker("Nadezhda", "Bogoeva", 400, 7),
                new Worker("Zhelyo", "Dobrev", 1200, 6),
                new Worker("Stefka", "Apostolova", 500, 8),
                new Worker("Ognyan", "Iliev", 120, 4),
                new Worker("Katerina", "Baleva", 300, 8),
                new Worker("Ivan", "Orhanov", 750, 8)
            };

            var sortedWorkers = workers.OrderByDescending(x => x.MoneyPerHour());

            PrintInGreen("Workers");
            foreach (var worker in sortedWorkers)
            {
                Console.WriteLine("{0} {1}: {2:F2}", worker.FirstName, worker.LastName, worker.MoneyPerHour());
            }

            List<Human> humans = new List<Human>();
            humans.AddRange(workers);
            humans.AddRange(students);

            var sortedHumans = humans.OrderBy(x => x.FirstName)
                .ThenBy(x => x.LastName);

            PrintInGreen("Humans");
            foreach (var human in sortedHumans)
            {
                Console.WriteLine("{0} {1}", human.FirstName, human.LastName);
            }
        }

        private static void PrintInGreen(string text)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(text);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
