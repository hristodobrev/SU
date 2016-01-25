namespace _15.SOLID_Principles.Interfaces
{
    using Enumerations;

    public interface IAppender
    {
        ILayout Layout { get; }

        ReportLevel ReportLevel { get; set; }

        void Append(string message, ReportLevel reportLevel);
    }
}