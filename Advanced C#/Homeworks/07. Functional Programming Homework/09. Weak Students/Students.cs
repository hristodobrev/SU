﻿using System;
using System.Collections.Generic;
using System.Linq;

public class Students
{
    public Students(string firstName, string lastName, int age, int facultyNumber, string phone, string email, IList<int> marks, int groupNumber)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Age = age;
        this.FacultyNumber = facultyNumber;
        this.Phone = phone;
        this.Email = email;
        this.Marks = marks;
        this.GroupNumber = groupNumber;
    }

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    public int FacultyNumber { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public IList<int> Marks { get; set; }
    public int GroupNumber { get; set; }
}