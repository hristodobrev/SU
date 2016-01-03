namespace Empires.UI
{
    using Empires.UI.Interfaces;
    using System;

    public class ConsoleWritter : IWritter
    {
        public void Write(string message)
        {
            Console.WriteLine(message);
        }
    }
}
