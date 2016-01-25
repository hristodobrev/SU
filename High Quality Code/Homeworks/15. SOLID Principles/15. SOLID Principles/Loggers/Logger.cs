namespace _15.SOLID_Principles.Loggers
{
    using System.Collections.Generic;

    using Enumerations;

    using Interfaces;

    public class Logger : ILogger
    {
        public Logger(params IAppender[] appenders)
        {
            Appenders = appenders;
        }

        public IEnumerable<IAppender> Appenders { get; private set; }

        public void Info(string message)
        {
            foreach (var appender in this.Appenders)
            {
                appender.Append(message, ReportLevel.Info);
            }
        }

        public void Warn(string message)
        {
            foreach (var appender in this.Appenders)
            {
                appender.Append(message, ReportLevel.Warn);
            }
        }

        public void Error(string message)
        {
            foreach (var appender in this.Appenders)
            {
                appender.Append(message, ReportLevel.Error);
            }
        }

        public void Critical(string message)
        {
            foreach (var appender in this.Appenders)
            {
                appender.Append(message, ReportLevel.Critical);
            }
        }

        public void Fatal(string message)
        {
            foreach (var appender in this.Appenders)
            {
                appender.Append(message, ReportLevel.Fatal);
            }
        }
    }
}
