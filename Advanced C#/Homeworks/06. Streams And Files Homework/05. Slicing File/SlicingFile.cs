using System;
using System.Collections.Generic;
using System.IO;

class SlicingFile
{
    static void Main()
    {
        Console.Write("Type the parts you want the file to be sliced to: ");
        int parts = int.Parse(Console.ReadLine());

        Slice("../../solid.avi", "../../part-", parts);

        List<string> files = new List<string>();
        for (int i = 0; i < parts; i++)
        {
            files.Add("../../part-" + (i + 1) + ".avi");
        }

        Assemble(files, "../../decompressed.avi", parts);

    }

    static void Slice(string sourceFile, string destinationDirectory, int parts)
    {
        using (FileStream source = new FileStream(sourceFile, FileMode.Open))
        {
            List<FileStream> destination = new List<FileStream>();

            for (int i = 0; i < parts; i++)
            {
                destination.Add(new FileStream(destinationDirectory + (i + 1) + ".avi", FileMode.Create));
                using (destination[i])
                {
                    byte[] buffer = new byte[source.Length / parts];
                    int readBytes = source.Read(buffer, 0, buffer.Length);
                    destination[i].Write(buffer, 0, readBytes);
                }
            }
        }
    }

    static void Assemble(List<string> files, string destinationDirectory, int parts)
    {
        using (FileStream destination = new FileStream(destinationDirectory, FileMode.Create))
        {
            for (int i = 0; i < parts; i++)
            {
                using (FileStream inputStream = new FileStream(files[i], FileMode.Open))
                {
                    byte[] buffer = new byte[4096];
                    int readBytes = inputStream.Read(buffer, 0, buffer.Length);
                    while (readBytes != 0)
                    {
                        destination.Write(buffer, 0, readBytes);
                        readBytes = inputStream.Read(buffer, 0, buffer.Length);
                        Console.WriteLine("{0:P}", Math.Min(inputStream.Position / (double)inputStream.Length, 1));
                    }
                }
            }
        }
    }
}