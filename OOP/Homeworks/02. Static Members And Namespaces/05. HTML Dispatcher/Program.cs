using System;
using System.IO;

namespace _05.HTML_Dispatcher
{
    class Program
    {
        static void Main()
        {
            ElementBuilder div = new ElementBuilder("div");
            div.AddAttribute("id", "page");
            div.AddAttribute("class", "big");
            div.AddAttribute("style", "background-color: pink; border-bottom: 5px solid black; margin: auto; width: 200px");
            div.AddContent("<p>Hello</p>");
            Console.WriteLine(div * 2);


            string image = HTMLDispatcher.CreateImage("/cat.png", "cat", "Cat");
            string url = HTMLDispatcher.CreateURL("http://www.someurl.com", "some url", "some text");
            string input = HTMLDispatcher.CreateInput("field", "Name", "Some Name");

            Console.WriteLine(div);
            Console.WriteLine(image);
            Console.WriteLine(url);
            Console.WriteLine(input);

            using (StreamWriter sw = new StreamWriter("index.html"))
            {
                sw.WriteLine(div);
            }
        }
    }
}
