package Problem1;

import java.io.BufferedReader;
import java.io.FileReader;
import java.io.IOException;

public class SumLines {
    public static void main(String[] args) throws IOException {
        BufferedReader bfr = new BufferedReader(new FileReader("src\\Problem1\\lines.txt"));

        String currentLine = bfr.readLine();
        int sum = 0;

        try {
            while (currentLine != null) {
                for (int i = 0; i < currentLine.length(); i++) {
                    sum += currentLine.charAt(i);
                }
                System.out.println(sum);
                sum = 0;
                currentLine = bfr.readLine();
            }
        } finally {
            bfr.close();
        }
    }
}
