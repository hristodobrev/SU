using System;

namespace _03.Company_Hierarchy.Interfaces
{
    using Persons;
using System.Collections.Generic;
    interface IManager
    {
        List<Employee> Employees { get; set; }
    }
}
