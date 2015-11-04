import java.util.Scanner;

public class PrintACharacterTriangle {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);
        int i = input.nextInt();
        for(int x = 0; x < i; x++){
            for (int y = 0; y <= x; y++){
                System.out.print(Character.toChars(97 + y));
                System.out.print(" ");
            }
            System.out.println();
        }
        for(int x = i - 2; x >= 0; x--){
            for (int y = 0; y <= x; y++){
                System.out.print(Character.toChars(97 + y));
                System.out.print(" ");
            }
            System.out.println();
        }

    }
}
