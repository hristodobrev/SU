using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

class ArrayManupilator
{
    static void Main()
    {
        int[] array = Console.ReadLine().Split(new char[0], StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
        string currentCommand = Console.ReadLine();
        List<string> output = new List<string>();

        while (currentCommand != "end")
        {
            string[] command = currentCommand.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
            if (command[0] == "exchange")
            {
                string stringArray = string.Join(" ", array);
                int index = int.Parse(command[1]);

                if (index < array.Length)
                {
                    int[] firstSequence = new int[index + 1];
                    int[] secondSequence = new int[array.Length - index - 1];

                    for (int i = 0; i < firstSequence.Length; i++)
                    {
                        firstSequence[i] = array[i];
                    }

                    for (int i = 0; i < secondSequence.Length; i++)
                    {
                        secondSequence[i] = array[index + 1 + i];
                    }

                    int sequenceIndex = 0;
                    for (int i = 0; i < array.Length; i++)
                    {
                        if (i < secondSequence.Length)
                        {
                            array[i] = secondSequence[i];
                        }
                        else
                        {
                            array[i] = firstSequence[sequenceIndex];
                            sequenceIndex++;
                        }
                    }
                }
                else
                {
                    output.Add("Invalid index");
                }
            }
            else if (command[0] == "min")
            {
                if (command[1] == "odd")
                {
                    var odds =
                        from number in array
                        where number % 2 != 0
                        select number;

                    if (odds.ToList().Count > 0)
                    {
                        int oddIndex = Array.IndexOf(array, odds.Min());
                        output.Add(oddIndex.ToString());
                    }
                    else
                    {
                        output.Add("No matches");
                    }
                }
                else
                {
                    var evens =
                        from number in array
                        where number % 2 == 0
                        select number;

                    if (evens.ToList().Count > 0)
                    {
                        output.Add(Array.IndexOf(array, evens.Min()).ToString());
                    }
                    else
                    {
                        output.Add("No matches");
                    }
                }
            }
            else if (command[0] == "max")
            {
                if (command[1] == "odd")
                {
                    var odds =
                        from number in array
                        where number % 2 != 0
                        select number;

                    if (odds.ToList().Count > 0)
                    {
                        output.Add(Array.IndexOf(array, odds.Max()).ToString());
                    }
                    else
                    {
                        output.Add("No matches");
                    }
                }
                else
                {
                    var evens =
                        from number in array
                        where number % 2 == 0
                        select number;

                    if (evens.ToList().Count > 0)
                    {
                        output.Add(Array.IndexOf(array, evens.Max()).ToString());
                    }
                    else
                    {
                        output.Add("No matches");
                    }
                }
            }
            else if (command[0] == "first")
            {
                if (command[2] == "even")
                {
                    int index = int.Parse(command[1]);
                    if (index <= array.Length)
                    {
                        List<int> evens = new List<int>();
                        int currentIndex = 0;
                        int count = 0;
                        while (count < index && currentIndex < array.Length)
                        {
                            if (array[currentIndex] % 2 == 0)
                            {
                                evens.Add(array[currentIndex]);
                                count++;
                            }
                            currentIndex++;
                        }
                        if (evens.Count == index)
                        {
                            output.Add("[" + string.Join(", ", evens) + "]");
                        }
                    }
                    else
                    {
                        output.Add("Invalid count");
                    }
                }
                if (command[2] == "odd")
                {
                    int index = int.Parse(command[1]);
                    if (index <= array.Length)
                    {
                        List<int> odds = new List<int>();
                        int currentIndex = 0;
                        int count = 0;
                        while (count < index && currentIndex < array.Length)
                        {
                            if (array[currentIndex] % 2 != 0)
                            {
                                odds.Add(array[currentIndex]);
                                count++;
                            }
                            currentIndex++;
                        }
                        output.Add("[" + string.Join(", ", odds) + "]");

                    }
                    else
                    {
                        output.Add("Invalid count");
                    }
                }
            }
            else if (command[0] == "last")
            {
                if (command[2] == "even")
                {
                    int index = int.Parse(command[1]);
                    if (index <= array.Length)
                    {
                        List<int> evens = new List<int>();
                        int currentIndex = array.Length - 1;
                        int count = 0;
                        while (count < index && currentIndex >= 0)
                        {
                            if (array[currentIndex] % 2 == 0)
                            {
                                evens.Add(array[currentIndex]);
                                count++;
                            }
                            currentIndex--;
                        }
                        evens.Reverse();
                        output.Add("[" + string.Join(", ", evens) + "]");

                    }
                    else
                    {
                        output.Add("Invalid count");
                    }
                }
                if (command[2] == "odd")
                {
                    int index = int.Parse(command[1]);
                    if (index <= array.Length)
                    {
                        List<int> odds = new List<int>();
                        int currentIndex = array.Length - 1;
                        int count = 0;
                        while (count < index && currentIndex >= 0)
                        {
                            if (array[currentIndex] % 2 != 0)
                            {
                                odds.Add(array[currentIndex]);
                                count++;
                            }
                            currentIndex--;
                        }
                        odds.Reverse();
                        output.Add("[" + string.Join(", ", odds) + "]");

                    }
                    else
                    {
                        output.Add("Invalid count");
                    }
                }
            }
            currentCommand = Console.ReadLine();
        }

        Console.WriteLine(string.Join("\n", output));
        Console.WriteLine("[" + string.Join(", ", array) + "]");
    }
}