namespace _03.Array_Test
{
    using System;
    using System.Linq;

    class ArrayTest
    {
        private const char ArgumentsDelimiter = ' ';

        public static void Main()
        {
            int sizeOfArray = int.Parse(Console.ReadLine());

            long[] array = Console.ReadLine()
                .Split(ArgumentsDelimiter)
                .Select(long.Parse)
                .ToArray();

            string command = Console.ReadLine();

            while (!command.Equals("stop"))
            {
                var commandArgs = command.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                int[] args = new int[2];

                if (commandArgs[0].Equals("add") ||
                    commandArgs[0].Equals("subtract") ||
                    commandArgs[0].Equals("multiply"))
                {
                    args[0] = int.Parse(commandArgs[1]);
                    args[1] = int.Parse(commandArgs[2]);

                    PerformAction(array, commandArgs[0], args);
                }
                else
                {
                    if (command.Equals("lshift"))
                    {
                        ArrayShiftLeft(array);
                    }
                    else if(command.Equals("rshift"))
                    {
                        ArrayShiftRight(array);
                    }
                }

                PrintArray(array);

                command = Console.ReadLine();
            }
        }

        static void PerformAction(long[] array, string action, int[] args)
        {
            int pos = args[0] - 1;
            if (pos >= array.Length)
            {
                return;
            }
            int value = args[1];

            switch (action)
            {
                case "multiply":
                    array[pos] *= value;
                    break;
                case "add":
                    array[pos] += value;
                    break;
                case "subtract":
                    array[pos] -= value;
                    break;
            }
        }

        private static void ArrayShiftRight(long[] array)
        {
            var last = array[array.Length - 1];
            for (int i = array.Length - 1; i >= 1; i--)
            {
                array[i] = array[i - 1];
            }
            array[0] = last;
        }

        private static void ArrayShiftLeft(long[] array)
        {
            var first = array[0];
            for (int i = 0; i < array.Length - 1; i++)
            {
                array[i] = array[i + 1];
            }
            array[array.Length - 1] = first;
        }

        private static void PrintArray(long[] array)
        {
            Console.WriteLine(string.Join(" ", array));
        }
    }
}
