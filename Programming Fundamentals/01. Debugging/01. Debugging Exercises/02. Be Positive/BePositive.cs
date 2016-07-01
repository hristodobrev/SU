namespace _02.Be_Positive
{
    using System;
    using System.Linq;

    class BePositive
    {
        public static void Main()
        {
            int countSequences = int.Parse(Console.ReadLine());

            for (int i = 0; i < countSequences; i++)
            {
                var numbers = Console.ReadLine()
                    .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToList();

                bool found = false;

                for (int j = 0; j < numbers.Count; j++)
                {
                    int currentNum = numbers[j];

                    if (currentNum >= 0)
                    {
                        if (found)
                        {
                            Console.Write(" ");
                        }

                        Console.Write(currentNum);

                        found = true;
                    }
                    else
                    {
                        if (j + 1 < numbers.Count)
                        {
                            currentNum += numbers[j + 1];
                        }

                        if (currentNum >= 0)
                        {
                            if (found)
                            {
                                Console.Write(" ");
                            }

                            Console.Write(currentNum);

                            found = true;
                        }

                        j++;
                    }
                }
                if (!found)
                {
                    Console.WriteLine("(empty)");
                }
                else
                {
                    Console.WriteLine();
                }
            }
        }
    }
}
