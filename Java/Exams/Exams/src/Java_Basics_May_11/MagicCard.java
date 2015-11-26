package Java_Basics_May_11;

import java.util.Scanner;

public class MagicCard {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);

        String[] handCards = scan.nextLine().split(" ");
        String type = scan.nextLine();
        String magicCard = scan.nextLine();

        String magicCardValue = magicCard.substring(0, magicCard.length() - 1);
        char magicCardFace = magicCard.charAt(magicCard.length() - 1);

        int sum = 0;

        int start = 0;

        if(type.equals("odd")) {
            start = 1;
        }

        for (int i = start; i < handCards.length; i+= 2) {
            String currentCardValue = handCards[i].substring(0, handCards[i].length() - 1);
            char face = handCards[i].charAt(handCards[i].length() - 1);
            if (currentCardValue.equals("A")){
                if (currentCardValue.equals(magicCardValue)) {
                    sum += 150 * 3;
                } else if (face == magicCardFace) {
                    sum += 150 * 2;
                } else {
                    sum += 150;
                }
            } else if (currentCardValue.equals("K")){
                if (currentCardValue.equals(magicCardValue)) {
                    sum += 140 * 3;
                } else if (face == magicCardFace) {
                    sum += 140 * 2;
                }else {
                    sum += 140;
                }
            }else if (currentCardValue.equals("Q")){
                if (currentCardValue.equals(magicCardValue)) {
                    sum += 130 * 3;
                } else if (face == magicCardFace) {
                    sum += 130 * 2;
                }else {
                    sum += 130;
                }
            }else if (currentCardValue.equals("J")){
                if (currentCardValue.equals(magicCardValue)) {
                    sum += 120 * 3;
                } else if (face == magicCardFace) {
                    sum += 120 * 2;
                }else {
                    sum += 120;
                }
            } else {
                if (currentCardValue.equals(magicCardValue)) {
                    sum += (Integer.parseInt(currentCardValue) * 10) * 3;
                } else if (face == magicCardFace) {
                    sum += (Integer.parseInt(currentCardValue) * 10) * 2;
                }else {
                    sum += (Integer.parseInt(currentCardValue) * 10);
                }
            }
        }
        System.out.println(sum);
    }
}
