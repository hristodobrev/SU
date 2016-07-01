namespace Tower_Of_Hanoi
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;

    class TowerOfHanoi
    {
        private static Stack<int> source;
        private static Stack<int> spare;
        private static Stack<int> destination;

        static void Main()
        {
            source = new Stack<int>(Enumerable.Range(1, 5).Reverse());
            spare = new Stack<int>();
            destination = new Stack<int>();

            Move(5, source, destination, spare);
        }

        private static void Move(int disk, Stack<int> source1, Stack<int> destination1, Stack<int> spare1)
        {
            if (disk == 0)
            {
                return;
            }

            Move(disk - 1, source1, spare1, destination1);

            PrintRods();
            Thread.Sleep(1000);
            destination1.Push(disk);
            source1.Pop();

            Move(disk - 1, spare1, destination1, source1);

        }

        private static void PrintRods()
        {
            Console.Clear();
            var height = Math.Max(Math.Max(source.Count, spare.Count), destination.Count);
            var sourceMax = source.Max();
            var spareMax = spare.Max();
            var destinationMax = destination.Max();
            var wider = Math.Max(sourceMax, Math.Max(spareMax, destinationMax));

            var firstPadding = wider - sourceMax;
            var secondPadding = wider * 3 - spareMax;
            var thirdPadding = wider * 5 - destinationMax;

            var sourceList = source.Reverse().ToList();
            for (int i = 0; i < sourceList.Count; i++)
            {
                Console.SetCursorPosition(firstPadding, height - i);
                Console.Write(new string(' ', sourceMax - sourceList[i]) + new string('-', sourceList[i]) + "*" + new string('-', sourceList[i]));
            }

            var spareList = spare.Reverse().ToList();
            for (int i = 0; i < spareList.Count; i++)
            {
                Console.SetCursorPosition(secondPadding, height - i);
                Console.Write(new string(' ', spareMax - spareList[i]) + new string('-', spareList[i]) + "*" + new string('-', spareList[i]));
            }

            var destinationList = destination.Reverse().ToList();
            for (int i = 0; i < destinationList.Count; i++)
            {
                Console.SetCursorPosition(thirdPadding, height - i);
                Console.Write(new string(' ', destinationMax - destinationList[i]) + new string('-', destinationList[i]) + "*" + new string('-', destinationList[i]));
            }

            Console.SetCursorPosition(0, height + 1);
        }
    }
}

