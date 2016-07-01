namespace _02.OOP_Snake_Game
{
    using System;
    using System.Threading;

    using Interfaces;

    public class Engine
    {
        public Engine(IRenderer renderer)
        {
            this.Renderer = renderer;
        }

        public void Run()
        {
            var snake = new Snake();
            var previousDirection = new Position(1, 0);

            while (!snake.IsDead)
            {
                Position direction = this.GetDirection(previousDirection);
                previousDirection = direction;
                snake.Clear(this.Renderer);
                snake.Move(direction);
                snake.Render(this.Renderer);
                Thread.Sleep(100);
            }
        }

        private IRenderer Renderer { get; set; }

        private Position GetDirection(Position previousDirection)
        {
            var right = new Position(1, 0);
            var down = new Position(0, 1);
            var left = new Position(-1, 0);
            var up = new Position(0, -1);
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo key = Console.ReadKey();
                if (key.Key == ConsoleKey.LeftArrow)
                {
                    if (!previousDirection.CompareTo(right))
                    {
                        return left;
                    }
                }
                if (key.Key == ConsoleKey.UpArrow)
                {
                    if (!previousDirection.CompareTo(down))
                    {
                        return up;
                    }
                }
                if (key.Key == ConsoleKey.RightArrow)
                {
                    if (!previousDirection.CompareTo(left))
                    {
                        return right;
                    }
                }
                if (key.Key == ConsoleKey.DownArrow)
                {
                    if (!previousDirection.CompareTo(up))
                    {
                        return down;
                    }
                }
            }

            return previousDirection;
        }
    }
}
