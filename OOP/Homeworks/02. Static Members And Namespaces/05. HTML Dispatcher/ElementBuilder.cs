using System;
using System.Collections.Generic;
using System.Text;

namespace _05.HTML_Dispatcher
{
    class ElementBuilder
    {
        private string name;
        private Dictionary<String, String> attributes;
        private string content;

        public ElementBuilder(string name)
        {
            this.Name = name;
            this.Attributes = new Dictionary<string, string>();
        }

        public string Name { get; set; }

        public Dictionary<String, String> Attributes { get; set; }

        public string Content { get; set; }

        public void AddAttribute(string atribute, string value)
        {
            this.Attributes.Add(atribute, value);
        }

        public void AddContent(string content)
        {
            StringBuilder sb = new StringBuilder(this.Content);
            sb.Append(content);
            this.Content = sb.ToString();
        }

        public static string operator *(ElementBuilder e1, int counts)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < counts; i++)
            {
                sb.Append(e1.ToString());
            }

            return sb.ToString();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<" + this.Name);
            foreach (var atribute in this.Attributes)
            {
                sb.Append(" " + atribute.Key + "=\"" + atribute.Value + "\"");
            }
            sb.Append(">");
            sb.Append(this.Content);
            sb.Append("</" + this.Name + ">");
            return sb.ToString();
        }
    }
}
