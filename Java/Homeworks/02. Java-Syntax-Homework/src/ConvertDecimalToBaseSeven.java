import java.util.Scanner;

public class ConvertDecimalToBaseSeven {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);

        int number = input.nextInt();

        System.out.println(toBaseSeven(number));

    }

    private static String toBaseSeven(int number) {
        String baseSeven = "";
        while (number / 7 != 0) {
            baseSeven += number % 7;
            number /= 7;
        }
        baseSeven += number % 7;
        String out = "";
        for (int i = baseSeven.length() - 1; i >= 0; i--) {
            out += baseSeven.charAt(i);
        }

        return out;
    }
}
