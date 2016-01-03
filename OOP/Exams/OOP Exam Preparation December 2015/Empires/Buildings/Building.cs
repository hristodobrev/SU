namespace Empires.Buildings
{
    using System;
    using Interfaces;
    using Empires.Units;
    using Empires.Resources;

    public abstract class Building : IBuilding
    {
        private int turns;

        protected Building()
        {
            this.turns = -1;
        }

        public int Turns
        {
            get
            {
                return this.turns;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("turns",
                        "Turns cannot be negative");
                }
                this.turns = value;
            }
        }

        public abstract Unit ProduceUnit();
               
        public abstract Resource ProduceResource();

        public abstract bool TryProduceUnit();

        public abstract bool TryProduceResource();
    }
}
