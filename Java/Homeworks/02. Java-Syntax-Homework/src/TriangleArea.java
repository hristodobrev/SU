import java.util.Scanner;

public class TriangleArea {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);
        int xA = input.nextInt();
        int yA =  input.nextInt();
        int xB = input.nextInt();
        int yB =  input.nextInt();
        int xC = input.nextInt();
        int yC =  input.nextInt();

        int sum = (int) (0.5 * Math.abs(((xA - xC) * (yB - yA) - (xA - xB) * (yC - yA))));
        System.out.println(sum);
    }
}
