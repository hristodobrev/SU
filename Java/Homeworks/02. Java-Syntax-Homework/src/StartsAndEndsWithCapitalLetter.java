import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class StartsAndEndsWithCapitalLetter {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);

        String text = input.nextLine();

        Pattern pat = Pattern.compile("(?<=\\b)[A-Z][A-Za-z]*[A-Z](?=\\b)");
        Matcher matcher = pat.matcher(text);

        while(matcher.find()) {
            System.out.print(matcher.group() + " ");
        }
    }
}
