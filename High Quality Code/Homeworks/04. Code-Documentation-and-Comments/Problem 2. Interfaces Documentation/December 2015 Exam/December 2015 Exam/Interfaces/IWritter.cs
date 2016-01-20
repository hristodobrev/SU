namespace December_2015_Exam.Interfaces
{
    /// <summary>
    /// Output writter.
    /// </summary>
    public interface IWritter
    {
        /// <summary>
        /// Writes a string on a single line.
        /// </summary>
        /// <param name="message">String which will be written.</param>
        void Write(string message);

        /// <summary>
        /// Writes a string on a single line and goes to the next line.
        /// </summary>
        /// <param name="message">String which will be written.</param>
        void WriteLine(string message);

        /// <summary>
        /// Writes a string on a single line.
        /// </summary>
        /// <param name="message">String which will be written.</param>
        /// <param name="args">The format agruments.</param>
        void Write(string message, params string[] args);

        /// <summary>
        /// Writes a string on a single line and goes to the next line.
        /// </summary>
        /// <param name="message">String which will be written.</param>
        /// <param name="args">The format agruments.</param>
        void WriteLine(string message, params string[] args);
    }
}
