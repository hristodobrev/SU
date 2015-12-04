namespace MassEffect.GameObjects.Ships
{
    using System;
    using System.Text;
    using System.Collections.Generic;
    using System.Linq;
    using GameObjects.Enhancements;
    using GameObjects.Locations;
    using Interfaces;

    public abstract class StarShip : IStarship
    {
        private IList<Enhancement> enhancements;

        protected StarShip(string name, int health, int shields, int damage, double fuel, StarSystem location)
        {
            this.enhancements = new List<Enhancement>();
            this.Name = name;
            this.Health = health;
            this.Shields = shields;
            this.Damage = damage;
            this.Fuel = fuel;
            this.Location = location;
        }

        public string Name { get; set; }

        public int Health { get; set; }

        public int Shields { get; set; }

        public int Damage { get; set; }

        public double Fuel { get; set; }

        public StarSystem Location { get; set; }

        public abstract IProjectile ProduceAttack();

        public virtual void RespondToAttack(IProjectile attack)
        {
            attack.Hit(this);
        }

        public IEnumerable<Enhancement> Enhancements
        {
            get { return this.enhancements; }
        }

        public void AddEnhancement(Enhancement enhancement)
        {
            if (enhancement == null)
            {
                throw new ArgumentNullException("Enhancement cannot be null");
            }

            this.enhancements.Add(enhancement);

            this.Damage += enhancement.DamageBonus;
            this.Shields += enhancement.ShieldBonus;
            this.Fuel += enhancement.FuelBonus;
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine(string.Format("--{0} - {1}", this.Name, this.GetType().Name));

            if (this.Health <= 0)
            {
                output.Append("(Destroyed)");
            }
            else
            {
                output.AppendLine(string.Format("-Location: {0}", this.Location.Name));
                output.AppendLine(string.Format("-Health: {0}", this.Health));
                output.AppendLine(string.Format("-Shields: {0}", this.Shields));
                output.AppendLine(string.Format("-Damage: {0}", this.Damage));
                output.AppendLine(string.Format("-Fuel: {0:F1}", this.Fuel));
                output.AppendLine(string.Format("-Enhancements: {0}", this.Enhancements.Any() ? string.Join(", ", this.Enhancements.Select(e => e.Name)) : "N/A"));
            }

            return output.ToString();
        }
    }
}
