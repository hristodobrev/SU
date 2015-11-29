namespace TheSlum.GameObjects.Characters
{
    using System;
    using System.Linq;
    using Interfaces;

    public class Warrior : Character, IAttack
    {
        public Warrior(string id, int x, int y, Team team)
            : base(id, x, y, 200, 100, team, 2)
        {
            this.AttackPoints = 150;
        }

        public int AttackPoints { get; set; }

        public override Character GetTarget(System.Collections.Generic.IEnumerable<Character> targetsList)
        {
            return targetsList
                .Where(t => t.Team != this.Team)
                .FirstOrDefault();
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
