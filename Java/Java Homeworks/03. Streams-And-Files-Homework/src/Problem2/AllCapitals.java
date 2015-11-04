package Problem2;

import java.io.*;
import java.util.ArrayList;
import java.util.List;

public class AllCapitals {
    public static void main(String[] args) throws IOException {
        BufferedReader bfr = new BufferedReader(new FileReader("src\\Problem2\\lines.txt"));

        FileWriter flwr = new FileWriter("src\\Problem2\\lines.txt", true);
        PrintWriter prwr = new PrintWriter(flwr, true);
        try {
            List<String> lines = new ArrayList<String>();
        String currentLine = bfr.readLine();

            while (currentLine != null) {
                lines.add(currentLine);
                currentLine = bfr.readLine();
            }

            PrintWriter writer = new PrintWriter("src\\Problem2\\lines.txt");
            writer.print("");
            writer.close();

            for (int i = 0; i < lines.size(); i++) {
                prwr.println(lines.get(i).toUpperCase());
            }
        } finally {
            bfr.close();
            flwr.close();
            prwr.close();
        }

    }
}
