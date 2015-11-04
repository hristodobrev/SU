package Homework;

import java.util.*;

public class LongestIncreasingSequence {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);

        int[] numbers = Arrays.stream(scan.nextLine().split(" "))
                .mapToInt(Integer::parseInt)
                .toArray();

        int longestSequenceIndex = 0;
        int longestSequenceLength = 1;

        for (int i = 0; i < numbers.length; i++) {
            int currentNumber = numbers[i];
            int currentLongestSequenceLength = 1;
            int currentIndex = i;
            System.out.print(currentNumber);

            for (int j = i + 1; j < numbers.length; j++) {
                int nextNumber = numbers[j];
                if (nextNumber > currentNumber){
                    System.out.print(" " + nextNumber);
                    currentNumber = nextNumber;
                    currentLongestSequenceLength++;
                    i++;
                } else {
                    break;
                }
            }

            if(currentLongestSequenceLength > longestSequenceLength) {
                longestSequenceLength = currentLongestSequenceLength;
                longestSequenceIndex = currentIndex;
            }
            System.out.println();
        }

        System.out.print("Longest:");
        for (int i = longestSequenceIndex; i < longestSequenceIndex + longestSequenceLength; i++) {
            System.out.print(" " + numbers[i]);
        }
    }
}
