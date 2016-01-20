using System;
using System.Linq;
using System.Collections.Generic;

public class Student
{
    private string firstName;
    private string lastName;
    private IList<Exam> exams; 

    public Student(string firstName, string lastName, IList<Exam> exams = null)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
        if (exams != null)
        {
            this.Exams = exams;
        }
        else
        {
            this.Exams = new List<Exam>();
        }
    }

    public string FirstName
    {
        get { return this.firstName; }
        private set
        {
            if (value == null)
            {
                throw new ArgumentNullException("Invalid first name!");
            }
            this.firstName = value;
        }
    }

    public string LastName
    {
        get { return this.lastName; }
        set
        {
            if (value == null)
            {
                throw new ArgumentNullException("Invalid last name!");
            }
            this.lastName = value;
        }
    }

    public IList<Exam> Exams
    {
        get { return this.exams; }
        set
        {
            if (value == null)
            {
                throw new ArgumentNullException("exams", "Exams cannot be null.");
            }
            this.exams = value;
        }
    }

    private IList<ExamResult> CheckExams()
    {
        IList<ExamResult> results = new List<ExamResult>();
        for (int i = 0; i < this.Exams.Count; i++)
        {
            results.Add(this.Exams[i].Check());
        }

        return results;
    }

    public double CalcAverageExamResultInPercents()
    {
        if (this.Exams.Count == 0)
        {
            throw new ArgumentException("The student has no exams.");
        }

        double[] examScore = new double[this.Exams.Count];
        IList<ExamResult> examResults = this.CheckExams();
        for (int i = 0; i < examResults.Count; i++)
        {
            examScore[i] =
                ((double)examResults[i].Grade - examResults[i].MinGrade) /
                (examResults[i].MaxGrade - examResults[i].MinGrade);
        }

        return examScore.Average();
    }
}
