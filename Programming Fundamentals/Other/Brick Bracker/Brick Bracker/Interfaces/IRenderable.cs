namespace Brick_Bracker.Interfaces
{
    public interface IRenderable
    {
        int X { get; }

        int Y { get; }

        int Width { get; }

        int Height { get; }

        char Texture { get; }
    }
}