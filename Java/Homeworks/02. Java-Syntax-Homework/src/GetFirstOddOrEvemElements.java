import java.util.ArrayList;
import java.util.Scanner;

public class GetFirstOddOrEvemElements {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);

        String[] currentLine = input.nextLine().split(" ");
        Integer[] numbers = new Integer[currentLine.length];
        for (int i = 0; i < currentLine.length; i++) {
            numbers[i] = Integer.parseInt(currentLine[i]);
        }
        ArrayList<Integer> selection = new ArrayList<>();
        String command1 = input.next();
        int count = input.nextInt();
        String command = input.next();
        if (command.equals("even")){
            for (int i = 0; i < numbers.length && selection.size() < count; i++) {
                if (numbers[i] % 2 == 0){
                    selection.add(numbers[i]);
                }
            }
        } else {
            for (int i = 0; i < numbers.length && selection.size() < count; i++) {
                if (numbers[i] % 2 == 1){
                    selection.add(numbers[i]);
                }
            }
        }
        for (Integer i: selection){
            System.out.print(i + " ");
        }
    }
}
