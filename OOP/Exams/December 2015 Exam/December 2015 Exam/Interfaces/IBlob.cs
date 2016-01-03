namespace December_2015_Exam.Interfaces
{
    using December_2015_Exam.Models.BehaviorTypes;

    public interface IBlob
    {
        string Name { get; }

        int Health { get; set; }

        int InitialHealth { get; }

        int Damage { get; set; }

        int InitialDamage { get; }

        bool IsAlive { get; }

        IAttack AttackType { get; }

        Behavior BehaviorType { get; }

        void Update();

        void Attack(IBlob target);

        void ResponseAttack(int damage);
    }
}
