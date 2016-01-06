namespace December_2015_Exam.UI
{
    using System;

    using December_2015_Exam.Interfaces;

    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            string message = Console.ReadLine();

            return message;
        }
    }
}
