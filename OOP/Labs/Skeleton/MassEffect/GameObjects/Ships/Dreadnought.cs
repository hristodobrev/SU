namespace MassEffect.GameObjects.Ships
{
    using GameObjects.Locations;
    using GameObjects.Projectiles;
    using Interfaces;

    public class Dreadnought : StarShip
    {
        public Dreadnought(string name, StarSystem location)
            : base(name, 200, 300, 150, 700, location)
        {

        }

        public override IProjectile ProduceAttack()
        {
            return new Laser((this.Shields / 2) + this.Damage);
        }

        public override void RespondToAttack(IProjectile attack)
        {
            this.Shields += 50;

            base.RespondToAttack(attack);

            this.Shields -= 50;
        }
    }
}
