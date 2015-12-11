namespace Workshop.Loggers
{
    using Interfaces;

    public class Logger : ILogger
    {
        public Logger(IAppender appender)
        {
            this.Appender = appender;
        }

        public IAppender Appender { get; private set; }

        public void Info(string msg)
        {
            this.Appender.Append(msg, ReportLevel.Info);
        }

        public void Warning(string msg)
        {
            this.Appender.Append(msg, ReportLevel.Warning);
        }

        public void Error(string msg)
        {
            this.Appender.Append(msg, ReportLevel.Error);
        }

        public void CriticalError(string msg)
        {
            this.Appender.Append(msg, ReportLevel.CriticalError);
        }

        public void FatalError(string msg)
        {
            this.Appender.Append(msg, ReportLevel.FatalError);
        }
    }
}
