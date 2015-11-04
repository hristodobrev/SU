using System;
using System.IO;

class CopyBinaryFile
{
    static void Main()
    {
        FileStream getImage = new FileStream("../../image.jpg", FileMode.Open);            // getting image
        FileStream copyImage = new FileStream("../../image-copy.jpg", FileMode.Create);    // destination of copy

        using (getImage)
        {
            using (copyImage)
            {
                byte[] buffer = new byte[8192];

                while (true)
                {
                    int readBytes = getImage.Read(buffer, 0, buffer.Length);

                    if (readBytes == 0)
                    {
                        break;
                    }

                    copyImage.Write(buffer,0 , readBytes);
                }
            }
        }

    }
}