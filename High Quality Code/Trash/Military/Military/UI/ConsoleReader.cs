namespace Military.UI
{
    using System;

    using Interfaces;

    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            string message = Console.ReadLine();

            return message;
        }
    }
}
