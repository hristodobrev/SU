package Homework;

import java.util.ArrayList;
import java.util.Scanner;

public class CombineListsOfLetters {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);

        char[] firstArray = scan.nextLine().toCharArray();
        char[] secondArray = scan.nextLine().toCharArray();

        ArrayList<Character> firstList = new ArrayList<>();
        ArrayList<Character> outputList = new ArrayList<>();

        for (int i = 0; i < firstArray.length; i++) {
            if (firstArray[i] != ' '){
                firstList.add(firstArray[i]);
                outputList.add(firstArray[i]);
            }
        }


        for (int i = 0; i < secondArray.length; i++) {
            if (secondArray[i] != ' ' && !firstList.contains(secondArray[i])){
                outputList.add(secondArray[i]);
            }
        }

        for (Character character : outputList) {
            System.out.print(character + " ");
        }
    }
}
