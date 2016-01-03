namespace December_2015_Exam
{
    using December_2015_Exam.Core;
    using December_2015_Exam.Interfaces;
    using December_2015_Exam.UI;

    class Program
    {
        static void Main()
        {
            IReader reader = new ConsoleReader();
            IWritter writter = new ConsoleWritter();
            IEngine engine = new Engine(reader, writter);
            engine.Run();
        }
    }
}
