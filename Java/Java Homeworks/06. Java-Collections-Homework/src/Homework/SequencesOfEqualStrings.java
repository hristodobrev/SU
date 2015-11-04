package Homework;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.Scanner;

public class SequencesOfEqualStrings {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        String[] words = scan.nextLine().split("\\s+");

        HashMap<String, Integer> wordsCounts = new HashMap<>();

        for (String word : words) {
            Integer count = wordsCounts.get(word);
            if(count == null){
                count = 0;
            }
            wordsCounts.put(word, count + 1);
        }

        for (String word : wordsCounts.keySet()) {
            ArrayList<String> currentWords = new ArrayList<>();
            for (int i = 0; i < wordsCounts.get(word); i++) {
                currentWords.add(word);
            }
            System.out.println(String.join(" ", currentWords));
        }
    }
}
