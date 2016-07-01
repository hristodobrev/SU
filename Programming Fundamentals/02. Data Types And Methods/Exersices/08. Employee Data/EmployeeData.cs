namespace _08.Employee_Data
{
    using System;

    class EmployeeData
    {
        static void Main()
        {
            string firstName = Console.ReadLine();
            string lastName = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            char gender = Console.ReadLine()[0];
            long personalId = long.Parse(Console.ReadLine());
            uint uniqueNumber = uint.Parse(Console.ReadLine());

            Console.WriteLine("First name: {0}\nLast name: {1}\nAge: {2}\nGender: {3}\nPersonal ID: {4}\nUnique Employee number: {5}",
                firstName,
                lastName,
                age,
                gender,
                personalId,
                uniqueNumber);
        }
    }
}
