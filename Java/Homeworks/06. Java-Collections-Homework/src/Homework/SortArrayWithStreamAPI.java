package Homework;

import com.sun.xml.internal.bind.v2.runtime.unmarshaller.XsiNilLoader;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.Collections;
import java.util.Scanner;

public class SortArrayWithStreamAPI {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);

        ArrayList<String> numbers = new ArrayList<>();

        numbers.addAll(Arrays.asList(scan.nextLine().split(" ")));

        String order = scan.nextLine();

        if (order.equals("Ascending")){
            numbers.stream()
                    .map(Integer::parseInt)
                    .sorted((n1, n2) -> n1.compareTo(n2));
        } else {
            numbers.stream()
                    .map(Integer::parseInt)
                    .sorted((n2, n1) -> n1.compareTo(n2));
        }
    }
}
