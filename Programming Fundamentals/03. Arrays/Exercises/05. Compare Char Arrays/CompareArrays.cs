namespace _05.Compare_Char_Arrays
{
    using System;
    using System.Linq;

    class CompareArrays
    {
        static void Main()
        {
            char[] first = Console.ReadLine().Split().Select(x => x[0]).ToArray();
            char[] second = Console.ReadLine().Split().Select(x => x[0]).ToArray();

            bool firstSmaller = true;

            int maxIndex = Math.Min(first.Length, second.Length);
            for (int i = 0; i < maxIndex; i++)
            {
                if (first[i].CompareTo(second[i]) > 0)
                {
                    firstSmaller = false;
                    break;
                }
            }

            if (firstSmaller && first.Length <= second.Length)
            {
                Console.WriteLine(string.Join("", first));
                Console.WriteLine(string.Join("", second));
            }
            else
            {
                Console.WriteLine(string.Join("", second));
                Console.WriteLine(string.Join("", first));
            }
        }
    }
}
