package Java_Basics_May_11;

import java.util.Scanner;
import java.util.SortedMap;
import java.util.regex.Pattern;

public class Enigma {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        int lines = Integer.parseInt(scan.nextLine());
        String[] output = new String[lines];
        for (int i = 0; i < lines; i++) {
            String currentLine = scan.nextLine();
            String newStr = currentLine.replaceAll("[0-9 ]+", "");
            int length = newStr.length();
            for (int j = 0; j < currentLine.length(); j++) {
                if(currentLine.charAt(j) >= '0' && currentLine.charAt(j) <= '9' || currentLine.charAt(j) == ' ') {
                    System.out.print(currentLine.charAt(j));
                } else {
                    System.out.print((char) (currentLine.charAt(j) + length / 2));
                }
            }
            System.out.println();
        }
    }
}
