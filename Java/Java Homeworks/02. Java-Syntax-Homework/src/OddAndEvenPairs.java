import java.util.ArrayList;
import java.util.Scanner;

public class OddAndEvenPairs {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);

        ArrayList<Integer> list = new ArrayList<>();

        String currentLine = input.nextLine();
        String trimmed = currentLine.replace("\\s\\s+", " ").trim();
        String[] lineArray = trimmed.split(" ");

        Integer[] numbers = new Integer[lineArray.length];

        if (numbers.length % 2 == 0){
            for (int i = 0; i < lineArray.length; i++) {
                numbers[i] = Integer.parseInt(lineArray[i]);
            }

            for (int i = 0; i < lineArray.length; i+= 2) {
                if (numbers[i] % 2 == 0 && numbers[i + 1] % 2 == 0) {
                    System.out.printf("%d, %d -> both are even\n", numbers[i], numbers[i + 1]);
                } else if(numbers[i] % 2 == 1 && numbers[i + 1] % 2 == 1) {
                    System.out.printf("%d, %d -> both are odd\n", numbers[i], numbers[i + 1]);
                } else {
                    System.out.printf("%d, %d -> different\n", numbers[i], numbers[i + 1]);
                }
            }
        } else {
            System.out.println("Invalid length");
        }
    }
}
