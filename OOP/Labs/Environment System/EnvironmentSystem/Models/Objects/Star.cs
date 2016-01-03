namespace EnvironmentSystem.Models.Objects
{
    using System;
    using System.Collections.Generic;

    public class Star : EnvironmentObject
    {
        private const int ImageChangeFrequency = 10;

        private static readonly char[] StarImages = new char[] { 'O', '@', '0' };
        private static readonly Random RandomImageIndex = new Random();

        private int currentState = 0;

        public Star(int x, int y, int width, int height)
            : base(x, y, width, height)
        {
            this.ImageProfile = new char[,] { { StarImages[0] } };
        }

        public override void Update()
        {
            if (currentState % ImageChangeFrequency == 0)
            {
                int index = RandomImageIndex.Next(0, StarImages.Length);
                this.ImageProfile = new char[,] { { StarImages[index] } };
            }

            this.currentState++;
        }

        public override void RespondToCollision(CollisionInfo collisionInfo)
        {
            if (collisionInfo.HitObject.CollisionGroup == CollisionGroup.Explosion)
            {
                this.Exists = false;
            }
        }

        public override IEnumerable<EnvironmentObject> ProduceObjects()
        {
            return new EnvironmentObject[0];
        }
    }
}
