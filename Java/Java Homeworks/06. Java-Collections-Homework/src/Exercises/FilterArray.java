package Exercises;

import java.util.Arrays;
import java.util.List;
import java.util.Scanner;
import java.util.stream.Collectors;

public class FilterArray {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        String[] elements = scan.nextLine().split("\\s+");

        List<Integer> numbers = Arrays.stream(elements)
                .filter(FilterArray::isNumber)
                .map(Integer::parseInt)
                .collect(Collectors.toList());

        int sum = numbers.stream().mapToInt(Integer::intValue).sum();
        System.out.println(sum);

    }

    private static boolean isNumber(String word) {
        for (Character ch : word.toCharArray()) {
            if (!Character.isDigit(ch)) {
                return false;
            }
        }

        return true;
    }
}
