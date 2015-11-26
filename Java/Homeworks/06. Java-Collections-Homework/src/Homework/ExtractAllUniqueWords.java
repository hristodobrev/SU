package Homework;

import java.util.Arrays;
import java.util.HashSet;
import java.util.Scanner;

public class ExtractAllUniqueWords {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        String[] words = scan.nextLine().toLowerCase().split("[^A-Za-z]+");

        HashSet<String> orderedWords = new HashSet<>();

        for (String word : words) {
            orderedWords.add(word.toLowerCase());
        }

        String[] output = new String[orderedWords.size()];

        int curIndex = 0;

        for (String orderedWord : orderedWords) {
            output[curIndex] = orderedWord;
            curIndex++;
        }

        Arrays.sort(output);

        System.out.println(String.join(" ", output));
    }
}