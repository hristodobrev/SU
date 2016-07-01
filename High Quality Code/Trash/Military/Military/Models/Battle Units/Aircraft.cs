namespace Military.Models.Battle_Units
{
    using System;
    using System.Text;

    using Eqiupments;

    using Equipments.Shileds;
    using Equipments.Weapons;

    using Exceptions;

    using Fighting_Utilities;

    using Interfaces;

    using Weapons;

    public class Aircraft : BattleUnit, IFightingUnit
    {
        public Aircraft(string name, int health)
            : base(name, health)
        {
        }

        public Weapon Weapon { get; private set; }

        public Shield Shield { get; private set; }

        public override void Equip(Equipment equipment)
        {
            if (equipment is Shield)
            {
                if (this.Shield != null)
                {
                    this.Shield.Carrier = null;
                }

                this.Shield = (Shield) equipment;
            }
            else if (equipment is Weapon)
            {
                if (this.Weapon != null)
                {
                    this.Weapon.Carrier = null;
                }

                this.Weapon = (Weapon) equipment;
            }
            else
            {
                throw new InconsistentEquipmentException("This unit does not support this type of equipment.");
            }

            equipment.Carrier = this;
        }

        public FightInfo Attack(IBattleUnit target)
        {
            if (this.Weapon == null)
            {
                throw new NotExistingElementException("The attacking unit has no weapon.");
            }
            if (!target.IsAlive)
            {
                throw new ArgumentException("Cannot attack destroyed units.");
            }

            int initialDamage = this.Weapon.Damage;
            int reducedDamage = target.ResponseAttack(initialDamage);

            FightInfo fightInfo = new FightInfo(this, target, initialDamage, reducedDamage);

            return fightInfo;
        }

        public override int ResponseAttack(int damage)
        {
            int armor = 0;
            if (this.Shield != null)
            {
                armor = this.Shield.Armor;
            }

            damage = Math.Max(0, damage - armor);

            this.Health = Math.Max(0, this.Health - damage);

            if (this.Health == 0)
            {
                this.IsAlive = false;
            }

            return damage;
        }

        public override string ToString()
        {
            StringBuilder info = new StringBuilder();
            info.Append(base.ToString());
            info.AppendFormat("Weapon: {0}", this.Weapon != null ? this.Weapon.ToString() : "None");
            info.AppendFormat("Shield: {0}", this.Shield != null ? this.Shield.ToString() : "None");

            return info.ToString();
        }
    }
}
