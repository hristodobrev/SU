﻿namespace MassEffect.GameObjects.Ships
{
    using System.Text;
    using Interfaces;
    using GameObjects.Projectiles;
    using GameObjects.Locations;

    public class Frigate : StarShip
    {
        private int projectilesFired;

        public Frigate(string name, StarSystem location)
            : base(name, 60, 50, 30, 220, location)
        {

        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder(base.ToString());

            if (this.Health > 0)
            {
                output.AppendLine(string.Format("-Projectiles fired: {0}", this.projectilesFired));
            }

            return output.ToString();
        }

        public override IProjectile ProduceAttack()
        {
            this.projectilesFired++;
            return new ShiedReaver(this.Damage);
        }
    }
}