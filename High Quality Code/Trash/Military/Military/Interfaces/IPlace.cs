namespace Military.Interfaces
{
    using System.Collections.Generic;

    using Models.Places;

    public interface IPlace
    {
        string Name { get; }

        int Capacity { get; }

        PlaceType Type { get; }
        
        IEnumerable<IBattleUnit> Units { get; }

        IBattleUnit GetUnitByName(string name);

        void Enter(IBattleUnit unit);

        void Exit(IBattleUnit unit);
    }
}
