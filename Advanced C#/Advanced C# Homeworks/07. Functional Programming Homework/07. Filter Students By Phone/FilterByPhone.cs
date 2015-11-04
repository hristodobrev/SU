using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

class FilterByPhone
{
    static void Main()
    {
        // Filter Students by Phone
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Filter Students by phone:".ToUpper());
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine();
        FilterByEmailDomain();

    }

    static void FilterByEmailDomain()
    {
        string pattern = @"\+3592[0-9| ]+|02 [0-9| ]+|\+359 2[0-9| ]+";
        Regex regex = new Regex(pattern);

        var filteredStudents =
            from student in InitializeStudentsList.students
            where regex.IsMatch(student.Phone)
            select student;

        PrintStudents(filteredStudents);
    }

    static void PrintStudents(IEnumerable<Students> students)
    {
        foreach (var student in students)
        {
            Console.WriteLine("First name: {0}", student.FirstName);
            Console.WriteLine("Last name: {0}", student.LastName);
            Console.WriteLine("Age: {0}", student.Age);
            Console.WriteLine("Faculty number: .{0}", student.FacultyNumber);
            Console.WriteLine("Phone: {0}", student.Phone);
            Console.WriteLine("Email: {0}", student.Email);
            Console.WriteLine("Marks: {0}", string.Join(", ", student.Marks));
            Console.WriteLine("Group number: {0}", student.GroupNumber);
            Console.WriteLine();
        }
    }
}
