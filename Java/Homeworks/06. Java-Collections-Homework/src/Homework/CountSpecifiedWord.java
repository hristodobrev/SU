package Homework;

import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class CountSpecifiedWord {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        String text = scan.nextLine();

        String wordSearch = scan.nextLine();

        Pattern pattern = Pattern.compile("\\b" + wordSearch.toLowerCase() + "\\b");
        Matcher matcher = pattern.matcher(text.toLowerCase());

        int counts = 0;

        while (matcher.find()){
            counts++;
        }

        System.out.println(counts);
    }
}
