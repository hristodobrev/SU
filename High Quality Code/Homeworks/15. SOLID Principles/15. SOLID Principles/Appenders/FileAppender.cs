namespace _15.SOLID_Principles.Appenders
{
    using System;
    using System.IO;

    using Enumerations;

    using Interfaces;

    public class FileAppender : IAppender
    {
        public FileAppender(ILayout layout)
        {
            this.Layout = layout;
        }

        public ILayout Layout { get; private set; }

        public ReportLevel ReportLevel { get; set; }

        public void Append(string message, ReportLevel reportLevel)
        {
            if ((int) reportLevel >= (int) this.ReportLevel)
            {
                string formattedMessage = this.Layout.Format(DateTime.Now, reportLevel, message);
                using (var fileWritter = new StreamWriter(new FileStream("file.txt", FileMode.Append)))
                {
                    fileWritter.WriteLine(formattedMessage);
                }
            }
        }
    }
}
