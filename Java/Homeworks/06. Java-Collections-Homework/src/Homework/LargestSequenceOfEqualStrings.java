package Homework;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.Scanner;

public class LargestSequenceOfEqualStrings {
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

        String wordTarget = "";
        int maxCount = 0;

        for (String word : wordsCounts.keySet()) {
            ArrayList<String> currentWords = new ArrayList<>();
            for (int i = 0; i < wordsCounts.get(word); i++) {
                currentWords.add(word);
            }
            if (currentWords.size() > maxCount){
                maxCount = currentWords.size();
                wordTarget = word;
            }
        }

        for (int i = 0; i < maxCount; i++) {
            System.out.print(wordTarget + " ");
        }
    }
}
