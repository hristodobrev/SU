namespace Military.Core.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Exceptions;

    using Interfaces;

    using Models.Eqiupments;

    public class Database : IDatabase
    {
        private List<IPlace> places;
        private List<IBattleUnit> battleUnits;
        private List<Equipment> equipments;

        public Database()
        {
            this.places = new List<IPlace>();
            this.battleUnits = new List<IBattleUnit>();
            this.equipments = new List<Equipment>();
        }

        public IEnumerable<IPlace> Places
        {
            get
            {
                return this.places;
            }
        } 

        public IEnumerable<IBattleUnit> BattleUnits
        {
            get
            {
                return this.battleUnits;
            }
        }

        public IEnumerable<Equipment> Equipments
        {
            get
            {
                return this.equipments;
            }
        }

        public IPlace GetPlaceByName(string name)
        {
            IPlace place = this.Places.FirstOrDefault(p => p.Name.Equals(name));

            return place;
        }

        public IBattleUnit GetBattleUnitByName(string name)
        {
            IBattleUnit unit = this.BattleUnits.FirstOrDefault(u => u.Name.Equals(name));

            return unit;
        }

        public Equipment GetEquipmentByName(string name)
        {
            Equipment equipment = this.Equipments.FirstOrDefault(e => e.Name.Equals(name));

            return equipment;
        }

        public object GetElementByName(string name)
        {
            object element = this.GetPlaceByName(name);
            if (element == null)
            {
                element = this.GetBattleUnitByName(name);
                if (element == null)
                {
                    element = this.GetEquipmentByName(name);
                }
            }

            return element;
        }

        public void AddPlace(IPlace place)
        {
            if (place == null)
            {
                throw new ArgumentNullException("The place connot be null.");
            }
            if (this.CheckExistingElement(place.Name))
            {
                throw new AlreadyExistingElementException("This name already exists.");
            }

            this.places.Add(place);
        }

        public void AddEquipment(Equipment equipment)
        {
            if (equipment == null)
            {
                throw new ArgumentNullException("The equipment connot be null.");
            }

            this.equipments.Add(equipment);
        }

        public void AddBattleUnit(IBattleUnit battleUnit)
        {
            if (battleUnit == null)
            {
                throw new ArgumentNullException("Battle unit cannot be null.");
            }

            this.battleUnits.Add(battleUnit);
        }

        private bool CheckExistingElement(string name)
        {
            if (this.GetElementByName(name) == null)
            {
                return false;
            }

            return true;
        }
    }
}
