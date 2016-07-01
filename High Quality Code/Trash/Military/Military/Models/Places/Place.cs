namespace Military.Models.Places
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Exceptions;

    using Interfaces;

    public class Place : IPlace
    {
        private string name;
        private int capacity;
        private List<IBattleUnit> units;

        public Place(string name, int capacity, PlaceType type)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.Type = type;
            this.units = new List<IBattleUnit>(capacity);
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Name of the place cannot be null or empty.");
                }

                this.name = value;
            }
        }

        public int Capacity
        {
            get
            {
                return this.capacity;
            }

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Capacity of the place cannot be negative or zero.");
                }

                this.capacity = value;
            }
        }

        public PlaceType Type { get; private set; }

        public IEnumerable<IBattleUnit> Units
        {
            get
            {
                return this.units;
            }
        }

        public IBattleUnit GetUnitByName(string name)
        {
            IBattleUnit unit = this.units.FirstOrDefault(u => u.Name.Equals(name));
            if (unit == null)
            {
                throw new ArgumentNullException(string.Format("There is no {0} at {1}", name, this.Name));
            }

            return unit;
        }

        public void Enter(IBattleUnit unit)
        {
            if (unit == null)
            {
                throw new ArgumentNullException("Unit should not be null.");
            }

            this.units.Add(unit);
        }

        public void Exit(IBattleUnit unit)
        {
            if(!this.units.Contains(unit))
            {
                throw new NotExistingElementException("There is no such unit in this place.");
            }

            this.units.Remove(unit);
        }

        public override string ToString()
        {
            StringBuilder info = new StringBuilder();
            info.AppendFormat("Place {0}:{1}", this.Name, Environment.NewLine);
            info.AppendFormat("Capacity: {0}/{1}{2}", this.Units.Count(), this.Capacity, Environment.NewLine);
            foreach (IBattleUnit battleUnit in this.Units)
            {
                info.AppendFormat(battleUnit.ToString());
            }

            return info.ToString();
        }
    }
}
