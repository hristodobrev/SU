package Homework;

import java.util.Arrays;
import java.util.Scanner;
import java.util.stream.Collectors;

public class SortArrayNumbers {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        int numbersCount = scan.nextInt();
        scan.nextLine();
        int[] numbers = Arrays.stream(scan.nextLine().split("\\s+"))
                .mapToInt(Integer::parseInt)
                .toArray();

        Arrays.sort(numbers);

        for (int number : numbers) {
            System.out.print(number + " ");
        }
    }
}
