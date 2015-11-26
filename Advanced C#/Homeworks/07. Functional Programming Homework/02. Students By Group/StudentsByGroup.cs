using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

class StudentsByGroup
{
    static void Main()
    {
        // Students by Group
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Students from group 2:".ToUpper());
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine();
        SortStudentsByGroup();
    }

    static void SortStudentsByGroup()
    {
        var sortedStudents =
            from student in InitializeStudentsList.students
            where student.GroupNumber == 2
            select student;

        var orderedStudents = sortedStudents.OrderBy(x => x.FirstName);

        PrintStudents(orderedStudents);
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
