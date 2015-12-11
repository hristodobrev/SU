namespace Workshop.Appenders
{
    using System;
    using Interfaces;

    public class ConsoleAppender : IAppender
    {
        public ConsoleAppender(ILayout layout)
        {
            this.Layout = layout;
        }

        public ILayout Layout { get; private set; }

        public void Append(string msg, ReportLevel level)
        {
            string output = Layout.Layout(msg, level);
            Console.WriteLine(output);
        }
    }
}
