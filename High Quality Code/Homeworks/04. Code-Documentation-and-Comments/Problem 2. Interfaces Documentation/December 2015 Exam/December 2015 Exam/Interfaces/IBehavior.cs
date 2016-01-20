namespace December_2015_Exam.Interfaces
{
    /// <summary>
    /// Behavior of the blob.
    /// </summary>
    public interface IBehavior
    {
        /// <summary>
        /// Updates all stats of the parent blob of this behavior.
        /// </summary>
        /// <param name="parent">The parent blob of this behavior.</param>
        void UpdateStats(IBlob parent);

        /// <summary>
        /// Checks whether the blob behavior is triggered.
        /// </summary>
        bool Triggered { get; }
    }
}
