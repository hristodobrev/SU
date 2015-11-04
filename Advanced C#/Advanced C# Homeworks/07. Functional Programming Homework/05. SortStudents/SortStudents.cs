using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

class SortStudents
{
    static void Main()
    {

        // Sort Students

        // with lambda expression
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Sort with lambda expression:".ToUpper());
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine();
        SortStudentsWithLambaExpression();
        // with linq query
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Sort with linq query:".ToUpper());
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine();
        SortStudentsWithLinqQuery();

    }

    static void SortStudentsWithLambaExpression()
    {
        var sortedStudents = InitializeStudentsList.students
            .OrderByDescending(x => x.FirstName)
            .ThenBy(x => x.LastName);

        PrintStudents(sortedStudents);
    }

    static void SortStudentsWithLinqQuery()
    {
        var sortedStudents =
            from student in InitializeStudentsList.students
            orderby student.FirstName descending, student.LastName descending
            
            select student;

        PrintStudents(sortedStudents);
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
