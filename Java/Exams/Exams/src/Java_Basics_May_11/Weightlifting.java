package Java_Basics_May_11;

import java.util.*;

public class Weightlifting {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        int lines = Integer.parseInt(scan.nextLine());

        TreeMap<String, TreeMap<String, Long>> data = new TreeMap<String, TreeMap<String, Long>>();

        for (int i = 0; i < lines; i++) {
            String[] splited = scan.nextLine().split(" ");
            String player = splited[0];
            String exercise = splited[1];
            Long weight = Long.parseLong(splited[2]);
            if (!data.containsKey(player)) {
                data.put(player, new TreeMap<String, Long>());
            }
            if (!data.get(player).containsKey(exercise)){
                data.get(player).put(exercise, weight);
            } else {
                Long playerWeights = data.get(player).get(exercise);
                data.get(player).put(exercise, playerWeights + weight);
            }
        }
        for (Map.Entry<String, TreeMap<String, Long>> entry : data.entrySet()) {
            String key = entry.getKey();
            System.out.print(key + " : ");
            List<String> values = new ArrayList<String>();
            for (Map.Entry<String,Long> value : entry.getValue().entrySet()) {
                values.add(value.getKey() + " - " + value.getValue() + " kg");
            }
            System.out.println(String.join(", ", values));
        }
    }
}
