namespace MassEffect.GameObjects.Ships
{
    using GameObjects.Locations;
    using GameObjects.Projectiles;
    using Interfaces;

    public class Cruiser : StarShip
    {
        public Cruiser(string name, StarSystem location)
            : base(name, 100, 100, 50, 300, location)
        {

        }

        public override IProjectile ProduceAttack()
        {
            return new PenetrationShell(this.Damage);
        }
    }
}
