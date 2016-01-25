using System.Windows.Controls;
using Game.Contracts;

namespace Game.UI
{
    public class Renderer : IRenderer
    {
        public Renderer(Canvas canvas)
        {
            this.Canvas = canvas;
        }

        public Canvas Canvas { get; private set; }

        public void Render(IRenderable model)
        {
            Canvas.SetTop(model.Image, model.X);
            Canvas.SetLeft(model.Image, model.Y);
            this.Canvas.Children.Add(model.Image);
        }
    }
}
