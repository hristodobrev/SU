namespace _15.SOLID_Principles.Layouts
{
    using System;

    using Enumerations;

    using Interfaces;

    public class SimpleLayout : ILayout
    {
        public string Format(DateTime date, ReportLevel reportLevel, string message)
        {
            string formattedMessage = date + " - " + reportLevel + " - " + message;

            return formattedMessage;
        }
    }
}
