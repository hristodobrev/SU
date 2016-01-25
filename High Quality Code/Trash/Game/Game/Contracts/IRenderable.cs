using System.Windows.Controls;

namespace Game.Contracts
{
    public interface IRenderable
    {
        int X { get; }

        int Y { get; }

        Image Image { get; }
    }
}
