namespace December_2015_Exam.Models.BehaviorTypes
{
    using December_2015_Exam.Interfaces;

    public class AggressiveBehavior : Behavior
    {
        private static int decreasingDamage = 5;

        public AggressiveBehavior()
            : base(false)
        {
        }

        public override void UpdateStats(IBlob parent)
        {
            if (!this.Triggered &&
                parent.Health <= parent.InitialHealth / 2)
            {
                parent.Damage *= 2;
                this.Triggered = true;
                this.FireEvent(parent);
                return;
            }

            if (this.Triggered)
            {
                if (parent.Damage > parent.InitialDamage)
                {
                    parent.Damage -= decreasingDamage;
                }

                if (parent.Damage < parent.InitialDamage)
                {
                    parent.Damage = parent.InitialDamage;
                }
            }
        }
    }
}
