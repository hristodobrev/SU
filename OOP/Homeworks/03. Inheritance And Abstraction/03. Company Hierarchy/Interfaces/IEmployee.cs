using System;

namespace _03.Company_Hierarchy.Interfaces
{
    using Enumerations;

    interface IEmployee
    {
        decimal Salary { get; set; }
        
        Department Department { get; set; }
    }
}
