namespace Empires.UI
{
    using Empires.UI.Interfaces;
    using System;

    public class ConsoleReader : IReader
    {
        public string Read()
        {
            return Console.ReadLine();
        }
    }
}
