package Homework;

import java.util.*;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class CardsFrequencies {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        String input = scan.nextLine();

        Pattern pattern = Pattern.compile("([0-9]+)*([JQKA])*");
        Matcher matcher = pattern.matcher(input);

        HashMap<String, Integer> cardsFrequencies = new HashMap<>();

        int cardsCount = 0;
        ArrayList<String> order = new ArrayList<>();

        while(matcher.find()){
            if (matcher.group(1) != null) {
                if(!cardsFrequencies.containsKey(matcher.group(1))){
                    cardsFrequencies.put(matcher.group(1), 1);
                } else {
                    int count = cardsFrequencies.get(matcher.group(1));
                    cardsFrequencies.put(matcher.group(1), count + 1);
                }
                if(!order.contains(matcher.group(1))) {
                    order.add(matcher.group(1));
                }
                cardsCount++;
            }
            if(matcher.group(2) != null) {
                if(!cardsFrequencies.containsKey(matcher.group(2))){
                    cardsFrequencies.put(matcher.group(2), 1);
                } else {
                    int count = cardsFrequencies.get(matcher.group(2));
                    cardsFrequencies.put(matcher.group(2), count + 1);
                }
                if(!order.contains(matcher.group(2))) {
                    order.add(matcher.group(2));
                }
                cardsCount++;
            }
        }

        for (String face : order) {
            double percentage = (double)cardsFrequencies.get(face) * 100 / cardsCount;
            System.out.printf("%s -> %.2f", face, percentage);
            System.out.println("%");
        }
    }
}
