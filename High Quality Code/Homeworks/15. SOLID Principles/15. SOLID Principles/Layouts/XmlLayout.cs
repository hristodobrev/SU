namespace _15.SOLID_Principles.Layouts
{
    using System;
    using System.Text;

    using Enumerations;

    using Interfaces;

    public class XmlLayout : ILayout
    {
        public string Format(DateTime date, ReportLevel reportLevel, string message)
        {
            StringBuilder formattedMessage = new StringBuilder();

            formattedMessage.AppendLine("<log>");
            formattedMessage.AppendLine("   <date>" + date + "</date>");
            formattedMessage.AppendLine("   <level>" + reportLevel + "</level>");
            formattedMessage.AppendLine("   <message>" + message + "</message>");
            formattedMessage.Append("</log>");

            return formattedMessage.ToString();
        }
    }
}
