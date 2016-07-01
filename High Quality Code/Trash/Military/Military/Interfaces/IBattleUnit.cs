namespace Military.Interfaces
{
    using Models.Eqiupments;

    public interface IBattleUnit
    {
        string Name { get; }

        int Health { get; }

        bool IsAlive { get; }

        void Equip(Equipment equipment);

        int ResponseAttack(int damage);
    }
}
