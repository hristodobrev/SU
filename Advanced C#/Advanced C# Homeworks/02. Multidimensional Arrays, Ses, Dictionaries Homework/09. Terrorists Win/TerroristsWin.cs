using System;
using System.Collections.Generic;
class TerroristsWin
{
    static void Main()
    {
        string input = Console.ReadLine();
        string[] splited = input.Split('|');
        List<string> output = new List<string>();
        bool isFirst = true;
        for (int i = 0; i < splited.Length; i++)
        {
            if (i % 2 == 1)
            {
                char[] bomb = splited[i].ToCharArray();
                int size = 0;
                List<char> currentWord = new List<char>();
                for (int j = 0; j < bomb.Length; j++)
                {
                    size += bomb[j];
                }
                size %= 10;
                if (isFirst)
                {
                    for (int j = 0; j < splited[i - 1].Length - size; j++)
                    {
                        currentWord.Add(splited[i - 1][j]);
                    }
                    output.Add(string.Join("", currentWord));
                    isFirst = false;
                }
                else
                {
                    for (int j = 0; j < splited[i - 1].Length - size; j++)
                    {
                        currentWord.Add(splited[i - 1][j]);
                    }
                    output.Add(string.Join("", currentWord));
                }
                currentWord.Clear();
                output.Add(new string('.', (size * 2) + splited[i].Length + 2));
                
            }
        }
        Console.WriteLine(string.Join("", output));
    }
}