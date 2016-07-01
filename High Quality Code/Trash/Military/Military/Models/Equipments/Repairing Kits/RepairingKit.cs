namespace Military.Models.Eqiupments.Repairing_Kits
{
    using System;
    using System.Text;

    using Interfaces;

    public class RepairingKit : Equipment
    {
        private int healingPoints;

        public RepairingKit(string name, int healingPoints, IBattleUnit carrier)
            : base(name, carrier)
        {
            this.HealingPoints = healingPoints;
        }

        public int HealingPoints
        {
            get
            {
                return this.healingPoints;
            }

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Healing points cannot be negative or zero.");
                }

                this.healingPoints = value;
            }
        }
        
        public override string ToString()
        {
            StringBuilder info = new StringBuilder();
            info.AppendFormat("Repairing Kit {0}: {1}HP [{2}]{3}", this.Name, this.HealingPoints, this.Carrier == null ? "Unequiped" : this.Carrier.Name, Environment.NewLine);

            return info.ToString();
        }
    }
}
