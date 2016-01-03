namespace December_2015_Exam.Models.AttackTypes
{
    using December_2015_Exam.Interfaces;

    public class PutridFart : IAttack
    {
        public int ProduceAttack(IBlob parent)
        {
            int damageToDeal = parent.Damage;
            return damageToDeal;
        }
    }
}
