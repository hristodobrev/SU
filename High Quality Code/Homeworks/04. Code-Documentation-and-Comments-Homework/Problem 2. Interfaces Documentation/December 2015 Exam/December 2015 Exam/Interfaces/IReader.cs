namespace December_2015_Exam.Interfaces
{
    /// <summary>
    /// Input reader.
    /// </summary>
    public interface IReader
    {
        /// <summary>
        /// Reads an information from a given single line.
        /// </summary>
        /// <returns>The read information as string.</returns>
        string ReadLine();
    }
}
