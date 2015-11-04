package October_26_2015_Retake;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.Scanner;

public class TheHeiganDance {
    private static HashMap<String, Integer> spellRange = new HashMap<>();
    private static final int MIN_ROW = 0;
    private static final int MAX_ROW = 14;
    private static final int MIN_COL = 0;
    private static final int MAX_COL = 14;

    public static void main(String[] args) {
        double heigan = 3000000d;
        int player = 18500;
        int cloudDamage = 3500;
        int eruptionDamage = 6000;
        int[] playerPosition = {7, 7};
        boolean heiganDead = false;
        boolean playerDead = false;
        boolean hasPlague = false;
        String playerKiller = "";

        Scanner scan = new Scanner(System.in);
        double damage = Double.parseDouble(scan.nextLine());

        while (true) {
            String[] commandArgs = scan.nextLine().split("\\s+");
            String attackType = commandArgs[0];
            int impactRow = Integer.parseInt(commandArgs[1]);
            int impactCol = Integer.parseInt(commandArgs[2]);

            heigan -= damage;
            heiganDead = heigan <= 0;

            if(hasPlague) {
                player -= cloudDamage;
                playerKiller = "Plague Cloud";
                playerDead = player <= 0;
                hasPlague = false;
            }

            if(playerDead || heiganDead) {
                break;
            }

            getSpellRange(impactRow, impactCol);
            if (isPlayerInSpellRange(playerPosition)) {
                if(playerPosition[0] > MIN_ROW && playerPosition[0] == spellRange.get("minRow")) {
                    playerPosition[0]--;
                } else if(playerPosition[1] < MAX_COL && playerPosition[1] == spellRange.get("maxCol")) {
                    playerPosition[1]++;
                } else if(playerPosition[0] < MAX_ROW && playerPosition[0] == spellRange.get("maxRow")) {
                    playerPosition[0]++;
                } else if(playerPosition[1] > MIN_COL && playerPosition[1] == spellRange.get("minCol")) {
                    playerPosition[1]--;
                }
            }

            if(isPlayerInSpellRange(playerPosition)) {
                if(attackType.equals("Cloud")) {
                    player -= cloudDamage;
                    playerKiller = "Plague Cloud";
                    hasPlague = true;
                } else {
                    player -= eruptionDamage;
                    playerKiller = "Eruption";
                }
                playerDead = player <= 0;
            }

            if(playerDead) {
                break;
            }
        }

        if(heiganDead) {
            System.out.println("Heigan: Defeated!");
        } else {
            System.out.printf("Heigan: %.2f\n", heigan);
        }
        if(playerDead) {
            System.out.println("Player: Killed by " + playerKiller);
        } else {
            System.out.println("Player: " + player);
        }
        System.out.println("Final position: " + playerPosition[0] + ", " + playerPosition[1]);
    }

    private static void getSpellRange(int row, int col) {
        spellRange.put("minRow", row - 1);
        spellRange.put("maxRow", row + 1);
        spellRange.put("minCol", col - 1);
        spellRange.put("maxCol", col + 1);
    }

    private static boolean isPlayerInSpellRange(int[] position) {
        boolean isInRowRange = position[0] <= spellRange.get("maxRow")
                && position[0] >= spellRange.get("minRow");
        boolean isInColRange = position[1] <= spellRange.get("maxCol")
                && position[1] >= spellRange.get("minCol");
        return isInColRange && isInRowRange;
    }
}