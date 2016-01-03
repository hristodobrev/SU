namespace EnvironmentSystem.Core
{
    using EnvironmentSystem.Interfaces;
    using System;

    public class KeyboardController : IController
    {
        public event EventHandler Pause;

        public void ProcessInput()
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo keyPressed = Console.ReadKey();
                if (keyPressed.Key == ConsoleKey.Spacebar)
                {
                    if (this.Pause != null)
                    {
                        this.Pause(this, new EventArgs());
                    }
                }
            }
        }
    }
}
