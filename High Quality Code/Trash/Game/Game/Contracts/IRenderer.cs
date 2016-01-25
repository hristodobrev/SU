using System.Windows.Controls;

namespace Game.Contracts
{
    public interface IRenderer
    {
        Canvas Canvas { get; }

        void Render(IRenderable model);
    }
}
