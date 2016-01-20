namespace December_2015_Exam.Models.BehaviorTypes
{
    using December_2015_Exam.Delegates;
    using December_2015_Exam.Interfaces;
    using System;

    public abstract class Behavior : IBehavior
    {
        public event BlobDelegate HasTriggered;

        protected Behavior(bool isTriggered)
        {
            this.Triggered = isTriggered;
        }

        public abstract void UpdateStats(IBlob parent);

        public bool Triggered { get; protected set; }

        protected void FireEvent(IBlob parent)
        {
            if (this.HasTriggered != null)
            {
                this.HasTriggered(parent);
            }
        }
    }
}
