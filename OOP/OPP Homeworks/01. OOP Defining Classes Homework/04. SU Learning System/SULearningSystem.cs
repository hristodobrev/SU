using System;
using _04.SU_Learning_System.Students;
using _04.SU_Learning_System.Trainers;
using System.Collections.Generic;
using System.Linq;

namespace _04.SU_Learning_System
{
    class SULearningSystem
    {
        static void Main()
        {
            List<Person> persons = new List<Person>();
            persons.Add(new SeniorTrainer("Mihail", "Draganov", 42));
            persons.Add(new OnsiteStudent("Georgi", "Peikov", 25, 4367743, 5.20, "Advanced C#", 2));
            persons.Add(new OnlineStudent("Georgi", "Peikov", 25, 4367743, 5.20, "Advanced Back-End"));
            persons.Add(new SeniorTrainer("Sonya", "Petkova", 48));
            persons.Add(new JuniorTrainer("Sonya", "Petkova", 48));
            persons.Add(new JuniorTrainer("Galq", "Vazova", 39));
            persons.Add(new GraduateStudent("Ivan", "Tsankov", 23, 5356672, 4.95));
            persons.Add(new CurrentStudent("Katerina", "Mileva", 19, 4536545, 5.78, "Java Fundamentals"));
            persons.Add(new DropoutStudent("Pesho", "Goshev", 21, 543536, 3.65, "Presence drunk on lectures."));
            persons.Add(new SeniorTrainer("Pencho", "Vasilev", 48));
            persons.Add(new OnsiteStudent("Vankata", "Draganov", 24, 4235436, 5.00, "Advanced C#", 5));
            persons.Add(new OnlineStudent("Stoqn", "Ivanov", 19, 547452654, 4.70, "Advanced Back-End"));
            persons.Add(new SeniorTrainer("Mihaila", "Dimitrova", 38));
            persons.Add(new JuniorTrainer("Ivaila", "Hristova", 43));
            persons.Add(new JuniorTrainer("Filip", "Ignatov", 36));
            persons.Add(new GraduateStudent("Tihomir", "Georgiev", 25, 2376535, 4.56));
            persons.Add(new CurrentStudent("Dimitar", "Conev", 23, 465256, 5.23, "Java Fundamentals"));
            persons.Add(new DropoutStudent("Ivan", "Petrov", 25, 765344, 5.65, "Killed an inocent student."));

            var currentStudentsOnly = persons.Where(x => x.GetType() == typeof(CurrentStudent));

            foreach (var student in currentStudentsOnly)
            {
                CurrentStudent st = (CurrentStudent)student;
                Console.WriteLine(st.ToString());
                Console.WriteLine("Student number: {0}\nAverage Grade: {1}\n", st.StudentNumber, st.AverageGrade);
            }
        }
    }
}
