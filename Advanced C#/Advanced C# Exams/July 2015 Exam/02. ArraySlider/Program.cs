using System;
using System.Numerics;
using System.Linq;

namespace _02.ArraySlider
{
    class ArraySlider
    {
        static void Main()
        {
            var arr = Console.ReadLine().Trim().Split(new char[] { }, StringSplitOptions.RemoveEmptyEntries).Select(BigInteger.Parse).ToArray();

            string line = Console.ReadLine();
            int currentIndex = 0;
            while (line != "stop")
            {
                var lineArgs = line.Split(new char[] { }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                int offset = int.Parse(lineArgs[0]) % arr.Length;
                string operation = lineArgs[1];
                BigInteger operand = BigInteger.Parse(lineArgs[2]);

                if (offset < 0)
                {
                    currentIndex = (currentIndex + offset + arr.Length) % arr.Length;
                }
                else
                {
                    currentIndex = (currentIndex + offset) % arr.Length;
                }

                ProcessComand(arr, currentIndex, operation, operand);

                line = Console.ReadLine();
            }

            Console.WriteLine("[" + string.Join(", ", arr) + "]");
        }

        private static void ProcessComand(BigInteger[] arr, int currentIndex, string operation, BigInteger operand)
        {
            switch (operation)
            {
                case "&":
                    arr[currentIndex] &= operand;
                    break;
                case "|":
                    arr[currentIndex] |= operand;
                    break;
                case "^":
                    arr[currentIndex] ^= operand;
                    break;
                case "+":
                    arr[currentIndex] += operand;
                    break;
                case "-":
                    arr[currentIndex] -= operand;
                    if (arr[currentIndex] < 0)
                    {
                        arr[currentIndex] = 0;
                    }
                    break;
                case "*":
                    arr[currentIndex] *= operand;
                    break;
                case "/":
                    arr[currentIndex] /= operand;
                    break;

            }
        }
    }
}
