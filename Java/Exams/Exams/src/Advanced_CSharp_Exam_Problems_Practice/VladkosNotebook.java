package Advanced_CSharp_Exam_Problems_Practice;

import java.util.*;

public class VladkosNotebook {
    public static void main(String[] args) {
        TreeMap<String, Player> notebook = new TreeMap<String, Player>();

        Scanner scan = new Scanner(System.in);
        String currentLine = scan.nextLine();
        while (!currentLine.equals("END")) {
            String[] commandArgs = currentLine.split("\\|");
            String color = commandArgs[0];
            String function = commandArgs[1];
            String value = commandArgs[2];

            if(!notebook.containsKey(color)) {
                notebook.put(color, new Player());
            }

            if(function.equals("win")) {
                notebook.get(color).winsCount++;
                ArrayList<String> currentOpponents = notebook.get(color).opponents;
                currentOpponents.add(value);
                notebook.get(color).opponents = currentOpponents;
            } else if (function.equals("loss")) {
                notebook.get(color).lossCount++;
                ArrayList<String> currentOpponents = notebook.get(color).opponents;
                currentOpponents.add(value);
                notebook.get(color).opponents = currentOpponents;
            } else if (function.equals("name")) {
                notebook.get(color).name = value;
            } else if(function.equals("age")) {
                int age = Integer.parseInt(value);
                notebook.get(color).age = age;
            }

            currentLine = scan.nextLine();
        }

        boolean isPrinted = false;

        for (String color : notebook.keySet()) {
            if(!notebook.get(color).name.equals("nobody") && notebook.get(color).age != 0) {
                System.out.printf("Color: %s\n", color);
                System.out.printf("-age: %d\n", notebook.get(color).age);
                System.out.printf("-name: %s\n", notebook.get(color).name);
                ArrayList<String> opponents = notebook.get(color).opponents;
                if (opponents.size() == 0) {
                    opponents.add("(empty)");
                } else {
                    Collections.sort(opponents);
                }
                System.out.printf("-opponents: %s\n", String.join(", ", opponents));
                double rank = (double)(notebook.get(color).winsCount + 1) / (notebook.get(color).lossCount + 1);
                System.out.printf("-rank: %.2f\n", rank);
                isPrinted = true;
            }
        }

        if (!isPrinted) {
            System.out.println("No data recovered.");
        }
    }
}

class Player {
    public String name = "nobody";
    public int winsCount;
    public int lossCount;
    public int age = 0;
    protected ArrayList<String> opponents = new ArrayList<String>();
}