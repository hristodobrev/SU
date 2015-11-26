using System;
using System.Collections.Generic;
class ActivityTracker
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        DateTime[] dates = new DateTime[n];
        Dictionary<string, int> users = new Dictionary<string, int>();
        string[] names = new string[n];
        int[] distance = new int[n];
        string[] currentLine = Console.ReadLine().Split();
        dates[0] = DateTime.Parse(currentLine[0]);
        users[currentLine[1]] = int.Parse(currentLine[2]);



        for (int i = 1; i < n; i++)
        {
            currentLine = Console.ReadLine().Split();
            dates[i] = DateTime.Parse(currentLine[0]);
            if (dates[i].Month == dates[i - 1].Month)
            {
                if (users.ContainsKey(currentLine[1]))
                {
                    users[currentLine[1]] += int.Parse(currentLine[2]);
                }
                else
                {
                    users[currentLine[1]] = int.Parse(currentLine[2]);
                }
            }
            else
            {
                Console.Write("{0}: ", dates[i - 1].Month);
                List<string> currentText = new List<string>();
                foreach (var item in users)
                {
                    currentText.Add((item.Key + "(" + item.Value + ")"));
                }
                Console.WriteLine(string.Join(", ", currentText));
            }
        }
    }
}