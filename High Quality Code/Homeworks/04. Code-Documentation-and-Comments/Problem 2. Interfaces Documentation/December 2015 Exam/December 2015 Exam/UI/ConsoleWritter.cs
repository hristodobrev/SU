namespace December_2015_Exam.UI
{
    using System;

    using December_2015_Exam.Interfaces;

    public class ConsoleWritter : IWritter
    {
        public void Write(string message)
        {
            Console.Write(message);
        }

        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }

        public void Write(string message, params string[] args)
        {
            Console.Write(message, args);
        }

        public void WriteLine(string message, params string[] args)
        {
            Console.WriteLine(message, args);
        }
    }
}
