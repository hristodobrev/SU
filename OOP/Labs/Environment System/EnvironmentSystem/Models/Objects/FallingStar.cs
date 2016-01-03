namespace EnvironmentSystem.Models.Objects
{
    using System;
    using System.Collections.Generic;

    public class FallingStar : MovingObject
    {
        public FallingStar(int x, int y, int width, int height, Point direction)
            : base(x, y, width, height, direction)
        {
            this.ImageProfile = new char[,] { { 'O' } };
        }

        public override void RespondToCollision(CollisionInfo collisionInfo)
        {
            var hitObjectGroup = collisionInfo.HitObject.CollisionGroup;
            if (hitObjectGroup == CollisionGroup.Ground || hitObjectGroup == CollisionGroup.Explosion)
            {
                this.Exists = false;
            }
        }

        public override IEnumerable<EnvironmentObject> ProduceObjects()
        {
            var producedObjects = new List<EnvironmentObject>();

            if (this.Exists)
            {
                producedObjects.Add(new Trail(this.Bounds.TopLeft.X - this.Direction.X, this.Bounds.TopLeft.Y - this.Direction.Y));
                producedObjects.Add(new Trail(producedObjects[0].Bounds.TopLeft.X - this.Direction.X, producedObjects[0].Bounds.TopLeft.Y - this.Direction.Y));
                producedObjects.Add(new Trail(producedObjects[1].Bounds.TopLeft.X - this.Direction.X, producedObjects[1].Bounds.TopLeft.Y - this.Direction.Y));
            }

            return producedObjects;
        }
    }
}
