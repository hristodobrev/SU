namespace Military.Models.Equipments.Shileds
{
    using System;
    using System.Text;

    using Eqiupments;

    using Interfaces;

    public class Shield : Equipment
    {
        private int armor;

        public Shield(string name, int armor, IBattleUnit carrier)
            : base(name, carrier)
        {
            this.Armor = armor;
        }

        public int Armor
        {
            get
            {
                return this.armor;
            }

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Armor of the shield cannot be negative or zero.");
                }

                this.armor = value;
            }
        }

        public override string ToString()
        {
            StringBuilder info = new StringBuilder();
            info.AppendFormat("Shield {0}: {1}ARM [{2}]{3}", this.Name, this.Armor, this.Carrier == null ? "Unequiped" : this.Carrier.Name, Environment.NewLine);

            return info.ToString();
        }
    }
}
