package Exercises;

import java.util.Scanner;

public class PrintNumbersFrom1ToN {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        int number = Integer.parseInt(scan.nextLine());

        PrintNumbers(number);
    }

    private static void PrintNumbers(int number){
        if(number < 1){
            return;
        }

        PrintNumbers(number - 1);
        System.out.println(number);
    }
}
