namespace Military.Models.Battle_Units
{
    using System;
    using System.Text;

    using Eqiupments;

    using Interfaces;
    public abstract class BattleUnit : IBattleUnit
    {
        protected BattleUnit(string name, int health)
        {
            this.Name = name;
            this.Health = health;
            this.IsAlive = true;
        }

        public string Name { get; protected set; }

        public int Health { get; protected set; }

        public bool IsAlive { get; protected set; }

        public abstract void Equip(Equipment equipment);

        public abstract int ResponseAttack(int damage);

        public override string ToString()
        {
            StringBuilder info = new StringBuilder();

            info.AppendFormat("{0} {1}:{2}", this.Name, this.IsAlive ? this.Health + "HP" : "Dead", Environment.NewLine);

            return info.ToString();
        }
    }
}
