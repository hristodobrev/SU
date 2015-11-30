namespace TheSlum
{
    using System;
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
            var targetsHp = targetsList
                .Where(t => t.Team == this.Team && t != this && t.IsAlive)
                .Select(t => t.HealthPoints);

            return targetsList
                .FirstOrDefault(t => t.HealthPoints == targetsHp.Min());
        }

        public override void AddToInventory(Item item)
        {
            this.Inventory.Add(item);
            this.ApplyItemEffects(item);
        }

        public override void RemoveFromInventory(Item item)
        {
            if (this.Inventory.Contains(item))
            {
                this.Inventory.Remove(item);
                this.RemoveItemEffects(item);
            }
        }

        public override string ToString()
        {
            return base.ToString() + String.Format(", Healing: {0}", this.HealingPoints);
        }
    }
}
