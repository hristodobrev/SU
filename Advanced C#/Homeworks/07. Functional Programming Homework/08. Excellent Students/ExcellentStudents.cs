using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

class ExcellentStudents
{
    static void Main()
    {
        // Choose excelent students
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Excellent students:".ToUpper());
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine();
        SelectExcellentStudents();

    }

    static void SelectExcellentStudents()
    {

        var filteredStudents =
            from student in InitializeStudentsList.students
            from mark in student.Marks
            where mark == 6
            select student.FirstName + " " + student.LastName + " [" + string.Join(", ", student.Marks) + "]";

        PrintStudents(filteredStudents);
    }

    static void PrintStudents(IEnumerable<string> students)
    {
        foreach (var student in students)
        {
            Console.WriteLine(student);
        }
    }
}
