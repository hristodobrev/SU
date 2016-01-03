namespace December_2015_Exam.Interfaces
{
    public interface IBehavior
    {
        void UpdateStats(IBlob parent);

        bool Triggered { get; }
    }
}
