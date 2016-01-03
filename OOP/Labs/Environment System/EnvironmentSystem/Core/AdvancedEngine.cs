namespace EnvironmentSystem.Core
{
    using EnvironmentSystem.Interfaces;
    using EnvironmentSystem.Models.DataStructures;
    using EnvironmentSystem.Models.Objects;
    using System;
    using System.Collections.Generic;
    using System.Threading;

    public class AdvancedEngine : Engine
    {
        protected readonly IController controller;

        private bool isPaused = false;

        public AdvancedEngine(int worldWidth,
            int worldHeight,
            IObjectGenerator<EnvironmentObject> objectGenerator,
            ICollisionHandler collisionHandler,
            IRenderer renderer,
            IController controller)
            : base(worldWidth, worldHeight, objectGenerator, collisionHandler, renderer)
        {
            this.controller = controller;
            this.AttachCotrollerEvents();
        }

        protected override void ExecuteEnvironmentLoop()
        {
            this.controller.ProcessInput();

            if (!this.isPaused)
            {
                base.ExecuteEnvironmentLoop();
            }
        }

        protected override void Insert(EnvironmentObject obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException("Object cannot be null.");
            }

            base.Insert(obj);
        }

        private void AttachCotrollerEvents()
        {
            this.controller.Pause += (sender, args) =>
                {
                    this.isPaused = !this.isPaused;
                };
        }
    }
}
