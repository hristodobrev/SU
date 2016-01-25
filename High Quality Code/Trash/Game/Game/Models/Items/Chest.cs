using System;
using System.Windows.Controls;
using Game.Contracts;

namespace Game.Models.Items
{
    public class Chest : IRenderable
    {
        private int amount;

        public Chest(int amount, int x, int y)
        {
            this.Amount = amount;
            this.X = x;
            this.Y = y;
            this.Opened = false;
        }

        public int Amount
        {
            get { return this.amount; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Amount cannot be negative or zero.");
                }
                this.amount = value;
            }
        }

        public bool Opened { get; set; }

        public int X { get; private set; }

        public int Y { get; private set; }

        public Image Image { get; set; }
    }
}
