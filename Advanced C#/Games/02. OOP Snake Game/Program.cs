namespace _02.OOP_Snake_Game
{
    using Interfaces;

    class Program
    {
        static void Main(string[] args)
        {
            IRenderer consoleRenderer = new ConsoleRenderer();
            Engine engine = new Engine(consoleRenderer);
            engine.Run();
        }
    }
}
