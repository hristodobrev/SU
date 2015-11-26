import java.util.Scanner;

public class CharacterMultiplier {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);
        String firstString = input.next();
        String secondString = input.next();

        boolean isFirstLonger = true;

        if (secondString.length() > firstString.length()){
            isFirstLonger = false;
        }

        int sum = 0;
        if (isFirstLonger){
            for (int i = 0; i < secondString.length(); i++) {
                sum += firstString.charAt(i) * secondString.charAt(i);
            }
            for (int i = secondString.length(); i < firstString.length(); i++) {
                sum += firstString.charAt(i);
            }
        } else {
            for (int i = 0; i < firstString.length(); i++) {
                sum += firstString.charAt(i) * secondString.charAt(i);
            }
            for (int i = firstString.length(); i < secondString.length(); i++) {
                sum += secondString.charAt(i);
            }
        }
        System.out.println(sum);
    }
}
