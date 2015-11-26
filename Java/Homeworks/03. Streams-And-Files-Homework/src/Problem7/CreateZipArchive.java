package Problem7;

import java.io.*;
import java.util.zip.ZipEntry;
import java.util.zip.ZipOutputStream;

public class CreateZipArchive {
    public static void main(String[] args) throws IOException {
        FileInputStream wordsInputStream = new FileInputStream(
                "src\\Problem7\\words.txt"
        );
        FileInputStream countCharsInputStream = new FileInputStream(
                "src\\Problem7\\count-chars.txt"
        );
        FileInputStream linesInputStream = new FileInputStream(
                "src\\Problem7\\lines.txt"
        );

        FileOutputStream dest = new FileOutputStream(
                "src\\Problem7\\text-files.zip"
        );

        ZipOutputStream zip = new ZipOutputStream(
                new BufferedOutputStream(
                        dest
                )
        );
            byte[] buffer = new byte[1024];
        while (true){
            int readBytes = wordsInputStream.read(buffer);
            if (readBytes == - 1){
                break;
            }
            zip.putNextEntry(new ZipEntry("words.txt"));
            zip.write(buffer, 0, readBytes);
            zip.closeEntry();
        }
        while (true){
            int readBytes = countCharsInputStream.read(buffer);
            if (readBytes == - 1){
                break;
            }
            zip.putNextEntry(new ZipEntry("count-chars.txt"));
            zip.write(buffer, 0, readBytes);
            zip.closeEntry();
        }
        while (true){
            int readBytes = linesInputStream.read(buffer);
            if (readBytes == - 1){
                break;
            }
            zip.putNextEntry(new ZipEntry("lines.txt"));
            zip.write(buffer, 0, readBytes);
            zip.closeEntry();
        }
        zip.close();
        wordsInputStream.close();
        linesInputStream.close();
        countCharsInputStream.close();
        dest.close();
    }
}
