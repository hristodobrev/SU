using System;

namespace _05.HTML_Dispatcher
{
    static class HTMLDispatcher
    {
        public static string CreateImage(string imageSource, string alt, string title)
        {
            ElementBuilder imageElement = new ElementBuilder("img");
            imageElement.AddAttribute("src", imageSource);
            imageElement.AddAttribute("alt", alt);
            imageElement.AddAttribute("title", title);
            return imageElement.ToString();
        }

        public static string CreateURL(string url, string title, string text)
        {
            ElementBuilder urlElement = new ElementBuilder("a");
            urlElement.AddAttribute("url", url);
            urlElement.AddAttribute("title", title);
            urlElement.AddAttribute("text", text);
            return urlElement.ToString();
        }

        public static string CreateInput(string type, string name, string value)
        {
            ElementBuilder inputElement = new ElementBuilder("input");
            inputElement.AddAttribute("type", type);
            inputElement.AddAttribute("name", name);
            inputElement.AddAttribute("value", value);
            return inputElement.ToString();
        }
    }
}
