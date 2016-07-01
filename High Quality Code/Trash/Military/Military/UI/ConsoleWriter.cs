namespace Military.UI
{
    using System;

    using Interfaces;
    public class ConsoleWriter : IWriter
    {
        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }

        public void Write(string message)
        {
            Console.Write(message);
        }

        public void WriteLine(string message, object[] args)
        {
            Console.WriteLine(message, args);
        }

        public void Write(string message, object[] args)
        {
            Console.Write(message, args);
        }
    }
}
