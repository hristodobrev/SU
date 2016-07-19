namespace _03.Asynchronous_Timer
{
using System;
    using System.Threading;

    class Program
    {
        static void Main(string[] args)
        {
            Action action = new Action(PrintSomething);
            AsyncTimer t = new AsyncTimer(action, 5, 1000);

            t.Run();

            string msg = Console.ReadLine();

            while (!msg.ToLower().Equals("quit") && !msg.ToLower().Equals("exit"))
            {
                msg = Console.ReadLine();
            }

            t.thread.Join();
        }

        static void PrintSomething()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Something Happened");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
