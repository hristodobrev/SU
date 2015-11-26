package Homework;

import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class CountSubstringOccurrences {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        String text = scan.nextLine();

        String wordSearch = scan.nextLine();

        int counts = 0;

        for (int i = 0; i < text.length() - wordSearch.length() + 1; i++) {
            String currentWord = text.substring(i, i + wordSearch.length());
            if (currentWord.toLowerCase().equals(wordSearch.toLowerCase())){
                counts++;
            }
        }

        System.out.println(counts);
    }
}
