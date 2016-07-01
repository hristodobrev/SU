namespace Brick_Bracker.Models
{
    using Interfaces;
    public class Player : IMovable, IRenderable
    {
        private const int PlayerWidth = 15;
        private const int PlayerHeight = 1;

        public Player(int x, int y, char texture)
        {
            this.X = x;
            this.Y = y;
            this.Width = PlayerWidth;
            this.Height = PlayerHeight;
            this.Texture = texture;
        }

        public int X { get; private set; }

        public int Y { get; private set; }

        public int Width { get; private set; }

        public int Height { get; private set; }

        public char Texture { get; private set; }

        public void Move(Direction direction)
        {
            this.X += direction.X;
        }
    }
}
