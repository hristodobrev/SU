namespace Brick_Bracker
{
    using Core;

    using UI;

    class Program
    {
        static void Main()
        {
            var renderer = new ConsoleRenderer();
            Engine engine = new Engine(renderer, 60, 20);
            engine.Run();
        }
    }
}
