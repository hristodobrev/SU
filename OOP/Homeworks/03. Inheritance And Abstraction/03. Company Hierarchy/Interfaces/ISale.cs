using System;

namespace _03.Company_Hierarchy.Interfaces
{
    interface ISale
    {
        string ProductName { get; set; }

        DateTime Date { get; set; }

        decimal Price { get; set; }
    }
}
