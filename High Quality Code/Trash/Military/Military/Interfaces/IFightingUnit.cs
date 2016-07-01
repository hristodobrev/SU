namespace Military.Interfaces
{
    using Models.Equipments.Shileds;
    using Models.Equipments.Weapons;
    using Models.Fighting_Utilities;
    using Models.Weapons;

    public interface IFightingUnit : IBattleUnit
    {
        Weapon Weapon { get; }

        Shield Shield { get; }

        FightInfo Attack(IBattleUnit target);
    }
}
