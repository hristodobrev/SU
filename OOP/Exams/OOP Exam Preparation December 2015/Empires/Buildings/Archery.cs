namespace Empires.Buildings
{
    using System;
    using Empires.Resources;
    using Empires.Units;
    using Empires.Enums;

    public class Archery : Building
    {
        private const int ResourceTurns = 2;
        private const int UnitTurns = 3;
        private const int ResourceQuantity = 5;

        public Archery()
        {

        }

        public override Unit ProduceUnit()
        {
            if (this.Turns % UnitTurns == 0)
            {
                return new Archer();
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
                Resource producedResource = new Resource(ResourceType.Gold);
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
            return string.Format("--Archery: {0} turns ({1} turns until Archer, {2} turns until Gold)",
                this.Turns,
                this.Turns % UnitTurns == 0 ? UnitTurns : UnitTurns - this.Turns % UnitTurns,
                this.Turns % ResourceTurns == 0 ? ResourceTurns : ResourceTurns - this.Turns % ResourceTurns);
        }
    }
}