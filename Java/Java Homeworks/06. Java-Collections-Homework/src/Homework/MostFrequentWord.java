package Homework;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.Scanner;

public class MostFrequentWord {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        String[] words = scan.nextLine().split("[^A-Za-z]+");

        ArrayList<String> mostFrequentWords = new ArrayList<>();
        ArrayList<Integer> counts = new ArrayList<>();
        counts.add(0);

        for (int i = 0; i < words.length; i++) {
            String currentWord = words[i];
            int currentCount = 1;
            for (int j = i + 1; j < words.length; j++) {
                if(currentWord.toLowerCase().equals(words[j].toLowerCase())){
                    currentCount++;
                }
            }

            if (currentCount > counts.get(0)){
                mostFrequentWords.clear();
                mostFrequentWords.add(currentWord);
                counts.clear();
                counts.add(currentCount);
            } else if(currentCount == counts.get(0)){
                mostFrequentWords.add(currentWord);
                counts.add(currentCount);
            }
        }

        String[] output = new String[mostFrequentWords.size()];

        for (int i = 0; i < mostFrequentWords.size(); i++) {
            output[i] = mostFrequentWords.get(i);
        }

        Arrays.sort(output);

        for (int i = 0; i < counts.size(); i++) {
            System.out.printf("%s -> %d times\n", output[i].toLowerCase(), counts.get(i));
        }
    }
}
