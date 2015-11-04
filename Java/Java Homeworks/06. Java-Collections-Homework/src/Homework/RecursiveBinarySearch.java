package Homework;

import java.util.Arrays;
import java.util.Scanner;

public class RecursiveBinarySearch {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);

        int number = scan.nextInt();
        scan.nextLine();

        int[] numbers = Arrays.stream(scan.nextLine().split("\\s+"))
                .mapToInt(Integer::parseInt)
                .toArray();

        int index = search(numbers, 0, numbers.length - 1, number);

        System.out.println(index);
    }

    private static int search(int[]numbers, int start, int end, int target){
        int middle = (start + end) / 2;

        if(end < start){
            return -1;
        }

        if(target == numbers[middle]){
            return middle;
        } else if(target < numbers[middle]){
            return search(numbers, start, middle - 1, target);
        } else {
            return search(numbers, middle + 1, end, target);
        }
    }
}
