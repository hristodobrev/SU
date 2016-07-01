namespace Brick_Bracker.Models
{
    using System;

    using Interfaces;
    public class Ball : IRenderable, IMovable
    {
        private const int BallWidth = 1;
        private const int BallHeight = 1;

        public Ball(int x, int y, char texture)
        {
            this.X = x;
            this.Y = y;
            this.Width = BallWidth;
            this.Height = BallHeight;
            this.Texture = texture;
            this.Direction = new Direction(1, -1);
        }

        public int X { get; private set; }
        
        public int Y { get; private set; }

        public int Width { get; private set; }

        public int Height { get; private set; }

        public char Texture { get; private set; }

        public Direction Direction { get; private set; }

        public void Update()
        {
            if (this.X + this.Direction.X >= Console.WindowWidth)
            {
                this.Direction.X = -1;
            }
            if (this.X + this.Direction.X < 0)
            {
                this.Direction.X = 1;
            }
            if (this.Y + this.Direction.Y >= Console.WindowHeight)
            {
                this.Direction.Y = -1;
            }
            if (this.Y + this.Direction.Y < 0)
            {
                this.Direction.Y = 1;
            }

            this.Move(this.Direction);
        }

        public void Move(Direction direction)
        {
            this.X += direction.X;
            this.Y += direction.Y;
        }
    }
}
