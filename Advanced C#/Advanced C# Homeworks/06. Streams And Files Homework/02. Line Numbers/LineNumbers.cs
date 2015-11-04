using System;
using System.IO;

class LineNumbers
{
    static void Main()
    {
        StreamReader reader = new StreamReader("../../text.txt");
        StreamWriter writer = new StreamWriter("../../text-with-lines.txt");
        using (reader)
        {
            using (writer)
            {
                int lineNumber = 1;
                string line = reader.ReadLine();
                while (line != null)
                {
                    writer.WriteLine("[{0}] {1}", lineNumber, line);
                    lineNumber++;
                    line = reader.ReadLine();
                }
                Console.WriteLine("You have successful written line number before every line in the ../../text.txt, the output file is:  ../../text-with-lines.txt");
            }
        }
    }
}
