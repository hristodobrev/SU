using System;
using System.IO;

class OddLines
{
    static void Main()
    {
        StreamReader fileStream = new StreamReader("../../text.txt");
        using (fileStream)
        {
            int currentLine = 0;
            string line = fileStream.ReadLine();
            while (line != null)
            {
                if (currentLine % 2 == 1)
                {
                    Console.WriteLine(line);
                }
                line = fileStream.ReadLine();
                currentLine++;
            }
        }
    }
}