namespace Workshop.Layouts
{
    using System;
    using Interfaces;

    class SimpleLayout : ILayout
    {
        public string Layout(string msg, ReportLevel level)
        {
            return string.Format("{0} - {1} - {2}", DateTime.Now, level, msg);
        }
    }
}
