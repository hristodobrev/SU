import java.util.Scanner;

public class CalculateExpression {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);

        float a = input.nextFloat();
        float b = input.nextFloat();
        float c = input.nextFloat();

        float firstFormulae = (float) Math.pow(((a * a + b * b) / (a * a - b * b)), (a + b + c) / Math.sqrt(c));
        float secondFormulae = (float) Math.pow((a * a + b * b - c * c * c), a - b);

        System.out.printf("F1 result: %.2f; F2 result: %.2f; Diff: %.2f", firstFormulae, secondFormulae, (double) Math.abs(((a + b + c) / 3) - ((firstFormulae + secondFormulae) / 2)));
    }
}
