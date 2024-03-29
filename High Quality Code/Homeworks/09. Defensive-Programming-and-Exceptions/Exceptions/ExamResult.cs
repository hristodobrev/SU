﻿using System;

public class ExamResult
{
    private int grade;
    private int minGrade;
    private int maxGrade;
    private string comments;

    public ExamResult(int grade, int minGrade, int maxGrade, string comments)
    {
        this.Grade = grade;
        this.MinGrade = minGrade;
        this.MaxGrade = maxGrade;
        this.Comments = comments;
    }

    public int Grade
    {
        get { return this.grade; }
        private set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException("grade", "Grade cannot be negative number.");
            }
            this.grade = value;
        }
    }

    public int MinGrade
    {
        get { return this.minGrade; }
        private set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException("minGrade", "MinGrade cannot be negative number.");
            }
            this.minGrade = value;
        }
    }

    public int MaxGrade
    {
        get { return this.maxGrade; }
        private set
        {
            if (value <= this.MinGrade)
            {
                throw new ArgumentOutOfRangeException("maxGrade", "MaxGrade cannot be smaller than or equal to MinGrade.");
            }
            this.maxGrade = value;
        }
    }

    public string Comments
    {
        get { return this.comments; }
        private set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("comments", "Comments cannot be null ot empty.");
            }
            this.comments = value;
        }
    }
}
