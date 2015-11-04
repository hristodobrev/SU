package October_26_2015_Retake;

import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class WeirdScript {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);

        long key = (Integer.parseInt(scan.nextLine())) % 52;
        if(key == 0) {
            key = 52;
        }

        if(key < 27) {
            key += 96;
        } else {
            key += 38;
        }

        String keyString = "";
        keyString += (char) key;
        keyString += (char) key;

        Pattern pattern = Pattern.compile(keyString + "(.*?)" + keyString);

        String currentLine = scan.nextLine();
        StringBuilder text = new StringBuilder();

        while (!currentLine.equals("End")) {
            text.append(currentLine);
            currentLine = scan.nextLine();
        }

        Matcher matcher = pattern.matcher(text);

        while (matcher.find()) {
            if(matcher.group(1).length() > 0) {
                System.out.println(matcher.group(1));
            }
        }
    }
}
