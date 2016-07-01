namespace Brick_Bracker.Core
{
    using System;
    using System.Collections.Generic;
    using System.Threading;

    using Interfaces;

    using Models;

    public class Engine
    {
        private List<IRenderable> gameObjects;

        public Engine(IRenderer renderer, int screenWidth, int screenHeight)
        {
            this.Renderer = renderer;
            this.ScreenWidth = screenWidth;
            this.ScreenHeight = screenHeight;
            this.Initialize();
        }

        private IRenderer Renderer { get; set; }

        private int ScreenWidth { get; set; }

        private int ScreenHeight { get; set; }

        private int GameSpeed { get; set; }

        private Player Player { get; set; }

        private Ball Ball { get; set; }

        public void Run()
        {
            while (true)
            {
                this.CheckPlayerMove();
                if (this.Ball.X == this.ScreenHeight - 1)
                {
                    this.CheckBallCollision();
                }
                this.Ball.Update();
                this.RenderScreen();
                Thread.Sleep(this.GameSpeed);
            }
        }

        private void Initialize()
        {
            Console.WindowWidth = this.ScreenWidth;
            Console.WindowHeight = this.ScreenHeight;
            Console.BufferHeight = Console.WindowHeight;
            Console.BufferWidth = Console.WindowWidth;
            this.gameObjects = new List<IRenderable>();
            this.GameSpeed = 50;
            this.Player = new Player(Console.BufferWidth / 2, Console.WindowHeight - 1, '=');
            this.Ball = new Ball(Console.BufferWidth / 2, Console.WindowHeight - 2, '☺');
            this.gameObjects.Add(this.Player);
            this.gameObjects.Add(this.Ball);
        }

        private void CheckBallCollision()
        {
            
        }

        private void CheckPlayerMove()
        {
            if (Console.KeyAvailable)
            {
                Direction playerDirection = new Direction(0, 0);

                var keyPressed = Console.ReadKey();
                if (keyPressed.Key == ConsoleKey.LeftArrow)
                {
                    playerDirection.X -= 5;
                }
                if (keyPressed.Key == ConsoleKey.RightArrow)
                {
                    playerDirection.X += 5;
                }

                if (this.AviablePlayerMove(playerDirection))
                {
                    this.Player.Move(playerDirection);
                }
            }
        }

        private bool AviablePlayerMove(Direction playerDirection)
        {
            var newPlayerPosition = this.Player.X + playerDirection.X;
            if (newPlayerPosition >= 0 && newPlayerPosition + this.Player.Width < this.ScreenWidth)
            {
                return true;
            }

            if (this.Player.X + this.Player.Width < this.ScreenWidth && this.Player.X > this.ScreenWidth - this.Player.X)
            {
                playerDirection.X = this.ScreenWidth - this.Player.X - this.Player.Width - 1;

                return true;
            }

            if (this.Player.X > 0)
            {
                playerDirection.X = -this.Player.X;

                return true;
            }

            return false;
        }

        private void RenderScreen()
        {
            Console.Clear();

            foreach (var renderable in this.gameObjects)
            {
                this.Renderer.Render(renderable);
            }
        }
    }
}
