package Homework;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.Scanner;
import java.util.stream.Collector;

public class FilterArray {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        String[] words = scan.nextLine().split("\\s+");

        String[] filtered = Arrays.stream(words)
                .filter(s -> s.length() > 3)
                .toArray(String[]::new);

        if(!(String.join(" ", filtered)).equals("")) {
            System.out.println(String.join(" ", filtered));
        } else {
            System.out.println("(empty)");
        }
    }
}
