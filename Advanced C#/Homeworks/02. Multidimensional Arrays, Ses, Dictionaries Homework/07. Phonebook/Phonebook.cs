using System;
using System.Collections.Generic;
using System.Linq;
class Phonebook
{
    static void Main()
    {
        Dictionary<string, string> phonebook = new Dictionary<string, string>();
        string currentLine = Console.ReadLine();
        while (currentLine != "search")
        {
            string[] splitLine = currentLine.Split('-');
            phonebook[splitLine[0]] = splitLine[1];
            currentLine = Console.ReadLine();
            if (currentLine == "search")
            {
                break;
            }
        }
        List<string> searchNames = new List<string>();
        while (true)
        {
            currentLine = Console.ReadLine();
            if (currentLine == "end")
            {
                break;
            }
            if (phonebook.ContainsKey(currentLine))
            {
                Console.WriteLine("{0} -> {1}", currentLine, phonebook[currentLine]);
            }
            else
            {
                Console.WriteLine("Contact {0} does not exist.", currentLine);
            }
        }
    }
}