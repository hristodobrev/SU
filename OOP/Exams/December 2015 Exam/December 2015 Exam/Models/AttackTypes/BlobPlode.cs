namespace December_2015_Exam.Models.AttackTypes
{
    using December_2015_Exam.Interfaces;

    public class BlobPlode : IAttack
    {
        public int ProduceAttack(IBlob parent)
        {
            parent.Health -= parent.Health / 2;
            if (parent.Health <= 0)
            {
                parent.Health = 1;
            }

            parent.BehaviorType.UpdateStats(parent);

            int damageToDeal = parent.Damage * 2;
            return damageToDeal;
        }
    }
}
