namespace Military.Interfaces
{
    using System.Collections.Generic;

    using Models.Eqiupments;

    public interface IDatabase
    {
        IEnumerable<IPlace> Places { get; }

        IEnumerable<IBattleUnit> BattleUnits { get; }

        IEnumerable<Equipment> Equipments { get; }

        IPlace GetPlaceByName(string name);

        IBattleUnit GetBattleUnitByName(string name);

        Equipment GetEquipmentByName(string name);

        object GetElementByName(string name);

        void AddPlace(IPlace place);

        void AddEquipment(Equipment equipment);

        void AddBattleUnit(IBattleUnit battleUnit);
    }
}
