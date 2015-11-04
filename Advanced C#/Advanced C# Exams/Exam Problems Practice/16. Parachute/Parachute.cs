using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

class Parachute
{
    static void Main()
    {
        string currentLine = Console.ReadLine();
        int cols = currentLine.Length;
        int playerPosition = currentLine.IndexOf("o");

        List<string> matrix = new List<string>();

        while (currentLine != "END")
        {
            matrix.Add(currentLine);
            Regex regex = new Regex(@"[<>]+");
            MatchCollection matches = regex.Matches(currentLine);

            int leftMoves = 0;
            int rightMoves = 0;

            foreach (Match match in matches)
            {
                Console.WriteLine(match.ToString());
                if (match.ToString()[0] == '<')
                {
                    leftMoves += match.ToString().Length;
                }
                else
                {
                    rightMoves++;
                }
            }

            Console.WriteLine("{0} - left moves, {1} - right moves", leftMoves, rightMoves);

            currentLine = Console.ReadLine();
        }
    }
}