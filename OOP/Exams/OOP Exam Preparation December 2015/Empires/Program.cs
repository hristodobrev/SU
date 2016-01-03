using Empires.Core;
using Empires.UI;
using Empires.UI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empires
{
    class Program
    {
        static void Main(string[] args)
        {
            IReader reader = new ConsoleReader();
            IWritter writter = new ConsoleWritter();
            Engine engine = new Engine(reader, writter);
            engine.Run();
        }
    }
}
