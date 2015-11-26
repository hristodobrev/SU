import java.util.Scanner;

public class FormattingNumbers {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);

        int a = input.nextInt();
        float b = input.nextFloat();
        double c = input.nextDouble();

        System.out.printf("|%-10s|%s|%10.2f|%-10.3f|", Integer.toHexString(a), String.format("%10s", Integer.toBinaryString(a)).replace(' ', '0'), b, c);

    }
}
