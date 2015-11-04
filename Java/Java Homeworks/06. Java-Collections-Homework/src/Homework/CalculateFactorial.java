package Homework;

import java.util.Scanner;

public class CalculateFactorial {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);

        int number = scan.nextInt();

        long factorial = calculateFactorial(number);

        System.out.println(factorial);
    }

    private static long calculateFactorial(int n){
        long number = 1;
        if (n > 0){
            number = n * calculateFactorial(n - 1);
        }
        return number;
    }
}
