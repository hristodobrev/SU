namespace _02.OOP_Snake_Game
{
    using System;

    using Interfaces;

    public class ConsoleRenderer : IRenderer
    {
        public void Render(int x, int y, char symbol)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(symbol);
            //Console.SetCursorPosition(0, 0);
        }
    }
}
