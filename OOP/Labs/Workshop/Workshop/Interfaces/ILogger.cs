namespace Workshop.Interfaces
{
    public interface ILogger
    {
        IAppender Appender { get; }

        void Info(string msg);

        void Warning(string msg);

        void Error(string msg);

        void CriticalError(string msg);

        void FatalError(string msg);
    }
}
