using System;

namespace _03.Company_Hierarchy.Interfaces
{
    using Enumerations;
    interface IProject
    {
        string Name { get; set; }
        
        DateTime StartDate { get; set; }
        
        string Details { get; set; }
        
        State State { get; set; }

        void CloseProject();
    }
}
