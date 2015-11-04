package Problem3;

import java.io.*;
import java.util.Arrays;
import java.util.List;

public class CountCharacterTypes {
    public static void main(String[] args) throws IOException {
        BufferedReader bfr = new BufferedReader(new FileReader("src\\Problem3\\words.txt"));

        FileWriter flwr = new FileWriter("src\\Problem3\\count-chars.txt", true);
        PrintWriter prwr = new PrintWriter(flwr, true);

        List vowels = Arrays.asList(new Character[]{'a', 'e', 'i', 'o', 'u'});
        List punctuations = Arrays.asList(new Character[]{'?', ',', '.', '!'});

        int vowelsCount = 0;
        int consonantsCount = 0;
        int punctuationsCount = 0;

        try {

            String currentLine = bfr.readLine();

            while (currentLine != null) {
                for (int i = 0; i < currentLine.length(); i++) {
                    if (currentLine.charAt(i) != ' ') {
                        if (vowels.contains(currentLine.charAt(i))) {
                            vowelsCount++;
                        } else if (punctuations.contains(currentLine.charAt(i))) {
                            punctuationsCount++;
                        } else {
                            consonantsCount++;
                        }
                    }
                }

                currentLine = bfr.readLine();
            }

            prwr.println("Vowels: " + vowelsCount);
            prwr.println("Consonants: " + consonantsCount);
            prwr.println("Punctuation: " + punctuationsCount);

        } finally {
            {
                bfr.close();
                flwr.close();
                prwr.close();
            }
        }
    }
}
