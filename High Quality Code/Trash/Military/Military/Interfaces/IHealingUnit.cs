namespace Military.Interfaces
{
    using Models.Eqiupments.Repairing_Kits;
    using Models.Equipments.Shileds;

    public interface IHealingUnit : IBattleUnit
    {
        RepairingKit RepairingKit { get; }

        Shield Shield { get; }
    }
}
