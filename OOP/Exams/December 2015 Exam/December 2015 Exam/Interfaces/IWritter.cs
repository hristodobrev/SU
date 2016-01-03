namespace December_2015_Exam.Interfaces
{
    public interface IWritter
    {
        void Write(string message);

        void WriteLine(string message);

        void Write(string message, params string[] args);

        void WriteLine(string message, params string[] args);
    }
}
