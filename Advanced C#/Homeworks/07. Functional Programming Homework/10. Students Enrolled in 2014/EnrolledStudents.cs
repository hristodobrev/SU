using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

class EnrolledStudents
{
    static void Main()
    {
        var enrolledStudents =
            from student in InitializeStudentsList.students
            where student.FacultyNumber.ToString().Substring(4, 2).Equals("14")
            select string.Join(", ", student.Marks);

        PrintStudents(enrolledStudents);
    }

    static void PrintStudents(IEnumerable<string> students)
    {
        foreach (var student in students)
        {
            Console.WriteLine(student);
        }
    }
}