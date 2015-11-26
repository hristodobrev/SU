import java.util.HashMap;
import java.util.Map;
import java.util.Scanner;

public class MagicExchangeableWords {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);
        String firstWord = input.next();
        String secondWord = input.next();
        System.out.println(areExchangeable(firstWord, secondWord));
    }

    public static boolean areExchangeable(String first, String second) {
        Map<Character, Character> suit = new HashMap<Character, Character>();

        for (int i = 0; i < first.length(); i++) {
            if (!suit.containsKey(first.charAt(i))) {
                suit.put(first.charAt(i), second.charAt(i));
            } else {
                if (suit.get(first.charAt(i)) != second.charAt(i)){
                    return false;
                }
            }
        }
        return true;
    }
}