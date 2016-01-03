namespace EnvironmentSystem.Models.Objects
{
    using System.Collections.Generic;

    public class UnstableStar : FallingStar
    {
        private int lifetime;

        public UnstableStar(int x, int y, int width, int height, Point direction, int lifetime = 8)
            : base(x, y, width, height, direction)
        {
            this.lifetime = lifetime;
            this.CollisionGroup = CollisionGroup.Explosion;
        }

        public override void Update()
        {
            base.Update();
            this.lifetime--;
            if (this.lifetime <= 0)
            {
                this.Exists = false;
            }
        }

        public override IEnumerable<EnvironmentObject> ProduceObjects()
        {
            if (this.Exists)
            {
                return base.ProduceObjects();
            }

            List<EnvironmentObject> producedObjects = new List<EnvironmentObject>();

            if (!this.Exists)
            {
                for (int x = this.Bounds.TopLeft.X - 2; x <= this.Bounds.TopLeft.X + this.Bounds.Width + 1; x++)
                {
                    for (int y = this.Bounds.TopLeft.Y - 2; y <= this.Bounds.TopLeft.Y + this.Bounds.Height + 1; y++)
                    {
                        if (!(x == this.Bounds.TopLeft.X && y == this.Bounds.TopLeft.Y))
                        {
                            producedObjects.Add(new Explosion(x, y));
                        }
                    }
                }
            }

            return producedObjects;
        }
    }
}
