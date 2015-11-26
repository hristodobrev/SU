package October_26_2015_Retake;

import java.util.Scanner;

public class TinySporebat {
    public static void main(String[] args) {
        int health = 5800;
        int glowcaps = 0;

        Scanner scan = new Scanner(System.in);

        String currentLine = scan.nextLine();

        boolean playerAlive = true;

        while (!currentLine.equals("Sporeggar")) {
            for (int i = 0; i < currentLine.length() - 1; i++) {
                if(currentLine.charAt(i) != 'L') {
                    health -= (int) currentLine.charAt(i);
                    if (health <= 0) {
                        playerAlive = false;
                        break;
                    }
                } else {
                    health += 200;
                }
            }
            if(playerAlive) {
                String glowcapsCount = "";
                glowcapsCount += currentLine.charAt(currentLine.length() - 1);
                glowcaps += Integer.parseInt(glowcapsCount);
            }

            currentLine = scan.nextLine();
        }

        if(playerAlive) {
            System.out.println("Health left: " + health);
            if(glowcaps < 30) {
                System.out.printf("Safe in Sporeggar, but another %d Glowcaps needed.\n", 30 - glowcaps);
            } else {
                System.out.println("Bought the sporebat. Glowcaps left: " + (glowcaps - 30));
            }
        } else {
            System.out.println("Died. Glowcaps: " + glowcaps);
        }
    }
}
