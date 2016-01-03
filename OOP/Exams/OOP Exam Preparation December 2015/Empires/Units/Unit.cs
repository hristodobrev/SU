namespace Empires.Units
{
    using System;

    public abstract class Unit
    {
        private int health;
        private int attackDamage;

        protected Unit(int health, int attackDamage)
        {
            this.Health = health;
            this.AttackDamage = attackDamage;
        }

        public int Health
        {
            get
            {
                return this.health;
            }
            protected set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("health",
                        "Health cannot be negative number or zero");
                }
                this.health = value;
            }
        }

        public int AttackDamage
        {
            get
            {
                return this.attackDamage;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("attack damage",
                        "Attack damage cannot be negative number or zero");
                }
                this.attackDamage = value;
            }
        }
    }
}
