using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

class WeakStudents
{

    static void Main()
    {
        // Choose weak students
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("weak students:".ToUpper());
        Console.ForegroundColor = ConsoleColor.White;

        var weakStudents = InitializeStudentsList.students.Where(x => SelectWeakStudent(x));

        foreach (var student in weakStudents)
        {
            Console.WriteLine("{0} {1} {2}", student.FirstName, student.LastName, string.Join(", ", student.Marks));
        }

    }

    static bool SelectWeakStudent(Students x)
    {
        int counter = 0;
        foreach (var mark in x.Marks)
        {
            if (mark.Equals(2))
            {
                counter++;
            }
        }
        if (counter == 2)
        {
            return true;
        }
        return false;
    }
}