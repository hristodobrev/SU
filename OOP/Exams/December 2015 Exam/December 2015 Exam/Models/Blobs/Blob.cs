namespace December_2015_Exam.Models.Blobs
{
    using System;
    using System.Text;

    using December_2015_Exam.Interfaces;
    using December_2015_Exam.Models.BehaviorTypes;
    using December_2015_Exam.Delegates;

    public class Blob : IBlob
    {
        public event BlobDelegate HasDied;

        private int initialHealth;
        private int initialDamage;

        private string name;
        private int health;
        private int damage;
        private Behavior behaviorType;
        private IAttack attackType;
        private bool isAlive;

        public Blob(string name, int health, int damage, Behavior behaviorType, IAttack attackType)
        {
            this.Name = name;
            this.Health = health;
            this.Damage = damage;
            this.BehaviorType = behaviorType;
            this.AttackType = attackType;
            this.initialHealth = this.Health;
            this.initialDamage = this.Damage;
            this.IsAlive = true;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                if (string.IsNullOrEmpty(value.Trim()))
                {
                    throw new ArgumentNullException("Blob's name cannot be null or empty.");
                }
                this.name = value;
            }
        }

        public int Health
        {
            get
            {
                return this.health;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Blob's health cannot be negative.");
                }
                this.health = value;
            }
        }

        public int InitialHealth
        {
            get
            {
                return this.initialHealth;
            }
        }

        public int Damage
        {
            get
            {
                return this.damage;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Blob's damage cannot be negative.");
                }
                this.damage = value;
            }
        }

        public int InitialDamage
        {
            get
            {
                return this.initialDamage;
            }
        }

        public bool IsAlive
        {
            get
            {
                return this.isAlive;
            }

            private set
            {
                if (this.isAlive == true && value == false && this.HasDied != null)
                {
                    this.HasDied(this);
                }
                this.isAlive = value;
            }
        }

        public IAttack AttackType
        {
            get
            {
                return this.attackType;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Blob's attack type cannot be null.");
                }
                this.attackType = value;
            }
        }

        public Behavior BehaviorType
        {
            get
            {
                return this.behaviorType;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Blob's behavior type cannot be null.");
                }
                this.behaviorType = value;
            }
        }

        public void Update()
        {
            this.behaviorType.UpdateStats(this);
            if (this.Health == 0)
            {
                this.IsAlive = false;
            }
        }

        public void Attack(IBlob target)
        {
            if (!this.isAlive)
            {
                throw new ArgumentException("Dead blobs cannot attack.");
            }

            int currentHealth = this.Health;

            int damageToDeal = this.AttackType.ProduceAttack(this);

            target.ResponseAttack(damageToDeal);
        }

        public void ResponseAttack(int damage)
        {
            if (this.Health - damage < 0)
            {
                this.Health = 0;
            }
            else
            {
                this.Health -= damage;
            }

            this.BehaviorType.UpdateStats(this);

            if (this.Health <= 0)
            {
                this.IsAlive = false;
            }
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            if (this.isAlive)
            {
                output.AppendFormat("Blob {0}: {1} HP, {2} Damage{3}",
                    this.Name,
                    this.Health,
                    this.Damage,
                    Environment.NewLine);
            }
            else
            {
                output.AppendFormat("Blob {0} KILLED{1}", this.Name, Environment.NewLine);
            }

            return output.ToString();
        }
    }
}
