namespace _15.SOLID_Principles.Interfaces
{
    using System;

    using Enumerations;

    public interface ILayout
    {
        string Format(DateTime date, ReportLevel reportLevel, string message);
    }
}
