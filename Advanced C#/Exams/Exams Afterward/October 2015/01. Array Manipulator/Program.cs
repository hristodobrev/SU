using System;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;

namespace _01.Array_Manipulator
{
    class Program
    {
        static void Main()
        {
            int[] array = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            string command = Console.ReadLine();

            while (command != "end")
            {
                string[] commandArgs = command.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                switch (commandArgs[0])
                {
                    case "exchange":
                        int index = int.Parse(commandArgs[1]);
                        if (index < 0 || index >= array.Length)
                        {
                            Console.WriteLine("Invalid index");
                            break;
                        }
                        array = ExchangeArray(array, index + 1);
                        break;
                    case "max":
                    case "min":
                        Console.WriteLine(GetIndex(array, commandArgs[0], commandArgs[1]));
                        break;
                    case "first":
                    case "last":
                        Console.WriteLine(GetSequence(array, int.Parse(commandArgs[1]), commandArgs[0], commandArgs[2]));
                        break;
                }

                command = Console.ReadLine();
            }

            Console.WriteLine("[{0}]", string.Join(", ", array));
        }

        private static string GetSequence(int[] array, int count, string comparison, string type)
        {
            if (count > array.Length)
            {
                return "Invalid count";
            }

            int remainder = type == "odd" ? 1 : 0;
            var filtered = array.Where(num => num % 2 == remainder).ToArray();

            return comparison == "first"
                ? "[" + string.Join(", ", filtered.Take(count)) + "]"
                : "[" + string.Join(", ", filtered.Reverse().Take(count).Reverse()) + "]";
        }

        private static string GetIndex(int[] array, string comparison, string type)
        {
            int remainder = type == "odd" ? 1 : 0;
            var filtered = array.Where(num => num % 2 == remainder).ToArray();

            if (!filtered.Any())
            {
                return "No matches";
            }

            return
                comparison == "min"
                    ? Array.LastIndexOf(array, filtered.Min()).ToString()
                    : Array.LastIndexOf(array, filtered.Max()).ToString();
        }

        private static int[] ExchangeArray(int[] array, int index)
        {
            return array.Skip(index).Concat(array.Take(index)).ToArray();
        }
    }
}