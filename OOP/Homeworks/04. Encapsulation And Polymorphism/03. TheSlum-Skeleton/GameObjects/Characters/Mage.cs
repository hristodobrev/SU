namespace TheSlum.GameObjects.Characters
{
    using System;
    using System.Linq;
    using Interfaces;

    public class Mage : Character, IAttack
    {
        public Mage(string id, int x, int y, Team team)
            : base(id, x, y, 150, 50, team, 5)
        {
            this.AttackPoints = 300;
        }

        public int AttackPoints { get; set; }

        public override Character GetTarget(System.Collections.Generic.IEnumerable<Character> targetsList)
        {
            return targetsList
                .Where(t => t.Team != this.Team)
                .LastOrDefault();
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
