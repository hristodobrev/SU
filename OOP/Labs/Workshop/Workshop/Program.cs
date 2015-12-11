namespace Workshop
{
    using Interfaces;
    using Workshop.Appenders;
    using Workshop.Layouts;
    using Workshop.Loggers;

    class Program
    {
        static void Main()
        {
            ILayout simpleLayout = new SimpleLayout();
            IAppender consoleAppender = new ConsoleAppender(simpleLayout);
            ILogger logger = new Logger(consoleAppender);

            logger.Error("Pesho does not consist.");
        }
    }
}
