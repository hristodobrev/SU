namespace Empires.Buildings
{
    using System;
    using Empires.Resources;
    using Empires.Units;
    using Empires.Enums;

    public class Barracks : Building
    {
        private const int ResourceTurns = 3;
        private const int UnitTurns = 4;
        private const int ResourceQuantity = 10;

        public Barracks()
        {

        }

        public override Unit ProduceUnit()
        {
            if (this.Turns % UnitTurns == 0)
            {
                return new Swordsman();
            }
            else
            {
                throw new ArgumentOutOfRangeException("Not enough turns to produce a unit");
            }
        }

        public override Resource ProduceResource()
        {
            if (this.Turns % ResourceTurns == 0)
            {
                Resource producedResource = new Resource(ResourceType.Steel);
                producedResource.Quantity = ResourceQuantity;
                return producedResource;
            }
            else
            {
                throw new ArgumentOutOfRangeException("Not enough turns to produce a resource");
            }
        }

        public override bool TryProduceUnit()
        {
            return this.Turns % UnitTurns == 0 && this.Turns != 0 ? true : false;
        }

        public override bool TryProduceResource()
        {
            return this.Turns % ResourceTurns == 0 && this.Turns != 0 ? true : false;
        }

        public override string ToString()
        {
            return string.Format("--Barracks: {0} turns ({1} turns until Swordsman, {2} turns until Steel)",
                this.Turns,
                this.Turns % UnitTurns == 0 ? UnitTurns : UnitTurns - this.Turns % UnitTurns,
                this.Turns % ResourceTurns == 0 ? ResourceTurns : ResourceTurns - this.Turns % ResourceTurns);
        }
    }
}
