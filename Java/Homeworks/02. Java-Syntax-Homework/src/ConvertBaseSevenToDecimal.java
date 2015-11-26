import java.util.Scanner;

public class ConvertBaseSevenToDecimal {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);

        int number = input.nextInt();
        System.out.println(sevToDec(Integer.toString(number)));
    }

    private static int sevToDec(String sev){
        int dec = 0;
        int step = 0;
        for (int i = sev.length() - 1; i >= 0; i--) {
            dec += Integer.parseInt(Character.toString(sev.charAt(i))) * Math.pow(7, step);
            step++;
        }
        return dec;
    }
}
