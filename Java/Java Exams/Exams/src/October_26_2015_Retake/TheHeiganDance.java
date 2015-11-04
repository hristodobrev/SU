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
        int heigan = 3000000;
        int player = 18500;
        int cloudDamage = 3500;
        int eruptionDamage = 6000;
        int[] playerPosition = {7, 7};

        Scanner scan = new Scanner(System.in);
        int damage = Integer.parseInt(scan.nextLine());

        while (true) {
            String[] commandArgs = scan.nextLine().split("\\s+");
            int impactRow = Integer.parseInt(commandArgs[1]);
            int impactCol = Integer.parseInt(commandArgs[2]);

            getSpellRange(impactRow, impactCol);
            if (playerInRange(playerPosition)) {

            }
        }
    }

    private static void getSpellRange(int row, int col) {
        spellRange.put("minRow", row - 1);
        spellRange.put("maxRow", row + 1);
        spellRange.put("minCol", col - 1);
        spellRange.put("maxCol", col + 1);
    }

    private static boolean playerInRange(int[] position) {
        //TODO implement boolean
        return false;
    }
}