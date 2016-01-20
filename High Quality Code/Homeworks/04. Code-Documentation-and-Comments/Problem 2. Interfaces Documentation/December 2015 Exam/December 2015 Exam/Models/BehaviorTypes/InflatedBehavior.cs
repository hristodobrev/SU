namespace December_2015_Exam.Models.BehaviorTypes
{
    using December_2015_Exam.Interfaces;

    public class InflatedBehavior : Behavior
    {
        private static int decreasingHealth = 10;

        public InflatedBehavior()
            : base(false)
        {
        }

        public override void UpdateStats(IBlob parent)
        {
            if (!this.Triggered && 
                parent.Health <= parent.InitialHealth / 2)
            {
                parent.Health += 50;
                this.Triggered = true;
                this.FireEvent(parent);
                return;
            }

            if (this.Triggered)
            {
                if (parent.Health - decreasingHealth < 0)
                {
                    parent.Health = 0;
                }
                else
                {
                    parent.Health -= decreasingHealth;
                }
            }
        }
    }
}
