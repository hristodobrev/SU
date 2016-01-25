namespace _15.SOLID_Principles.Appenders
{
    using System;

    using Enumerations;

    using Interfaces;

    public class ConsoleAppender : IAppender
    {
        public ConsoleAppender(ILayout layout)
        {
            this.Layout = layout;
        }

        public ILayout Layout { get; private set; }

        public ReportLevel ReportLevel { get; set; }

        public void Append(string message, ReportLevel reportLevel)
        {
            if ((int) reportLevel >= (int) this.ReportLevel)
            {
                string formattedMessage = this.Layout.Format(DateTime.Now, reportLevel, message);
                Console.WriteLine(formattedMessage);
            }
        }
    }
}