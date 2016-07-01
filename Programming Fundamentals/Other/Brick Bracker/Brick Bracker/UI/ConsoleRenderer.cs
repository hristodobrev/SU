namespace Brick_Bracker.UI
{
    using System;

    using Interfaces;

    public class ConsoleRenderer : IRenderer
    {
        public void Render(IRenderable model)
        {
            Console.SetCursorPosition(model.X, model.Y);
            Console.Write(new string(model.Texture, model.Width));
        }
    }
}
