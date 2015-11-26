package October_4_2015;

import jdk.nashorn.internal.runtime.regexp.joni.Regex;

import java.util.Scanner;
import java.util.regex.Pattern;

public class DragonSharp {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        int linesCount = Integer.parseInt(scan.nextLine());

        for (int i = 0; i < linesCount; i++) {
            String currentLine = scan.nextLine();
            int firstQuoteIndex = currentLine.indexOf('"');
            int secondQuoteIndex = currentLine.indexOf('"', firstQuoteIndex + 1);
            String logic = currentLine.substring(0, firstQuoteIndex);
            String[] splited = logic.split(" ");

        }
    }
}
