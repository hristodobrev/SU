package Problem4;

import java.io.FileInputStream;
import java.io.FileOutputStream;
import java.io.IOException;

public class CopyJPGFile {
    public static void main(String[] args) throws IOException {
        FileInputStream fis = new FileInputStream("src\\Problem4\\image.jpg");
        FileOutputStream fos = new FileOutputStream("src\\Problem4\\my-copied-picture.jpg");
        try{
            byte[] buffer = new byte[1024];
            while (true) {
                int bytesRead = fis.read(buffer);
                if (bytesRead == -1) {
                    break;
                }
                fos.write(buffer, 0, bytesRead);
            }
        } finally {
            fis.close();
            fos.close();
        }
    }
}
