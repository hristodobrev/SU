namespace TheSlum.GameObjects.Characters
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Interfaces;

    public class Healer : Character, IHeal
    {
        public Healer(string id, int x, int y, Team team)
            : base(id, x, y, 75, 50, team, 6)
        {
            this.HealingPoints = 60;
        }

        public int HealingPoints { get; set; }

        public override Character GetTarget(System.Collections.Generic.IEnumerable<Character> targetsList)
        {
            var targetsFromAlianceTeam = targetsList
                .Where(t => t.Team == this.Team);

            if (targetsFromAlianceTeam.Count() == 0)
            {
                return null;
            }

            int minHp = int.MaxValue;

            foreach (var aliance in targetsFromAlianceTeam)
            {
                if (aliance.HealthPoints < minHp && aliance != this)
                {
                    minHp = aliance.HealthPoints;
                }
            }

            return targetsFromAlianceTeam.FirstOrDefault(t => t.HealthPoints == minHp);
        }

        public override void RemoveFromInventory(Item item)
        {
            if (this.Inventory.Contains(item))
            {
                this.Inventory.Remove(item);
            }
        }

        public override void AddToInventory(Item item)
        {
            this.Inventory.Add(item);
        }

        protected override void ApplyItemEffects(Item item)
        {
            this.ApplyItemEffects(item);
        }

        protected override void RemoveItemEffects(Item item)
        {
            this.RemoveItemEffects(item);
        }
    }
}
