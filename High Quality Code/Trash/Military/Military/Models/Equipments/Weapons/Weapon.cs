namespace Military.Models.Equipments.Weapons
{
    using System;
    using System.Text;

    using Eqiupments;

    using Interfaces;

    public class Weapon : Equipment
    {
        private int damage;

        public Weapon(string name, int damage, IBattleUnit carrier)
            : base(name, carrier)
        {
            this.Damage = damage;
        }

        public int Damage
        {
            get
            {
                return this.damage;
            }

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Damage of the weapon cannot be negative or zero.");
                }

                this.damage = value;
            }
        }

        public override string ToString()
        {
            StringBuilder info = new StringBuilder();
            info.AppendFormat("Weapon {0}: {1}DMG [{2}]{3}", this.Name, this.Damage, this.Carrier == null ? "Unequiped" : this.Carrier.Name, Environment.NewLine);
            
            return info.ToString();
        }
    }
}
