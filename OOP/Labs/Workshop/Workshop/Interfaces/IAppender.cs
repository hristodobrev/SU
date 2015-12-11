namespace Workshop.Interfaces
{
    public interface IAppender
    {
        ILayout Layout { get; }

        void Append(string msg, ReportLevel level);
    }
}
